using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * Array Quadruplet
Given an unsorted array of integers arr and a number s, write a function findArrayQuadruplet that finds four numbers (quadruplet) in arr that sum up to s. Your function should return an array of these numbers in an ascending order. If such a quadruplet doesn’t exist, return an empty array.

Note that there may be more than one quadruplet in arr whose sum is s. You’re asked to return the first one you encounter (considering the results are sorted).

Explain and code the most efficient solution possible, and analyze its time and space complexities.

Example:

input:  arr = [2, 7, 4, 0, 9, 5, 1, 3], s = 20

output: [0, 4, 7, 9] # The ordered quadruplet of (7, 4, 0, 9)
                     # whose sum is 20. Notice that there
                     # are two other quadruplets whose sum is 20:
                     # (7, 9, 1, 3) and (2, 4, 9, 5), but again you’re
                     # asked to return the just one quadruplet (in an
                     # ascending order)
     * */
    class ArrayQuadruplet
    {
        public static int[] FindArrayQuadruplet(int[] arr, int s)
        {
            // your code goes here
            if (arr == null || arr.Length == 0 || arr.Length < 4)
            {
                return new int[0];
            }

            Array.Sort(arr);
            int x = 0;
            int y = 1;
            int m = y + 1;
            int n = arr.Length - 1;
            while (x < arr.Length - 1)
            {
                y = x + 1;
                while (y < arr.Length - 1)
                {
                    var sumx_y = arr[x] + arr[y];
                    m = y + 1;
                    n = arr.Length - 1;
                    while (m < n)
                    {
                        var sum = sumx_y + arr[m] + arr[n];
                        if (sum == s)
                        {
                            // return from here
                            return new int[] { arr[x], arr[y], arr[m], arr[n] };
                        }
                        if (sum < s)
                        {
                            m++;
                        }
                        else
                        {
                            n--;
                        }
                    }
                    y++;
                }
                x++;
            }

            return new int[0];
        }

        static void Main(string[] args)
        {
            int[] input = { 2, 7, 4, 0, 9, 5, 1, 3 };
            int s = 20;
            var result = FindArrayQuadruplet(input, s);
            foreach(var element in result)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }
    }
}
