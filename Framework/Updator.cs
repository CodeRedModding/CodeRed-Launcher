using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private static async Task<Report> InstallLauncher()
        {
            Report report = new Report();
            Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

            if (tempFolder.Exists())
            {
                Directory.Delete(tempFolder.GetPath(), true);
            }

            Directory.CreateDirectory(tempFolder.GetPath());

            if (tempFolder.Exists())
            {
                string launcherUrl = await Retrievers.GetLauncherUrl();

                if (!String.IsNullOrEmpty(launcherUrl))
                {
                    Architecture.Path downloadedFile = tempFolder / "CodeRedLauncher.zip";

                    if (await Downloaders.DownloadFile(launcherUrl, tempFolder, "CodeRedLauncher.zip"))
                    {
                        if (downloadedFile.Exists())
                        {
                            using (ZipArchive zipArchive = ZipFile.OpenRead(downloadedFile.GetPath()))
                            {

                            }
                        }
                    }
                }
            }

            Status &= ~UpdatorStatus.STATUS_LAUNCHER;
            return report;
        }

        public static async Task<Report> InstallModule()
        {
            Report report = new Report();
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
                    Architecture.Path downloadedFile = tempFolder / "CodeRedModule.zip";

                    if (await Downloaders.DownloadFile(moduleUrl, tempFolder, "CodeRedModule.zip"))
                    {
                        if (downloadedFile.Exists())
                        {
                            using (ZipArchive zipArchive = ZipFile.OpenRead(downloadedFile.GetPath()))
                            {

                            }
                        }
                    }
                }
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
                    Report moduleReport = await InstallModule();

                    if (!moduleReport.Succeeded)
                    {
                        return moduleReport;
                    }
                }


                if ((Status & UpdatorStatus.STATUS_LAUNCHER) != 0)
                {
                    return await InstallLauncher();
                }
            }
            else
            {
                Logger.Write("Could not install updates, launcher is running in offline mode!");
            }

            return report;
        }
    }
}
