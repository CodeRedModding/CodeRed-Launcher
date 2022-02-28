using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Collections.Generic;

namespace CodeRedLauncher.Extensions
{
    public static class Strings
    {
        private static readonly char[] AlphabetChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private static readonly char[] DecimalChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static readonly char[] HexadecimalChars = { 'A', 'B', 'C', 'D', 'E', 'F' };

        public static bool IsCharAlphabet(char c)
        {
            return AlphabetChars.Contains(c.ToString().ToUpper()[0]);
        }

        public static bool IsCharDecimal(char c)
        {
            return DecimalChars.Contains(c.ToString().ToUpper()[0]);
        }

        public static bool IsCharHexadecimal(char c)
        {
            if (HexadecimalChars.Contains(c.ToString().ToUpper()[0]))
            {
                return true;
            }

            return IsCharDecimal(c);
        }

        private static bool SequenceMatches(string baseStr, string matchStr, Int32 startOffset)
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
