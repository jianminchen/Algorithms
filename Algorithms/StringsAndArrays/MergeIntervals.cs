using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    /*
     * Given a set of non-overlapping intervals, insert a new interval into the intervals (merge if necessary).

You may assume that the intervals were initially sorted according to their start times.

Example 1:

Given intervals [1,3],[6,9] insert and merge [2,5] would result in [1,5],[6,9].

Example 2:

Given [1,2],[3,5],[6,7],[8,10],[12,16], insert and merge [4,9] would result in [1,2],[3,10],[12,16].

This is because the new interval [4,9] overlaps with [3,5],[6,7],[8,10].

Make sure the returned intervals are also sorted.
     * */
    class MergeIntervalsClass
    {
        private static int[][] MergeIntervals(int[][] input, int[] interval)
        {
            if (input == null || input.GetLength(0) == 0)
            {
                return input;
            }

            int lower = 0;
            int upper = 0;
            List<int[]> result = new List<int[]>();
            int i = 0;
            while (i < input.Length)
            {
                if (input[i][0] <= interval[0] && input[i][1] > interval[0])
                {
                    lower = input[i][0];
                    while (!(input[i][0] <= interval[1] && input[i][1] > interval[1]) && i < input.Length)
                    {
                        i++;
                    }

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
        //    //[1,2],[3,5],[6,7],[8,10],[12,16], insert and merge[4, 9] should return [1,2], [3,10], [12,16]
        //    int[][] input = new int[][] {new int[]{1,2}, new int[]{3,5}, new int[]{6,7}, new int[]{8,10}, new int[] {12,16}};
        //    var result = MergeIntervals(input, new int[] { 4, 9 });
        //    Console.ReadKey();
        //}
    }
}
