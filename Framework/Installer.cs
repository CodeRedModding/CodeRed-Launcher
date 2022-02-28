using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CodeRedLauncher
{
    public enum InstallerStatus : byte
    {
        STATUS_IDLE,
        STATUS_DELETE_KEY,
        STATUS_CREATE_KEY
    }

    /*
     *             FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                InstallFolder = fbd.SelectedPath;

                if (!InstallFolder.Contains("CodeRed"))
                {
                    InstallFolder += "\\CodeRed";
                }

                LocationBox.Text = InstallFolder;
            }
     */

    public static class Installer
    {
        private static readonly string SubKey = "CodeRedModding";
        private static readonly string KeyName = "InstallPath";
        public static InstallerStatus Status { get; set; } = InstallerStatus.STATUS_IDLE;

        public static void ModifyRegistry(bool bDeleteKey, string installPath)
        {
            if (bDeleteKey)
            {
                Status = InstallerStatus.STATUS_DELETE_KEY;
                RegistryKey coderedKey = Registry.CurrentUser.OpenSubKey(SubKey);

                if (coderedKey != null)
                {
                    coderedKey.DeleteValue(KeyName, false);
                    coderedKey.Close();
                    Registry.CurrentUser.DeleteSubKey(SubKey);
                }
            }
            else
            {
                Status = InstallerStatus.STATUS_CREATE_KEY;
                RegistryKey coderedKey = Registry.CurrentUser.CreateSubKey(SubKey);

                if (coderedKey != null)
                {
                    coderedKey.SetValue(KeyName, installPath);
                    coderedKey.Close();
                }
            }
        }
    }
}
