using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{/*
    Given a 2D array binaryMatrix of 0s and 1s, implement a function getNumberOfIslands that returns the number of islands of 1s in binaryMatrix.

An island is defined as a group of adjacent values that are all 1s. A cell in binaryMatrix is considered adjacent to another cell if they are next to each either on the same row or column. Note that two values of 1 are not part of the same island if they’re sharing only a mutual “corner” (i.e. they are diagonally neighbors).

Explain and code the most efficient solution possible and analyze its time and space complexities.

Example:

input:  binaryMatrix = [ [0,    1,    0,    1,    0],
                         [0,    0,    1,    1,    1],
                         [1,    0,    0,    1,    0],
                         [0,    1,    1,    0,    0],
                         [1,    0,    1,    0,    1] ]

output: 6 # since this is the number of islands in binaryMatrix.
          # See all 6 islands color-coded below.
alt
    */
    class IslandCount
    {
        public static int GetNumberOfIslands(int[,] binaryMatrix)
        {
            // your code goes here
            if (binaryMatrix == null || (binaryMatrix.GetLength(0) == 0 &&
                                        binaryMatrix.GetLength(1) == 0))
            {
                return 0;
            }

            int islandCount = 0;

            for (int i = 0; i < binaryMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < binaryMatrix.GetLength(1); j++)
                {
                    if (binaryMatrix[i, j] == 1)
                    {
                        VisitIslands(binaryMatrix, i, j);
                        islandCount++;
                    }
                }
            }

            return islandCount;
        }

        static void VisitIslands(int[,] binaryMatrix, int i, int j)
        {
            binaryMatrix[i, j] = 0;

            if (i - 1 >= 0 && binaryMatrix[i - 1, j] == 1)
            {
                VisitIslands(binaryMatrix, i - 1, j);
            }
            if (j - 1 >= 0 && binaryMatrix[i, j - 1] == 1)
            {
                VisitIslands(binaryMatrix, i, j - 1);
            }
            if (i + 1 < binaryMatrix.GetLength(0) && binaryMatrix[i + 1, j] == 1)
            {
                VisitIslands(binaryMatrix, i + 1, j);
            }
            if (j + 1 < binaryMatrix.GetLength(1) && binaryMatrix[i, j + 1] == 1)
            {
                VisitIslands(binaryMatrix, i, j + 1);
            }
        }

        //static void Main(string[] args)
        //{
        //    int[,] input = new int[5, 5]{{0, 1, 0, 1, 0 },
        //                 { 0, 0, 1, 1, 1},
        //                 {1, 0, 0, 1, 0},
        //                 {0, 1, 1, 0, 0},
        //                 {1, 0, 1, 0, 1} };
        //    var result = GetNumberOfIslands(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
