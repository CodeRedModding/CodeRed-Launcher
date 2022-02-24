using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using CodeRedLauncher.Controls;

namespace CodeRedLauncher
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            StartupRoutine();
        }

        private void TitleBar_MinimizedEvent(object sender, EventArgs e)
        {
            TrayIcon.Visible = true;

            if (Configuration.ShouldHideWhenMinimized())
            {
                this.Hide();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            TrayIcon.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void DashboardTabBtn_Click(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_DASHBOARD);
        }

        private void NewsTabBtn_Click(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_NEWS);
        }

        private void TrackerTabBtn_Click(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_TRACKER);
        }

        private void TexturesTabBtn_Click(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_TEXTURES);
        }

        private void ScriptsTabBtn_Click(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_SCRIPTS);
        }

        private void SettingsTabBtn_Click(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_SETTINGS);
        }

        private void AboutTabBtn_Click(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_ABOUT);
        }

        private void ExitTabBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LaunchBtn_Click(object sender, EventArgs e)
        {
            if (!LibraryManager.AnyProcessRunning())
            {
                if (Storage.CheckInitialized())
                {
                    PlatformTypes platform = Storage.GetCurrentPlatform(true);

                    if (platform == PlatformTypes.TYPE_STEAM)
                    {
                        Path gameFile = Storage.GetSteamPath() / "RocketLeague.exe";

                        if (gameFile.Exists())
                        {
                            Process.Start(new ProcessStartInfo(gameFile.GetPath()) { UseShellExecute = false });
                        }
                        else
                        {
                            Logger.Write("Failed to locate the users Rocket League executable on Steam!", LogLevel.LEVEL_ERROR);
                        }
                    }
                    else if (platform == PlatformTypes.TYPE_EPIC)
                    {
                        Path gameFile = Storage.GetEpicPath() / "RocketLeague.exe";

                        if (gameFile.Exists())
                        {
                            Process.Start(new ProcessStartInfo(gameFile.GetPath()) { UseShellExecute = false });
                        }
                        else
                        {
                            Logger.Write("Failed to locate the users Rocket League executable on Epic!", LogLevel.LEVEL_ERROR);
                        }
                    }
                }
            }
        }

        private void ManualInjectBtn_Click(object sender, EventArgs e)
        {
            if (!Configuration.ShouldInjectAll())
            {
                List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                if (processes.Count > 0)
                {
                    LogInjectionResult(LibraryManager.TryLoadIndividual(processes[0], Storage.GetLibraryFile()), true);
                }
            }
            else
            {
                List<InjectionResults> results = LibraryManager.TryLoadDynamic(Storage.GetLibraryFile());

                if (results.Count > 0)
                {
                    foreach (InjectionResults result in results)
                    {
                        LogInjectionResult(result, true);
                    }
                }
            }
        }

        private void AutoCheckUpdatesBx_Click(object sender, EventArgs e)
        {
            Configuration.AutoCheckUpdates.SetValue(AutoCheckUpdatesBx.Checked).Save();
        }

        private void PreventInjectionBx_Click(object sender, EventArgs e)
        {
            Configuration.PreventInjection.SetValue(PreventInjectionBx.Checked).Save();
        }

        private void RunOnStartupBx_Click(object sender, EventArgs e)
        {
            Configuration.RunOnStartup.SetValue(RunOnStartupBx.Checked).Save();
            RegistryKey startKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (RunOnStartupBx.Checked)
            {
                startKey.SetValue(Assembly.GetProduct(), Application.ExecutablePath);
            }
            else
            {
                startKey.DeleteValue(Assembly.GetProduct(), false);
            }
        }

        private void MinimizeOnStartupBx_Click(object sender, EventArgs e)
        {
            Configuration.MinimizeOnStartup.SetValue(MinimizeOnStartupBx.Checked).Save();
        }

        private void HideWhenMinimizedBx_Click(object sender, EventArgs e)
        {
            Configuration.HideWhenMinimized.SetValue(HideWhenMinimizedBx.Checked).Save();
        }

        private void InjectAllInstancesBx_Click(object sender, EventArgs e)
        {
            Configuration.InjectAllInstances.SetValue(InjectAllInstancesBx.Checked).Save();
        }

        private void OnInjectionTypeChanged()
        {
            if (TimeoutRadioBtn.Checked)
            {
                Configuration.InjectionType.SetValue(InjectionTypes.TYPE_TIMEOUT.ToString()).Save();
            }
            else if (ManualRadioBtn.Checked)
            {
                Configuration.InjectionType.SetValue(InjectionTypes.TYPE_MANUAL.ToString()).Save();
            }
            else if (AlwaysRadioBtn.Checked)
            {
                Configuration.InjectionType.SetValue(InjectionTypes.TYPE_ALWAYS.ToString()).Save();
            }
            else
            {
                Configuration.InjectionType.ResetToDefault().Save();
                Logger.Write("Unknown injection type detected, resetting to default!", LogLevel.LEVEL_WARN);
            }
        }

        private void TimeoutRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            OnInjectionTypeChanged();
        }

        private void ManualRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            OnInjectionTypeChanged();
        }

        private void AlwaysRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            OnInjectionTypeChanged();
        }

        private void InjectionTimeoutBx_TextChangedEvent(object sender, EventArgs e)
        {
            Int32 timeoutValue = Int32.Parse(InjectionTimeoutBx.DisplayText);

            if (Configuration.InjectionTimeoutRange.IsInRange(timeoutValue))
            {
                Configuration.InjectionTimeout.SetValue(timeoutValue).Save();
            }
            else
            {
                Configuration.InjectionTimeout.ResetToDefault().Save();
                Logger.Write("Injection timeout out of range, resetting to defaut!", LogLevel.LEVEL_WARN);
            }
        }

        private void WebsiteLink_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(WebsiteLink.Text) { UseShellExecute = true });
        }

        private void DiscordLink_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(DiscordLink.Text) { UseShellExecute = true });
        }

        private void PatreonLink_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(PatreonLink.Text) { UseShellExecute = true });
        }

        private void Icons8Link_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(Icons8Link.Text) { UseShellExecute = true });
        }

        private void CheckUpdatesBtn_Click(object sender, EventArgs e)
        {
            CheckForUpdates(true);
        }

        private void ProcessTmr_Tick(object sender, EventArgs e)
        {
            if (Configuration.GetInjectionType() != InjectionTypes.TYPE_ALWAYS)
            {
                if (LibraryManager.AnyProcessRunning())
                {
                    ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_RUNNING;

                    if (!InjectTmr.Enabled)
                    {
                        ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_INJECTING;
                        InjectTmr.Start();
                    }
                }
                else
                {
                    InjectTmr.Stop();
                    ManualInjectBtn.Visible = false;
                    ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_NOT_RUNNING;
                }
            }
            else
            {
                ProcessTmr.Stop();
                ManualInjectBtn.Visible = false;
                ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_DISABLED;
            }
        }

        private void InjectTmr_Tick(object sender, EventArgs e)
        {
            CheckForUpdates(true);

            if (Updator.IsOutdated && Configuration.ShouldPreventInjection())
            {
                Logger.Write("Prevented injection, updator returned out of date!");
                return;
            }

            if (Configuration.GetInjectionType() == InjectionTypes.TYPE_MANUAL)
            {
                ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_MANUAL;
                ManualInjectBtn.Visible = true;
                return;
            }
            else
            {
                ManualInjectBtn.Visible = false;
            }

            if (!Configuration.ShouldInjectAll())
            {
                List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                if (processes.Count > 0)
                {
                    LogInjectionResult(LibraryManager.TryLoadIndividual(processes[0], Storage.GetLibraryFile()), true);
                }
                else
                {
                    InjectTmr.Stop();
                }
            }
            else
            {
                List<InjectionResults> results = LibraryManager.TryLoadDynamic(Storage.GetLibraryFile());

                if (results.Count > 0)
                {
                    foreach (InjectionResults result in results)
                    {
                        LogInjectionResult(result, true);
                    }
                }
                else
                {
                    InjectTmr.Stop();
                }
            }
        }

        void LogInjectionResult(InjectionResults result, bool bUpdateStatus)
        {
            if (bUpdateStatus)
            {
                ProcessCtrl.Result = result;
            }

            switch (result)
            {
                case InjectionResults.RESULT_LIBRARY_NOT_FOUND:
                    Logger.Write("Failed to inject, could not find library file!", LogLevel.LEVEL_ERROR);
                    break;
                case InjectionResults.RESULT_PROCESS_NOT_FOUND:
                    Logger.Write("Failed to inject, process is no longer valid!", LogLevel.LEVEL_WARN);
                    InjectTmr.Stop();
                    break;
                case InjectionResults.RESULT_RETRY_INJECTION:
                    Logger.Write("Failed to inject, retry keyword detected.", LogLevel.LEVEL_WARN);
                    InjectTmr.Stop();
                    break;
                case InjectionResults.RESULT_ALREADY_INJECTED:
                    // If we uncomment this it will write to the log file infinitely as long as the game is running.
                    // Logger.Write("Successfully injected, changes applied in-game.");
                    break;
                case InjectionResults.RESULT_HANDLE_NOT_FOUND:
                    Logger.Write("Failed to inject, process handle is invalid!", LogLevel.LEVEL_ERROR);
                    InjectTmr.Stop();
                    break;
                case InjectionResults.RESULT_KERNAL_NOT_FOUND:
                    Logger.Write("Failed to inject, load library not found!", LogLevel.LEVEL_FATAL);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.RESULT_ALLOCATE_FAIL:
                    Logger.Write("Failed to inject, could not allocate space in memory!", LogLevel.LEVEL_ERROR);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.RESULT_WRITE_FAILT:
                    Logger.Write("Failed to inject, could not write into memory!", LogLevel.LEVEL_ERROR);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.RESULT_THREAD_FAIL:
                    Logger.Write("Failed to inject, could not create remote thread!", LogLevel.LEVEL_ERROR);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.RESULT_SUCCESS:
                    Logger.Write("Successfully injected, changes applied in-game.");
                    break;
            }
        }

        private async void StartupRoutine()
        {
            this.Text = Assembly.GetTitle();
            TitleBar.BoundForm = this; // Bind "MainFrm" to the "CRTitleBar", which handles mouse moving and dragging the window around.

            Interface.BindControl(TabCtrl);
            Interface.BindTab(Tabs.TAB_DASHBOARD, DashboardTabBtn, DashboardTab);
            Interface.BindTab(Tabs.TAB_NEWS, NewsTabBtn, NewsTab);
            Interface.BindTab(Tabs.TAB_TRACKER, TrackerTabBtn, TrackerTab);
            Interface.BindTab(Tabs.TAB_TEXTURES, TexturesTabBtn, TexturesTab);
            Interface.BindTab(Tabs.TAB_SCRIPTS, ScriptsTabBtn, ScriptsTab);
            Interface.BindTab(Tabs.TAB_SETTINGS, SettingsTabBtn, SettingsTab);
            Interface.BindTab(Tabs.TAB_ABOUT, AboutTabBtn, AboutTab);

            Logger.CheckInitialized(); // Create and initialize the log file for the launcher.
            ConfigToInterface(); // Retrieves the users configuration settings and assigns it to the ui.
            StorageToInterface(); // Retrieves Rocket League paths, version, and platform info to then assign to the UI.

            if (await Retrievers.CheckInitialized())
            {
                // Temporarily disabled.
                ChangelogCtrl.DisplayText = await Retrievers.GetChangelog();
                DiscordLink.Text = await Retrievers.GetDiscordUrl();

                if (Configuration.ShouldCheckForUpdates())
                {
                    CheckForUpdates(false); // Setting to false because we don't want to display a popup on startup if no update is found, plus there's no need to invalidate anything.
                }

                // Don't want to bother monitoring processes while updating if we aren't doing anything with it yet, like during updates...
                if (Updator.Status == UpdatorStatus.STATUS_IDLE)
                {
                    ProcessTmr.Start();
                }
            }
            else
            {
                Logger.Write("Failed to do download remote information, cannot check for updates or verify installed version!", LogLevel.LEVEL_WARN);
            }

            NewsCtrl.ParseArticles("https://www.rocketleague.com/ajax/articles-results/?p=0&lang=en-us"); // In the future remember to make this url dynamic, aka returned by the "Retrievers" class.
        }

        private void ConfigToInterface()
        {
            if (Configuration.CheckInitialized())
            {
                AutoCheckUpdatesBx.Checked = Configuration.ShouldCheckForUpdates();
                PreventInjectionBx.Checked = Configuration.ShouldPreventInjection();
                RunOnStartupBx.Checked = Configuration.ShouldRunOnStartup();
                MinimizeOnStartupBx.Checked = Configuration.ShouldMinimizeOnStartup();
                HideWhenMinimizedBx.Checked = Configuration.ShouldHideWhenMinimized();
                InjectAllInstancesBx.Checked = Configuration.ShouldInjectAll();

                InjectionTypes injectionType = Configuration.GetInjectionType();

                switch (injectionType)
                {
                    case InjectionTypes.TYPE_TIMEOUT:
                        TimeoutRadioBtn.Checked = true;
                        break;
                    case InjectionTypes.TYPE_MANUAL:
                        ManualRadioBtn.Checked = true;
                        break;
                    case InjectionTypes.TYPE_ALWAYS:
                        AlwaysRadioBtn.Checked = true;
                        break;
                    default:
                        TimeoutRadioBtn.Checked = true;
                        break;
                }

                InjectTmr.Interval = Configuration.GetInjectionTimeout();
                InjectionTimeoutBx.DisplayText = Configuration.GetInjectionTimeout().ToString();
            }
            else
            {
                Logger.Write("Failed to initialize the users settings!", LogLevel.LEVEL_ERROR);
            }
        }

        private void StorageToInterface()
        {
            if (Storage.CheckInitialized())
            {
                LauncherVersionText.Text = "v" + Assembly.GetVersion();
                ModuleVersionText.Text = "v" + Storage.GetModuleVersion();
                PsyonixBuildText.Text = Storage.GetPsyonixBuild();
                NetBuildText.Text = Storage.GetNetBuild().ToString();
                PlatformText.Text = Storage.GetPlatformString(false);

                PlatformTypes platform = Storage.GetCurrentPlatform(false);

                switch (platform)
                {
                    case PlatformTypes.TYPE_STEAM:
                        LaunchBtn.DisplayImage = Properties.Resources.Steam_White;
                        PlatformImg.BackgroundImage = Properties.Resources.Steam_White;
                        break;
                    case PlatformTypes.TYPE_EPIC:
                        PlatformImg.BackgroundImage = Properties.Resources.Epic_White;
                        LaunchBtn.DisplayImage = Properties.Resources.Epic_White;
                        break;
                    default:
                        PlatformImg.BackgroundImage = Properties.Resources.Question_White;
                        LaunchBtn.DisplayImage = Properties.Resources.Question_White;
                        break;
                }

                LaunchBtn.Visible = true;
                ManualInjectBtn.Visible = false;
            }
            else
            {
                Logger.Write("Failed to retrieve local directory information, cannot verify Rocket League version!", LogLevel.LEVEL_ERROR);
            }
        }

        // If "bInvalidate" is set to true it forces the application to re-fetch all local and remote information, this also doubles to determine to display a message popup if there is no update found.
        private async void CheckForUpdates(bool bInvalidate)
        {
            if (bInvalidate)
            {
                Storage.Invalidate();
            }

            if (Storage.CheckInitialized())
            {
                UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_CHECKING;
                StorageToInterface();

                if (bInvalidate)
                {
                    Retrievers.Invalidate();
                }

                if (await Retrievers.CheckInitialized())
                {
                    bool moduleOutdated = Storage.GetModuleVersion() != await Retrievers.GetModuleVersion();
                    bool launcherOutdated = Assembly.GetVersion() != await Retrievers.GetLauncherVersion();
                    Updator.IsOutdated = ((moduleOutdated || launcherOutdated) == true);

                    // Prioritize updating launcher first, in case the launcher update fixes something wrong with the dll updator.
                    // The updator for the launcher is always downloaded first, so that will always be up to date.

                    // REMEMBER TO DO ASYNC STARTING OF ProcessTmr WHEN UPDATING IS DONE! AND MESSAGEBOX
                    if (moduleOutdated && launcherOutdated)
                    {
                        UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_BOTH;
                        UpdateCtrl.TitleImage = Properties.Resources.Warning_White;
                    }
                    else if (moduleOutdated)
                    {
                        UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_MODULE;
                        UpdateCtrl.TitleImage = Properties.Resources.Warning_White;
                    }
                    else if (launcherOutdated)
                    {
                        UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_LAUNCHER;
                        UpdateCtrl.TitleImage = Properties.Resources.Warning_White;
                    }
                    else
                    {
                        UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_UPDATED;
                        UpdateCtrl.TitleImage = Properties.Resources.Success_White;
                        ProcessTmr.Start();
                    }
                }
            }
            else
            {
                Logger.Write("Failed to retrieve local directory information while checking for updates!", LogLevel.LEVEL_FATAL);
            }
        }
    }
}