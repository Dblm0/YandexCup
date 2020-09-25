using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace palindromeFactor
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = Console.ReadLine();
            Console.WriteLine(FindMinimalPalindrome(source));
        }
        static string FindMinimalPalindrome(string source)
        {
            var lengths = Enumerable.Range(2, source.Length + 2);

            foreach (int palindromeLength in lengths)
            {
                var extracted = ExtractPalindromes(source, palindromeLength);

                var minimal = extracted.Min();
                if (!string.IsNullOrEmpty(minimal))
                    return minimal;
            }
            return "-1";
        }
        static IEnumerable<string> ExtractPalindromes(string source, int palindromeLength)
        {
            for (int i = 0; i <= source.Length - palindromeLength; i++)
            {
                var testStr = source.Slice(i, palindromeLength);
                if (IsPalindrome(testStr))
                    yield return new string(testStr.ToArray());
            }
        }
        static bool IsPalindrome(IEnumerable<char> testTarget)
        {
            return testTarget.SequenceEqual(testTarget.Reverse());
        }
    }
    static class IEnumerableSliceExtension
    {
        public static IEnumerable<T> Slice<T>(this IEnumerable<T> source, int start, int length)
        {
            return source.Skip(start).Take(length);
        }
    }
}
