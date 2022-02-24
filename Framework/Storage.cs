using System;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeRedLauncher
{
    public enum PlatformTypes : byte
    {
        TYPE_UNKNOWN,
        TYPE_STEAM,
        TYPE_EPIC
    }

    public static class Storage
    {
        private static bool Initialized = false;
        private static bool VersionsValid = false;

        private static PrivateSetting EmptySetting = new PrivateSetting();
        private static PrivateSetting GamesFolder = new PrivateSetting();
        private static PrivateSetting LogFile = new PrivateSetting();
        private static PrivateSetting ModuleFolder = new PrivateSetting();
        private static PrivateSetting LibraryFile = new PrivateSetting();
        private static PrivateSetting SteamFolder = new PrivateSetting();
        private static PrivateSetting EpicFolder = new PrivateSetting();
        private static PrivateSetting CurrentPlatform = new PrivateSetting(PlatformTypes.TYPE_UNKNOWN.ToString());
        private static PrivateSetting PsyonixBuild = new PrivateSetting("000000.000000.000000");
        private static PrivateSetting NetBuild = new PrivateSetting("0");
        private static PrivateSetting ModuleVersion = new PrivateSetting("0.0f");

        public static void Invalidate()
        {
            VersionsValid = false;
            CheckInitialized();
        }

        public static bool CheckInitialized()
        {
            if (!Initialized)
            {
                if (FindDirectories())
                {
                    return true;
                }
                else
                {
                    bool shownMessage = false;

                    if (!shownMessage)
                    {
                        shownMessage = true;
                        MessageBox.Show("Error: Failed to initialize directories!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return false;
                }
            }

            if (!VersionsValid)
            {
                ParseLogFile();
                ParseVersionFile();
            }

            return true;
        }

        private static void ParseLogFile()
        {
            Path gamesPath = GamesFolder.GetPathValue();

            if (gamesPath.Exists())
            {
                Path logFile = gamesPath / "TAGame" / "Logs" / "Launch.log";

                if (logFile.Exists())
                {
                    LogFile.SetValue(logFile);
                    
                    // Opening with "FileShare.ReadWrite" is important here because RocketLeague.exe locks the log file when the game is running, without it you wouldn't be able to read its contents.
                    FileStream logStream = File.Open(logFile.GetPath(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    string logContents;

                    using (StreamReader sr = new StreamReader(logStream))
                    {
                        logContents = sr.ReadToEnd();
                    }

                    Match psyMatch = Regex.Match(logContents, "Log: GPsyonixBuildID (.*)\r", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                    Match directoryMatch = Regex.Match(logContents, "Init: Base directory: (.*)\r", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);
                    Match netMatch = Regex.Match(logContents, "Log: BuildID: (.*) from GPsyonixBuildID", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

                    if (psyMatch.Groups[1].Success)
                    {
                        PsyonixBuild.SetValue(psyMatch.Groups[1].Value);
                        VersionsValid = true;
                    }
                    else
                    {
                        VersionsValid = false;
                    }

                    if (netMatch.Groups[1].Success)
                    {
                        NetBuild.SetValue(netMatch.Groups[1].Value);
                    }

                    if (directoryMatch.Groups[1].Success)
                    {
                        string baseDirectory = directoryMatch.Groups[1].Value;

                        if (baseDirectory.Contains("steamapps"))
                        {
                            CurrentPlatform.SetValue(PlatformTypes.TYPE_STEAM.ToString());
                        }
                        else if (baseDirectory.Contains("Epic Games"))
                        {
                            CurrentPlatform.SetValue(PlatformTypes.TYPE_EPIC.ToString());
                        }
                        else
                        {
                            CurrentPlatform.SetValue(PlatformTypes.TYPE_UNKNOWN.ToString());
                        }
                    }
                }
                else
                {
                    VersionsValid = false;
                }
            }
            else
            {
                VersionsValid = false;
            }
        }

        private static void ParseVersionFile()
        {
            VersionsValid = false;
            Path moduleFolder = ModuleFolder.GetPathValue();

            if (moduleFolder.Exists())
            {
                Path versionFile = moduleFolder / "DLL" / "Version.txt";

                if (versionFile.Exists())
                {
                    FileStream versionStream = File.Open(versionFile.GetPath(), FileMode.Open, FileAccess.Read);
                    string versionContents;

                    using (StreamReader sr = new StreamReader(versionStream))
                    {
                        versionContents = sr.ReadToEnd();
                    }

                    if (!String.IsNullOrEmpty(versionContents))
                    {
                        ModuleVersion.SetValue(versionContents);

                        if (ModuleVersion.GetFloatValue() != ModuleVersion.GetFloatValue(true))
                        {
                            VersionsValid = true;
                        }
                    }
                }
            }
        }

        private static bool ParseRegistryKeys()
        {
            bool foundAtLeastOnePath = false;
            bool foundModPath = false;

            RegistryKey modKey = Registry.CurrentUser.OpenSubKey("CodeRedModding");

            if (modKey != null)
            {
                Object modObj = modKey.GetValue("InstallPath");

                if (modObj != null)
                {
                    Path moduleFolder = new Path(modObj.ToString());

                    if (moduleFolder.Exists())
                    {
                        ModuleFolder.SetValue(moduleFolder);
                        LibraryFile.SetValue(moduleFolder / "DLL" / "CodeRed.dll");
                    }
                    else
                    {
                        MessageBox.Show("Error: Failed validate the CodeRed install path!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }

                    foundModPath = true;
                }
            }

            if (!foundModPath)
            {
                MessageBox.Show("Error: Failed to locate the CodeRed install path!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            RegistryKey epicKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\EpicGames\\Unreal Engine");

            if (epicKey != null)
            {
                Object epicObj = epicKey.GetValue("INSTALLDIR");

                if (epicObj != null)
                {
                    Path epicFolder = (new Path(epicObj.ToString()) / "rocketleague" / "Binaries" / "Win64");

                    if (epicFolder.Exists())
                    {
                        EpicFolder.SetValue(epicFolder);
                        foundAtLeastOnePath = true;
                    }
                    else
                    {
                        EpicFolder.SetValue("");
                    }
                }
            }

            RegistryKey steamKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Valve\\Steam");

            if (steamKey != null)
            {
                Object steamObj = steamKey.GetValue("InstallPath");

                if (steamObj != null)
                {
                    // We are phrasing the "libraryfolders.vdf" file here because it's possibe to have Steam installed on one drive, but have the "steamapps" folder on a different drive/location.
                    // This is not stored in the registry and this file is the only place that I could find where it has path/drive info like this.
                    // If anyone has a better solution or suggestion please do create an issue in the repo, or submit your own pull request.

                    Path libraryFile = new Path(steamObj.ToString()).Append("steamapps").Append("libraryfolders.vdf");

                    if (libraryFile.Exists())
                    {
                        string libraryContents = File.ReadAllText(libraryFile.GetPath());
                        MatchCollection pathMatches = Regex.Matches(libraryContents, "\"path\"\t\t\"(.*)\"", RegexOptions.IgnoreCase | RegexOptions.RightToLeft);

                        foreach (Match match in pathMatches)
                        {
                            if (match.Success && match.Groups[1].Success)
                            {
                                Path steamFolder = (new Path(match.Groups[1].Value) / "steamapps" / "common" / "rocketleague" / "Binaries" / "Win64");

                                if (steamFolder.Exists())
                                {
                                    SteamFolder.SetValue(steamFolder);
                                    foundAtLeastOnePath = true;
                                    break;
                                }
                                else
                                {
                                    SteamFolder.SetValue("");
                                    continue;
                                }
                            }
                        }
                    }
                }
            }

            return foundAtLeastOnePath;
        }

        private static bool FindDirectories()
        {
            if (!Initialized)
            {
                Path gamesFolder = (new Path(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) / "My Games" / "Rocket League");

                if (gamesFolder.Exists())
                {
                    GamesFolder.SetValue(gamesFolder);
                    ParseLogFile();
                    ParseVersionFile();

                    if (ParseRegistryKeys())
                    {
                        Initialized = true;
                    }
                    else
                    {
                        bool shownMessage = false;

                        if (!shownMessage)
                        {
                            shownMessage = true;
                            MessageBox.Show("Error: Failed to locate the needed registry keys!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    bool shownMessage = false;

                    if (!shownMessage)
                    {
                        shownMessage = true;
                        MessageBox.Show("Error: Failed to find the Rocket League games folder!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return Initialized;
        }

        public static Path GetGamesPath()
        {
            if (CheckInitialized()) { return GamesFolder.GetPathValue(); }
            return EmptySetting.GetPathValue();
        }

        public static Path GetLogFile()
        {
            if (CheckInitialized()) { return LogFile.GetPathValue(); }
            return EmptySetting.GetPathValue();
        }

        public static Path GetModulePath()
        {
            if (CheckInitialized()) { return ModuleFolder.GetPathValue(); }
            return EmptySetting.GetPathValue();
        }

        public static Path GetLibraryFile()
        {
            if (CheckInitialized()) { return LibraryFile.GetPathValue(); }
            return EmptySetting.GetPathValue();
        }

        public static Path GetSteamPath()
        {
            if (CheckInitialized()) { return SteamFolder.GetPathValue(); }
            return EmptySetting.GetPathValue();
        }

        public static Path GetEpicPath()
        {
            if (CheckInitialized()) { return EpicFolder.GetPathValue(); }
            return EmptySetting.GetPathValue();
        }

        public static PlatformTypes GetCurrentPlatform(bool bInvalidate)
        {
            if (bInvalidate)
            {
                Invalidate();
            }

            if (CheckInitialized()) { return CurrentPlatform.GetEnumValue<PlatformTypes>(); }
            return CurrentPlatform.GetEnumValue<PlatformTypes>(true);
        }

        public static string GetPlatformString(bool bInvalidate)
        {
            PlatformTypes platformType = GetCurrentPlatform(bInvalidate);

            switch (platformType)
            {
                case PlatformTypes.TYPE_STEAM:
                    return "Steam";
                case PlatformTypes.TYPE_EPIC:
                    return "Epic Games";
                default:
                    return "Unknown";
            }
        }

        public static string GetPsyonixBuild()
        {
            if (CheckInitialized()) { return PsyonixBuild.GetStringValue(); }
            return PsyonixBuild.GetStringValue(true);
        }

        public static Int32 GetNetBuild()
        {
            if (CheckInitialized()) { return NetBuild.GetInt32Value(); }
            return NetBuild.GetInt32Value(true);
        }

        public static float GetModuleVersion()
        {
            if (CheckInitialized()) { return ModuleVersion.GetFloatValue(); }
            return ModuleVersion.GetFloatValue(true);
        }
    }
}
