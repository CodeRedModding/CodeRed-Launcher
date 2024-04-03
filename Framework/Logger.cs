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
        private static bool m_initialized = false;
        private static Architecture.Path m_logFile = new Architecture.Path();

        public static bool CheckInitialized()
        {
            if (!m_initialized || !m_logFile.Exists())
            {
                CreateLogFile();

                if (m_initialized)
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
            if (!m_initialized || !m_logFile.Exists())
            {
                Architecture.Path modPath = Storage.GetModulePath();
                
                if (modPath.Exists())
                {
                    m_logFile.Set(modPath / "Launcher.log");

                    if (!m_logFile.Exists())
                    {
                        await File.Create(m_logFile.GetPath()).DisposeAsync();
                    }

                    using (StreamWriter stream = new StreamWriter(m_logFile.GetPath(), false))
                    {
                        stream.Write(""); // Clearing the old log file.
                    }

                    m_initialized = true;
                }
            }
        }

        private static string CreateTimestamp()
        {
            return "[" + DateTime.Now.ToString() + "] ";
        }

        public static void Write(string str, LogLevel level = LogLevel.LEVEL_NONE)
        {
            if (CheckInitialized())
            {
                string newLine = CreateTimestamp();

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

                using (StreamWriter stream = new StreamWriter(m_logFile.GetPath(), true))
                {
                    stream.Write(newLine);
                }
            }
        }
    }
}