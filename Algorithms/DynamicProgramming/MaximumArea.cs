using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    class MaximumArea
    {
        private static int MaximalSquareArea(int[,] input)
        {
            int[,] map = new int[input.GetLength(0), input.GetLength(1)];
            int i = 0;
            int j = 0;

            int max = 0;
            for (i = 0; i < input.GetLength(0); i++)
            {
                for (j = 0; j < input.GetLength(1); j++)
                {
                    if(i == 0 || j == 0)
                    {
                        map[i, j] = input[i, j];
                    }
                    else if (input[i, j] == 1)
                    {
                        map[i, j] = Math.Min(Math.Min(map[i - 1, j], map[i, j - 1]), map[i - 1, j - 1]) + 1;
                        if (map[i, j] > max)
                        {
                            max = map[i, j];
                        }
                    }
                    else
                    {
                        map[i, j] = 0;
                    }
                }
            }

            return max * max;
        }

  //      public static void Main(string[] args)
  //      {
  //          //int[,] input = new int[4, 4] { { 0, 1, 1, 1 }, { 0, 1, 1, 1 }, { 0, 1, 1, 1 }, { 1, 0, 1, 0 } };
  //          int[,] input = new int[,]
  //          {
  //{ 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
  //{ 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
  //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
  //{ 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1 },
  //{ 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1 },
  //{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
  //{ 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1 },
  //{ 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0 },
  //{ 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 1 },
  //{ 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1 },
  //{ 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
  //{ 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
  //{ 1, 1, 1, 0, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1 },
  //{ 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1 },
  //{ 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1 } };
  //          var result = MaximalSquareArea(input);
  //          Console.WriteLine(result);
  //          Console.ReadKey();
  //      }
    }
}
