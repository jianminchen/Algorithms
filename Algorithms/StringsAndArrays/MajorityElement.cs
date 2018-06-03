using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    /*
     * Given an array of size n, find the majority element. The majority element is the element that appears more than floor(n/2) times.

You may assume that the array is non-empty and the majority element always exist in the array.

Example :

Input : [2, 1, 2]
Return  : 2 which occurs 2 times which is greater than 3/2. 
     * */
    class MajorityElement
    {
        private static int GetMajorityElement(int[] input)
        {
            int majorIndex = 0;
            int count = 1;
            for (int i = 1; i < input.Length; i++)
            {
                count = input[majorIndex] == input[i] ? count + 1 : count - 1;
                if (count == 0)
                {
                    majorIndex = i;
                    count = 1;
                }
            }

            return input[majorIndex];
        }

        // the solution is based on Moore's voting algorithm
        //public static void Main(string[] args)
        //{
        //    int[] input = new int[] { 1, 3, 2, 4, 2, 2, 2 };
        //    var result = GetMajorityElement(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
