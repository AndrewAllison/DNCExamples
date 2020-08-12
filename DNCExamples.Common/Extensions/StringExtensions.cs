using System;
using System.Collections.Generic;
using System.Text;

namespace DNCExamples.Common.Extensions
{
    /// <summary>
    /// String object extensions mostly convinience ones.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Will check to see if a string is null or empty and return a default value if it is.
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <param name="sDefault">The default value to return if the string is null or Empty</param>
        /// <returns></returns>
        public static string ValueOrDefault(this string s, string sDefault)
        {
            if (string.IsNullOrEmpty(s))
                return sDefault;
            return s;
        }

        /// <summary>
        /// Truncate a string to a given value.
        /// </summary>
        /// <param name="value">String value that will be worked on</param>
        /// <param name="threshold">The size that the string will be truncated to.</param>
        /// <returns>A string value sliced down to the number of characters determined in the threshold field.</returns>
        public static string Truncate(this string value, int threshold)
        {
            return !string.IsNullOrEmpty(value) && value.Length > threshold ? value.Substring(0, threshold) : value;
        }
    }
}
