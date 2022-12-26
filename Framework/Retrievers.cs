using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Http.Headers;
using System.Drawing;

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
                    PingReply pingReply = await newPing.SendPingAsync(new Uri(url).Host, 10000);

                    if (pingReply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                    else
                    {
                        Logger.Write("Ping request failed, reason " + pingReply.Status.ToString(), LogLevel.LEVEL_WARN);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write(ex.ToString(), LogLevel.LEVEL_WARN);
                }

            }

            return false;
        }

        public static async Task<Image> DownloadImage(string url)
        {
            Image image = null;

            if (!String.IsNullOrEmpty(url))
            {
                if (await WebsiteOnline(url))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true };
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            Stream stream = await response.Content.ReadAsStreamAsync();

                            try
                            {
                                image = Image.FromStream(stream);
                            }
                            catch (Exception ex)
                            {
                                image = null;
                            }
                        }
                    }
                }
                else
                {
                    Logger.Write("Website is offline, failed to download page for url \"" + url + "\"!", LogLevel.LEVEL_WARN);
                }
            }

            return image;
        }

        public static async Task<string> DownloadPage(string url)
        {
            string pageContent = "";

            if (!String.IsNullOrEmpty(url))
            {
                if (await WebsiteOnline(url))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true };
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            pageContent = await response.Content.ReadAsStringAsync();
                        }
                    }
                }
                else
                {
                    Logger.Write("Website is offline, failed to download page for url \"" + url + "\"!", LogLevel.LEVEL_WARN);
                }
            }

            return pageContent;
        }

        public static async Task<bool> DownloadFile(string url, Architecture.Path folder, string fileName)
        {
            if (folder.Exists())
            {
                if (!String.IsNullOrEmpty(url))
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            string path = (folder / fileName).GetPath();
                            byte[] content = await response.Content.ReadAsByteArrayAsync();

                            if (content.Length > 0)
                            {
                                File.WriteAllBytes(path, content);
                                return File.Exists(path);
                            }
                        }
                    }
                }
            }

            return false;
        }
    }

    public static class Retrievers
    {
        private static bool Initialized = false;
        private static readonly string RemoteUrl = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/main/Launcher.json";

        private static List<InternalSetting> RemoteSettings = new List<InternalSetting>()
        {
            new InternalSetting("000000.000000.000000", "PsyonixVersion"),
            new InternalSetting("0.0.0", "LauncherVersion"),
            new InternalSetting("0.0.0", "ModuleVersion"),
            new InternalSetting(null, "UninstallerUrl"),
            new InternalSetting(null, "LauncherUrl"),
            new InternalSetting(null, "DropperUrl"),
            new InternalSetting(null, "ModuleUrl"),
            new InternalSetting(null, "DiscordUrl"),
            new InternalSetting(null, "KofiUrl"),
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
                    Dictionary<string, string> mappedBody = Extensions.Json.MapValuesToKeys(pageBody);

                    for (Int32 i = 0; i < RemoteSettings.Count; i++)
                    {
                        if (mappedBody.ContainsKey(RemoteSettings[i].Name))
                        {
                            RemoteSettings[i].SetValue(mappedBody[RemoteSettings[i].Name]);
                            Logger.Write("Retrieved remote value: " + RemoteSettings[i].GetStringValue());
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
                if (await DownloadRemote() == false)
                {
                    Logger.Write("Failed to download remote information, cannot check for updates or verify installed version!", LogLevel.LEVEL_WARN);
                    MessageBox.Show("Warning: Failed to download remote information, cannot check for updates or verify installed version!", Assembly.GetTitle(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            return Initialized;
        }

        public static async Task<string> GetPsyonixVersion()
        {
            if (await CheckInitialized()) { return GetStoredSetting("PsyonixVersion").GetStringValue(); }
            return GetStoredSetting("PsyonixVersion").GetStringValue(true);
        }

        // The first twelve numbers in the Psyonix version string is a date timestamp, with the remaining six being the perforce changelist.
        // First two numbers are the year, second two are the month, and last two are the day.
        public static async Task<UInt32> GetPsyonixDate()
        {
            if (await CheckInitialized())
            {
                string psyonixVersion =  GetStoredSetting("PsyonixVersion").GetStringValue();
                string buildDate = psyonixVersion.Substring(0, psyonixVersion.IndexOf("."));

                if (Extensions.Strings.IsStringDecimal(buildDate))
                {
                    return UInt32.Parse(buildDate);
                }
            }

            return 0;
        }

        public static async Task<string> GetLauncherVersion()
        {
            if (await CheckInitialized()) { return GetStoredSetting("LauncherVersion").GetStringValue(); }
            return GetStoredSetting("LauncherVersion").GetStringValue(true);
        }

        public static async Task<string> GetModuleVersion()
        {
            if (await CheckInitialized()) { return GetStoredSetting("ModuleVersion").GetStringValue(); }
            return GetStoredSetting("ModuleVersion").GetStringValue(true);
        }

        public static async Task<string> GetUninstallerUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("UninstallerUrl").GetStringValue(); }
            return GetStoredSetting("UninstallerUrl").GetStringValue(true);
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

        public static async Task<string> GetKofiUrl()
        {
            if (await CheckInitialized()) { return GetStoredSetting("KofiUrl").GetStringValue(); }
            return GetStoredSetting("KofiUrl").GetStringValue(true);
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