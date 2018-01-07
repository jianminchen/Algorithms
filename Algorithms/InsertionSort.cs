using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ScratchPad
{
    class InsertionSort
    {
        //public static void Main(string[] args)
        //{
        //    int[] input = { 2, 7, 1, 9, 3, 4, 10, 5 };
        //    Sort(input);
        //    foreach (int t in input)
        //    {
        //        Console.WriteLine(t);
        //    }
        //    Console.ReadKey();
        //}

        private static void Sort(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (input[j] < input[j - 1])
                    {
                        var temp = input[j];
                        input[j] = input[j - 1];
                        input[j - 1] = temp;
                    }
                }
            }
        }
    }
}