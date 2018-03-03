using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    class WaveArray
    {
        /*
         * Given an array of integers, sort the array into a wave like array and return it, 
In other words, arrange the elements into a sequence such that a1 >= a2 <= a3 >= a4 <= a5.....

Example

Given [1, 2, 3, 4]

One possible answer : [2, 1, 4, 3]
Another possible answer : [4, 1, 3, 2]
         * */
        private static int[] Wave(int[] input)
        {            
            Array.Sort(input);
            for (int i = 1; i < input.Length; i++)
            {
                if (i % 2 == 1)
                {
                    int temp = input[i];
                    input[i] = input[i - 1];
                    input[i - 1] = temp;
                }

            }

            return input;
        }

        //public static void Main(string[] args)
        //{
        //    int[] input = new int[] { 2,5,1,3,4,6,9};
        //    var result = Wave(input);
        //    foreach(var item in result)
        //    {
        //        Console.WriteLine(item);
        //    }

        //    Console.ReadKey();
        //}
    }
}
