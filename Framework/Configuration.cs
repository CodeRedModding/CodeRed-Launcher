using System;
using System.IO;

namespace CodeRedLauncher
{
    public enum InjectionTypes : byte
    {
        TYPE_UNKNOWN,
        TYPE_TIMEOUT,
        TYPE_MANUAL,
        TYPE_ALWAYS
    }

    // Stores and manages all user modifiable settings in the launcher, as well as saving them offline.
    public static class Configuration
    {
        private static bool Initialized = false;
        private static Architecture.Path StorageFile = new Architecture.Path();

        public static PublicSetting OfflineMode = new PublicSetting(
            "false",
            "OfflineMode",
            "Run the launcher in offline mode.",
            "Disables update and version checks when not connected to the internet."
        );

        public static PublicSetting AutoCheckUpdates = new PublicSetting(
            "True",
            "AutoCheckUpdates",
            "Automatically check for updates",
            "Choose to automatically check for updates and compare versions, as well as before each injection.",
            SaveChanges
        );

        public static PublicSetting PreventInjection = new PublicSetting(
            "True",
            "PreventInjection",
            "Prevent injection when out of date",
            "Prevents injecting out of date modules into unsupported Rocket League versions.",
            SaveChanges
        );

        public static PublicSetting RunOnStartup = new PublicSetting(
            "False",
            "RunOnStartup",
            "Run on windows startup",
            "Choose to automatically open the launcher on Windows startup.",
            SaveChanges
        );

        public static PublicSetting MinimizeOnStartup = new PublicSetting(
            "False",
            "MinimizeOnStartup",
            "Minimize on startup",
            "Choose to automatically minimize the launcher when opened.",
            SaveChanges
        );

        public static PublicSetting HideWhenMinimized = new PublicSetting(
            "False",
            "HideWhenMinimized",
            "Hide when minimized",
            "Choose to automatically hide to the system tray when the launcher is minimized.",
            SaveChanges
        );

        public static PublicSetting InjectAllInstances = new PublicSetting(
            "False",
            "InjectAllInstances",
            "Inject into all game instances",
            "Choose to inject the module into all running Rocket League instances, may take up more resources.",
            SaveChanges
        );

        public static PublicSetting InjectionType = new PublicSetting(
            "TYPE_TIMEOUT",
            "InjectionType",
            "Module injection type",
            "Injection method to use by the launcher when injecting modules.",
            SaveChanges
        );

        public static PublicSetting InjectionTimeout = new PublicSetting(
            "20000",
            "InjectionTimeout",
            "Module injection timeout",
            "Time delay in milliseconds used when injecting into Rocket League.",
            SaveChanges
        );

        public static Architecture.Range32 InjectionTimeoutRange = new Architecture.Range32(5000, 300000); // 5 seconds to 5 minutes.

