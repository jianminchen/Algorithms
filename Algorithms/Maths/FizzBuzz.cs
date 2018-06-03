using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Maths
{
    /*
     * Given a positive integer N, print all the integers from 1 to N. But for multiples of 3 print “Fizz” instead of the number and for the multiples of 5 print “Buzz”. Also for number which are multiple of 3 and 5, prints “FizzBuzz”.

Example

N = 5
Return: [1 2 Fizz 4 Buzz]
     * */
    class FizzBuzz
    {
        private static List<string> GetFizzBuzz(int A)
        {
            List<string> result = new List<string>();
            for (int i = 1; i <= A; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    result.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result;
        }

        //public static void Main(string[] args)
        //{
        //    var result = GetFizzBuzz(15);
        //    foreach(var element in result)
        //    {
        //        Console.WriteLine(element);
        //    }

        //    Console.ReadKey();
        //}
    }

}
