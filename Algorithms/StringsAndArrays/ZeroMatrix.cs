using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    // Write an algorithm such that if an element in an MxN matrix is 0, its entire row and column are set to 0

    class ZeroMatrix
    {
        private static void ConvertToZeroes(int[,] matrix, int rows, int cols)
        {
            int[] rowsToBeZeroed = new int[rows];
            int[] colsToBeZeroed = new int[cols];

            for(int i = 0; i<rows; i++)
            {
                for(int j = 0; j< cols;j++)
                {
                    if(matrix[i,j] == 0)
                    {
                        rowsToBeZeroed[i] = 1;
                        colsToBeZeroed[j] = 1;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
               if(rowsToBeZeroed[i] == 1)
                {
                    for(int j=0;j<cols;j++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }

            for (int j = 0; j < cols; j++)
            {
                if (colsToBeZeroed[j] == 1)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
        }

        //public static void Main(string[] args)
        //{
        //    int[,] matrix = new int[4, 4] { { 1,1,0,1}, {0,1,1,1 }, {1,1,1,1 }, {1,1,1,1} };
        //    /*
        //     * 1 1 0 1
        //     * 0 1 1 1
        //     * 1 1 1 1
        //     * 1 1 1 1
        //     * */
        //    ConvertToZeroes(matrix, 4,4);
        //    for(int i = 0; i< 4;i++)
        //    {
        //        for(int j = 0; j< 4;j++)
        //        {
        //            Console.WriteLine("matrix[{0}][{1}]={2}", i, j, matrix[i,j]);
        //        }
        //    }

        //    Console.ReadKey();
        //}
    }
}
