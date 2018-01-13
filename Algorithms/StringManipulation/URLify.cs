using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.StringManipulation
{
    // Given an input string replace all spaces with %20
    class URLify
    {
        //public static void Main(string[] args)
        //{
        //    string input = "  Hello World. How are you? ";

        //    char[] output = EscapeString(input);

        //    Console.WriteLine(input);
        //    Console.WriteLine(output);
        //    Console.ReadKey();
        //}

        private static char[] EscapeString(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input.ToArray();

            int countSpaces = 0;
            foreach(char c in input)
            {
                if (c == ' ')
                    countSpaces++;
            }

            char[] result = new char[input.Length + (2 * countSpaces)];
            int i = result.Length - 1;
            int j = input.Length - 1;
            while (i >= 0)
            {
                if(input[j] == ' ')
                {
                    result[i] = '0';
                    result[i - 1] = '2';
                    result[i - 2] = '%';
                    i = i - 3;
                }
                else
                {
                    result[i] = input[j];
                    i--;
                }

                j--;
            }

            return result;
        }
    }
}
