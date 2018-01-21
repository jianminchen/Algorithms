using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * Getting a Different Number
Given an array arr of unique nonnegative integers, implement a function getDifferentNumber that finds the smallest nonnegative integer that is NOT in the array.
Even if your programming language of choice doesn’t have that restriction (like Python), assume that the maximum value an integer can have is MAX_INT = 2^31-1. So, for instance, the operation MAX_INT + 1 would be undefined in our case.
Your algorithm should be efficient, both from a time and a space complexity perspectives.
Solve first for the case when you’re NOT allowed to modify the input arr. If successful and still have time, see if you can come up with an algorithm with an improved space complexity when modifying arr is allowed. Do so without trading off the time complexity.
Analyze the time and space complexities of your algorithm.
Example:
input:  arr = [0, 1, 2, 3]

output: 4 
     * */
    class GetDifferentNumber
    {
        public static int GetNumber(int[] arr)
        {
            // your code goes here
            if (arr == null || arr.Length == 0)
            {
                return 0;
            }

            HashSet<int> map = new HashSet<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!map.Contains(arr[i]))
                {
                    map.Add(arr[i]);
                }
            }

            for(int i = 0; i < arr.Length; i++)
            {
                if(!map.Contains(i))
                {
                    return i;
                }
            }

            return arr.Length;
        }

        static void Main(string[] args)
        {

            int[] input = new int[] { 4, 1, 0, 3 };
            var result = GetNumber(input);
            System.Console.WriteLine(result);
            Console.ReadKey();
            // input 4, 1, 0, 3
            // after sorting : 0,1,3,4
            // 2
            //  output 2
        }
    }
}
