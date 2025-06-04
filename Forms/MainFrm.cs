using System;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO.Compression;
using System.Threading.Tasks;
using System.Collections.Generic;
using CodeRedLauncher.Controls;
using System.Drawing;

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
            SetupUserInterface();
            CheckForInstances();
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                TitleBar_OnMinimized(this, null);
            }
        }

        private void TitleBar_OnMinimized(object sender, EventArgs e)
        {
            if (Configuration.ShouldHideWhenMinimized())
            {
                this.Hide();
            }
            else if (this.WindowState != FormWindowState.Minimized)
            {
                this.Show();
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
            TabManager.SelectTab(Tabs.Dashboard);
        }

        private void NewsTabBtn_OnTabClick(object sender, EventArgs e)
        {
            TabManager.SelectTab(Tabs.News);
        }

        private void SettingsTabBtn_OnTabClick(object sender, EventArgs e)
        {
            TabManager.SelectTab(Tabs.Settings);
        }

        private void AboutTabBtn_OnTabClick(object sender, EventArgs e)
        {
            TabManager.SelectTab(Tabs.About);
        }

        private void ExitTabBtn_OnTabClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LaunchBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (!LibraryManager.AnyProcessRunning() && LocalStorage.CheckInitialized())
            {
                PlatformTypes platform = LocalStorage.GetCurrentPlatform(true);

                if (platform == PlatformTypes.Steam)
                {
                    Architecture.Path gameFile = (LocalStorage.GetSteamPath() / "RocketLeague.exe");

                    if (gameFile.Exists())
                    {
                        Logger.Write("(LaunchBtn) Trying to start process \"" + gameFile.GetPath() + "\"!");
                        Process.Start(new ProcessStartInfo(gameFile.GetPath()) { UseShellExecute = false });
                    }
                    else
                    {
                        Logger.Write("(LaunchBtn) Failed to locate the users Rocket League executable on Steam!", LogLevel.Error);
                    }
                }
            }
        }

        private void ManualInjectBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (Updater.IsOutdated() && Configuration.ShouldPreventInjection())
            {
                Logger.Write("(ManualInjectBtn) Prevented injection, updater returned out of date!");
                ProcessStatusCtrl.DisplayType = StatusTypes.Process_Outdated;
                InjectTmr.Stop();
                return;
            }

            if (!Configuration.ShouldInjectAll())
            {
                List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                if (processes.Count > 0)
                {
                    Logger.Write("(ManualInjectBtn) Process found!");
                    ProcessInjectionResult(LibraryManager.TryLoadIndividual(processes[0], LocalStorage.GetLibraryFile()));
                }
            }
            else
            {
                List<InjectionResults> results = LibraryManager.TryLoadDynamic(LocalStorage.GetLibraryFile());

                if (results.Count > 0)
                {
                    Logger.Write("P(ManualInjectBtn) Process found!");

                    foreach (InjectionResults result in results)
                    {
                        ProcessInjectionResult(result);
                    }
                }
            }
        }

        private void AutoCheckUpdatesBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.AutoCheckUpdates.SetValue(AutoCheckUpdatesBx.BoxChecked).Save();

            if (AutoCheckUpdatesBx.BoxChecked)
            {
                CheckForUpdates(true, true);
            }
        }

        private void AutoInstallBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.AutoInstallUpdates.SetValue(AutoInstallBx.BoxChecked).Save();
        }

        private void PreventInjectionBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.PreventInjection.SetValue(PreventInjectionBx.BoxChecked).Save();

            if (AutoCheckUpdatesBx.BoxChecked)
            {
                CheckForUpdates(true, true);
            }
        }

        private void RunOnStartupBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.RunOnStartup.SetValue(RunOnStartupBx.BoxChecked).Save();
            RegistryKey startKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (startKey != null)
            {
                if (RunOnStartupBx.BoxChecked)
                {
                    Logger.Write("(RunOnStartupBx) Setting run on start registry value to \"" + Application.ExecutablePath + "\"...");
                    startKey.SetValue(Assembly.GetProduct(), Application.ExecutablePath);
                }
                else
                {
                    Logger.Write("(RunOnStartupBx) Deleting run on start registry key...");
                    startKey.DeleteValue(Assembly.GetProduct(), false);
                }

                startKey.Close();
            }
        }

        private void MinimizeOnStartupBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.MinimizeOnStartup.SetValue(MinimizeOnStartupBx.BoxChecked).Save();
        }

        private void HideWhenMinimizedBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.HideWhenMinimized.SetValue(HideWhenMinimizedBx.BoxChecked).Save();
        }

        private void InjectAllInstancesBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.InjectAllInstances.SetValue(InjectAllInstancesBx.BoxChecked).Save();
        }

        private void ManualInjectBx_OnCheckChanged(object sender, EventArgs e)
        {
            if (ManualInjectBx.BoxChecked)
            {
                Configuration.InjectionType.SetValue(InjectionTypes.Manual.ToString()).Save();

                if (LibraryManager.AnyProcessRunning() && (ProcessStatusCtrl.DisplayType != StatusTypes.Process_Manual))
                {
                    if (InjectTmr.Enabled)
                    {
                        InjectTmr.Stop();
                    }

                    ProcessStatusCtrl.DisplayType = StatusTypes.Process_Loading;
                }
            }
            else
            {
                Configuration.InjectionType.SetValue(InjectionTypes.Timeout.ToString()).Save();
            }
        }

        private void LightModeBx_OnCheckChanged(object sender, EventArgs e)
        {
            Configuration.LightMode.SetValue(LightModeBx.BoxChecked).Save();
            UpdateTheme();
        }

        private void InjectionTimeoutBx_OnValueChanged(object sender, EventArgs e)
        {
            if (Configuration.InjectionTimeoutRange.IsInRange(InjectionTimeoutBx.Value))
            {
                Configuration.InjectionTimeout.SetValue(InjectionTimeoutBx.Value).Save();
                InjectTmr.Interval = InjectionTimeoutBx.Value;
            }
        }

        private void InstallPathBtn_OnButtonClick(object sender, EventArgs e)
        {
            if (!LibraryManager.AnyProcessRunning())
            {
                Architecture.Path modulePath = LocalStorage.GetModulePath();

                if (modulePath.Exists())
                {
                    Architecture.Path newPath = new Architecture.Path();
                    FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        newPath = new Architecture.Path(folderBrowser.SelectedPath);

                        if (newPath.Exists())
                        {
                            if (!newPath.GetPath().Contains("CodeRed"))
                            {
                                newPath.Append("CodeRed").CreateDirectory();
                            }
                        }

                        Logger.Write("(InstallPathBtn) User selected \"" + folderBrowser.SelectedPath + "\" for new install path.");
                    }

                    if (newPath.Exists())
                    {
                        if (modulePath != newPath)
                        {
                            PathPopup.ShowPopup();
                            Extensions.Filesystem.CopyDirectory(modulePath.GetPath(), newPath.GetPath(), true);
                            Directory.Delete(modulePath.GetPath(), true);

                            Installer.ModifyRegistry(false, newPath);
                            Configuration.Invalidate(true);
                            LocalStorage.Invalidate(true);
                            ConfigToInterface();
                            StorageToInterface();
                            PathPopup.HidePopup();
                        }
                        else
                        {
                            Logger.Write("(InstallPathBtn) Selected path is the same as the current one, cannot move install path!", LogLevel.Warning);
                        }
                    }
                    else
                    {
                        Logger.Write("(InstallPathBtn) Selected path is invalid, cannot move install path!", LogLevel.Error);
                    }
                }
            }
        }

        private void OpenFolderBtn_OnButtonClick(object sender, EventArgs e)
        {
            Architecture.Path folderPath = LocalStorage.GetModulePath();

            if (folderPath.Exists())
            {
                Process.Start(new ProcessStartInfo(folderPath.GetPath()) { UseShellExecute = true });
            }
        }

        private void ExportLogsBtn_OnButtonClick(object sender, EventArgs e)
        {
            Architecture.Path modulePath = LocalStorage.GetModulePath();
            Architecture.Path launchPath = (modulePath / "Settings" / "Launcher.cr");
            Architecture.Path variablesPath = (modulePath / "Settings" / "Variables.cr");
            Architecture.Path logsPath = (LocalStorage.GetGamesPath() / "TAGame" / "Logs");

            if (modulePath.Exists())
            {
                Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

                if (tempFolder.Exists())
                {
                    Logger.Write("(ExportLogsBtn) Old temporary folder found, deleting...");
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

                if (launchPath.Exists())
                {
                    filesToExport.Add(launchPath.GetPath());
                }

                if (variablesPath.Exists())
                {
                    filesToExport.Add(variablesPath.GetPath());
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
                            string zipName = ("crash_logs_" + DateTimeOffset.Now.ToUnixTimeSeconds().ToString());
                            Architecture.Path zipFolder = (tempFolder / zipName);
                            Directory.CreateDirectory(zipFolder.GetPath());

                            if (zipFolder.Exists())
                            {
                                Logger.Write("(ExportLogsBtn) Found \"" + filesToExport.Count + "\" files to export.");

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
                                File.Move(zipFile.GetPath(), (folderBrowser.SelectedPath + "\\" + zipName + ".zip"));
                                Directory.Delete(tempFolder.GetPath(), true);
                                MessageBox.Show("Successfully exported \"" + filesToExport.Count.ToString() + "\" files to: " + folderBrowser.SelectedPath.ToString(), Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There were no crash dumps or logs found to export!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CheckUpdatesBtn_OnButtonClick(object sender, EventArgs e)
        {
            CheckUpdatesBtn.ButtonEnabled = false;
            CheckForUpdates(true, true);
        }

        private void TermsBtn_OnButtonClick(object sender, EventArgs e)
        {
            TermsPopup.DisplayType = CRPolicy.PolicyView.View;
            TermsPopup.ShowPopup();
        }

        private void PolicyBtn_OnButtonClick(object sender, EventArgs e)
        {
            PolicyPopup.DisplayType = CRPolicy.PolicyView.View;
            PolicyPopup.ShowPopup();
        }

        private void EasterEggImg_Click(object sender, EventArgs e)
        {
            if (EasterEggImg.BackgroundImage == null)
            {
                EasterEggImg.BackgroundImage = (Configuration.ShouldUseLightMode() ? Properties.Resources.Cupcake_Purple : Properties.Resources.Cupcake_Red);
            }
            else
            {
                EasterEggImg.BackgroundImage = null;
                Process.Start(new ProcessStartInfo("https://www.youtube.com/watch?v=-vNLePwhc7w") { UseShellExecute = true });
            }
        }

        private void ProcessTmr_Tick(object sender, EventArgs e)
        {
            if (LibraryManager.AnyProcessRunning())
            {
                LaunchBtn.DisplayText = "Launch (Already running)";

                if ((ProcessStatusCtrl.DisplayType != StatusTypes.Process_Injecting) && (ProcessStatusCtrl.DisplayType != StatusTypes.Process_Manual))
                {
                    Logger.Write("(ProcessTmr) Process is running!");

                    if (!Updater.IsOutdated())
                    {
                        CheckForUpdates(true, false);
                        ProcessStatusCtrl.DisplayType = StatusTypes.Process_Running;
                    }
                    else
                    {
                        ProcessStatusCtrl.DisplayType = StatusTypes.Process_Outdated;
                    }

                    if (Updater.IsOutdated() && Configuration.ShouldPreventInjection())
                    {
                        Logger.Write("(ProcessTmr) Prevented injection, updater returned out of date!");
                        ProcessStatusCtrl.DisplayType = StatusTypes.Process_Outdated;
                        InjectTmr.Stop();
                    }
                    else
                    {
                        if (Configuration.InjectionType.GetStringValue() == InjectionTypes.Manual.ToString())
                        {
                            ManualInjectBtn.BringToFront();
                            ManualInjectBtn.Visible = true;
                            LaunchBtn.SendToBack();
                            LaunchBtn.Visible = false;
                            ProcessStatusCtrl.DisplayType = StatusTypes.Process_Manual;
                            InjectTmr.Stop();
                        }
                        else
                        {
                            ManualInjectBtn.SendToBack();
                            ManualInjectBtn.Visible = false;
                            
                            if (LocalStorage.GetCurrentPlatform(false) == PlatformTypes.Steam)
                            {
                                LaunchBtn.BringToFront();
                                LaunchBtn.Visible = true;
                            }
                            else
                            {
                                LaunchBtn.SendToBack();
                                LaunchBtn.Visible = false;
                            }

                            ProcessStatusCtrl.DisplayType = StatusTypes.Process_Injecting;
                            InjectTmr.Start();
                        }
                    }
                }
            }
            else
            {
                InjectTmr.Stop();
                ManualInjectBtn.SendToBack();
                ManualInjectBtn.Visible = false;

                if (LocalStorage.GetCurrentPlatform(false) == PlatformTypes.Steam)
                {
                    LaunchBtn.DisplayText = "Launch Rocket League";
                    LaunchBtn.BringToFront();
                    LaunchBtn.Visible = true;
                }
                else
                {
                    LaunchBtn.SendToBack();
                    LaunchBtn.Visible = false;
                }

                ProcessStatusCtrl.DisplayType = StatusTypes.Process_Idle;
            }
        }

        private void InjectTmr_Tick(object sender, EventArgs e)
        {
            if (!Configuration.OfflineMode.GetBoolValue())
            {
                if (Updater.IsOutdated() && Configuration.ShouldPreventInjection())
                {
                    Logger.Write("(InjectTmr) Prevented injection, updater returned out of date!");
                    ProcessStatusCtrl.DisplayType = StatusTypes.Process_Outdated;
                    InjectTmr.Stop();
                    return;
                }
            }

            if (Configuration.GetInjectionType() == InjectionTypes.Manual)
            {
                ProcessStatusCtrl.DisplayType = StatusTypes.Process_Manual;
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
                    Logger.Write("(InjectTmr) Process found!");
                    ProcessInjectionResult(LibraryManager.TryLoadIndividual(processes[0], LocalStorage.GetLibraryFile()));
                }

                InjectTmr.Stop();
            }
            else
            {
                List<InjectionResults> results = LibraryManager.TryLoadDynamic(LocalStorage.GetLibraryFile());

                if (results.Count > 0)
                {
                    Logger.Write("(InjectTmr) Process found!");

                    foreach (InjectionResults result in results)
                    {
                        ProcessInjectionResult(result);
                    }
                }

                InjectTmr.Stop();
            }
        }

        private void UpdateTmr_Tick(object sender, EventArgs e)
        {
            if (!Updater.IsOutdated())
            {
                Logger.Write("(UpdateTmr) Auto checking for updates...");
                CheckForUpdates(true, true);
            }
            else
            {
                UpdateTmr.Stop();
            }
        }

        void ProcessInjectionResult(InjectionResults result)
        {
            ProcessStatusCtrl.ResultType = result;

            switch (result)
            {
                case InjectionResults.UnhandledException:
                    Logger.Write("(ProcessInjectionResult) Failed to inject, unhandled exception occurred!", LogLevel.Error);
                    break;
                case InjectionResults.LibraryNotFound:
                    Logger.Write("(ProcessInjectionResult) Failed to inject, could not find library file!", LogLevel.Error);
                    break;
                case InjectionResults.ProcessNotFound:
                    Logger.Write("(ProcessInjectionResult) Failed to inject, process is no longer valid!", LogLevel.Warning);
                    InjectTmr.Stop();
                    break;
                case InjectionResults.AlreadyInjected:
                    // If we uncomment this it will write to the log file indefinitely as long as the game is running.
                    // Logger.Write("Successfully injected, changes applied in game.");
                    break;
                case InjectionResults.HandleNotFound:
                    Logger.Write("(ProcessInjectionResult) Failed to inject, window handle is invalid!", LogLevel.Error);
                    InjectTmr.Stop();
                    break;
                case InjectionResults.KernalNotFound:
                    Logger.Write("(ProcessInjectionResult) Failed to inject, load library not found!", LogLevel.Fatal);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.AllocateFail:
                    Logger.Write("(ProcessInjectionResult) Failed to inject, could not allocate space in memory!", LogLevel.Error);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.WriteFail:
                    Logger.Write("(ProcessInjectionResult) Failed to inject, could not write library into memory!", LogLevel.Error);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.ThreadFail:
                    Logger.Write("(ProcessInjectionResult) Failed to inject, could not create remote thread!", LogLevel.Error);
                    ProcessTmr.Stop();
                    InjectTmr.Stop();
                    break;
                case InjectionResults.Success:
                    Logger.Write("(ProcessInjectionResult) Successfully injected, changes applied in game.");
                    break;
                default:
                    break;
            }
        }

        private void CheckForInstances()
        {
            List<Process> launchers = new List<Process>();
            Process[] processList = Process.GetProcessesByName("CodeRedLauncher");

            foreach (Process process in processList)
            {
                if (process.ProcessName.Contains("CodeRedLauncher") || process.MainWindowTitle.Contains("CodeRed Launcher"))
                {
                    launchers.Add(process);
                }
            }

            if (launchers.Count > 1)
            {
                DuplicatePopup.Bind(this, TitleBar);
                DuplicatePopup.ShowPopup();
            }
            else
            {
                DuplicatePopup.HidePopup();
                StartupRoutine();
            }
        }

        private void SetupUserInterface()
        {
            this.Text = Assembly.GetTitle();
            TabPnl.BringToFront();

            TitleBar.BoundForm = this;
            TitleBar.DisplayText = Assembly.GetTitle().ToUpper();
            TitleBar.BringToFront();

            DuplicatePopup.Bind(this, TitleBar);
            PolicyPopup.Bind(this, TitleBar);
            TermsPopup.Bind(this, TitleBar);
            InstallPopup.Bind(this, TitleBar);
            PathPopup.Bind(this, TitleBar);
            OfflinePopup.Bind(this, TitleBar);
            UpdatePopup.Bind(this, TitleBar);

            TabManager.BindControl(TabCtrl);
            TabManager.BindTab(Tabs.Dashboard, DashboardTabBtn, DashboardTab);
            TabManager.BindTab(Tabs.News, NewsTabBtn, NewsTab);
            TabManager.BindTab(Tabs.Settings, SettingsTabBtn, SettingsTab);
            TabManager.BindTab(Tabs.About, AboutTabBtn, AboutTab);
            TabManager.BindTab(Tabs.Exit, ExitTabBtn, null);
            TabManager.SelectTab(Tabs.Dashboard);

            TermsBtn.Visible = Assembly.UsingTerms();
            PolicyBtn.Visible = Assembly.UsingPrivacy();
            UpdateTheme();
        }

        private async void StartupRoutine(bool bInvalidate = false)
        {
            if (!Assembly.UsingTerms() && !Assembly.UsingPrivacy())
            {
                Point updateLoc = CheckUpdatesBtn.Location;
                updateLoc.Y += 22;
                CheckUpdatesBtn.Location = updateLoc;
            }
            else if (Assembly.UsingTerms() && !Assembly.UsingPrivacy())
            {
                TermsBtn.Width = CheckUpdatesBtn.Width;
            }
            else if (Assembly.UsingPrivacy() && !Assembly.UsingTerms())
            {
                PolicyBtn.Width = CheckUpdatesBtn.Width;
                PolicyBtn.Location = TermsBtn.Location;
            }

            Architecture.Path tempFolder = (new Architecture.Path(Path.GetTempPath()) / "CodeRedLauncher");

            if (tempFolder.Exists())
            {
                Logger.Write("(StartupRoutine) Old launcher folder found, deleting...");
                Directory.Delete(tempFolder.GetPath(), true); // This is to cleanup anything left over by the auto updater program.
            }

            bool canContinue = true;
            Configuration.CheckInitialized();

            if (Assembly.UsingPrivacy())
            {
                PolicyPopup.DescriptionText = await RemoteStorage.GetPrivacyPolicy();
                string policyHash = Configuration.HashMD5(PolicyPopup.DescriptionText);

                if ((policyHash != Configuration.GetPrivacyHash()) || string.IsNullOrEmpty(PolicyPopup.DescriptionText))
                {
                    Configuration.PrivacyHash.SetValue(policyHash);
                    Configuration.PrivacyPolicy.SetValue(false);
                }

                if (!Configuration.AgreedToPolicy())
                {
                    if (string.IsNullOrEmpty(PolicyPopup.DescriptionText))
                    {
                        OfflinePopup.OfflineType = CROffline.OfflineLayouts.Installer;
                        OfflinePopup.ShowPopup();
                    }
                    else
                    {
                        PolicyPopup.DisplayType = CRPolicy.PolicyView.Register;
                        PolicyPopup.ShowPopup();
                    }

                    canContinue = false;
                }
            }

            if (Assembly.UsingTerms())
            {
                TermsPopup.DescriptionText = await RemoteStorage.GetTermsOfUse();
                string termsHash = Configuration.HashMD5(TermsPopup.DescriptionText);

                if ((termsHash != Configuration.GetTermsHash()) || string.IsNullOrEmpty(TermsPopup.DescriptionText))
                {
                    Configuration.TermsHash.SetValue(termsHash);
                    Configuration.TermsOfUse.SetValue(false);
                }

                if (!Configuration.AgreedToTerms())
                {
                    if (string.IsNullOrEmpty(TermsPopup.DescriptionText))
                    {
                        OfflinePopup.OfflineType = CROffline.OfflineLayouts.Installer;
                        OfflinePopup.ShowPopup();
                    }
                    else
                    {
                        TermsPopup.DisplayType = CRPolicy.PolicyView.Register;
                        TermsPopup.ShowPopup();
                    }

                    canContinue = false;
                }
            }

            if (canContinue)
            {
                ContinuePolicy(false);
            }
        }

        private async void ContinuePolicy(bool bInvalidate)
        {
            if (!LocalStorage.HasCoderedRegistry() || !LocalStorage.GetModulePath().Exists())
            {
                if (await RemoteStorage.CheckInitialized())
                {
                    InstallPopup.ShowPopup();
                }
                else
                {
                    OfflinePopup.OfflineType = CROffline.OfflineLayouts.Installer;
                    OfflinePopup.ShowPopup();
                }

                return;
            }

            if (bInvalidate)
            {
                LocalStorage.Invalidate(true);
                RemoteStorage.Invalidate();
            }

            Logger.CheckInitialized(); // Create and initialize the log file for the launcher.

            if (Configuration.CheckInitialized())
            {
                if (await RemoteStorage.CheckInitialized())
                {
                    if (await Downloaders.WebsiteOnline(RemoteStorage.GetRemoteURL()) == false)
                    {
                        OfflinePopup.OfflineType = CROffline.OfflineLayouts.Default;
                        OfflinePopup.ShowPopup();
                    }
                    else
                    {
                        ContinueStartup(false);
                    }
                }
                else
                {
                    OfflinePopup.OfflineType = CROffline.OfflineLayouts.Default;
                    OfflinePopup.ShowPopup();
                }
            }
            else
            {
                if (!LocalStorage.GetLibraryFile().Exists())
                {
                    await Installer.DownloadModule();
                    StartupRoutine(true);
                }
                else
                {
                    ContinueStartup(false);
                }
            }

            ConfigToInterface(); // Retrieves the users configuration settings and assigns it to the UI.
            StorageToInterface(); // Retrieves Rocket League paths, version, and platform info to then assign to the UI.
        }

        private async void ContinueStartup(bool bInvalidate)
        {
            if (!Configuration.OfflineMode.GetBoolValue())
            {
                if (bInvalidate)
                {
                    RemoteStorage.Invalidate();
                }

                if (Configuration.ShouldCheckForUpdates())
                {
                    await CheckForUpdates(false, true);
                }
                else
                {
                    UpdateStatusCtrl.DisplayType = StatusTypes.Version_Idle;
                    RetrieversToInterface();
                    NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                }
            }
            else
            {
                ChangelogCtrl.DisplayType = ChangelogViews.Offline;
            }

            if (Configuration.ShouldMinimizeOnStartup())
            {
                this.Hide();
            }

            ProcessTmr.Start();
        }

        private async void RetrieversToInterface()
        {
            if (!Configuration.OfflineMode.GetBoolValue())
            {
                ChangelogCtrl.ModuleText = await RemoteStorage.GetModuleChangelog();
                ChangelogCtrl.LauncherText = await RemoteStorage.GetLauncherChangelog();
                DiscordInfoCtrl.DisplayDescription = await RemoteStorage.GetDiscordUrl();
                DonateInfoCtrl.DisplayDescription = await RemoteStorage.GetKofiUrl();

                if (ChangelogCtrl.DisplayType == ChangelogViews.Offline)
                {
                    ChangelogCtrl.DisplayType = ChangelogViews.Module;
                }
            }
            else
            {
                ChangelogCtrl.DisplayType = ChangelogViews.Offline;
            }
        }

        private void ConfigToInterface()
        {
            if (Configuration.CheckInitialized())
            {
                AutoCheckUpdatesBx.BoxChecked = Configuration.ShouldCheckForUpdates();
                AutoInstallBx.BoxChecked = Configuration.ShouldAutoInstall();
                PreventInjectionBx.BoxChecked = Configuration.ShouldPreventInjection();
                RunOnStartupBx.BoxChecked = Configuration.ShouldRunOnStartup();
                MinimizeOnStartupBx.BoxChecked = Configuration.ShouldMinimizeOnStartup();
                HideWhenMinimizedBx.BoxChecked = Configuration.ShouldHideWhenMinimized();
                InjectAllInstancesBx.BoxChecked = Configuration.ShouldInjectAll();
                ManualInjectBx.BoxChecked = (Configuration.GetInjectionType() == InjectionTypes.Manual);
                LightModeBx.BoxChecked = Configuration.ShouldUseLightMode();
                InjectionTimeoutBx.MinimumValue = Configuration.InjectionTimeoutRange.Minimum;
                InjectionTimeoutBx.MaximumValue = Configuration.InjectionTimeoutRange.Maximum;
                InjectionTimeoutBx.Value = Configuration.GetInjectionTimeout();
                InjectTmr.Interval = InjectionTimeoutBx.Value;
                Configuration.SaveChanges();
                UpdateTheme();
            }
        }

        private async void StorageToInterface()
        {
            if (LocalStorage.CheckInitialized())
            {
                InstallPathBx.DisplayText = LocalStorage.GetModulePath().GetPath();
                LauncherInfoCtrl.DisplayDescription = Assembly.GetVersion();
                ModuleInfoCtrl.DisplayDescription = LocalStorage.GetModuleVersion();
                PsyonixInfoCtrl.DisplayDescription = LocalStorage.GetPsyonixVersion();
                BuildInfoCtrl.DisplayDescription = LocalStorage.GetNetBuild().ToString();
                PlatformInfoCtrl.DisplayDescription = LocalStorage.GetPlatformString(false);
                CreditsLbl.Text = "CodeRed is developed by @ItsBranK, but its creation would not have been possible without the inspiration of the following people: ";
                CreditsLbl.Text += await RemoteStorage.GetCredits();
            }
        }

        private void UpdateTheme()
        {
            bool lightMode = LightModeBx.BoxChecked;
            ControlTheme control = (lightMode ? ControlTheme.Light : ControlTheme.Dark);
            IconTheme icon = (lightMode ? IconTheme.Purple : IconTheme.Red);
            IconTheme iconAlt = IconTheme.White;

            // Main
            {
                this.BackColor = (lightMode ? GPalette.DarkGrey : GPalette.PureBlack);
                TabManager.SetTheme(control, icon);
                TitleBar.ControlType = control;
                TabPnl.BackColor = (lightMode ? GPalette.White : GPalette.LightBlack);
                DuplicatePopup.SetTheme(control, iconAlt);
                PolicyPopup.SetTheme(control, iconAlt);
                TermsPopup.SetTheme(control, iconAlt);
                InstallPopup.SetTheme(control, iconAlt);
                PathPopup.SetTheme(control, iconAlt);
                OfflinePopup.SetTheme(control, iconAlt);
                UpdatePopup.SetTheme(control, iconAlt);
            }

            // Dashboard
            {
                DashboardArtOne.BackgroundImage = (lightMode ? Properties.Resources.TL1_Light : Properties.Resources.TL1_Dark);
                DashboardArtTwo.BackgroundImage = (lightMode ? Properties.Resources.BR1_Light : Properties.Resources.BR1_Dark);
                ProcessStatusCtrl.SetTheme(control, icon);
                UpdateStatusCtrl.SetTheme(control, icon);
                ChangelogCtrl.SetTheme(control, icon);
                LaunchBtn.SetTheme(control, iconAlt);
                ManualInjectBtn.SetTheme(control, iconAlt);
            }

            // News
            {
                NewsArtOne.BackgroundImage = (lightMode ? Properties.Resources.TL2_Light : Properties.Resources.TL2_Dark);
                NewsArtTwo.BackgroundImage = (lightMode ? Properties.Resources.TR2_Light : Properties.Resources.TR2_Dark);
                NewsCtrl.SetTheme(control, icon);
            }

            // Settings
            {
                SettingsArtOne.BackgroundImage = (lightMode ? Properties.Resources.TR3_Light : Properties.Resources.TR3_Dark);
                SettingsArtTwo.BackgroundImage = (lightMode ? Properties.Resources.BR3_Light : Properties.Resources.BR3_Dark);
                AutoCheckUpdatesBx.SetTheme(control, icon);
                AutoInstallBx.SetTheme(control, icon);
                PreventInjectionBx.SetTheme(control, icon);
                RunOnStartupBx.SetTheme(control, icon);
                MinimizeOnStartupBx.SetTheme(control, icon);
                HideWhenMinimizedBx.SetTheme(control, icon);
                InjectAllInstancesBx.SetTheme(control, icon);
                ManualInjectBx.SetTheme(control, icon);
                LightModeBx.SetTheme(control, icon);
                InjectionTimeoutLbl.SetTheme(control, icon);
                InjectionTimeoutBx.ControlType = control;
                InstallPathLbl.SetTheme(control, icon);
                InstallPathBx.ControlType = control;
                InstallPathBtn.SetTheme(control, iconAlt);
                OpenFolderBtn.SetTheme(control, iconAlt);
                ExportLogsBtn.SetTheme(control, iconAlt);
            }

            // About
            {
                AboutArtOne.BackgroundImage = (lightMode ? Properties.Resources.TR4_Light : Properties.Resources.TR4_Dark);
                LauncherInfoCtrl.SetTheme(control, icon);
                ModuleInfoCtrl.SetTheme(control, icon);
                PsyonixInfoCtrl.SetTheme(control, icon);
                BuildInfoCtrl.SetTheme(control, icon);
                PlatformInfoCtrl.SetTheme(control, icon);
                WebsiteInfoCtrl.SetTheme(control, icon);
                DiscordInfoCtrl.SetTheme(control, icon);
                DonateInfoCtrl.SetTheme(control, icon);
                RemixInfoCtrl.SetTheme(control, icon);
                CheckUpdatesBtn.SetTheme(control, iconAlt);
                PolicyBtn.SetTheme(control, iconAlt);
                CreditsLbl.ForeColor = (lightMode ? GPalette.DarkGrey : GPalette.LightGrey);
            }
        }

        // If "bInvalidate" is set to true it forces the application to retrieve all local and remote information.
        private async Task<bool> CheckForUpdates(bool bInvalidate, bool bShowPrompt)
        {
            if (!Updater.IsUpdating())
            {
                if (!Configuration.OfflineMode.GetBoolValue() || bInvalidate)
                {
                    Logger.Write("(CheckForUpdates) Checking for updates...");
                    UpdateStatusCtrl.DisplayType = StatusTypes.Version_Checking;
                    UpdateStatusCtrl.ViewType = StatusViews.One;

                    if (await RemoteStorage.CheckInitialized())
                    {
                        bool moduleOutdated = await Updater.IsModuleOutdated(bInvalidate);
                        bool launcherOutdated = await Updater.IsLauncherOutdated(bInvalidate);

                        UInt32 localVersion = LocalStorage.GetPsyonixDate();
                        UInt32 remoteVersion = await RemoteStorage.GetPsyonixDate();
                        bool ignoreModule = (localVersion > remoteVersion);

                        // If the installed Rocket League version is greater than the one retrieved remotely, an update for the module is not out yet.

                        if (ignoreModule && !launcherOutdated)
                        {
                            Logger.Write("(CheckForUpdates) CodeRed is out of date, no new module version has been released yet!");
                            Updater.OverrideModule();
                            UpdateStatusCtrl.DisplayType = StatusTypes.Version_Unsafe;
                            UpdateStatusCtrl.ViewType = StatusViews.Three;

                            // Every sixty seconds this timer automatically checks for updates.

                            if (!UpdateTmr.Enabled)
                            {
                                UpdateTmr.Start();
                            }

                            NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                        }
                        else if (Updater.IsOutdated())
                        {
                            UpdateTmr.Stop();

                            // Prioritize updating the module first, then the launcher.

                            if (!ignoreModule && moduleOutdated && launcherOutdated)
                            {
                                UpdateStatusCtrl.DisplayType = StatusTypes.Version_Both;
                                UpdateStatusCtrl.ViewType = StatusViews.Three;

                                if (LibraryManager.AnyProcessRunning())
                                {
                                    List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                                    if (processes.Count > 0 && LibraryManager.IsModuleLoaded(processes[0], true))
                                    {
                                        UpdatePopup.UpdateType = CRUpdate.UpdateLayouts.Running;
                                    }
                                    else
                                    {
                                        UpdatePopup.UpdateType = CRUpdate.UpdateLayouts.Both;
                                    }
                                }
                                else
                                {
                                    UpdatePopup.UpdateType = CRUpdate.UpdateLayouts.Both;
                                }

                                if (bShowPrompt)
                                {
                                    if (Configuration.ShouldAutoInstall() && (UpdatePopup.UpdateType != CRUpdate.UpdateLayouts.Running))
                                    {
                                        UpdatePopup_ButtonClickAccept(null, null);
                                    }
                                    else
                                    {
                                        UpdatePopup.ShowPopup();
                                    }
                                }
                                else
                                {
                                    NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                                }
                            }
                            else if (!ignoreModule && moduleOutdated)
                            {
                                UpdateStatusCtrl.DisplayType = StatusTypes.Version_Module;
                                UpdateStatusCtrl.ViewType = StatusViews.Three;

                                if (LibraryManager.AnyProcessRunning())
                                {
                                    List<Process> processes = ProcessManager.GetFilteredProcesses(LibraryManager.Settings.ProcessName);

                                    if ((processes.Count > 0) && LibraryManager.IsModuleLoaded(processes[0], true))
                                    {
                                        Logger.Write("(CheckForUpdates) Process found!");
                                        UpdatePopup.UpdateType = CRUpdate.UpdateLayouts.Running;
                                    }
                                    else
                                    {
                                        UpdatePopup.UpdateType = CRUpdate.UpdateLayouts.Module;
                                    }
                                }
                                else
                                {
                                    UpdatePopup.UpdateType = CRUpdate.UpdateLayouts.Module;
                                }

                                if (bShowPrompt)
                                {
                                    if (Configuration.ShouldAutoInstall() && (UpdatePopup.UpdateType != CRUpdate.UpdateLayouts.Running))
                                    {
                                        UpdatePopup_ButtonClickAccept(null, null);
                                    }
                                    else
                                    {
                                        UpdatePopup.ShowPopup();
                                    }
                                }
                                else
                                {
                                    NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                                }
                            }
                            else if (launcherOutdated)
                            {
                                UpdateStatusCtrl.DisplayType = StatusTypes.Version_Launcher;
                                UpdateStatusCtrl.ViewType = StatusViews.Three;

                                // Doesn't matter if Rocket League is open or not when updating the launcher, so no need to check if any processes are running.

                                if (bShowPrompt)
                                {
                                    UpdatePopup.UpdateType = CRUpdate.UpdateLayouts.Launcher;

                                    if (Configuration.ShouldAutoInstall())
                                    {
                                        UpdatePopup_ButtonClickAccept(null, null);
                                    }
                                    else
                                    {
                                        UpdatePopup.ShowPopup();
                                    }
                                }
                                else
                                {
                                    NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                                }
                            }
                            else
                            {
                                UpdateStatusCtrl.DisplayType = StatusTypes.Version_Safe;
                                UpdateStatusCtrl.ViewType = StatusViews.Two;

                                if (Configuration.ShouldAutoInstall())
                                {
                                    UpdatePopup_ButtonClickAccept(null, null);
                                }
                                else
                                {
                                    UpdatePopup.ShowPopup();
                                }

                                ProcessTmr.Start();
                            }
                        }
                        else
                        {
                            Logger.Write("(CheckForUpdates) No updates found!");
                            UpdateStatusCtrl.ViewType = StatusViews.Two;
                            UpdateStatusCtrl.DisplayType = StatusTypes.Version_Safe;
                            NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                        }
                    }
                }
                else
                {
                    Logger.Write("(CheckForUpdates) Could not check for updates, launcher is running in offline mode!");
                }
            }

            RetrieversToInterface();
            ConfigToInterface();
            StorageToInterface();
            CheckUpdatesBtn.ButtonEnabled = true;
            return true;
        }

        private async void InstallCodeRed(bool bManuallyChoose)
        {
            Result pathReport = Installer.CreateInstallPath(bManuallyChoose);

            if (pathReport.Succeeded)
            {
                Result moduleReport = await Installer.DownloadModule();

                if (moduleReport.Succeeded)
                {
                    await CheckForUpdates(true, false);
                    StartupRoutine(true);
                    InstallPopup.HidePopup();
                }
                else if (moduleReport.HasFailReason())
                {
                    MessageBox.Show(moduleReport.FailReason, Assembly.GetTitle());
                }
            }
            else if (pathReport.HasFailReason())
            {
                MessageBox.Show(pathReport.FailReason, Assembly.GetTitle());
            }

            InstallPopup.ButtonsEnabled = true;
        }

        private void DuplicatePopup_ButtonClickAccept(object sender, EventArgs e)
        {
            DuplicatePopup.HidePopup();
            StartupRoutine();
        }

        private void DuplicatePopup_ButtonClickDeny(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void InstallPopup_ButtonClickAccept(object sender, EventArgs e)
        {
            InstallPopup.ButtonsEnabled = false;
            InstallPopup.DisplayType = CRInstall.InstallLayouts.Downloading;
            InstallCodeRed(false);
        }

        private void InstallPopup_ButtonClickDeny(object sender, EventArgs e)
        {
            InstallPopup.ButtonsEnabled = false;
            InstallPopup.DisplayType = CRInstall.InstallLayouts.Downloading;
            InstallCodeRed(true);
        }

        private void OfflinePopup_ButtonClickAccept(object sender, EventArgs e)
        {
            Configuration.OfflineMode.SetValue(false);
            ContinueStartup(true);
            OfflinePopup.HidePopup();
        }

        private void OfflinePopup_ButtonClickDeny(object sender, EventArgs e)
        {
            Configuration.OfflineMode.SetValue(true);
            ContinueStartup(false);
            OfflinePopup.HidePopup();
        }

        private void OfflinePopup_ButtonClickAlt(object sender, EventArgs e)
        {
            TitleBar_OnExit(null, null);
        }

        private async void UpdatePopup_ButtonClickAccept(object sender, EventArgs e)
        {
            this.TopMost = false;
            UpdatePopup.ButtonsEnabled = false;
            UpdateStatusCtrl.DisplayType = StatusTypes.Version_Downloading;

            RemoteStorage.Invalidate();
            await RemoteStorage.CheckInitialized();
            Result report = await Updater.InstallUpdates(UpdatePopup);
            UpdatePopup.ButtonsEnabled = true;

            if (report.Succeeded)
            {
                NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
                UpdatePopup.HidePopup();
                ProcessTmr.Start();
                CheckForUpdates(true, false);
            }
            else if (report.HasFailReason())
            {
                UpdatePopup.UpdateType = CRUpdate.UpdateLayouts.Fail;
                Logger.Write("(UpdatePopup) " + report.FailReason, LogLevel.Error);
            }
        }

        private async void UpdatePopup_ButtonClickDeny(object sender, EventArgs e)
        {
            NewsCtrl.ParseArticles(await RemoteStorage.GetNewsUrl());
        }

        private void PolicyPopup_ButtonClickAccept(object sender, EventArgs e)
        {
            PolicyPopup.HidePopup();
            Configuration.PrivacyPolicy.SetValue(true);

            if (!TermsPopup.Visible)
            {
                ContinuePolicy(false);
            }
        }

        private void PolicyPopup_ButtonClickDeny(object sender, EventArgs e)
        {
            Configuration.PrivacyPolicy.SetValue(false);
            TitleBar_OnExit(null, null);
        }

        private void TermsPopup_ButtonClickAccept(object sender, EventArgs e)
        {
            TermsPopup.HidePopup();
            Configuration.TermsOfUse.SetValue(true);

            if (!PolicyPopup.Visible)
            {
                ContinuePolicy(false);
            }
        }

        private void TermsPopup_ButtonClickDeny(object sender, EventArgs e)
        {
            Configuration.TermsOfUse.SetValue(false);
            TitleBar_OnExit(null, null);
        }
    }
}