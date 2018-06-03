using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    /*
     * Given a list of non negative integers, arrange them such that they form the largest number.

For example:

Given [3, 30, 34, 5, 9], the largest formed number is 9534330.

Note: The result may be very large, so you need to return a string instead of an integer.
    */
    class LargestNumber
    {
        private static string GetLargestNumber(int[] input)
        {
            Array.Sort(input, IsLessThan);
            Array.Reverse(input);
            if (input[0] == 0)
            {
                return "0";
            }

            StringBuilder sb = new StringBuilder();
            foreach (var element in input)
            {
                sb.Append(element.ToString());
            }

            return sb.ToString();
        }

        private static int IsLessThan(int first, int second)
        {
            return (first.ToString() + second.ToString()).CompareTo(
                second.ToString() + first.ToString());
        }

        //public static void Main(string[] args)
        //{
        //    // [3, 30, 34, 5, 9], the largest formed number is 9534330.
        //    int[] input = new int[] { 3, 30, 34, 5, 9 };
        //    var result = GetLargestNumber(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
