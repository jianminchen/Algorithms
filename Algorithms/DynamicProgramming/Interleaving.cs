using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    class Interleaving
    {
        //private static bool IsInterleaved(string first, string second, string third, int i, int j, int k)
        //{
        //    if(string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second) && string.IsNullOrEmpty(third))
        //    {
        //        return true;
        //    }

        //    if(string.IsNullOrEmpty(third))
        //    {
        //        return false;
        //    }
            
        //    if(first.Length + second.Length != third.Length)
        //    {
        //        return false;
        //    }

        //    if(k == third.Length)
        //    {
        //        if(i < first.Length|| j < second.Length)
        //        {
        //            return false;
        //        }
        //        else
        //        {
        //            if( i == first.Length && j == second.Length )
        //            {
        //                return true;
        //            }
        //        }
        //    }


        //    if (i <= first.Length - 1 || j <= second.Length - 1)
        //    {
        //        bool firstResult = false;
        //        if(i <= first.Length - 1 && first[i] == third[k])
        //        {
        //            firstResult = IsInterleaved(first, second, third, i + 1, j, k + 1);
        //        }

        //        bool secondResult = false;
        //        if (j <= second.Length - 1 && second[j] == third[k])
        //        {
        //            secondResult = IsInterleaved(first, second, third, i, j + 1, k+1);                    
        //        }

        //        return firstResult || secondResult;
        //    }

        //    return false;
        //}

        private static bool IsInterleaved(string first, string second, string third)
        {
            if(first == null && second == null && third == null)
            {
                return true;
            }

            // if first + second != third
            if(first.Length + second.Length != third.Length)
            {
                return false;
            }

            bool[,] map = new bool[first.Length + 1, second.Length + 1];
            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    // if both are 0
                    if (i == 0 && j == 0)
                    {
                        map[i, j] = true;
                    }

                    // if first is empty
                    else if (i == 0 && second[j - 1] == third[j - 1])
                    {
                        map[i, j] = map[i, j - 1];
                    }
                    // if second is empty
                    else if (j == 0 && first[i - 1] == third[i - 1])
                    {
                        map[i, j] = map[i-1, j];
                    }
                    // current char of third matches with current char of first but not with current char of second
                    else if (i > 0 && j > 0 && first[i-1] == third[i+j-1] && second[j-1]!= third[i+j-1])
                    {
                        map[i, j] = map[i - 1, j];
                    }
                    // current char of third matches with current char of second but not with current char of first
                    else if (i > 0 && j > 0 && second[j - 1] == third[i + j - 1] && first[i - 1] != third[i + j - 1])
                    {
                        map[i, j] = map[i, j-1];
                    }
                    // current char of third matches with current char of first and second
                    else if (i > 0 && j > 0 && first[i - 1] == third[i + j - 1] && second[j - 1] == third[i + j - 1])
                    {
                        map[i, j] = map[i - 1, j] || map[i,j-1];
                    }
                }
            }

            return map[first.Length, second.Length];
        }

        //public static void Main(string[] args)
        //{
        //    string first="xyz";
        //    string second="abc";
        //    string third="xaybzc";

        //    bool result = IsInterleaved(first, second, third);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
