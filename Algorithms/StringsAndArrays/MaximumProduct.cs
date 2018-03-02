using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    class MaximumProduct
    {
        private static long GetMaxProduct(int[] input)
        {
            long maxProduct;
            long secondMaxProduct;

            if(input == null || input.Length < 2)
            {
                return -1;
            }

            int max = Int32.MinValue;
            int secondMax = Int32.MinValue;
            int min = Int32.MaxValue;
            int secondMin = Int32.MaxValue;
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i] > max)
                {
                    secondMax = max;
                    max = input[i];
                }
                else if(input[i] > secondMax)
                {
                    secondMax = input[i];
                }

                if(input[i] < min)
                {
                    secondMin = min;
                    min = input[i];
                }
                else if(input[i] < secondMin)
                {
                    secondMin = input[i];
                }
            }

            maxProduct = max * secondMax;
            secondMaxProduct = min * secondMin;
            if(secondMaxProduct > maxProduct)
            {
                maxProduct = secondMaxProduct;
            }

            return maxProduct;
        }

        //public static void Main(string[] args)
        //{
        //    //int[] input = new int[] { -20, -50, 8, -1, 5, 100, 50 };
        //    int[] input = new int[] { -3,-5,-7,-1,0,1,2,3,0,8,7};
        //    var result = GetMaxProduct(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
