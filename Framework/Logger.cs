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
        private static Extensions.Path LogFile = new Extensions.Path();

        public static bool CheckInitialized()
        {
            if (!Initialized)
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
            if (!Initialized)
            {
                Extensions.Path modPath = Storage.GetModulePath();
                
                if (modPath.Exists())
                {
                    LogFile.Set(modPath / "Injector.log");

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
            return "[" + DateTime.Now.ToString() + "] [" + stackTrace.GetFrame(1).GetMethod().Name + "] ";
        }

        public static void Write(string text, LogLevel level = LogLevel.LEVEL_NONE)
        {
            if (CheckInitialized())
            {
                string newLine = CreateTimestamp(new StackTrace());

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

                newLine += (text + "\n");
                File.AppendAllText(LogFile.GetPath(), newLine);
            }
        }
    }
}
