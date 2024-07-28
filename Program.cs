using System;
using System.Windows.Forms;

namespace CodeRedLauncher
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware); // All custom UI elements are anchored and scale on their own, "DpiUnaware" is required to be set for this to work properly.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFrm());
        }
    }
}