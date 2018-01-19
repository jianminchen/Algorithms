using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringManipulation
{
    class CompressString
    {
        //public static void Main(string[] args)
        //{
        //    string input = "abcdddddddddddddd";

        //    string output = Compress(input);
        //    Console.WriteLine(input);
        //    Console.WriteLine(output);
        //    Console.ReadKey();
        //}

        internal static string Compress(string input)
        {
            StringBuilder sb = new StringBuilder();
            int countConsecutive = 0;
            for (int i = 0; i < input.Length; i++)
            {
                countConsecutive++;
                if ((i + 1 >= input.Length) || (input[i] != input[i + 1]))
                {
                    sb.Append(input[i]);
                    sb.Append(countConsecutive);
                    countConsecutive = 0;
                }
            }

            string output = sb.ToString();
            if (output.Length > input.Length)
                return input;
            else
                return output;
        }
    }
}
