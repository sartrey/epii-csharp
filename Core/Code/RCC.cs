using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPII
{
    /// <summary>
    /// radix conversion code
    /// </summary>
    public class RCC
    {
        public const string Safe62
            = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        public const string Dec
            = "0123456789";
        public const string Hex
            = "0123456789abcdef";

        public static string HexToDec(string text)
        {
            return Any(text, Hex, Dec);
        }

        public static string HexToSafe62(string text)
        {
            return Any(text, Hex, Safe62);
        }

        public static string DecToHex(string text)
        {
            return Any(text, Dec, Hex);
        }

        public static string DecToSafe62(string text)
        {
            return Any(text, Dec, Safe62);
        }

        public static string Safe62ToDec(string text)
        {
            return Any(text, Safe62, Dec);
        }

        /// <summary>
        /// convert text from charset1 to charset2
        /// </summary>
        public static string Any(string text, string charset1, string charset2)
        {
            int base_from = charset1.Length;
            int base_to = charset2.Length;
            if (text.Any(c => !charset1.Contains(c)))
                throw new ArgumentException();
            var input = new List<int>();
            input.AddRange(text.Select(c => charset1.IndexOf(c)));
            var cache1 = new List<int>(); //remainder
            var cache2 = new List<int>(); //answer
            while (input.Count > 0) {
                if (input.Count == 1 && input[0] < base_to) {
                    cache1.Add(input[0]);
                    break;
                }
                int y = 0;
                foreach (var x in input) {
                    y = y * base_from + x;
                    cache2.Add(y / base_to);
                    y %= base_to;
                }
                cache1.Add(y);
                input.Clear();
                var flag = false;
                foreach (var t in cache2) {
                    if (flag || t > 0) {
                        input.Add(t);
                        flag = true;
                    }
                }
                cache2.Clear();
            }
            var sbd = new StringBuilder();
            for (var i = cache1.Count - 1; i >= 0; i--)
                sbd.Append(charset2[cache1[i]]);
            return sbd.ToString();
        }
    }
}