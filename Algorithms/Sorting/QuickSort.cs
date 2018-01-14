using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Sorting
{
    class QuickSort
    {
        public static void Main(string[] args)
        {
            int[] input = { 13, 8, 1, 9, 2, 4, 1, 10, 5, 12 };
            Sort(input, 0, input.Length - 1);
            foreach(int element in input)
            {
                Console.WriteLine(element);
            }

            Console.ReadKey();
        }

        private static void Sort(int[] input, int low, int high)
        {
            if (high <= low)
            {
                return;
            }

            int partition = Partition(input, low, high);
            Sort(input, low, partition - 1);
            Sort(input, partition + 1, high);
        }

        private static int Partition(int[] input, int low, int high)
        {
            int i = low;
            int j = high + 1;
            while(true)
            {
                while(input[++i] < input[low])
                {
                    if(i == high)
                    {
                        break;
                    }
                }

                while(input[low] < input[--j])
                {
                    if(j == low)
                    {
                        break;
                    }
                }

                if(j <= i)
                {
                    break;
                }

                Exchange(input, i, j);
            }

            Exchange(input, low, j);
            return j;
        }

        private static void Exchange(int[] input, int first, int second)
        {
            int temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }
    }
}
