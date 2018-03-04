using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Maths
{
    /*
     * Given 2 non negative integers m and n, find gcd(m, n)

GCD of 2 integers m and n is defined as the greatest integer g such that g is a divisor of both m and n.
Both m and n fit in a 32 bit signed integer.

Example

m : 6
n : 9

GCD(m, n) : 3 
     * */
    class GCD
    {
        private static int GetGCD(int A, int B)
        {
            int smaller = A > B ? B : A;
            if (smaller < 2)
            {
                return A > B ? A : B;
            }

            for (int i = smaller; i > 1; i--)
            {
                if ((A % i == 0) && (B % i == 0))
                {
                    return i;
                }
            }

            return 1;
        }

        //public static void Main(string[] args)
        //{
        //    var result = GetGCD(3, 9);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
