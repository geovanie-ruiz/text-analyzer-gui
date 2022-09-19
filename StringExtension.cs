using System;
using System.Text;

namespace TextAnalyzer
{
    public static class StringExtension
    {
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
