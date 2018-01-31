using System;

namespace Algorithms.DynamicProgramming
{
    class LongestCommonSubsequence
    {
        private static int LengthOfLongestCommonSubsequence(string first, string second)
        {
            int max = 0;
            if(string.IsNullOrEmpty(first) || string.IsNullOrEmpty(second))
            {
                return max;
            }

            int[,] table = new int[first.Length + 1, second.Length + 1];
            for(int i = first.Length - 1; i >= 0; i--)
            {
                for(int j = second.Length - 1;j >= 0; j--)
                {
                    if(first[i] == second[j])
                    {
                        table[i, j] = 1 + table[i + 1, j + 1];
                        if(table[i,j] > max)
                        {
                            max = table[i, j];
                        }
                    }
                    else
                    {
                        table[i, j] = 0;
                    }
                }
            }

            return max;
        }

        //public static void Main(string[] args)
        //{
        //    string first = "ravec";
        //    string second = "meavec";

        //    int result = LengthOfLongestCommonSubsequence(first, second);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
