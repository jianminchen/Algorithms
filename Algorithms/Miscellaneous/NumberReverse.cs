using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Miscellaneous
{
    class NumberReverse
    {
        public static int Reverse(int x)
        {
            bool negative = false;
            if (x < 0)
            {
                negative = true;
                x = x * -1;
            }

            long result = 0;
            while (x > 0)
            {
                var digit = x % 10;
                if (result * 10 > int.MaxValue)
                {
                    return 0;
                }
                result = result * 10 + digit;
                x = x / 10;
            }

            return negative == true ? (int)result * -1 : (int)result;
        }

        public static void Main(string[] args)
        {
            var result = NumberReverse.Reverse(1534236469);
            Console.Write(result);
            Console.ReadKey();
        }
    }
}
