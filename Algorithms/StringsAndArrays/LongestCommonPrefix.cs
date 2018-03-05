using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    /*
     * 
     * Write a function to find the longest common prefix string amongst an array of strings.
Longest common prefix for a pair of strings S1 and S2 is the longest string S which is the prefix of both S1 and S2.
As an example, longest common prefix of "abcdefgh" and "abcefgh" is "abc".
Given the array of strings, you need to find the longest S which is the prefix of ALL the strings in the array.
Example:
Given the array as:
[
  "abcdefgh",
  "aefghijk",
  "abcefgh"
]
     * */

    class LongestCommonPrefix
    {
        private static string GetLongestCommonPrefix(string[] input)
        {
            StringBuilder result = new StringBuilder();

            int minLength = Int32.MaxValue;
            foreach (var inputString in input)
            {
                if (inputString.Length < minLength)
                {
                    minLength = inputString.Length;
                }
            }

            for (int i = 0; i < minLength; i++)
            {
                char c = input[0][i];
                foreach (var inputString in input)
                {
                    if (inputString[i] != c)
                    {
                        return result.ToString();
                    }
                }

                result.Append(c);
            }

            return result.ToString();
        }

        //public static void Main(string[] args)
        //{
        //    string[] input = new string[] {"abce", "abcdef", "abchijk" };
        //    var result = GetLongestCommonPrefix(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
