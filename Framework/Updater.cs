using System;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Windows.System;

namespace CodeRedLauncher
{
    enum UpdatorStatus : byte
    {
        Idle,
        Preparing,
        DownloadingModule,
        DownloadingLauncher,
        InstallingModule,
        InstallingLauncher
    }

    public static class Updater
    {
        private static bool m_launcherOutdated = false;
        private static bool m_moduleOutdated = false;
        private static UpdatorStatus m_updateStatus = UpdatorStatus.Idle;
        private static Controls.CRUpdate m_updateCtrl = null;
        private static List<string> m_excluded = new List<string>() { ".cr", ".crsp", ".crsq", ".crps", ".crst", ".crsl", ".crvu" }; // File types we don't want to override when updating, like personal user settings.

        public static bool IsUpdating()
        {
            return (m_updateStatus != UpdatorStatus.Idle);
        }

        public static bool IsOutdated()
        {
            return (m_launcherOutdated || m_moduleOutdated);
        }

        private static void SetStatus(UpdatorStatus status)
        {
            m_updateStatus = status;

            if (m_updateCtrl != null)
            {
                switch (status)
                {
                    case UpdatorStatus.DownloadingModule:
                        m_updateCtrl.UpdateType = Controls.CRUpdate.UpdateLayouts.DownloadingModule;
                        break;
                    case UpdatorStatus.DownloadingLauncher:
                        m_updateCtrl.UpdateType = Controls.CRUpdate.UpdateLayouts.DownloadingLauncher;
                        break;
                    case UpdatorStatus.InstallingModule:
                        m_updateCtrl.UpdateType = Controls.CRUpdate.UpdateLayouts.InstallingModule;
                        break;
                    case UpdatorStatus.InstallingLauncher:
                        m_updateCtrl.UpdateType = Controls.CRUpdate.UpdateLayouts.InstallingLauncher;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void OverrideLauncher()
        {
            m_moduleOutdated = false;
        }

        public static void OverrideModule()
        {
            m_moduleOutdated = false;
        }

        public static async Task<bool> IsModuleOutdated(bool bInvalidate)
        {
            if (bInvalidate)
            {
                LocalStorage.Invalidate();
                RemoteStorage.Invalidate();
            }

            if (await RemoteStorage.CheckInitialized())
            {
                if (LocalStorage.GetModuleVersion() != await RemoteStorage.GetModuleVersion())
                {
                    Logger.Write("(IsModuleOutdated) Module detected as outdated!");
                    m_moduleOutdated = true;
                    return true;
                }
            }

            Logger.Write("(IsModuleOutdated) Module is up to date!");
            m_moduleOutdated = false;
            return false;
        }

        public static async Task<bool> IsLauncherOutdated(bool bInvalidate)
        {
            if (bInvalidate)
            {
                LocalStorage.Invalidate();
                RemoteStorage.Invalidate();
            }

            if (await RemoteStorage.CheckInitialized())
            {
                if (Assembly.GetVersion() != await RemoteStorage.GetLauncherVersion())
                {
                    Logger.Write("(IsLauncherOutdated) Launcher detected as outdated!");
                    m_launcherOutdated = true;
                    return true;
                }
            }

            Logger.Write("(IsLauncherOutdated) Launcher is up to date!");
            m_launcherOutdated = false;
            return false;
        }

        private static async Task<Result> InstallModule(bool bForceInstall)
        {
            SetStatus(UpdatorStatus.Preparing);
            Result result = new Result();

            if (!bForceInstall && !m_moduleOutdated)
            {
                SetStatus(UpdatorStatus.Idle);
                result.FailReason = "No module update required.";
                return result;
            }

            Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

            if (tempFolder.Exists())
            {
                Logger.Write("(InstallModule) Deleting temporary folder...");
                Directory.Delete(tempFolder.GetPath(), true);
            }

            Directory.CreateDirectory(tempFolder.GetPath());

            if (tempFolder.Exists())
            {
                string moduleUrl = await RemoteStorage.GetModuleUrl();

                if (!string.IsNullOrEmpty(moduleUrl))
                {
                    Logger.Write("(InstallModule) Downloading module archive...");
                    Architecture.Path downloadedFile = (tempFolder / "CodeRedModule.zip");
                    SetStatus(UpdatorStatus.DownloadingModule);

                    if (await Downloaders.DownloadFile(moduleUrl, tempFolder, "CodeRedModule.zip"))
                    {
                        if (downloadedFile.Exists())
                        {
                            Architecture.Path modulePath = LocalStorage.GetModulePath();

                            if (!modulePath.Exists())
                            {
                                Directory.CreateDirectory(modulePath.GetPath());
                            }

                            Logger.Write("(InstallModule) Extracting file from archive...");
                            SetStatus(UpdatorStatus.InstallingModule);
                            await Task.Delay(1500);

                            using (ZipArchive zipArchive = ZipFile.OpenRead(downloadedFile.GetPath()))
                            {
                                foreach (ZipArchiveEntry archiveEntry in zipArchive.Entries)
                                {
                                    Architecture.Path fullPath = (modulePath / archiveEntry.FullName);

                                    if (!Directory.Exists(fullPath.GetFolderPath()))
                                    {
                                        Directory.CreateDirectory(fullPath.GetFolderPath());
                                    }

                                    // Nothing to extract if it's just a directory so we can skip the rest.

                                    if (!fullPath.IsFile())
                                    {
                                        continue;
                                    }

                                    string fileFilter = fullPath.GetPath().ToLower();
                                    bool shouldSkip = false;

                                    if (!bForceInstall)
                                    {
                                        // Skip overriding existing files that may be user-specific, such as settings or scripts.

                                        foreach (string file in m_excluded)
                                        {
                                            if (fileFilter.EndsWith(file))
                                            {
                                                shouldSkip = true;
                                                break;
                                            }
                                        }
                                    }

                                    if (!shouldSkip)
                                    {
                                        archiveEntry.ExtractToFile(fullPath.GetPath(), true);
                                    }
                                }
                            }

                            Logger.Write("(InstallModule) Done!");
                            result.Succeeded = true;
                            m_moduleOutdated = false;
                            Configuration.SaveChanges();
                        }
                    }
                    else
                    {
                        result.FailReason = "Failed to download module archive.";
                    }
                }
                else
                {
                    result.FailReason = "Failed to retrieve download link.";
                }

                Directory.Delete(tempFolder.GetPath(), true);
            }

            SetStatus(UpdatorStatus.Idle);
            return result;
        }

        public static async Task<Result> ForceInstallModule()
        {
            return await InstallModule(true);
        }

        private static async Task<Result> InstallLauncher(bool bForceInstall)
        {
            SetStatus(UpdatorStatus.Preparing);
            Result result = new Result();

            if (!bForceInstall && !m_launcherOutdated)
            {
                SetStatus(UpdatorStatus.Idle);
                result.FailReason = "No launcher update required.";
                return result;
            }

            Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

            if (tempFolder.Exists())
            {
                Logger.Write("(InstallLauncher) Deleting temporary folder...");
                Directory.Delete(tempFolder.GetPath(), true);
            }

            Directory.CreateDirectory(tempFolder.GetPath());

            if (tempFolder.Exists())
            {
                string launcherUrl = await RemoteStorage.GetLauncherUrl();
                string dropperUrl = await RemoteStorage.GetDropperUrl();

                if (!string.IsNullOrEmpty(launcherUrl) && !string.IsNullOrEmpty(dropperUrl))
                {
                    Architecture.Path launcherArchive = (tempFolder / "CodeRedLauncher.zip");
                    Architecture.Path launcherExe = (tempFolder / "CodeRedLauncher.exe");
                    Architecture.Path dropperArchive = (tempFolder / "CodeRedDropper.zip");
                    Architecture.Path dropperExe = (tempFolder / "CodeRedDropper.exe");

                    Logger.Write("(InstallLauncher) Downloading launcher archive...");
                    SetStatus(UpdatorStatus.DownloadingLauncher);

                    if (await Downloaders.DownloadFile(launcherUrl, tempFolder, "CodeRedLauncher.zip"))
                    {
                        if (launcherArchive.Exists())
                        {
                            Logger.Write("(InstallLauncher) Extracting file from archive...");

                            using (ZipArchive zipArchive = ZipFile.OpenRead(launcherArchive.GetPath()))
                            {
                                foreach (ZipArchiveEntry archiveEntry in zipArchive.Entries)
                                {
                                    if (archiveEntry.FullName.Contains("CodeRed"))
                                    {
                                        archiveEntry.ExtractToFile(launcherExe.GetPath(), true);
                                    }
                                }
                            }

                            if (launcherExe.Exists())
                            {
                                File.Delete(launcherArchive.GetPath());
                                Logger.Write("(InstallLauncher) Downloading dropper archive...");

                                if (await Downloaders.DownloadFile(dropperUrl, tempFolder, "CodeRedDropper.zip"))
                                {
                                    if (dropperArchive.Exists())
                                    {
                                        Logger.Write("(InstallLauncher) Extracting file from archive...");
                                        SetStatus(UpdatorStatus.InstallingLauncher);
                                        await Task.Delay(1500);

                                        using (ZipArchive zipArchive = ZipFile.OpenRead(dropperArchive.GetPath()))
                                        {
                                            foreach (ZipArchiveEntry archiveEntry in zipArchive.Entries)
                                            {
                                                if (archiveEntry.FullName.Contains("CodeRed"))
                                                {
                                                    archiveEntry.ExtractToFile(dropperExe.GetPath(), true);
                                                }
                                            }
                                        }

                                        File.Delete(dropperArchive.GetPath());

                                        if (dropperExe.Exists())
                                        {
                                            Logger.Write("(InstallLauncher) Done!");
                                            result.Succeeded = true;
                                            m_launcherOutdated = false;

                                            // Since the launcher is "half portable", the user can place the exe wherever they want and move it around.
                                            // This text file is just super simple dynamic way to insure the dropper can always find it.

                                            Architecture.Path launcherPath = (tempFolder / "LauncherPath.txt");
                                            File.WriteAllText(launcherPath.GetPath(), Application.ExecutablePath);

                                            // Dropper file closes the launcher, deletes the exe, moves the newly downloaded one in place of the old exe, then runs it.
                                            Process.Start(new ProcessStartInfo(dropperExe.GetPath()) { UseShellExecute = false });
                                            Environment.Exit(0);
                                        }
                                        else
                                        {
                                            result.FailReason = "Failed to extract dropper executable from its archive.";
                                        }
                                    }
                                }
                                else
                                {
                                    result.FailReason = "Failed to download dropper archive.";
                                }
                            }
                            else
                            {
                                result.FailReason = "Failed to extract launcher executable from its archive.";
                            }
                        }
                        else
                        {
                            result.FailReason = "Failed to download launcher archive.";
                        }
                    }
                    else
                    {
                        result.FailReason = "Failed to download launcher executable.";
                    }
                }
                else
                {
                    result.FailReason = "Failed to retrieve download links.";
                }

                Directory.Delete(tempFolder.GetPath(), true);
            }

            SetStatus(UpdatorStatus.Idle);
            return result;
        }

        public static async Task<Result> ForceInstallLauncher()
        {
            return await InstallLauncher(true);
        }

        public static async Task<Result> InstallUpdates(Controls.CRUpdate updateCtrl)
        {
            m_updateCtrl = updateCtrl;
            Result result = new Result();

            if (!Configuration.OfflineMode.GetBoolValue())
            {
                if (m_moduleOutdated)
                {
                    Result moduleResult = await InstallModule(false);

                    if (!moduleResult.Succeeded)
                    {
                        Logger.Write("(InstallUpdates) " + moduleResult.FailReason, LogLevel.Error);
                        return moduleResult;
                    }
                }

                if (m_launcherOutdated)
                {
                    Result launcherResult = await InstallLauncher(false);

                    if (!launcherResult.Succeeded)
                    {
                        Logger.Write("(InstallUpdates) " + launcherResult.FailReason, LogLevel.Error);
                        return launcherResult;
                    }
                }

                result.Succeeded = true;
            }
            else
            {
                result.FailReason = "Could not install updates, launcher is running in offline mode!";
                Logger.Write("(InstallUpdates) " + result.FailReason, LogLevel.Error);
            }

            return result;
        }
    }
}