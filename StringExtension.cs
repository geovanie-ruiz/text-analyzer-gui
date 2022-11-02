using System;
using System.Text;

namespace TextAnalyzer
{
    /// <summary>
    /// Helper class for string manipulation
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Removes punctuation from a string and converts to appropriate
        /// delimiter character or nothing
        /// </summary>
        /// <param name="s">string to be stripped</param>
        /// <returns>string stripped of special characters</returns>
        public static string StripPunctuation(this string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (char.IsPunctuation(c))
                {
                    // n-dash and m-dash should be delimiter
                    if (c == '-' || c == '—')
                    {
                        sb.Append("|");
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
