using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    class Fibonacci
    {
        private static ulong GetFibonacci(int number)
        {
            if(number < 2)
            {
                return 1;
            }
            // here we are storing a table of size n, we can optimize this as we dont need to store all n numbers
            ulong[] table = new ulong[number + 1];
            table[0] = 0;
            table[1] = 1;
            for(int i = 2; i <= number; i++)
            {
                table[i] = table[i - 1] + table[i - 2];
            }

            return table[number];
        }

        //public static void Main(string[] args)
        //{
        //    int i = 10;
        //    ulong result = GetFibonacci(i);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
