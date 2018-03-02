using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    class NobleInteger
    {
        /*
         * Given an integer array, find if an integer p exists in the array such that the number of integers greater than p in the array equals to p
If such an integer is found return 1 else return -1.
         * */
        private static int CheckNoble(int[] input)
        {
            Array.Sort(input);
            for (int i = 0; i < input.Length; i++)
            {
                if ((input.Length - 1) - i == input[i])
                {
                    if (i + 1 < input.Length && input[i] < input[i + 1])
                    {
                        return 1;
                    }
                    if (i + 1 == input.Length)
                    {
                        return 1;
                    }
                }
            }

            return -1;
        }

        //public static void Main(string[] args)
        //{
        //    int[] input = new int[] { -2, 0, -4, -6 };
        //    var result = CheckNoble(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
