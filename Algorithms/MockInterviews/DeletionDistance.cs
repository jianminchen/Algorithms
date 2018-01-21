using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    class DeletionDistance
    {
        public static int DeletionDistanceSuboptimal(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2))
            {
                return 0;
            }
            else if (string.IsNullOrEmpty(str1))
            {
                return str2.Length;
            }
            else if (string.IsNullOrEmpty(str2))
            {
                return str1.Length;
            }

            if (str1[str1.Length - 1] == str2[str2.Length - 1])
            {
                return DeletionDistanceSuboptimal(str1.Substring(0, str1.Length - 1), str2.Substring(0, str2.Length - 1));
            }
            else
            {
                return 1 + Math.Min(DeletionDistanceSuboptimal(str1.Substring(0, str1.Length - 1), str2),
                                 DeletionDistanceSuboptimal(str1, str2.Substring(0, str2.Length - 1)));
            }
        }

        public static int DeletionDistanceOptimal(string str1, string str2)
        {
            int[,] memo = new int[str1.Length + 1, str2.Length + 1];
            for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    if (i == 0)
                    {
                        memo[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        memo[i, j] = i;
                    }
                    else if (str1[i - 1] == str2[j - 1])
                    {
                        memo[i, j] = memo[i - 1, j - 1];
                    }
                    else
                    {
                        int memo1 = memo[i - 1, j];
                        int memo2 = memo[i, j - 1];
                        memo[i, j] = 1 + Math.Min(memo1, memo2);
                    }
                }
            }

            return memo[str1.Length, str2.Length];
        }

        static void Main(string[] args)
        {
            string str1 = "dog";
            string str2 = "frog";

            var deletionDistance = DeletionDistanceOptimal(str1, str2);
            Console.WriteLine(deletionDistance);
        }
    }
}
