using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace palindromeFactor
{
    class SpanFinder
    {
        static string FindMinimalPalindrome(ReadOnlySpan<char> source)
        {
            for (int palindromeLength = 2; palindromeLength <= source.Length; palindromeLength++)
            {
                var extracted = ExtractPalindromes(source, palindromeLength);
                if (extracted.Count > 0)
                    return extracted.OrderBy(x => x).First();
            }
            return "-1";
        }
        static List<string> ExtractPalindromes(ReadOnlySpan<char> source, int palindromeLength)
        {
            var result = new List<string>();
            for (int i = 0; i < source.Length - palindromeLength; i++)
            {
                var testStr = source.Slice(i, palindromeLength);
                if (IsPalindrome(testStr))
                    result.Add(testStr.ToString());
            }
            return result;
        }
        static bool IsPalindrome(ReadOnlySpan<char> testTarget)
        {
            Span<char> copy = new char[testTarget.Length];
            testTarget.CopyTo(copy);
            copy.Reverse();
            return testTarget.SequenceEqual(copy);
        }
    }
}
