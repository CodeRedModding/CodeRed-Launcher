using System;
using System.Collections.Generic;
using System.IO;

namespace CodeRedLauncher
{
    public enum LogLevel : byte
    {
        None,
        Warning,
        Error,
        Fatal
    }

    public static class Logger
    {
        private static bool m_initialized = false;
        private static Architecture.Path m_logFile = new Architecture.Path();
        private static List<string> m_logQueue = new List<string>();

        public static bool CheckInitialized()
        {
            if (!m_initialized)
            {
                CreateLogFile();

                if (m_initialized)
                {
                    Write("(CheckInitialized) Log file created successfully.");
                }
            }

            return m_initialized;
        }

        private async static void CreateLogFile()
        {
            if (!m_initialized)
            {
                Architecture.Path modPath = LocalStorage.GetModulePath();
                
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

                    foreach (string str in m_logQueue)
                    {
                        WriteInternal(str);
                    }

                    m_logQueue.Clear();
                }
            }
        }

        private static string CreateTimestamp()
        {
            return "[" + DateTime.Now.ToString() + "] ";
        }

        public static void Write(string str, LogLevel level = LogLevel.None)
        {
            string formattedStr = CreateTimestamp();

            switch (level)
            {
                case LogLevel.Warning:
                    formattedStr += "WARNING: ";
                    break;
                case LogLevel.Error:
                    formattedStr += "ERROR: ";
                    break;
                case LogLevel.Fatal:
                    formattedStr += "FATAL: ";
                    break;
                default:
                    break;
            }

            formattedStr += (str + Environment.NewLine);

            if (m_initialized)
            {
                WriteInternal(formattedStr);
            }
            else
            {
                m_logQueue.Add(formattedStr);
            }
        }

        private static void WriteInternal(string str)
        {
            if (!string.IsNullOrEmpty(str) && m_initialized && m_logFile.Exists())
            {
                using (StreamWriter stream = new StreamWriter(m_logFile.GetPath(), true))
                {
                    stream.Write(str);
                }
            }
        }
    }
}