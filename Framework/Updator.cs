using System;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeRedLauncher
{
    [Flags]
    public enum UpdatorStatus : UInt32
    {
        STATUS_NONE = 0,
        STATUS_LAUNCHER = 1 << 0,
        STATUS_MODULE = 1 << 1
    }

    public static class Updator
    {
        public static UpdatorStatus Status { get; set; } = UpdatorStatus.STATUS_NONE;
        public static bool IsOutdated { get; set; } = false;

        public static async Task<Report> InstallLauncher(bool bForceInstall)
        {
            Report report = new Report();

            if (!bForceInstall)
            {
                if (!IsOutdated || ((Status & UpdatorStatus.STATUS_LAUNCHER) == 0))
                {
                    report.FailReason = "No launcher update required.";
                    return report;
                }
            }

            Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

            if (tempFolder.Exists())
            {
                Directory.Delete(tempFolder.GetPath(), true);
            }

            Directory.CreateDirectory(tempFolder.GetPath());

            if (tempFolder.Exists())
            {
                string launcherUrl = await Retrievers.GetLauncherUrl();
                string dropperUrl = await Retrievers.GetDropperUrl();

                if (!String.IsNullOrEmpty(launcherUrl) && !String.IsNullOrEmpty(dropperUrl))
                {
                    Architecture.Path launcherArchive = (tempFolder / "CodeRedLauncher.zip");
                    Architecture.Path launcherExe = (tempFolder / "CodeRedLauncher.exe");
                    Architecture.Path dropperArchive = (tempFolder / "CodeRedDropper.zip");
                    Architecture.Path dropperExe = (tempFolder / "CodeRedDropper.exe");

                    if (await Downloaders.DownloadFile(launcherUrl, tempFolder, "CodeRedLauncher.zip"))
                    {
                        if (launcherArchive.Exists())
                        {
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

                                if (await Downloaders.DownloadFile(dropperUrl, tempFolder, "CodeRedDropper.zip"))
                                {
                                    if (dropperArchive.Exists())
                                    {
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
                                            // Since the launcher is "half portable", the user can place the exe wherever they want. This text file is just super simple dynamic way of always finding it.
                                            Architecture.Path launcherPath = (tempFolder / "LauncherPath.txt");
                                            File.CreateText(launcherPath.GetPath());
                                            File.WriteAllText(launcherPath.GetPath(), Application.ExecutablePath);

                                            // Dropper file closes the launcher, deletes the exe, moves the newly downloaded one in place of the old exe, then runs it.
                                            Process.Start(new ProcessStartInfo(dropperExe.GetPath()) { UseShellExecute = false });
                                            Environment.Exit(0);
                                        }
                                        else
                                        {
                                            report.FailReason = "Failed to extract dropper executable from its archive.";
                                            return report;
                                        }
                                    }
                                }
                                else
                                {
                                    report.FailReason = "Failed to download dropper archive.";
                                    return report;
                                }
                            }
                            else
                            {
                                report.FailReason = "Failed to extract launcher executable from its archive.";
                                return report;
                            }
                        }
                        else
                        {
                            report.FailReason = "Failed to download launcher archive.";
                            return report;
                        }
                    }
                    else
                    {
                        report.FailReason = "Failed to download launcher executable.";
                        return report;
                    }
                }
                else
                {
                    report.FailReason = "Failed to retrieve download links.";
                    return report;
                }

                //Directory.Delete(tempFolder.GetPath(), true);
            }

            Status &= ~UpdatorStatus.STATUS_LAUNCHER;
            return report;
        }

        public static async Task<Report> InstallModule(bool bForceInstall)
        {
            Report report = new Report();

            if (!bForceInstall)
            {
                if (!IsOutdated || ((Status & UpdatorStatus.STATUS_MODULE) == 0))
                {
                    report.FailReason = "No module update required.";
                    return report;
                }
            }

            Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

            if (tempFolder.Exists())
            {
                Directory.Delete(tempFolder.GetPath(), true);
            }

            Directory.CreateDirectory(tempFolder.GetPath());

            if (tempFolder.Exists())
            {
                string moduleUrl = await Retrievers.GetModuleUrl();

                if (!String.IsNullOrEmpty(moduleUrl))
                {
                    Architecture.Path downloadedFile = (tempFolder / "CodeRedModule.zip");

                    if (await Downloaders.DownloadFile(moduleUrl, tempFolder, "CodeRedModule.zip"))
                    {
                        if (downloadedFile.Exists())
                        {
                            Architecture.Path modulePath = Storage.GetModulePath();

                            if (!modulePath.Exists())
                            {
                                Directory.CreateDirectory(modulePath.GetPath());
                            }

                            using (ZipArchive zipArchive = ZipFile.OpenRead(downloadedFile.GetPath()))
                            {
                                foreach (ZipArchiveEntry archiveEntry in zipArchive.Entries)
                                {
                                    Architecture.Path fullPath = modulePath / archiveEntry.FullName;
                                    Directory.CreateDirectory(Path.GetDirectoryName(fullPath.GetPath()));
                                    string fileFilter = fullPath.GetPath().ToLower();

                                    // Skip overriding existing files that may be user-specific, such as settings or scripts.
                                    if (fileFilter.EndsWith(".script") || fileFilter.EndsWith(".sequence") || fileFilter.EndsWith(".cr"))
                                    {
                                        continue;
                                    }

                                    archiveEntry.ExtractToFile(fullPath.GetPath(), true);
                                }
                            }

                            Configuration.SaveChanges();
                            report.Succeeded = true;
                        }
                    }
                    else
                    {
                        report.FailReason = "Failed to download module archive.";
                        return report;
                    }
                }
                else
                {
                    report.FailReason = "Failed to retrieve download link.";
                    return report;
                }

                Directory.Delete(tempFolder.GetPath(), true);
            }

            Status &= ~UpdatorStatus.STATUS_MODULE;
            return report;
        }

        public static async Task<Report> InstallUpdates()
        {
            Report report = new Report(true);

            if (!Configuration.OfflineMode.GetBoolValue())
            {
                if ((Status & UpdatorStatus.STATUS_MODULE) != 0)
                {
                    Report moduleReport = await InstallModule(false);

                    if (!moduleReport.Succeeded)
                    {
                        Logger.Write(moduleReport.FailReason, LogLevel.LEVEL_WARN);
                        return moduleReport;
                    }
                }

                if ((Status & UpdatorStatus.STATUS_LAUNCHER) != 0)
                {
                    Report launcherReport = await InstallLauncher(false);

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
