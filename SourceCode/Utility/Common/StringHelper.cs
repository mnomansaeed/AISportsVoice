using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using static Utility.GlobalConstants;

namespace Utility
{
    public static class StringHelper
    {//test comments
        public static string GetDisplay(bool? nullable, string trueDisplay, string falseDisplay, string unspecifiedDisplay)
        {
            return nullable.HasValue ? nullable.Value ? trueDisplay : falseDisplay : unspecifiedDisplay;
        }


        public static string Replace(string source, NameValueCollection nameValueCollection)
        {
            if ((source == null) || (nameValueCollection == null))
            {
                return source;
            }

            StringBuilder result = new StringBuilder(source);
            foreach (string key in nameValueCollection.Keys)
            {
                result = result.Replace(key, nameValueCollection[key]);
            }
            return result.ToString();
        }

        public static string GetTruncatedWithEllipsis(string source, int truncateThreshold)
        {
            if (String.IsNullOrEmpty(source))
            {
                return null;
            }
            const int ellipsisCharCode = 133;
            if (source.Length <= truncateThreshold)
            {
                return source;
            }
            string result = source.Substring(0, truncateThreshold);
            byte[] bytes = new byte[] { ellipsisCharCode };
            result += Encoding.Default.GetString(bytes);
            return result;
        }

        public static string[] GetGroupedList(List<string> source, string keyValueFormat)
        {
            if (source == null)
            {
                return new string[] { };
            }
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string stringKey in source)
            {
                if (dictionary.ContainsKey(stringKey))
                {
                    dictionary[stringKey]++;
                }
                else
                {
                    dictionary.Add(stringKey, 1);
                }
            }
            List<string> groupedList = new List<string>();
            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                string resultString = (pair.Value > 1) ? String.Format(keyValueFormat, pair.Key, pair.Value) : pair.Key;
                groupedList.Add(resultString);
            }
            return groupedList.ToArray();
        }


        public static string[] Compact(string[] source)
        {
            if (source == null || source.Length == 0)
            {
                return source;
            }
            List<string> list = new List<string>();
            foreach (string s in source)
            {
                string str = null;
                if (!string.IsNullOrEmpty(s))
                {
                    str = s.Trim();
                }
                if (string.IsNullOrEmpty(str))
                {
                    continue;
                }
                list.Add(str);
            }
            return list.ToArray();
        }

        public static string GetCompactedJoin(string[] source, string delimiter)
        {
            source = Compact(source);
            if (source == null || source.Length == 0)
            {
                return String.Empty;
            }
            return String.Join(delimiter, source);
        }



        public static string[] ProperCase(string[] source)
        {
            if (source == null || source.Length == 1)
            {
                return source;
            }
            List<string> stringList = new List<string>();
            foreach (string str in source)
            {
                stringList.Add(ProperCase(str));
            }
            return stringList.ToArray();
        }

        public static string ProperCase(string source)
        {
            if (String.IsNullOrEmpty(source))
            {
                return source;
            }
            StringBuilder sb = new StringBuilder();
            bool hasPrecedingWhiteSpace = true;
            foreach (char c in source)
            {
                char chr = c;
                if (Char.IsWhiteSpace(chr) || Char.IsPunctuation(chr))
                {
                    hasPrecedingWhiteSpace = true;
                }
                else
                {
                    if (Char.IsLetter(chr) && hasPrecedingWhiteSpace)
                    {
                        chr = Char.ToUpper(chr);
                    }
                    else
                    {
                        chr = Char.ToLower(chr);
                    }
                    hasPrecedingWhiteSpace = false;
                }
                sb.Append(chr);
            }
            return sb.ToString();
        }

        public static string FormatHexidecimal(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2);
            foreach (byte encodedByte in bytes)
            {
                sb.AppendFormat("{0:x2}", encodedByte);
            }
            return sb.ToString();
        }

        public static byte[] StringToByteArray(string source, Encoding encoding)
        {
            return encoding.GetBytes(source);
        }

        public static byte[] StringToByteArray(string source)
        {
            return StringToByteArray(source, new UTF8Encoding());
        }

        public static string ByteArrayToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        public static string ByteArrayToString(byte[] bytes)
        {
            return ByteArrayToString(bytes, new UTF8Encoding());
        }

        public static string TrimLength(string content, int length)
        {
            content = content.Replace("'", String.Empty);
            if (content.Length >= length) return content.Substring(0, length);
            else return content;
        }

        public static string Pluralize(int quantity, string source)
        {
            if (String.IsNullOrEmpty(source))
            {
                return source;
            }
            return quantity > 1 ? source + "s" : source;
        }

        public static string Pluralize(decimal quantity, string source)
        {
            if (String.IsNullOrEmpty(source))
            {
                return source;
            }
            return quantity > 1 ? source + "s" : source;
        }


        public static string PurgeCharacters(string input, IList<char> charsToRemove)
        {
            List<char> allowed = new List<char>();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (!charsToRemove.Contains(c))
                {
                    allowed.Add(c);
                }
            }
            return new string(allowed.ToArray());
        }

        public static string RemoveSpaces(string s)
        {
            StringBuilder b = new StringBuilder();

            try
            {
                foreach (char c in s)
                {
                    if (!char.IsWhiteSpace(c))
                    {
                        b.Append(c);
                    }
                }
            }

            catch { }

            return b.ToString();

        }

        public static string RemoveNonLettersAndNonDigits(string s)
        {
            StringBuilder b = new StringBuilder();

            try
            {
                foreach (char c in s)
                {
                    if (char.IsLetterOrDigit(c))
                    {
                        b.Append(c);
                    }
                }
            }

            catch { }

            return b.ToString();

        }

        /// <summary>
        /// Check the marital status, if 2 means married
        /// </summary>
        /// <param name="MaritalStatus"></param>
        /// <returns></returns>
        public static bool IsMarried(byte MaritalStatus)
        {
            return MaritalStatus == 2;//Married
        }

    }
}

