using System;
using System.IO;
using Microsoft.Win32;
using System.Text.Json;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;
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

        private void TitleBar_OnMinimized(object sender, EventArgs e)
        {
            if (Configuration.ShouldHideWhenMinimized())
            {
                this.Hide();
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void TitleBar_OnExit(object sender, EventArgs e)
        {
            this.TrayIcon.Visible = false;
            Environment.Exit(0);
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }

        private void DashboardTabBtn_OnTabClick(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_DASHBOARD);
        }

        private void NewsTabBtn_OnTabClick(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_NEWS);
        }

        private void SessionsTabBtn_OnTabClick(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_SESSIONS);
        }

        private void TexturesTabBtn_OnTabClick(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_TEXTURES);
        }

        private void ScriptsTabBtn_OnTabClick(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_SCRIPTS);
        }

        private void SettingsTabBtn_OnTabClick(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_SETTINGS);
        }

        private void AboutTabBtn_OnTabClick(object sender, EventArgs e)
        {
            Interface.SelectTab(Tabs.TAB_ABOUT);
        }

        private void ExitTabBtn_OnTabClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void ChangelogCtrl_OnChangelogSwap(object sender, EventArgs e)
        {
            if (ChangelogCtrl.DisplayTitle == "Module Changelog")
            {
                ChangelogCtrl.DisplayTitle = "Launcher Changelog";

                if (!Configuration.OfflineMode.GetBoolValue())
                {
                    ChangelogCtrl.DisplayText = await Retrievers.GetLauncherChangelog();
                }
                else
                {
                    ChangelogCtrl.DisplayText = "Offline mode enabled, cannot retrieve changelog information at this time.";
                }
            }
            else
            {
                ChangelogCtrl.DisplayTitle = "Module Changelog";

                if (!Configuration.OfflineMode.GetBoolValue())
                {
                    ChangelogCtrl.DisplayText = await Retrievers.GetModuleChangelog();
                }
                else
                {
                    ChangelogCtrl.DisplayText = "Offline mode enabled, cannot retrieve changelog information at this time.";
                }
            }
        }

        private void LaunchBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (!LibraryManager.AnyProcessRunning())
            {
                if (Storage.CheckInitialized())
                {
                    PlatformTypes platform = Storage.GetCurrentPlatform(true);

                    if (platform == PlatformTypes.TYPE_STEAM)
                    {
                        Architecture.Path gameFile = Storage.GetSteamPath() / "RocketLeague.exe";

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
                        Architecture.Path gameFile = Storage.GetEpicPath() / "RocketLeague.exe";

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
                    LogInjectionResult(LibraryManager.TryLoadIndividual(processes[0], Storage.GetLibraryFile()));
                }
            }
            else
            {
                List<InjectionResults> results = LibraryManager.TryLoadDynamic(Storage.GetLibraryFile());

                if (results.Count > 0)
                {
                    foreach (InjectionResults result in results)
                    {
                        LogInjectionResult(result);
                    }
                }
            }
        }

        private void ReloadSessionsBtn_OnButtonClick(object sender, EventArgs e)
        {
            Sessions.ParseSessions();
            TotalSessionsLbl.Text = ("Sessions Found: " + Sessions.ParsedSessions.Count);
        }

        private void AutoCheckUpdatesBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.AutoCheckUpdates.SetValue(AutoCheckUpdatesBx.Checked).Save();
        }

        private void PreventInjectionBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.PreventInjection.SetValue(PreventInjectionBx.Checked).Save();
        }

        private void RunOnStartupBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.RunOnStartup.SetValue(RunOnStartupBx.Checked).Save();
            RegistryKey startKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (startKey != null)
            {
                if (RunOnStartupBx.Checked)
                {
                    Logger.Write("Setting run on start registry value to \"" + Application.ExecutablePath + "\"...");
                    startKey.SetValue(Assembly.GetProduct(), Application.ExecutablePath);
                }
                else
                {
                    Logger.Write("Deleting run on start registry key...");
                    startKey.DeleteValue(Assembly.GetProduct(), false);
                }

                startKey.Close();
            }
        }

        private void MinimizeOnStartupBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.MinimizeOnStartup.SetValue(MinimizeOnStartupBx.Checked).Save();
        }

        private void HideWhenMinimizedBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.HideWhenMinimized.SetValue(HideWhenMinimizedBx.Checked).Save();
        }

        private void InjectAllInstancesBx_OnCheckChanged(object sender, EventArgs e)
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
                Logger.Write("Unknown injection type detected, resetting value to default!", LogLevel.LEVEL_WARN);
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

        private void InjectionTimeoutBx_OnValueChanged(object sender, EventArgs e)
        {
            if (Configuration.InjectionTimeoutRange.IsInRange(InjectionTimeoutBx.Value))
            {
                Configuration.InjectionTimeout.SetValue(InjectionTimeoutBx.Value).Save();
                InjectTmr.Interval = InjectionTimeoutBx.Value;
            }
        }

        private void OpenFolderBtn_OnButtonClick(object sender, EventArgs e)
        {
            Architecture.Path folderPath = Storage.GetModulePath();

            if (folderPath.Exists())
            {
                Process.Start(new ProcessStartInfo(folderPath.GetPath()) { UseShellExecute = true });
            }
        }

        private void ExportLogsBtn_OnButtonClick(object sender, EventArgs e)
        {
            Architecture.Path modulePath = Storage.GetModulePath();
            Architecture.Path logsPath = (Storage.GetGamesPath() / "TAGame" / "Logs");

            if (modulePath.Exists())
            {
                Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

                if (tempFolder.Exists())
                {
                    Directory.Delete(tempFolder.GetPath(), true);
                }

                List<string> filesToExport = new List<string>();
                List<Architecture.Path> moduleFiles = modulePath.GetFiles(true);

                foreach (Architecture.Path file in moduleFiles)
                {
                    if (file.Exists())
                    {
                        string filePath = file.GetPath();

                        if (filePath.Contains(".log"))
                        {
                            filesToExport.Add(filePath);
                        }
                    }
                }

                if (logsPath.Exists())
                {
                    List<Architecture.Path> logFiles = logsPath.GetFiles();

                    foreach (Architecture.Path file in logFiles)
                    {
                        if (file.Exists())
                        {
                            string filePath = file.GetPath();

                            if (filePath.Contains(".mdump") || filePath.Contains(".mdmp") || filePath.Contains(".dmp") || filePath.Contains(".log"))
                            {
                                filesToExport.Add(filePath);
                            }
                        }
                    }
                }

                if (filesToExport.Count > 0)
                {
                    FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        Directory.CreateDirectory(tempFolder.GetPath());

                        if (Directory.Exists(tempFolder.GetPath()))
                        {
                            string zipName = "crash_logs_" + DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
                            Architecture.Path zipFolder = (tempFolder / zipName);
                            Directory.CreateDirectory(zipFolder.GetPath());

                            if (zipFolder.Exists())
                            {
                                Logger.Write("Found \"" + filesToExport.Count + "\" files to export.");

                                foreach (string file in filesToExport)
                                {
                                    if (File.Exists(file))
                                    {
                                        FileInfo fileInfo = new FileInfo(file);
                                        File.Copy(file, (zipFolder / fileInfo.Name).GetPath());
                                    }
                                }

                                Architecture.Path zipFile = (tempFolder / (zipName + ".zip"));
                                ZipFile.CreateFromDirectory(zipFolder.GetPath(), zipFile.GetPath());
                                File.Move(zipFile.GetPath(), folderBrowser.SelectedPath + "\\" + zipName + ".zip");
                                Directory.Delete(tempFolder.GetPath(), true);

                                MessageBox.Show("Successfully exported \"" + filesToExport.Count.ToString() + "\" crash logs to: " + folderBrowser.SelectedPath.ToString(), Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There were no crash dumps or logs found to export! This could be either a good or bad thing...", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void KofiLink_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(KofiLink.Text) { UseShellExecute = true });
        }

        private void Icons8Link_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo(Icons8Link.Text) { UseShellExecute = true });
        }

        private void CheckUpdatesBtn_OnButtonClick(object sender, EventArgs e)
        {
            CheckForUpdates(true);
        }

        private void ProcessTmr_Tick(object sender, EventArgs e)
        {
            if (Configuration.GetInjectionType() != InjectionTypes.TYPE_ALWAYS)
            {
                if (LibraryManager.AnyProcessRunning())
                {
                    LaunchBtn.DisplayText = "Launch (Already Running)";

                    if (ProcessCtrl.Status != CRProcessPanel.StatusTypes.TYPE_INJECTING)
                    {
                        if (!Updator.IsOutdated())
                        {
                            ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_RUNNING;
                            ProcessCtrl.Result = InjectionResults.RESULT_NONE;
                        }
                        else
                        {
                            ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_OUTDATED;
                            ProcessCtrl.Result = InjectionResults.RESULT_NONE;
                        }

                        if (Updator.IsOutdated() && Configuration.ShouldPreventInjection())
                        {
                            ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_OUTDATED;
                            ProcessCtrl.Result = InjectionResults.RESULT_NONE;
                            InjectTmr.Stop();
                        }
                        else
                        {
                            ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_INJECTING;
                            ProcessCtrl.Result = InjectionResults.RESULT_NONE;
                            InjectTmr.Start();
                        }
                    }
                }
                else
                {
                    InjectTmr.Stop();
                    LaunchBtn.DisplayText = "Launch Rocket League";
                    ManualInjectBtn.Visible = false;
                    ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_NOT_RUNNING;
                    ProcessCtrl.Result = InjectionResults.RESULT_NONE;
                }
            }
            else
            {
                ProcessTmr.Stop();
                ManualInjectBtn.Visible = false;
                ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_DISABLED;
                ProcessCtrl.Result = InjectionResults.RESULT_NONE;
            }
        }

        private void InjectTmr_Tick(object sender, EventArgs e)
        {
            CheckForUpdates(true);

            if (!Configuration.OfflineMode.GetBoolValue())
            {
                if (Updator.IsOutdated() && Configuration.ShouldPreventInjection())
                {
                    Logger.Write("Prevented injection, updator returned out of date!");
                    ProcessCtrl.Status = CRProcessPanel.StatusTypes.TYPE_OUTDATED;
                    InjectTmr.Stop();
                    return;
                }
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
                    LogInjectionResult(LibraryManager.TryLoadIndividual(processes[0], Storage.GetLibraryFile()));
                }

                InjectTmr.Stop();
            }
            else
            {
                List<InjectionResults> results = LibraryManager.TryLoadDynamic(Storage.GetLibraryFile());

                if (results.Count > 0)
                {
                    foreach (InjectionResults result in results)
                    {
                        LogInjectionResult(result);
                    }
                }

                InjectTmr.Stop();
            }
        }

        private void UpdateTmr_Tick(object sender, EventArgs e)
        {
            if (Updator.IsOutdated())
            {
                Logger.Write("Auto checking for updates...");
                CheckForUpdates(true);
            }
            else
            {
                UpdateTmr.Stop();
            }
        }

        void LogInjectionResult(InjectionResults result)
        {
            ProcessCtrl.Result = result;

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
                    // If we uncomment this it will write to the log file indefinitely as long as the game is running.
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

        private async void StartupRoutine(bool bInvalidate = false)
        {
            this.Text = Assembly.GetTitle();

            TitleBar.BoundForm = this;
            InstallPopupCtrl.BoundForm = this;
            InstallOfflinePopupCtrl.BoundForm = this;
            UpdatePopupCtrl.BoundForm = this;
            OfflinePopupCtrl.BoundForm = this;

            Interface.BindControl(TabCtrl);
            Interface.BindTab(Tabs.TAB_DASHBOARD, DashboardTabBtn, DashboardTab);
            Interface.BindTab(Tabs.TAB_NEWS, NewsTabBtn, NewsTab);
            Interface.BindTab(Tabs.TAB_SESSIONS, SessionsTabBtn, SessionsTab);
            Interface.BindTab(Tabs.TAB_TEXTURES, TexturesTabBtn, TexturesTab);
            Interface.BindTab(Tabs.TAB_SCRIPTS, ScriptsTabBtn, ScriptsTab);
            Interface.BindTab(Tabs.TAB_SETTINGS, SettingsTabBtn, SettingsTab);
            Interface.BindTab(Tabs.TAB_ABOUT, AboutTabBtn, AboutTab);

            Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

            if (tempFolder.Exists())
            {
                // This is to cleanup anything left over by the auto updator/dropper program.
                Directory.Delete(tempFolder.GetPath(), true);
            }

            if (!Storage.HasCoderedRegistry() || !Storage.GetModulePath().Exists())
            {
                if (await Retrievers.CheckInitialized())
                {
                    InstallPopupCtrl.Show();
                }
                else
                {
                    InstallOfflinePopupCtrl.Show();
                }

                return;
            }

            if (bInvalidate)
            {
                Storage.Invalidate(true);
                Retrievers.Invalidate();
            }

            Logger.CheckInitialized(); // Create and initialize the log file for the launcher.

            if (Configuration.CheckInitialized())
            {
                if (Configuration.ShouldMinimizeOnStartup())
                {
                    TitleBar_OnMinimized(null, null);
                }

                if (await Retrievers.CheckInitialized())
                {
                    string pingUrl = await Retrievers.GetModuleUrl();

                    if ((await Downloaders.WebsiteOnline(pingUrl)) == false)
                    {
                        OfflinePopupCtrl.Show();
                    }
                    else
                    {
                        ContinueStartup();
                    }
                }
                else
                {
                    OfflinePopupCtrl.Show();
                }

                NewsCtrl.ParseArticles(await Retrievers.GetNewsUrl());
            }
            else
            {
                if (!Storage.GetLibraryFile().Exists())
                {
                    await Installer.DownloadModule();
                    StartupRoutine(true);
                }
                else
                {
                    ContinueStartup();
                }
            }

            ConfigToInterface(); // Retrieves the users configuration settings and assigns it to the UI.
            StorageToInterface(); // Retrieves Rocket League paths, version, and platform info to then assign to the UI.
        }

        private async void ContinueStartup()
        {
            if (!Configuration.OfflineMode.GetBoolValue())
            {
                ChangelogCtrl.DisplayText = await Retrievers.GetModuleChangelog();
                DiscordLink.Text = await Retrievers.GetDiscordUrl();
                KofiLink.Text = await Retrievers.GetKofiUrl();

                if (Configuration.ShouldCheckForUpdates())
                {
                    CheckForUpdates(false);
                }
            }
            else
            {
                ChangelogCtrl.DisplayText = "Offline mode enabled, cannot retrieve changelog information at this time.";
                DiscordLink.Text = "Offline mode enabled";
            }

            ProcessTmr.Start();
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

                InjectionTimeoutBx.MinimumValue = Configuration.InjectionTimeoutRange.Minimum;
                InjectionTimeoutBx.MaximumValue = Configuration.InjectionTimeoutRange.Maximum;
                InjectionTimeoutBx.Value = Configuration.GetInjectionTimeout();
                InjectTmr.Interval = InjectionTimeoutBx.Value;
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
                LauncherVersionText.Text =  Assembly.GetVersion();
                ModuleVersionText.Text = Storage.GetModuleVersion();
                PsyonixVersionText.Text = Storage.GetPsyonixVersion();
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
        }

        // If "bInvalidate" is set to true it forces the application to retrieve all local and remote information.
        private async Task<bool> CheckForUpdates(bool bInvalidate)
        {
            if (!Configuration.OfflineMode.GetBoolValue() || bInvalidate)
            {
                Logger.Write("Checking for updates...");
                UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_CHECKING;

                if (await Retrievers.CheckInitialized())
                {
                    bool moduleOutdated = await Updator.IsModuleOutdated(bInvalidate);
                    bool launcherOutdated = await Updator.IsLauncherOutdated(bInvalidate);

                    UInt32 localVersion = Storage.GetPsyonixDate();
                    UInt32 remoteVersion = await Retrievers.GetPsyonixDate();
                    bool ignoreModule = (localVersion > remoteVersion);

                    // If the installed Rocket League version is greater than the one retrieved remotely, an update for the module is not out yet.
                    if (ignoreModule && !launcherOutdated)
                    {
                        Logger.Write("CodeRed is out of date, no new module version has been released yet!");
                        Updator.OverrideStatus(UpdatorStatus.STATUS_OVERRIDE);
                        UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_OUTDATED;
                        UpdateCtrl.TitleImage = Properties.Resources.Hourglass_White;

                        // Every sixty seconds this timer automatically checks for updates.
                        if (!UpdateTmr.Enabled)
                        {
                            UpdateTmr.Start();
                        }
                    }
                    else if (Updator.IsOutdated())
                    {
                        UpdateTmr.Stop();

                        // Prioritize updating the module first, then the launcher.
                        if (!ignoreModule && moduleOutdated && launcherOutdated)
                        {
                            UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_BOTH;
                            UpdateCtrl.TitleImage = Properties.Resources.Warning_White;

                            if (LibraryManager.AnyProcessRunning())
                            {
                                List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                                if (processes.Count > 0 && LibraryManager.IsModuleLoaded(processes[0], true))
                                {
                                    UpdatePopupCtrl.ButtonLayout = CRPopup.ButtonLayouts.TYPE_SINGLE;
                                    UpdatePopupCtrl.DisplayDescription = "A new version of both the module and launcher were found, but Rocket League needs to be closed in order to install it first! Please close the game and try again.";
                                }
                                else
                                {
                                    UpdatePopupCtrl.DisplayDescription = "A new version of both the module and launcher were found, would you like to automatically install both now?";
                                }
                            }
                            else
                            {
                                UpdatePopupCtrl.DisplayDescription = "A new version of both the module and launcher were found, would you like to automatically install both now?";
                            }

                            UpdatePopupCtrl.Show();
                        }
                        else if (!ignoreModule && moduleOutdated)
                        {
                            UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_MODULE;
                            UpdateCtrl.TitleImage = Properties.Resources.Warning_White;

                            if (LibraryManager.AnyProcessRunning())
                            {
                                List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                                if (processes.Count > 0 && LibraryManager.IsModuleLoaded(processes[0], true))
                                {
                                    UpdatePopupCtrl.ButtonLayout = CRPopup.ButtonLayouts.TYPE_DOUBLE;
                                    UpdatePopupCtrl.DisplayDescription = "A new version of the module was found, but Rocket League needs to be closed in order to install it first! Please close the game and try again.";
                                }
                                else
                                {
                                    UpdatePopupCtrl.DisplayDescription = "A new version of the module was found, would you like to automatically install it now?";
                                }
                            }
                            else
                            {
                                UpdatePopupCtrl.DisplayDescription = "A new version of the module was found, would you like to automatically install it now?";
                            }

                            UpdatePopupCtrl.Show();
                        }
                        else if (launcherOutdated)
                        {
                            UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_LAUNCHER;
                            UpdateCtrl.TitleImage = Properties.Resources.Warning_White;

                            // Doesn't matter if Rocket League is open or not when updating the launcher, so no need to check if any processes are running.

                            UpdatePopupCtrl.ButtonLayout = CRPopup.ButtonLayouts.TYPE_DOUBLE;
                            UpdatePopupCtrl.DisplayDescription = "A new version of the launcher was found, would you like to automatically install it now?";
                            UpdatePopupCtrl.Show();
                        }
                        else
                        {
                            UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_UPDATED;
                            UpdateCtrl.TitleImage = Properties.Resources.Success_White;
                            UpdatePopupCtrl.Hide();
                            ProcessTmr.Start();
                        }
                    }
                    else
                    {
                        Logger.Write("No updates found!");
                        UpdateCtrl.Status = CRUpdatePanel.StatusTypes.TYPE_UPDATED;
                    }
                }
            }
            else
            {
                Logger.Write("Could not check for updates, launcher is running in offline mode!");
            }

            StorageToInterface();
            return true;
        }

        private async void InstallPopupCtrl_DoubleFirstButtonClick(object sender, EventArgs e)
        {
            Result pathReport = Installer.CreateInstallPath(true);

            if (pathReport.Succeeded)
            {
                Result moduleReport = await Installer.DownloadModule();

                if (moduleReport.Succeeded)
                {
                    await CheckForUpdates(true);
                    StartupRoutine(true);
                    InstallPopupCtrl.Hide();
                }
                else if (moduleReport.FailReason != null)
                {
                    Logger.Write(moduleReport.FailReason, LogLevel.LEVEL_ERROR);
                    MessageBox.Show(moduleReport.FailReason);
                }
            }
            else if (pathReport.FailReason != null)
            {
                Logger.Write(pathReport.FailReason, LogLevel.LEVEL_ERROR);
                MessageBox.Show(pathReport.FailReason);
            }
        }

        private async void InstallPopupCtrl_DoubleSecondButtonClick(object sender, EventArgs e)
        {
            Result pathReport = Installer.CreateInstallPath(false);

            if (pathReport.Succeeded)
            {
                Result moduleReport = await Installer.DownloadModule();

                if (moduleReport.Succeeded)
                {
                    Storage.Invalidate(true);
                    await CheckForUpdates(true);
                    StartupRoutine(true);
                    InstallPopupCtrl.Hide();
                }
                else if (moduleReport.FailReason != null)
                {
                    Logger.Write(moduleReport.FailReason, LogLevel.LEVEL_ERROR);
                    MessageBox.Show(moduleReport.FailReason);
                }
            }
            else if (pathReport.FailReason != null)
            {
                Logger.Write(pathReport.FailReason, LogLevel.LEVEL_ERROR);
                MessageBox.Show(pathReport.FailReason);
            }
        }

        private void InstallOfflinePopupCtrl_SingleButtonClick(object sender, EventArgs e)
        {
            TitleBar_OnExit(null, null);
        }

        private void UpdatePopupCtrl_DoubleFirstButtonClick(object sender, EventArgs e)
        {
            this.TopMost = false;
            ProcessTmr.Start();
            UpdatePopupCtrl.Hide();
        }

        private async void UpdatePopupCtrl_DoubleSecondButtonClick(object sender, EventArgs e)
        {
            Result report = await Updator.InstallUpdates();

            if (report.Succeeded)
            {
                UpdatePopupCtrl.Hide();
                ProcessTmr.Start();
                this.TopMost = false;
            }
            else if (report.FailReason != null)
            {
                Logger.Write(report.FailReason, LogLevel.LEVEL_ERROR);
            }
        }

        private void UpdatePopupCtrl_SingleButtonClick(object sender, EventArgs e)
        {
            UpdatePopupCtrl.Hide();
        }

        private void OfflinePopupCtrl_DoubleFirstButtonClick(object sender, EventArgs e)
        {
            Configuration.OfflineMode.SetValue(false);
            ContinueStartup();
            OfflinePopupCtrl.Hide();
        }

        private void OfflinePopupCtrl_DoubleSecondButtonClick(object sender, EventArgs e)
        {
            Configuration.OfflineMode.SetValue(true);
            ContinueStartup();
            OfflinePopupCtrl.Hide();
        }
    }
}