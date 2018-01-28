using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * Minimum Number of Platforms Required for a Railway/Bus Station
3.2
Given arrival and departure times of all trains that reach a railway station, find the minimum number of platforms required for the railway station so that no train waits.
We are given two arrays which represent arrival and departure times of trains that stop
Examples:
Input:  arr[]  = {9:00,  9:40, 9:50,  11:00, 15:00, 18:00}
        dep[]  = {9:10, 12:00, 11:20, 11:30, 19:00, 20:00}
Output: 3
There are at-most three trains at a time (time between 11:00 to 11:20)
     * */

    class MinimumNumberOfPlatforms
    {
        private static int GetMinimumPlatforms(int[] arr, int[] dep)
        {
            if(arr == null || dep == null || arr.Length != dep.Length)
            {
                return -1;
            }

            Array.Sort(arr);
            Array.Sort(dep);

            int i = 0;
            int j = 0;
            int maxPlatforms = 0;
            int totalTrains = 0;
            while(i < arr.Length)
            {
                if(arr[i] < dep[j])
                {
                    i++;
                    totalTrains++;
                }
                else
                {
                    j++;
                    totalTrains--;
                }

                if(totalTrains > maxPlatforms)
                {
                    maxPlatforms = totalTrains;
                }
            }

            return maxPlatforms;
        }

        public static void Main(string[] args)
        {
            int[] arr = new int[] { 900, 940, 950, 1100, 1500, 1800 };
            int[] dep = new int[] { 910, 1200, 1120, 1130, 1900, 2000 };

            int minimumPlatforms = GetMinimumPlatforms(arr, dep);
            Console.WriteLine(minimumPlatforms);
            Console.ReadKey();
        }
    }
}
