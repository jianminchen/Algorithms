using System;
using System.Collections.Generic;

class Solution
{
    /*
     * Find The Duplicates
        Given two sorted arrays arr1 and arr2 of passport numbers, implement a function findDuplicates that returns an array of all passport numbers that are both in arr1 and arr2. Note that the output array should be sorted in an ascending order.

        Let N and M be the lengths of arr1 and arr2, respectively. Solve for two cases and analyze the time & space complexities of your solutions: M ≈ N - the array lengths are approximately the same M ≫ N - arr2 is much bigger than arr1.

        Example:

        input:  arr1 = [1, 2, 3, 5, 6, 7], arr2 = [3, 6, 7, 8, 20]

        output: [3, 6, 7] # since only these three values are both in arr1 and arr2
        Constraints:

        [time limit] 5000ms

        [input] array.integer arr1

        1 ≤ arr1.length ≤ 100
        [input] array.integer arr2

        1 ≤ arr2.length ≤ 100
        [output] array.integer
     * */
    public static int[] FindDuplicates(int[] arr1, int[] arr2)
    {
        // your code goes here
        int i = 0;
        int j = 0;
        List<int> output = new List<int>();

        if (arr1 == null || arr2 == null)
        {
            return output.ToArray();
        }

        while (i < arr1.Length && j < arr2.Length)
        {
            if (arr1[i] == arr2[j])
            {
                output.Add(arr1[i]);
                i++;
                j++;
            }
            else
            {
                if (arr1[i] < arr2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
        }

        return output.ToArray();
    }

    public static int[] FindDuplicatesOptimized(int[] arr1, int[] arr2)
    {
        // your code goes here
        List<int> output = new List<int>();

        if (arr1 == null || arr2 == null)
        {
            return output.ToArray();
        }

        foreach (var element in arr1)
        {
            if (Exists(element, arr2, 0, arr2.Length - 1))
            {
                output.Add(element);
            }
        }

        return output.ToArray();
    }

    static bool Exists(int element, int[] input, int low, int high)
    {
        if (high < low)
            return false;
        int mid = low + (high - low) / 2;
        if (input[mid] == element)
            return true;


        if (input[mid] < element)
        {
            return Exists(element, input, mid + 1, high);
        }
        else
        {
            return Exists(element, input, low, mid - 1);
        }
    }

    //static void Main(string[] args)
    //{
    //    // arr1 = 1,2000
    //    // arr2 = 1,2,3,4,5,...,2000
    //    int[] arr1 = new int[] { 1, 2, 6, 7 };
    //    int[] arr2 = new int[] { 3, 6, 7, 8, 20 };
    //    var result = FindDuplicatesOptimized(arr1, arr2);
    //    foreach (var element in result)
    //    {
    //        Console.WriteLine(element);
    //    }

    //    Console.ReadKey();
    //}
}

