using System;
using System.Collections.Generic;
using System.Text;

namespace DNCExamples.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ValueOrDefault(this string s, string sDefault)
        {
            if (string.IsNullOrEmpty(s))
                return sDefault;
            return s;
        }

        public static string Truncate(this string value, int threshold)
        {
            return !string.IsNullOrEmpty(value) && value.Length > threshold ? value.Substring(0, threshold) : value;
        }
    }
}
