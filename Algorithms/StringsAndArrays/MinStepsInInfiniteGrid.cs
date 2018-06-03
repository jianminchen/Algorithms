using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    /*
     * You are in an infinite 2D grid where you can move in any of the 8 directions :

 (x,y) to 
    (x+1, y), 
    (x - 1, y), 
    (x, y+1), 
    (x, y-1), 
    (x-1, y-1), 
    (x+1,y+1), 
    (x-1,y+1), 
    (x+1,y-1) 
You are given a sequence of points and the order in which you need to cover the points. Give the minimum number of steps in which you can achieve it. You start from the first point.

Example :

Input : [(0, 0), (1, 1), (1, 2)]
Output : 2
It takes 1 step to move from (0, 0) to (1, 1). It takes one more step to move from (1, 1) to (1, 2).

This question is intentionally left slightly vague. Clarify the question by trying out a few cases in the “See Expected Output” section.
     * */
    class MinStepsInInfiniteGrid
    {
        private static int CoverPoints(int[] first, int[] second)
        {
            int minimum = 0;
            int xDiff = 0;
            int yDiff = 0;
            for (int i = 1; i < first.Length; i++)
            {
                xDiff = Math.Abs(first[i] - first[i - 1]);
                yDiff = Math.Abs(second[i] - second[i - 1]);

                minimum += yDiff > xDiff ? yDiff : xDiff;
            }

            return minimum;
        }

        //public static void Main(string[] args)
        //{
        //    int[] xCoords = new int[] {0,3,7};
        //    int[] yCoords = new int[] {0,3,7};

        //    var result = CoverPoints(xCoords, yCoords);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
