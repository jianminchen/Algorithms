using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * Array of Array Products
Given an array of integers arr, you’re asked to calculate for each index i the product of all integers except the integer at that index (i.e. except arr[i]). Implement a function arrayOfArrayProducts that takes an array of integers and returns an array of the products.

Solve without using division and analyze your solution’s time and space complexities.

Examples:

input:  arr = [8, 10, 2]
output: [20, 16, 80] # by calculating: [10*2, 8*2, 8*10]

input:  arr = [2, 7, 3, 4]
output: [84, 24, 56, 42] # by calculating: [7*3*4, 2*3*4, 2*7*4, 2*7*3]

     * */
    class ArrayOfArrayProducts
    {
        public static int[] GetProducts(int[] arr)
        {
            // your code goes here
            if (arr == null || arr.Length == 0 || arr.Length == 1)
            {
                return new List<int>().ToArray();
            }

            int[] first = new int[arr.Length];
            int[] second = new int[arr.Length];

            int runningProduct = 1;
            for (int i = 0; i < arr.Length; i++)
            {
                runningProduct *= arr[i];
                first[i] = runningProduct;
            }

            runningProduct = 1;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                runningProduct *= arr[i];
                second[i] = runningProduct;
            }

            int[] output = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                int firstComponent = i > 0 ? first[i - 1] : 1;
                int secondComponent = i < arr.Length - 1 ? second[i + 1] : 1;

                output[i] = firstComponent * secondComponent;
            }

            return output;
        }

        static void Main(string[] args)
        {
            int[] arr = new int[]{2,7,3,4};
            var result = GetProducts(arr);
            foreach(var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();            
        }
    }
}
