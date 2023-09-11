using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CodeRedLauncher
{
    public static class Installer
    {
        private static readonly string _subKey = "CodeRedModding";
        private static readonly string _keyName = "InstallPath";

        public static void ModifyRegistry(bool bDeleteKey, Architecture.Path installPath)
        {
            if (bDeleteKey)
            {
                RegistryKey coderedKey = Registry.CurrentUser.OpenSubKey(_subKey);

                if (coderedKey != null)
                {
                    Logger.Write("Deleting install path registry key...");
                    coderedKey.DeleteValue(_keyName, false);
                    coderedKey.Close();
                    Registry.CurrentUser.DeleteSubKey(_subKey);
                }
            }
            else
            {
                RegistryKey coderedKey = Registry.CurrentUser.CreateSubKey(_subKey);

                if (coderedKey != null)
                {
                    coderedKey.SetValue(_keyName, installPath.GetPath());
                    coderedKey.Close();
                }
            }
        }

        public static Result CreateInstallPath(bool bManuallyChoose)
        {
            Result report = new Result();
            Architecture.Path installPath = new Architecture.Path();

            if (bManuallyChoose)
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    installPath = new Architecture.Path(folderBrowser.SelectedPath);

                    if (installPath.Exists())
                    {
                        if (!installPath.GetPath().Contains("CodeRed"))
                        {
                            installPath.Append("CodeRed").CreateDirectory();
                        }

                        Logger.Write("User manually selected \"" + installPath.GetPath() + "\" for the install path.");
                    }
                }
            }
            else
            {
                installPath.Set(Storage.GetGamesPath() / "CodeRed");
                Directory.CreateDirectory(installPath.GetPath());
            }

            if (installPath.Exists())
            {
                ModifyRegistry(false, installPath);
                Storage.Invalidate(true);
                report.Succeeded = true;
            }
            else
            {
                report.FailReason = "Failed to locate desired install path.";
            }

            return report;
        }

        public static async Task<Result> DownloadModule()
        {
            Result report = new Result();
            Architecture.Path moduleFolder = Storage.GetModulePath();

            if (moduleFolder.Exists())
            {
                Result moduleReport = await Updator.ForceInstallModule(); // Doing a little cheaty cheat here, letting the updator do the rest of the work.

                if (!moduleReport.Succeeded)
                {
                    Configuration.CheckInitialized();
                    Logger.Write(moduleReport.FailReason, LogLevel.LEVEL_WARN);
                    return moduleReport;
                }
                else
                {
                    report.Succeeded = true;
                }
            }
            else
            {
                report.FailReason = "Failed to locate folder, cannot download latest module archive!";
            }

            return report;
        }
    }
}
