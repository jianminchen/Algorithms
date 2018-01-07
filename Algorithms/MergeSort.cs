using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MergeSort
    {
        public static void Main(string[] args)
        {
            int[] input = { 3, 1, 9, 5, 2, 7, 1, 10, 20, 15, 4, 30 };
            int[] temp = new int[input.Length];
            Sort(input, temp, 0, input.Length - 1);
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }

            Console.ReadKey();
        }

        private static void Merge(int[] input, int[] temp, int low, int mid, int high)
        {
            for(int k = low; k <= high; k++)
            {
                temp[k] = input[k];
            }

            int i = low;
            int j = mid + 1;

            for(int k = low; k<= high; k++)
            {
                if(i > mid)
                {
                    input[k] = temp[j++];
                }
                else if(j > high)
                {
                    input[k] = temp[i++];
                }
                else if (temp[j] < temp[i])
                {
                    input[k] = temp[j++];
                }
                else
                {
                    input[k] = temp[i++];
                }
            }
        }

        private static void Sort(int[] input, int[] temp, int low, int high)
        {
            if (high <= low)
                return;

            int mid = low + (high - low) / 2;
            Sort(input, temp, low, mid);
            Sort(input, temp, mid + 1, high);
            Merge(input, temp, low, mid, high);
        }
    }
}
