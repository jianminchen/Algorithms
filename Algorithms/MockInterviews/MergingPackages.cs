using System;
using System.Collections.Generic;

class MergingPackages
{
    /*
     * Merging 2 Packages
Given a package with a weight limit limit and an array arr of item weights, implement a function getIndicesOfItemWeights that finds two items whose sum of weights equals the weight limit limit. Your function should return a pair [i, j] of the indices of the item weights, ordered such that i < j. If such a pair doesn’t exist, return an empty array.

Analyze the time and space complexities of your solution.

Example:

input:  arr = [4, 6, 10, 15, 16],  lim = 21

output: [3, 1] # since these are the indices of the
               # weights 6 and 15 whose sum equals to 21
Constraints:

[time limit] 5000ms

[input] array.integer arr

0 ≤ arr.length ≤ 100
[input] integer limit

[output] array.integer
     * */
    public static int[] GetIndicesOfItemWeights(int[] arr, int limit)
    {
        // your code goes here
        List<int> result = new List<int>();
        if (arr == null || arr.Length == 0)
        {
            return result.ToArray();
        }

        Dictionary<int, int> map = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            if (map.ContainsKey(arr[i]))
            {
                result.Add(i);
                result.Add(map[arr[i]]);
            }
            else
            {
                if (map.ContainsKey(limit - arr[i]))
                {
                    map[limit - arr[i]] = i;
                }
                else
                {
                    map.Add(limit - arr[i], i);
                }
            }
        }

        return result.ToArray();
    }

    //static void Main(string[] args)
    //{
    //    /*
    //    4,4,1      lim=5
    //    */
    //    //int[] arr = new int[] { 4, 6, 10, 15, 16 };
    //    //int lim = 21;

    //    int[] arr = new int[] { 4, 4, 1 };
    //    int lim = 5;
    //    var result = GetIndicesOfItemWeights(arr, lim);
    //    foreach (var element in result)
    //    {
    //        Console.WriteLine(element);
    //    }

    //    Console.ReadKey();
    //}
}

