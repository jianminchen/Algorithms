using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScratchPad
{
    class SelectionSort
    {
        //public static void Main(string[] args)
        //{
        //    int[] input = { 2, 7, 1, 9, 3, 4, 10, 5 };
        //    var result = Sort(input);
        //    foreach (int t in result)
        //    {
        //        Console.WriteLine(t);
        //    }
        //    Console.ReadKey();
        //}

        private static int[] Sort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[j] < input[min])
                    {
                        min = j;
                    }
                }
                int temp = input[i];
                input[i] = input[min];
                input[min] = temp;
            }
            return input;
        }
    }
}