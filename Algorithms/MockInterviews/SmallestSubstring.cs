using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * Smallest Substring of All Characters
Given an array of unique characters arr and a string str, Implement a function getShortestUniqueSubstring that finds the smallest substring of str containing all the characters in arr. Return "" (empty string) if such a substring doesn’t exist.

Come up with an asymptotically optimal solution and analyze the time and space complexities.

Example:

input:  arr = ['x','y','z'], str = "xyyzyzyx"

output: "zyx"
Constraints:

[time limit] 5000ms

[input] array.character arr

1 ≤ arr.length ≤ 30
[input] string str

1 ≤ str.length ≤ 500
[output] string
     * */
    class SmallestSubstring
    {
        public static string GetShortestUniqueSubstring(char[] arr, string str)
        {
            // your code goes here
            if(string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            Dictionary<char, int> arrMap = new Dictionary<char, int>();

            for (int k = 0; k < arr.Length; k++)
            {
                arrMap.Add(arr[k], 0);
            }

            int i = 0;
            int j = 0;

            int matchCount = 0;
            string minResult = "";
            while (j < str.Length)
            {
                if (!arrMap.ContainsKey(str[j]))
                {
                    j++;
                    continue;
                }

                if (arrMap[str[j]] == 0)
                {
                    matchCount++;
                }

                arrMap[str[j]]++;
                while (matchCount == arr.Length)
                {
                    var tempLength = j - i + 1;
                    if (tempLength == arr.Length)
                    {
                        return str.Substring(i, tempLength);
                    }

                    if (minResult == "" || tempLength < minResult.Length)
                    {
                        minResult = str.Substring(i, tempLength);
                    }

                    if (arrMap.ContainsKey(str[i]))
                    {
                        if (arrMap[str[i]] - 1 == 0)
                        {
                            matchCount--;
                        }

                        arrMap[str[i]]--;
                    }

                    i++;
                }

                j++;
            }

            return minResult;
        }

        //static void Main(string[] args)
        //{
        //    //char[] input = new char[] { 'x', 'y', 'z' };
        //    //string str = "xyyzyzyx";
        //    char[] input = new char[] { 'A' };
        //    string str = "B";

        //    var result = GetShortestUniqueSubstring(input, str);

        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
