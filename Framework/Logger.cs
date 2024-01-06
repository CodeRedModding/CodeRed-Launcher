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
        private static bool _initialized = false;
        private static Architecture.Path _logFile = new Architecture.Path();

        public static bool CheckInitialized()
        {
            if (!_initialized || !_logFile.Exists())
            {
                CreateLogFile();

                if (_initialized)
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
            if (!_initialized || !_logFile.Exists())
            {
                Architecture.Path modPath = Storage.GetModulePath();
                
                if (modPath.Exists())
                {
                    _logFile.Set(modPath / "Launcher.log");

                    if (!_logFile.Exists())
                    {
                        await File.Create(_logFile.GetPath()).DisposeAsync();
                    }

                    File.WriteAllText(_logFile.GetPath(), string.Empty); // "Truncuating" the log file without needing to open it in a stream.
                    _initialized = true;
                }
            }
        }

        private static string CreateTimestamp(StackTrace stackTrace)
        {
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
                File.AppendAllText(_logFile.GetPath(), newLine);
            }
        }
    }
}