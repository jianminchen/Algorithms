using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Maths
{
    /*
     * Given a number N, find all prime numbers upto N ( N included ).

Example:

if N = 7,

all primes till 7 = {2, 3, 5, 7}

Make sure the returned array is sorted.
     * */
    class SieveOfErastothenes
    {
        private static List<int> sieve(int A)
        {
            List<int> result = new List<int>();
            for (int i = 2; i <= A; i++)
            {
                if (IsPrime(i) == true)
                {
                    result.Add(i);
                }
            }

            return result;
        }

        private static bool IsPrime(int number)
        {
            for (int i = 2; i <= (int)Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        //public static void Main(string[] args)
        //{
        //    var result = sieve(7);
        //    foreach(var element in result)
        //    {
        //        Console.WriteLine(element);
        //    }

        //    Console.ReadKey();
        //}
    }
}
