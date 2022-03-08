using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace CodeRedLauncher.Extensions
{
    public static class Strings
    {
        private static readonly char[] AlphabetChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private static readonly char[] DecimalChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static readonly char[] HexadecimalChars = { 'a', 'b', 'c', 'd', 'e', 'f' };

        public static bool IsCharAlphabet(char c)
        {
            return AlphabetChars.Contains(Char.ToLower(c));
        }

        public static bool IsCharDecimal(char c)
        {
            return DecimalChars.Contains(Char.ToLower(c));
        }

        public static bool IsCharHexadecimal(char c)
        {
            if (HexadecimalChars.Contains(Char.ToLower(c)))
            {
                return true;
            }

            return IsCharDecimal(c);
        }

        public static bool IsStringAlphabet(string str)
        {
            foreach (char c in str)
            {
                if (!IsCharAlphabet(c))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsStringDecimal(string str)
        {
            foreach (char c in str)
            {
                if (!IsCharDecimal(c))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsStringHexadecimal(string str)
        {
            foreach (char c in str)
            {
                if (!IsCharHexadecimal(c))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool StringSequenceMatches(string baseStr, string matchStr, Int32 startOffset)
        {
            Int32 matches = 0;

            if ((baseStr.Length - startOffset) + matchStr.Length <= baseStr.Length)
            {
                for (Int32 i = 0; i < matchStr.Length; i++)
                {
                    if (baseStr[startOffset + i] == matchStr[i])
                    {
                        matches++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return (matches == matchStr.Length);
        }

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

        public static Dictionary<string, string> MapValuesToKeys(string str)
        {
            // Remove simple pretty print characters.
            str = str.Replace("\n", "");
            str = str.Replace("\t", " ");

            Dictionary<string, string> returnMap = new Dictionary<string, string>();
            List<string>splitPairs = SplitRange(str, '"', '"', false);

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

            return returnMap;
        }
    }

    public static class Json
    {
        // Iterating through key and values then mapping them out, as an alternative to deserializing into an object.
        public static Dictionary<string, string> MapContent(string jsonStr)
        {
            Dictionary<string, string> mappedJson = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(jsonStr))
            {
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
}
