using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    class NthRoot
    {
        public static double Root(double x, int n)
        {
            // your code goes here
            if (x == 0)
            {
                return 0;
            }
            double lowerBound = 0;
            double upperBound = 1 > x ? 1 : x;
            double approxRoot = (lowerBound + upperBound) / 2;
            while (approxRoot - lowerBound >= 0.001)
            {
                if (Math.Pow(approxRoot, n) > x)
                {
                    upperBound = approxRoot;
                }
                else if (Math.Pow(approxRoot, n) < x)
                {
                    lowerBound = approxRoot;
                }
                else
                {
                    break;
                }

                approxRoot = (lowerBound + upperBound) / 2;
            }

            return approxRoot;
        }

        static void Main(string[] args)
        {
            var result = Root(27, 3);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
