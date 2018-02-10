using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Algorithms.MockInterviews
{
    using System;
    using System.Collections.Generic;

    class KMessedArraySort
    {
        public static int[] SortKMessedArray(int[] arr, int k)
        {
            if (k < 0)
            {
                return null;
            }

            if (arr == null || arr.Length == 0 || k == 0)
            {
                return arr;
            }

            if (k > arr.Length)
            {
                k = arr.Length;
            }

            SortedSet<int> set = new SortedSet<int>();
            int i = 0;
            while (i <= k)
            {
                set.Add(arr[i++]);
            }

            int[] output = new int[arr.Length];
            int j = 0;
            while (i < arr.Length && j < arr.Length)
            {
                output[j++] = set.Min;
                set.Remove(set.Min);

                set.Add(arr[i++]);
            }

            i = 0;
            while (i <= k)
            {
                output[j++] = set.Min;
                set.Remove(set.Min);
                i++;
            }

            return output;
        }

        //static void Main(string[] args)
        //{
        //    int[] input = new int[] {1, 4, 5, 2, 3, 7, 8, 6, 10, 9 };
        //    int k = 2;

        //    var result = SortKMessedArray(input, k);
        //    foreach(var element in result)
        //    {
        //        Console.WriteLine(element);
        //    }

        //    Console.ReadKey();
        //}

        // 1, 4, 5, 2, 3, 7, 8, 6, 10, 9   k=2
    }


}
