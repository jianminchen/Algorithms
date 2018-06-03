using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    class FirstPositiveMissingNumber
    {
        /*
         * Given an unsorted integer array, find the first missing positive integer.

Example:

Given [1,2,0] return 3,

[3,4,-1,1] return 2,

[-8, -7, -6] returns 1

Your algorithm should run in O(n) time and use constant space.
         * */
        private static int GetFirstMissingPositive(int[] input)
        {
            if (input == null || input.Length == 0)
            {
                return 1;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < 1 || input[i] > input.Length)
                {
                    input[i] = 0;
                }
            }

            int temp = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] <= 0)
                {
                    continue;
                }

                if (input[input[i] - 1] <= 0)
                {
                    input[input[i] - 1] = -1;
                    input[i] = 0;
                }
                else
                {
                    temp = input[input[i] - 1];
                    input[input[i] - 1] = -1;
                    while (temp > 0)
                    {
                        int secondTemp = input[temp - 1];
                        input[temp - 1] = -1;
                        temp = secondTemp;
                    }
                }
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 0)
                {
                    return i + 1;
                }
            }

            return input.Length + 1;
        }

        //public static void Main(string[] args)
        //{
        //    //Given[1, 2, 0] return 3,
        //    //[3,4,-1,1] return 2,
        //    //[-8, -7, -6] returns 1
        //    int[] input = new int[] { 1, 1, 1 };
        //    var result = GetFirstMissingPositive(input);
        //    Console.Write(result);
        //    Console.ReadKey();
        //}
    }
}
