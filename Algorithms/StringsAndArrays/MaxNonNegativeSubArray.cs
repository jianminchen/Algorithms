using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    class MaxNonNegativeSubArray
    {
        /*
         * Find out the maximum sub-array of non negative numbers from an array.
The sub-array should be continuous. That is, a sub-array created by choosing the second and fourth element and skipping the third element is invalid.

Maximum sub-array is defined in terms of the sum of the elements in the sub-array. Sub-array A is greater than sub-array B if sum(A) > sum(B).

Example:

A : [1, 2, 5, -7, 2, 3]
The two sub-arrays are [1, 2, 5] [2, 3].
The answer is [1, 2, 5] as its sum is larger than [2, 3]
NOTE: If there is a tie, then compare with segment's length and return segment which has maximum length
NOTE 2: If there is still a tie, then return the segment with minimum starting index
         * */
        private static List<int> GetMaxSet(int[] input)
        {
            long maximumSum = 0;
            long currentSum = 0;
            List<int> result = new List<int>();
            List<int> currentSet = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < 0)
                {
                    if (currentSum >= maximumSum)
                    {
                        maximumSum = currentSum;
                        result = currentSet;
                    }

                    currentSum = 0;
                    currentSet = new List<int>();
                }
                else
                {
                    currentSum += input[i];
                    currentSet.Add(input[i]);
                }
            }

            if (currentSum > maximumSum)
            {
                result = currentSet;
            }
            
            return result;
        }

        //public static void Main(string[] args)
        //{
        //    int[] input = new int[] { 1967513926, 1540383426, -1303455736, -521595368 };
        //    var result = GetMaxSet(input);
        //    Console.ReadKey();
        //}
    }
}
