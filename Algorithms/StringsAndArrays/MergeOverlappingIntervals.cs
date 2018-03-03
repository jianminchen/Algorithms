using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    class MergeOverlappingIntervals
    {
        /*
         * Given a collection of intervals, merge all overlapping intervals.

For example:

Given [1,3],[2,6],[8,10],[15,18],

return [1,6],[8,10],[15,18].

Make sure the returned intervals are sorted.
         * */
        private static int[][] MergeIntervals(int[][] input)
        {
            if (input == null || input.GetLength(0) == 0)
            {
                return input;
            }

            int lower = 0;
            int upper = 0;
            List<int[]> result = new List<int[]>();
            int i = 1;
            while (i < input.Length)
            {
                if (input[i-1][1] >= input[i][0])
                {
                    lower = input[i-1][0];
                    while (!(input[i][0] > input[i-1][1]) && i < input.Length)
                    {
                        i++;
                    }
                    i--;
                    upper = input[i][1];
                    result.Add(new int[] { lower, upper });
                }
                else
                {
                    result.Add(new int[] { input[i][0], input[i][1] });
                }

                i++;
            }

            return result.ToArray();
        }

        //public static void Main(string[] args)
        //{
        //    //Given [1,3],[2,6],[8,10],[15,18],

        //    //return [1, 6],[8,10],[15,18].
        //    int[][] input = new int[][] { new int[] { 1, 3 }, new int[] { 2, 6 }, new int[] { 8, 10 }, new int[] { 15, 18 } };
        //    var result = MergeIntervals(input);
        //    Console.ReadKey();
        //}
    }
}
