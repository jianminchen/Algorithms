using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * Given an array of positive integers, return the number of triangles that can be formed 
with three different array elements as three sides of triangles. 
For example, if the input array is {4, 6, 3, 7}, the output should be 3. 
There are three triangles possible {3, 4, 6}, {4, 6, 7} and {3, 6, 7}. 
Note that {3, 4, 7} is not a possible triangle.
     * */
    class NumberOfTriangles
    {
        private static int GetNumberOfTriangles(int[] input)
        {
            if (input == null || input.Length < 3)
            {
                return 0;
            }

            Array.Sort(input);

            int numberOfTriangles = 0;
            for (int i = 0; i < input.Length - 2; i++)
            {
                int k = i + 2;
                for (int j = i + 1; j < k; j++)
                {
                    while (k < input.Length && input[i] + input[j] > input[k])
                    {
                        k++;
                    }

                    numberOfTriangles += k - j - 1;
                }
            }

            return numberOfTriangles;
        }    

        //public static void Main(string[] args)
        //{
        //    int[] input = new int[] { 4, 6, 3, 7 };
        //    var result = GetNumberOfTriangles(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
