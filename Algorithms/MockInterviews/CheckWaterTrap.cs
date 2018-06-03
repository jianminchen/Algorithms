using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    class CheckWaterTrap
    {
        public static int Trap(int[] height)
        {
            if (height == null || height.Length == 0)
            {
                return 0;
            }

            int maxWaterTrap = 0;
            int i = 0;
            int j = 0;
            List<int> tempBuffer = new List<int>();
            while (j < height.Length)
            {
                if (height[j] < height[i])
                {
                    tempBuffer.Add(height[j]);
                    j++;
                    continue;
                }

                if (height[j] >= height[i] && (i != j))
                {
                    foreach (var item in tempBuffer)
                    {
                        var min = height[j] > height[i] ? height[i] : height[j];
                        if (item < min)
                        {
                            maxWaterTrap += min - item;
                        }
                    }

                    tempBuffer = new List<int>();
                    i = j;
                    // found water reserve
                }

                j++;
            }

            int min1 = height[j - 1] < height[i] ? height[j - 1] : height[i];
            for (int k = i; k < tempBuffer.Count(); k++)
            {
                if ((k + 1 < tempBuffer.Count() && tempBuffer[k] < tempBuffer[k + 1]))
                {
                    min1 = tempBuffer[k+1];
                }
                //var min = height[j-1] > height[i] ? height[i] : height[j-1];
            }

            foreach (var item in tempBuffer)
            {
                if (item < min1)
                {
                    maxWaterTrap += min1 - item;
                }
            }


            return maxWaterTrap;
        }

        //public static void Main(string[] args)
        //{
        //    //int[] input = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
        //    //int[] input = new int[] { 5,4,1, 2 };
        //    int[] input = new int[] { 4, 2, 3 };
        //    var result = Trap(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
