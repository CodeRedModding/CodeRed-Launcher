using System;
using System.IO;
using System.Diagnostics;

namespace CodeRedLauncher
{
    public enum LogLevel : byte
    {
        LEVEL_NONE,
        LEVEL_WARN,
        LEVEL_ERROR,
        LEVEL_FATAL
    }

    public static class Logger
    {
        private static bool Initialized = false;
        private static Architecture.Path LogFile = new Architecture.Path();

        public static bool CheckInitialized()
        {
            if (!Initialized || !LogFile.Exists())
            {
                CreateLogFile();

                if (Initialized)
                {
                    Write("Log file created successfully.");
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private async static void CreateLogFile()
        {
            if (!Initialized || !LogFile.Exists())
            {
                Architecture.Path modPath = Storage.GetModulePath();
                
                if (modPath.Exists())
                {
                    LogFile.Set(modPath / "Launcher.log");

                    if (!LogFile.Exists())
                    {
                        await File.Create(LogFile.GetPath()).DisposeAsync();
                    }

                    File.WriteAllText(LogFile.GetPath(), string.Empty); // "Truncuating" the log file without needing to open it in a stream.
                    Initialized = true;
                }
            }
        }

        private static string CreateTimestamp(StackTrace stackTrace)
        {
            // return "[" + DateTime.Now.ToString() + "] [" + stackTrace.GetFrame(0).GetMethod().Name + "] "; // Doesn't work for some reason, changes every single time the program is run which frame is grabbed.
            return "[" + DateTime.Now.ToString() + "] ";
        }

        public static void Write(string str, LogLevel level = LogLevel.LEVEL_NONE)
        {
            if (CheckInitialized())
            {
                string newLine = CreateTimestamp(new StackTrace(4));

                switch (level)
                {
                    case LogLevel.LEVEL_WARN:
                        newLine += "WARNING: ";
                        break; 
                    case LogLevel.LEVEL_ERROR:
                        newLine += "ERROR: ";
                        break;
                    case LogLevel.LEVEL_FATAL:
                        newLine += "FATAL ERROR: ";
                        break;
                }

                newLine += (str + Environment.NewLine);
                File.AppendAllText(LogFile.GetPath(), newLine);
            }
        }
    }
}
