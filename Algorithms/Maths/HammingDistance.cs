using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Maths
{
    /*
     * Algorithm to get sum of pairwise hamming distance between numbers in an array of ints
     * Hamming distance between two non-negative integers is defined as the number of positions at which the corresponding bits are different.

For example,

HammingDistance(2, 7) = 2, as only the first and the third bit differs in the binary representation of 2 (010) and 7 (111).

Given an array of N non-negative integers, find the sum of hamming distances of all pairs of integers in the array.
Return the answer modulo 1000000007.

        Example

Let f(x, y) be the hamming distance defined above.

A=[2, 4, 6]

We return,
f(2, 2) + f(2, 4) + f(2, 6) + 
f(4, 2) + f(4, 4) + f(4, 6) +
f(6, 2) + f(6, 4) + f(6, 6) = 

0 + 2 + 1
2 + 0 + 1
1 + 1 + 0 = 8
     * */
    class HammingDistance
    {
        private static int GetCompleteHammingDistance(int[] input)
        {
            Dictionary<KeyValuePair<int, int>, int> map = new Dictionary<KeyValuePair<int, int>, int>();
            int hammingDistance = 0;
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input.Length; j++)
                {
                    KeyValuePair<int, int> first = new KeyValuePair<int, int>(input[i], input[j]);
                    if (map.ContainsKey(first))
                    {
                        hammingDistance += map[first];
                    }
                    else
                    {
                        var result = GetHammingDistance(input[i], input[j]);
                        hammingDistance += result;
                        map.Add(new KeyValuePair<int, int>(input[i], input[j]), result);
                        KeyValuePair<int, int> second = new KeyValuePair<int, int>(input[j], input[i]);
                        if (!map.ContainsKey(second))
                        {
                            map.Add(new KeyValuePair<int, int>(input[j], input[i]), result);
                        }
                    }
                }
            }

            return hammingDistance;
        }

        private static int GetHammingDistance(int first, int second)
        {
            int xor = first ^ second;
            // count the number of 1s in the xor which gives the hamming distance
            int count = 0;
            while (xor > 0)
            {
                xor = xor & (xor - 1);
                count++;
            }

            return count;
        }

        //public static void Main(string[] args)
        //{
        //    //A=[2, 4, 6]
        //    int[] input = new int[] { 2, 4, 6 };
        //    var result = GetCompleteHammingDistance(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
