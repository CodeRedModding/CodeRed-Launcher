using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CodeRedLauncher
{
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
        public Int32 Demolishes { get; set; }
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

    public static class Sessions
    {
        private static List<SessionObject> ParsedSessions = new List<SessionObject>();
        public static Architecture.Range32 Timeframe = new Architecture.Range32(0, 30); // Current day, to thirty days back.

        public static void ReloadSessions()
        {
            Architecture.Path sessionsFolder = Storage.GetModulePath() / "Sessions";

            if (sessionsFolder.Exists())
            {
                ParsedSessions.Clear();
                List<Architecture.Path> sessionsFiles = sessionsFolder.GetFiles(true);
                Logger.Write("Found \"" + sessionsFiles.Count + "\" session files.");

                foreach (Architecture.Path sessionsFile in sessionsFiles)
                {
                    List<SessionObject> sessionObjects = JsonSerializer.Deserialize<List<SessionObject>>(File.ReadAllText(sessionsFile.GetPath()));

                    if (sessionObjects.Count > 0)
                    {
                        foreach (SessionObject sessionObject in sessionObjects)
                        {
                            ParsedSessions.Add(sessionObject);
                        }
                    }
                }
            }
            else
            {
                Logger.Write("Failed to find users sessions folder, cannot parse files!");
            }
        }
    }
}