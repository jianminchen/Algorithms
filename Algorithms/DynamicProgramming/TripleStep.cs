using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    /*
     * Triple Step: A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3
steps at a time. Implement a method to count how many possible ways the child can run up the
stairs.
     * */
    class TripleStep
    {
        private static long CountWays(int n)
        {
            long[] memo = new long[n + 1];
            for(int i = 0; i < n+1; i++)
            {
                memo[i] = -1;
            }

            return RecursiveCountWays(n, memo);
        }

        private static long RecursiveCountWays(int n, long[] memo)
        {
            if(n < 0)
            {
                return 0;
            }
            else if(n == 0)
            {
                return 1;
            }
            else if(memo[n] > -1)
            {
                return memo[n];
            }
            else
            {
                memo[n] = RecursiveCountWays(n-1, memo) + RecursiveCountWays(n-2, memo) + RecursiveCountWays(n - 3, memo);
                return memo[n];
            }

        }

        public static void Main(string[] args)
        {
            int n = 5;
            var result = CountWays(5);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
