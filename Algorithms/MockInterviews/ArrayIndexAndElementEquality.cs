using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * Array Index & Element Equality
Given a sorted array arr of distinct integers, write a function indexEqualsValueSearch that returns the lowest index i for which arr[i] == i. Return -1 if there is no such index. Analyze the time and space complexities of your solution and explain its correctness.

Examples:

input: arr = [-8,0,2,5]
output: 2 # since arr[2] == 2

input: arr = [-1,0,3,6]
output: -1 # since no index in arr satisfies arr[i] == i.

     * */
    class ArrayIndexAndElementEquality
    {
        public static int IndexEqualsValueSearch(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return -1; // assuming -1 is for error because we are returning indices
            }

            int start = 0;
            int end = arr.Length - 1;
            int mid;
            int candidateIndex = -1;
            while (start <= end)
            {
                mid = start + (end - start) / 2;
                if (arr[mid] == mid)
                {
                    // possible candidate
                    candidateIndex = mid;
                    if (candidateIndex > 0 && arr[candidateIndex - 1] == (candidateIndex - 1))
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        break; // or return candidateIndex
                    }
                }
                else if (arr[mid] > mid)
                {
                    // no point in scanning to the right of mid
                    end = mid - 1;
                }
                else
                {
                    // arr[mid] < mid
                    // no point in scanning to the left of mid
                    start = mid + 1;
                }
            }

            return candidateIndex;
        }

        //public static void Main(string[] args)
        //{
        //    int[] input = new int[] { -8, 0, 2, 5 };
        //    var result = IndexEqualsValueSearch(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
