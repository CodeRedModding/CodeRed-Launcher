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
    public class MatchData
    {
        public UInt32 Score { get; set; }
        public UInt32 Goals { get; set; }
        public UInt32 Assists { get; set; }
        public UInt32 Saves { get; set; }
        public UInt32 Shots { get; set; }
        public UInt32 Clears { get; set; }
        public UInt32 Demolishes { get; set; }
        public UInt32 Exterminations { get; set; }
        public UInt32 DropshotDamage { get; set; }
        public UInt32 Knockouts { get; set; }
        public UInt32 KnockoutAssists { get; set; }
        public UInt32 KnockoutDeaths { get; set; }
        public UInt32 KnockoutDamage { get; set; }
        public UInt32 KnockoutHits { get; set; }
        public UInt32 KnockoutGrabs { get; set; }
        public UInt32 KnockoutBlocks { get; set; }
        public UInt64 StartTime { get; set; }
        public UInt64 EndTime { get; set; }
        public float StartSkill { get; set; }
        public float EndSkill { get; set; }
        public bool StartCached { get; set; }
        public bool EndCached { get; set; }
        public bool LeftEarly { get; set; }
        public bool Won { get; set; }
    }

    public class SessionInfo
    {
        public Int32 Playlist { get; set; }
        public UInt32 Wins { get; set; }
        public UInt32 Losses { get; set; }
        public UInt32 Streak { get; set; }
        public bool OnFire { get; set; }
        public UInt64 Matches { get; set; }
        public MatchData[] MatchData { get; set; }
    }

    public static class Sessions
    {
        public static List<SessionInfo> ParsedSessions = new List<SessionInfo>();
        public static Architecture.Range32 Timeframe = new Architecture.Range32(0, 30); // Current day, to thirty days back.

        public static void ParseSessions()
        {
            Architecture.Path sessionsFolder = Storage.GetModulePath() / "Sessions";

            if (sessionsFolder.Exists())
            {
                ParsedSessions.Clear();
                List<Architecture.Path> sessionsFiles = sessionsFolder.GetFiles(true);
                Logger.Write("Found \"" + sessionsFiles.Count.ToString() + "\" session files.");

                foreach (Architecture.Path sessionsFile in sessionsFiles)
                {
                    List<SessionInfo> sessionObjects = JsonSerializer.Deserialize<List<SessionInfo>>(File.ReadAllText(sessionsFile.GetPath()));

                    if (sessionObjects.Count > 0)
                    {
                        foreach (SessionInfo sessionObject in sessionObjects)
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