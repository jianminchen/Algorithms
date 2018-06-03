using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    class LongestArithmeticProgression
    {
        public static int solve(List<int> A)
        {
            if (A == null || A.Count() == 0)
            {
                return 0;
            }

            if (A.Count() == 1)
            {
                return 1;
            }

            int[] input = A.ToArray();
            Array.Sort(input);

            int[,] map = new int[A.Count(), A.Count()];
            for (int i = 0; i < A.Count() - 1; i++)
            {
                map[i, A.Count() - 1] = 2;
            }

            int max = 2;

            for (int j = A.Count() - 2; j >= 1; j--)
            {
                int i = j - 1;
                int k = j + 1;
                while (i >= 0 && k <= A.Count() - 1)
                {
                    if ((input[i] + input[k]) > 2 * input[j])
                    {
                        map[i, j] = 2;
                        i--;
                    }
                    else if ((input[i] + input[k]) < 2 * input[j])
                    {
                        k++;
                    }
                    else
                    {
                        map[i, j] = map[j, k] + 1;
                        if (map[i, j] > max)
                        {
                            max = map[i, j];
                        }

                        i--;
                        k++;
                    }
                }

                while (i >= 0)
                {
                    map[i, j] = 2;
                    i--;
                }
            }
            return max;
        }

    //    public static void Main(string[] args)
    //    {
    //        List<int> input = new List<int>();
    //        input.Add(9);
    //        input.Add(4);
    //        input.Add(7);
    //        input.Add(2);
    //        input.Add(10);

    //        var result = solve(input);
    //        Console.WriteLine(result);
    //        Console.ReadKey();
    //    }
    }
}
