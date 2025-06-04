using System;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace CodeRedLauncher.Extensions
{
    public static class Strings
    {
        public static List<string> SplitRange(string str, char from, char to, bool bIncludeChar)
        {
            List<string> splitStrings = new List<string>();
            string currentWord = "";
            bool startWord = false;

            foreach (char c in str)
            {
                if (!startWord)
                {
                    if (c == from)
                    {
                        startWord = true;

                        if (bIncludeChar)
                        {
                            currentWord += c;
                        }
                    }
                }
                else if (startWord)
                {
                    if (c == to)
                    {
                        startWord = false;

                        if (bIncludeChar)
                        {
                            currentWord += c;
                        }

                        splitStrings.Add(currentWord);
                        currentWord = "";
                    }
                    else
                    {
                        currentWord += c;
                    }
                }
            }

            return splitStrings;
        }
    }

    public static class Json
    {
        public static Dictionary<string, string> MapValuesToKeys(string jsonStr)
        {
            Dictionary<string, string> returnMap = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(jsonStr))
            {
                // Remove simple pretty print characters.
                jsonStr = jsonStr.Replace("\r", "");
                jsonStr = jsonStr.Replace("\n", "");
                jsonStr = jsonStr.Replace("\b", "");
                jsonStr = jsonStr.Replace("\t", " ");

                List<string> splitPairs = Strings.SplitRange(jsonStr, '"', '"', false);

                bool swap = false;
                string currentKey = "";
                string currentValue = "";

                foreach (string pair in splitPairs)
                {
                    if (!swap)
                    {
                        currentKey = pair;
                        swap = true;
                    }
                    else
                    {
                        currentValue = pair;
                        returnMap[currentKey] = currentValue;
                        swap = false;
                    }
                }
            }

            return returnMap;
        }

        // Iterating through key and values then mapping them out, as an alternative to deserializing into an object.
        public static Dictionary<string, string> MapContent(string jsonStr)
        {
            Dictionary<string, string> mappedJson = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(jsonStr))
            {
                // Remove simple pretty print characters.
                jsonStr = jsonStr.Replace("\r", "");
                jsonStr = jsonStr.Replace("\n", "");
                jsonStr = jsonStr.Replace("\b", "");
                jsonStr = jsonStr.Replace("\t", " ");

                JsonDocument parsedBody = JsonDocument.Parse(jsonStr);
                JsonElement.ObjectEnumerator objectEnum = parsedBody.RootElement.EnumerateObject();

                while (objectEnum.MoveNext())
                {
                    JsonProperty currentProperty = objectEnum.Current;
                    mappedJson[currentProperty.Name] = currentProperty.Value.ToString();
                }
            }

            return mappedJson;
        }
    }

    public class Filesystem
    {
        // https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-copy-directories
        public static void CopyDirectory(string sourceDir, string destinationDir, bool bRecursive)
        {
            DirectoryInfo sourceInfo = new DirectoryInfo(sourceDir);
            DirectoryInfo[] dirs = sourceInfo.GetDirectories();
            Directory.CreateDirectory(destinationDir);

            foreach (FileInfo file in sourceInfo.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            if (bRecursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}
