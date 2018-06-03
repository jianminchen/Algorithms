using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    /*
     * Given a string s consists of upper/lower-case alphabets and empty space characters ' ', return the length of last word in the string.

If the last word does not exist, return 0.

Note: A word is defined as a character sequence consists of non-space characters only.

Example:

Given s = "Hello World",

return 5 as length("World") = 5.
     * */

    class LengthOfLastWord
    {
        private static int GetLengthOfLastWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            int currentIndex = 0;
            string nextWord = GetNextWord(input, ref currentIndex);
            int lengthOfLastWord = 0;

            while (nextWord != null)
            {
                lengthOfLastWord = nextWord.Length;
                nextWord = GetNextWord(input, ref currentIndex);
            }

            return lengthOfLastWord;
        }

        private static string GetNextWord(string input, ref int currentIndex)
        {
            StringBuilder sb = new StringBuilder();
            if (currentIndex >= input.Length)
            {
                return null;
            }
            else
            {
                for (int i = currentIndex; i < input.Length; i++)
                {

                    if (input[i] == ' ')
                    {
                        while (i < input.Length && input[i] == ' ')
                        {
                            i++;
                            currentIndex++;
                        }

                        return sb.ToString();
                    }
                    else
                    {
                        currentIndex++;
                        sb.Append(input[i]);
                    }
                }

                return sb.ToString();
            }
        }

        //public static void Main(string[] args)
        //{
        //    string input = "Hello World how are you ";
        //    var result = GetLengthOfLastWord(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