        private static bool PhraseConfigFile()
        {
            if (StorageFile.Exists())
            {
                string[] fileLines = File.ReadAllLines(StorageFile.GetPath());

                if (fileLines.Length > 0)
                {
                    foreach (string line in fileLines)
                    {
                        if (line.Contains(AutoCheckUpdates.Name)) { AutoCheckUpdates.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                        if (line.Contains(PreventInjection.Name)) { PreventInjection.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                        if (line.Contains(RunOnStartup.Name)) { RunOnStartup.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                        if (line.Contains(MinimizeOnStartup.Name)) { MinimizeOnStartup.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                        if (line.Contains(HideWhenMinimized.Name)) { HideWhenMinimized.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                        if (line.Contains(InjectAllInstances.Name)) { InjectAllInstances.SetValue(line.Contains("True") ? "True" : "False"); continue; }
                        if (line.Contains(InjectionTypes.TYPE_TIMEOUT.ToString())) { InjectionType.SetValue(InjectionTypes.TYPE_TIMEOUT.ToString()); continue; }
                        if (line.Contains(InjectionTypes.TYPE_MANUAL.ToString())) { InjectionType.SetValue(InjectionTypes.TYPE_MANUAL.ToString()); continue; }
                        if (line.Contains(InjectionTypes.TYPE_ALWAYS.ToString())) { InjectionType.SetValue(InjectionTypes.TYPE_ALWAYS.ToString()); continue; }
                        if (line.Contains(InjectionTimeout.Name)) { InjectionTimeout.SetValue(line.Substring(17, line.Length - 17)); continue; }
                    }

                    return true;
                }
                else
                {
                    SetDefaultSettings(true);
                }
            }
            else
            {
                SetDefaultSettings(true);
            }

            return false;
        }

        public static bool CheckInitialized()
        {
            if (!Initialized)
            {
                StorageFile = Storage.GetModulePath() / "Settings" / "Injector.cr";

                if (StorageFile.Exists())
                {
                    if (PhraseConfigFile())
                    {
                        Initialized = true;
                    }
                }
                else
                {
                    SetDefaultSettings(true);
                }
            }

            return Initialized;
        }

        public static void SetDefaultSettings(bool bSaveChanges = false)
        {
            AutoCheckUpdates.ResetToDefault();
            PreventInjection.ResetToDefault();
            RunOnStartup.ResetToDefault();
            MinimizeOnStartup.ResetToDefault();
            HideWhenMinimized.ResetToDefault();
            InjectAllInstances.ResetToDefault();
            InjectionType.ResetToDefault();
            InjectionTimeout.ResetToDefault();

            if (bSaveChanges)
            {
                SaveChanges();
            }
        }

        public async static void SaveChanges()
        {
            if (StorageFile.Parent().Exists())
            {
                string file = StorageFile.GetPath();

                if (!StorageFile.Exists())
                {
                    await File.Create(StorageFile.GetPath()).DisposeAsync();
                }

                File.WriteAllText(file, string.Empty); // "Truncuating" the file without needing to open it in a stream.
                File.AppendAllText(file, AutoCheckUpdates.Name + " " + AutoCheckUpdates.GetStringValue() + "\n");
                File.AppendAllText(file, PreventInjection.Name + " " + PreventInjection.GetStringValue() + "\n");
                File.AppendAllText(file, RunOnStartup.Name + " " + RunOnStartup.GetStringValue() + "\n");
                File.AppendAllText(file, MinimizeOnStartup.Name + " " + MinimizeOnStartup.GetStringValue() + "\n");
                File.AppendAllText(file, HideWhenMinimized.Name + " " + HideWhenMinimized.GetStringValue() + "\n");
                File.AppendAllText(file, InjectAllInstances.Name + " " + InjectAllInstances.GetStringValue() + "\n");
                File.AppendAllText(file, InjectionType.Name + " " + InjectionType.GetStringValue() + "\n");
                File.AppendAllText(file, InjectionTimeout.Name + " " + InjectionTimeout.GetStringValue());
            }
        }

        public static bool ShouldCheckForUpdates()
        {
            if (CheckInitialized()) { return AutoCheckUpdates.GetBoolValue(); }
            return AutoCheckUpdates.GetBoolValue(true);
        }

        public static bool ShouldPreventInjection()
        {
            if (CheckInitialized()) { return PreventInjection.GetBoolValue(); }
            return PreventInjection.GetBoolValue(true);
        }

        public static bool ShouldRunOnStartup()
        {
            if (CheckInitialized()) { return RunOnStartup.GetBoolValue(); }
            return RunOnStartup.GetBoolValue(true);
        }

        public static bool ShouldMinimizeOnStartup()
        {
            if (CheckInitialized()) { return MinimizeOnStartup.GetBoolValue(); }
            return MinimizeOnStartup.GetBoolValue(true);
        }

        public static bool ShouldHideWhenMinimized()
        {
            if (CheckInitialized()) { return HideWhenMinimized.GetBoolValue(); }
            return HideWhenMinimized.GetBoolValue(true);
        }

        public static bool ShouldInjectAll()
        {
            if (CheckInitialized()) { return InjectAllInstances.GetBoolValue(); }
            return InjectAllInstances.GetBoolValue(true);
        }

        public static InjectionTypes GetInjectionType()
        {
            if (CheckInitialized()) { return InjectionType.GetEnumValue<InjectionTypes>(); }
            return InjectionType.GetEnumValue<InjectionTypes>(true);
        }

        public static Int32 GetInjectionTimeout()
        {
            if (CheckInitialized()) { return InjectionTimeout.GetInt32Value(); }
            return InjectionTimeout.GetInt32Value(true);
        }
    }
}