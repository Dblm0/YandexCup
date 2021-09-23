using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace palindromeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = Console.ReadLine();
            Console.WriteLine(FindMinimalPalindrome(source));
        }
        const int MIN_LENGTH = 2;
        const int MAX_LENGTH = 3;
        static string FindMinimalPalindrome(string source)
        {
            string res = null;
            for (int i = 0; i <= source.Length - MIN_LENGTH; i++)
            {
                if (source.IsEqualChars(i, i + MIN_LENGTH - 1))
                {
                    ChangeIfBetter(ref res, source.Substring(i, MIN_LENGTH));
                }
                else if (res?.Length != MIN_LENGTH &&
                    i <= source.Length - MAX_LENGTH &&
                    source.IsEqualChars(i, i + MAX_LENGTH - 1))
                {
                    ChangeIfBetter(ref res, source.Substring(i, MAX_LENGTH));
                }
            }
            return string.IsNullOrEmpty(res) ? "-1" : res;
        }
        static void ChangeIfBetter(ref string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(oldValue) ||
                oldValue.CompareTo(newValue) > 0 ||
                newValue.Length < oldValue.Length)
            {
                oldValue = newValue;
            }
        }   
    }
    static class StringExtensions
    {
        public static bool IsEqualChars(this string source, int idx1, int idx2)
        {
            return source[idx1] == source[idx2];
        }
    }
}
