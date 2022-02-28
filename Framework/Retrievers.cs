using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;

// https://zetcode.com/csharp/json/

namespace CodeRedLauncher
{
    public static class Downloaders
    {
        public static async Task<bool> WebsiteOnline(string url)
        {
            if (!String.IsNullOrEmpty(url))
            {
                Ping newPing = new Ping();

                try
                {
                    PingReply pingReply = await newPing.SendPingAsync(new Uri(url).Host);

                    if (pingReply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write(ex.ToString(), LogLevel.LEVEL_WARN);
                }

            }

            return false;
        }

        public static async Task<string> DownloadPage(string url)
        {
            string? pageContent = null;

            if (!String.IsNullOrEmpty(url))
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        pageContent = await response.Content.ReadAsStringAsync();
                    }
                }
            }

            return pageContent;
        }

        public static async Task<bool> DownloadFile(string url, Architecture.Path toFolder, string fileName)
        {
            if (!String.IsNullOrEmpty(url))
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string path = (toFolder / fileName).GetPath();
                        byte[] content = await response.Content.ReadAsByteArrayAsync();

                        if (content.Length > 0)
                        {
                            File.WriteAllBytes(path, content);
                            return File.Exists(path);
                        }
                    }
                }
            }

            return false;
        }
    }

    public class MatchObject
    {
        public UInt64 Timestamp { get; set; }
        public float StartSkill { get; set; }
        public float EndSkill { get; set; }
        public Int32 Score { get; set; }
        public Int32 Goals { get; set; }
        public Int32 Assists { get; set; }
        public Int32 Saves { get; set; }
        public Int32 Shots { get; set; }
        public Int32 Damage { get; set; }
        public bool Partied { get; set; }
        public bool LeftEarly { get; set; }
        public bool Won { get; set; }
    }

    public class SessionObject
    {
        public Int32 Playlist { get; set; }
        public Int32 Wins { get; set; }
        public Int32 Losses { get; set; }
        public Int32 Streak { get; set; }
        public bool OnFire { get; set; }
        public Int32 Matches { get; set; }
        public MatchObject[] MatchData { get; set; }
    }

    public static class Retrievers
    {
        private static bool Initialized = false;
        private static readonly string RemoteUrl = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/main/Remote.json";

        private static List<InternalSetting> RemoteSettings = new List<InternalSetting>()
        {
            new InternalSetting("000000.000000.000000", "PsyonixVersion"),
            new InternalSetting("0.0.0", "LauncherVersion"),
            new InternalSetting("0.0f", "ModuleVersion"),
            new InternalSetting(null, "LauncherUrl"),
            new InternalSetting(null, "DropperUrl"),
            new InternalSetting(null, "ModuleUrl"),
            new InternalSetting(null, "DiscordUrl"),
            new InternalSetting(null, "NewsUrl"),
            new InternalSetting("No changelog provided for the most recent update.", "LauncherChangelog"),
            new InternalSetting("No changelog provided for the most recent update.", "ModuleChangelog")
        };

        private static InternalSetting? GetStoredSetting(string name)
        {
            foreach (InternalSetting setting in RemoteSettings)
            {
                if (setting.Name == name)
                {
                    return setting;
                }
            }

            return null;
        }

        private static async Task<bool> DownloadRemote()
        {
            if (!Initialized)
            {
                string pageBody = await Downloaders.DownloadPage(RemoteUrl);

                if (!String.IsNullOrEmpty(pageBody))
                {
                    Dictionary<string, string> mappedBody = Extensions.Json.MapContent(pageBody);

                    for (Int32 i = 0; i < RemoteSettings.Count; i++)
                    {
                        if (mappedBody.ContainsKey(RemoteSettings[i].Name))
                        {
                            RemoteSettings[i].SetValue(mappedBody[RemoteSettings[i].Name]);
                        }
                    }

                    Initialized = true;
                }
            }

            return Initialized;
        }

        public static async void Invalidate()
        {
            Initialized = false;
            await CheckInitialized();
        }

        public static async Task<bool> CheckInitialized()
        {
            if (!Initialized)
            {
                if (await DownloadRemote())
                {
                    return true;
                }
                else
                {
                    Logger.Write("Failed to do download remote information, cannot check for updates or verify installed version!", LogLevel.LEVEL_WARN);
                    MessageBox.Show("Warning: Failed to do download remote information, cannot check for updates or verify installed version!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return true;
        }

        public static async Task<string> GetPsyonixBuild()
        {
            if (await CheckInitialized()) { return GetStoredSetting("PsyonixVersion").GetStringValue(); }
            return GetStoredSetting("PsyonixVersion").GetStringValue(true);
        }

        public static async Task<float> GetInstallerVersion()
        {
            if (await CheckInitialized()) { return GetStoredSetting("InstallerVersion").GetFloatValue(); }
            return GetStoredSetting("InstallerVersion").GetFloatValue(true);
        }

        public static async Task<string> GetLauncherVersion()
        {
            if (await CheckInitialized()) { return GetStoredSetting("LauncherVersion").GetStringValue(); }
            return GetStoredSetting("LauncherVersion").GetStringValue(true);
        }

        public static async Task<float> GetModuleVersion()
        {
            if (await CheckInitialized()) { return GetStoredSetting("ModuleVersion").GetFloatValue(); }
            return GetStoredSetting("ModuleVersion").GetFloatValue(true);
        }

        public static async Task<string> GetLauncherUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("LauncherUrl").GetStringValue(); }
            return GetStoredSetting("LauncherUrl").GetStringValue(true);
        }

        public static async Task<string> GetDropperUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("DropperUrl").GetStringValue(); }
            return GetStoredSetting("DropperUrl").GetStringValue(true);
        }

        public static async Task<string> GetModuleUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("ModuleUrl").GetStringValue(); }
            return GetStoredSetting("ModuleUrl").GetStringValue(true);
        }

        public static async Task<string> GetDiscordUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("DiscordUrl").GetStringValue(); }
            return GetStoredSetting("DiscordUrl").GetStringValue(true);
        }

        public static async Task<string> GetNewsUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("NewsUrl").GetStringValue(); }
            return GetStoredSetting("NewsUrl").GetStringValue(true);
        }

        public static async Task<string> GetLauncherChangelog()
        {
            if (await CheckInitialized()) { return GetStoredSetting("LauncherChangelog").GetStringValue(); }
            return GetStoredSetting("LauncherChangelog").GetStringValue(true);
        }

        public static async Task<string> GetModuleChangelog()
        {
            if (await CheckInitialized()) { return GetStoredSetting("ModuleChangelog").GetStringValue(); }
            return GetStoredSetting("ModuleChangelog").GetStringValue(true);
        }
    }
}