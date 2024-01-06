using System;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CodeRedLauncher
{
    public static class Updator
    {
        private static bool _isUpdating = false;
        private static bool _launcherOutdated = false;
        private static bool _moduleOutdated = false;
        private static List<string> _excludedExtensions = new List<string>() { ".cr", ".crsp", ".crsq", ".crps", ".crst", ".crsl", ".crvu" };

        public static bool IsUpdating()
        {
            return _isUpdating;
        }

        public static bool IsOutdated()
        {
            return (_launcherOutdated || _moduleOutdated);
        }

        public static void OverrideLauncher()
        {
            _moduleOutdated = false;
        }

        public static void OverrideModule()
        {
            _moduleOutdated = false;
        }

        public static async Task<bool> IsModuleOutdated(bool bInvalidate)
        {
            if (bInvalidate)
            {
                Storage.Invalidate();
                Retrievers.Invalidate();
            }

            if (await Retrievers.CheckInitialized())
            {
                if (Storage.GetModuleVersion() != await Retrievers.GetModuleVersion())
                {
                    Logger.Write("Module detected as outdated!");
                    _moduleOutdated = true;
                    return true;
                }
            }

            Logger.Write("Module is up to date!");
            _moduleOutdated = false;
            return false;
        }

        public static async Task<bool> IsLauncherOutdated(bool bInvalidate)
        {
            if (bInvalidate)
            {
                Storage.Invalidate();
                Retrievers.Invalidate();
            }

            if (await Retrievers.CheckInitialized())
            {
                if (Assembly.GetVersion() != await Retrievers.GetLauncherVersion())
                {
                    Logger.Write("Launcher detected as outdated!");
                    _launcherOutdated = true;
                    return true;
                }
            }

            Logger.Write("Launcher is up to date!");
            _launcherOutdated = false;
            return false;
        }

        private static async Task<Result> InstallModule(bool bForceInstall)
        {
            _isUpdating = true;
            Result report = new Result();

            if (!bForceInstall && !_moduleOutdated)
            {
                report.FailReason = "No module update required.";
                _isUpdating = false;
                return report;
            }

            Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

            if (tempFolder.Exists())
            {
                Logger.Write("Deleting temporary folder...");
                Directory.Delete(tempFolder.GetPath(), true);
            }

            Directory.CreateDirectory(tempFolder.GetPath());

            if (tempFolder.Exists())
            {
                string moduleUrl = await Retrievers.GetModuleUrl();

                if (!string.IsNullOrEmpty(moduleUrl))
                {
                    Architecture.Path downloadedFile = (tempFolder / "CodeRedModule.zip");
                    Logger.Write("Downloading module archive...");

                    if (await Downloaders.DownloadFile(moduleUrl, tempFolder, "CodeRedModule.zip"))
                    {
                        if (downloadedFile.Exists())
                        {
                            Architecture.Path modulePath = Storage.GetModulePath();

                            if (!modulePath.Exists())
                            {
                                Directory.CreateDirectory(modulePath.GetPath());
                            }

                            Logger.Write("Extracting file from archive...");

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

                                        foreach (string file in _excludedExtensions)
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

                            Logger.Write("Done!");
                            report.Succeeded = true;
                            _moduleOutdated = false;
                            Configuration.SaveChanges();
                        }
                    }
                    else
                    {
                        report.FailReason = "Failed to download module archive.";
                    }
                }
                else
                {
                    report.FailReason = "Failed to retrieve download link.";
                }

                Directory.Delete(tempFolder.GetPath(), true);
            }

            _isUpdating = false;
            return report;
        }

        public static async Task<Result> ForceInstallModule()
        {
            return await InstallModule(true);
        }

        private static async Task<Result> InstallLauncher(bool bForceInstall)
        {
            _isUpdating = true;
            Result report = new Result();

            if (!bForceInstall && !_launcherOutdated)
            {
                report.FailReason = "No launcher update required.";
                _isUpdating = false;
                return report;
            }

            Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

            if (tempFolder.Exists())
            {
                Logger.Write("Deleting temporary folder...");
                Directory.Delete(tempFolder.GetPath(), true);
            }

            Directory.CreateDirectory(tempFolder.GetPath());

            if (tempFolder.Exists())
            {
                string launcherUrl = await Retrievers.GetLauncherUrl();
                string dropperUrl = await Retrievers.GetDropperUrl();

                if (!string.IsNullOrEmpty(launcherUrl) && !string.IsNullOrEmpty(dropperUrl))
                {
                    Architecture.Path launcherArchive = (tempFolder / "CodeRedLauncher.zip");
                    Architecture.Path launcherExe = (tempFolder / "CodeRedLauncher.exe");
                    Architecture.Path dropperArchive = (tempFolder / "CodeRedDropper.zip");
                    Architecture.Path dropperExe = (tempFolder / "CodeRedDropper.exe");
                    Logger.Write("Downloading launcher archive...");

                    if (await Downloaders.DownloadFile(launcherUrl, tempFolder, "CodeRedLauncher.zip"))
                    {
                        if (launcherArchive.Exists())
                        {
                            Logger.Write("Extracting file from archive...");

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
                                Logger.Write("Downloading dropper archive...");

                                if (await Downloaders.DownloadFile(dropperUrl, tempFolder, "CodeRedDropper.zip"))
                                {
                                    if (dropperArchive.Exists())
                                    {
                                        Logger.Write("Extracting file from archive...");

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
                                            Logger.Write("Done!");
                                            report.Succeeded = true;
                                            _launcherOutdated = false;

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
                                            report.FailReason = "Failed to extract dropper executable from its archive.";
                                        }
                                    }
                                }
                                else
                                {
                                    report.FailReason = "Failed to download dropper archive.";
                                }
                            }
                            else
                            {
                                report.FailReason = "Failed to extract launcher executable from its archive.";
                            }
                        }
                        else
                        {
                            report.FailReason = "Failed to download launcher archive.";
                        }
                    }
                    else
                    {
                        report.FailReason = "Failed to download launcher executable.";
                    }
                }
                else
                {
                    report.FailReason = "Failed to retrieve download links.";
                }

                Directory.Delete(tempFolder.GetPath(), true);
            }

            _isUpdating = false;
            return report;
        }

        public static async Task<Result> ForceInstallLauncher()
        {
            return await InstallLauncher(true);
        }

        public static async Task<Result> InstallUpdates()
        {
            Result report = new Result(true);

            if (!Configuration.OfflineMode.GetBoolValue())
            {
                if (_moduleOutdated)
                {
                    Result moduleReport = await InstallModule(false);

                    if (!moduleReport.Succeeded)
                    {
                        Logger.Write(moduleReport.FailReason, LogLevel.LEVEL_WARN);
                        return moduleReport;
                    }
                }

                if (_launcherOutdated)
                {
                    Result launcherReport = await InstallLauncher(false);

                    if (!launcherReport.Succeeded)
                    {
                        Logger.Write(launcherReport.FailReason, LogLevel.LEVEL_WARN);
                        return launcherReport;
                    }
                }

                report.Succeeded = true;
            }
            else
            {
                report.FailReason = "Could not install updates, launcher is running in offline mode!";
            }

            return report;
        }
    }
}