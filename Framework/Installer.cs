using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CodeRedLauncher
{
    public static class Installer
    {
        private static readonly string m_subKey = "CodeRedModding";
        private static readonly string m_keyName = "InstallPath";

        public static void ModifyRegistry(bool bDeleteKey, Architecture.Path installPath)
        {
            if (bDeleteKey)
            {
                RegistryKey coderedKey = Registry.CurrentUser.OpenSubKey(m_subKey);

                if (coderedKey != null)
                {
                    Logger.Write("(ModifyRegistry) Deleting install path registry key...");
                    coderedKey.DeleteValue(m_keyName, false);
                    coderedKey.Close();
                    Registry.CurrentUser.DeleteSubKey(m_subKey);
                }
            }
            else
            {
                RegistryKey coderedKey = Registry.CurrentUser.CreateSubKey(m_subKey);

                if (coderedKey != null)
                {
                    Logger.Write("(ModifyRegistry) Saving install path \"" + installPath.GetPath() + "\" to registry!");
                    coderedKey.SetValue(m_keyName, installPath.GetPath());
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

                        Logger.Write("(CreateInstallPath) User manually selected \"" + installPath.GetPath() + "\" for the install path.");
                    }
                }
            }
            else
            {
                installPath.Set(LocalStorage.GetGamesPath() / "CodeRed");
                Directory.CreateDirectory(installPath.GetPath());
            }

            if (installPath.Exists())
            {
                ModifyRegistry(false, installPath);
                LocalStorage.Invalidate(true);
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
            Architecture.Path moduleFolder = LocalStorage.GetModulePath();

            if (moduleFolder.Exists())
            {
                Result moduleReport = await Updater.ForceInstallModule(); // Doing a little cheaty cheat here, letting the updater do the rest of the work.

                if (!moduleReport.Succeeded)
                {
                    Configuration.CheckInitialized();
                    Logger.Write("(DownloadModule) Failed to download module file: " + moduleReport.FailReason, LogLevel.Error);
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
