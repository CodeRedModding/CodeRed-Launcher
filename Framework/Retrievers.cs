using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Http.Headers;
using System.Drawing;

namespace CodeRedLauncher
{
    public static class Downloaders
    {
        private static TimeSpan m_timeout = TimeSpan.FromMinutes(15);
        private static string m_userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:124.0) Gecko/20100101 Firefox/124.0";

        public static async Task<bool> WebsiteOnline(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                Ping newPing = new Ping();

                try
                {
                    PingReply pingReply = await newPing.SendPingAsync(new Uri(url).Host, 2500);

                    if (pingReply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                    else
                    {
                        Logger.Write("Ping request failed: " + pingReply.Status.ToString(), LogLevel.LEVEL_WARN);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write("Ping request error: " + ex.Message, LogLevel.LEVEL_ERROR);
                    return false;
                }

            }

            return false;
        }

        public static async Task<Image> DownloadImage(string url, bool bNoCache = true)
        {
            Image image = null;

            if (!string.IsNullOrEmpty(url))
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        client.Timeout = m_timeout;
                        client.DefaultRequestHeaders.UserAgent.ParseAdd(m_userAgent);

                        if (bNoCache)
                        {
                            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true };
                        }

                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            Stream stream = await response.Content.ReadAsStreamAsync();

                            try
                            {
                                image = Image.FromStream(stream);
                            }
                            catch (Exception)
                            {
                                image = null;
                            }
                        }
                        else
                        {
                            Logger.Write("Website is offline, failed to download image for url \"" + url + "\"!", LogLevel.LEVEL_WARN);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Write("Download image fail: " + ex.Message, LogLevel.LEVEL_WARN);
                        return null;
                    }
                }
            }

            return image;
        }

        public static async Task<string> DownloadPage(string url, bool bNoCache = true)
        {
            string pageContent = "";

            if (!string.IsNullOrEmpty(url))
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.Timeout = m_timeout;
                        client.DefaultRequestHeaders.UserAgent.ParseAdd(m_userAgent);

                        if (bNoCache)
                        {
                            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true };
                        }

                        HttpResponseMessage response = await client.GetAsync(url);

                        if (response.IsSuccessStatusCode)
                        {
                            pageContent = await response.Content.ReadAsStringAsync();
                        }
                        else
                        {
                            Logger.Write(("Website response failed for url \"" + url + "\", status code \"" + response.StatusCode.ToString() + "\"!"), LogLevel.LEVEL_WARN);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Write("Download page fail: " + ex.Message, LogLevel.LEVEL_WARN);
                }
            }

            return pageContent;
        }

        public static async Task<bool> DownloadFile(string url, Architecture.Path folder, string fileName, bool bNoCache = true)
        {
            if (folder.Exists() && !string.IsNullOrEmpty(url))
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.Timeout = m_timeout;
                        client.DefaultRequestHeaders.UserAgent.ParseAdd(m_userAgent);

                        if (bNoCache)
                        {
                            client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true, NoStore = true };
                        }

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
                catch (Exception ex)
                {
                    Logger.Write(ex.Message, LogLevel.LEVEL_ERROR);
                    return false;
                }
            }

            return false;
        }
    }

    // Dowwnloads and stores values from the remote config.
    public static class Retrievers
    {
        private static bool m_initialized = false;
        private static string m_remoteUrl = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/main/Public/Launcher.cr";
        private static string m_privacyUrl = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/main/Public/PrivacyPolicy.cr";
        private static string m_tosUrl = "https://raw.githubusercontent.com/CodeRedModding/CodeRed-Retrievers/main/Public/TermsOfService.cr";
        private static string m_privacyContent = "";
        private static string m_tosContent = "";

        private static List<InternalSetting> _remoteSettings = new List<InternalSetting>()
        {
            new InternalSetting("000000.000000.000000", "PsyonixVersion"),
            new InternalSetting("0.0.0", "LauncherVersion"),
            new InternalSetting("0.0.0", "ModuleVersion"),
            new InternalSetting(null, "UninstallerUrl"),
            new InternalSetting(null, "LauncherUrl"),
            new InternalSetting(null, "DropperUrl"),
            new InternalSetting(null, "ModuleUrl"),
            new InternalSetting("https://discord.com/", "DiscordUrl"),
            new InternalSetting("https://ko-fi.com/", "KofiUrl"),
            new InternalSetting(null, "NewsUrl"),
            new InternalSetting(null, "LauncherAlt"),
            new InternalSetting("No changelog provided for the most recent update.", "LauncherChangelog"),
            new InternalSetting("No changelog provided for the most recent update.", "ModuleChangelog"),
            new InternalSetting("Bakkes, Martinn, TaylorSasser, ButternCream, GlenHumphrey, ToolB0x, BeardedOranges, and Megasplat/Aberinkula/FrancesElMute.", "Credits"),
            new InternalSetting("false", "AltEndpoint"),
        };

        private static InternalSetting? GetStoredSetting(string name)
        {
            foreach (InternalSetting setting in _remoteSettings)
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
            if (!m_initialized && (await Downloaders.WebsiteOnline(GetRemoteURL())))
            {
                string pageBody = await Downloaders.DownloadPage(GetRemoteURL());

                if (!string.IsNullOrEmpty(pageBody))
                {
                    Dictionary<string, string> mappedBody = Extensions.Json.MapValuesToKeys(pageBody);

                    for (Int32 i = 0; i < _remoteSettings.Count; i++)
                    {
                        if (mappedBody.ContainsKey(_remoteSettings[i].Name))
                        {
                            _remoteSettings[i].SetValue(mappedBody[_remoteSettings[i].Name]);
                            Logger.Write("Retrieved remote value: " + _remoteSettings[i].GetStringValue());

                            if ((_remoteSettings[i].Name == "LauncherAlt") && (_remoteSettings[i].GetStringValue() != "null"))
                            {
                                m_remoteUrl = _remoteSettings[i].GetStringValue();
                            }
                        }
                    }

                    m_initialized = true;
                }
            }

            return m_initialized;
        }

        public static async void Invalidate()
        {
            m_initialized = false;
            await CheckInitialized();
        }

        public static async Task<bool> CheckInitialized()
        {
            if (!m_initialized)
            {
                if (await DownloadRemote() == false)
                {
                    Logger.Write("Failed to download remote information, cannot check for updates or verify installed version!", LogLevel.LEVEL_WARN);
                }
            }

            return m_initialized;
        }

        public static string GetRemoteURL()
        {
            return m_remoteUrl;
        }

        public static string GetPrivacyURL()
        {
            return m_privacyUrl;
        }

        public static string GetTermsURL()
        {
            return m_tosUrl;
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

        public static async Task<string> GetCredits()
        {
            if (await CheckInitialized()) { return GetStoredSetting("Credits").GetStringValue(); }
            return GetStoredSetting("Credits").GetStringValue(true);
        }

        public static async Task<string> GetPrivacyPolicy()
        {
            if (string.IsNullOrEmpty(m_privacyContent)) { m_privacyContent = await Downloaders.DownloadPage(GetPrivacyURL()); }
            return m_privacyContent;
        }

        public static async Task<string> GetTermsOfUse()
        {
            if (string.IsNullOrEmpty(m_tosContent)) { m_tosContent = await Downloaders.DownloadPage(GetTermsURL()); }
            return m_tosContent;
        }
    }
}