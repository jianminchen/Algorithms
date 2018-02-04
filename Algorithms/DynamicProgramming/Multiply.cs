using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    class Multiply
    {
        private static int RecMultiply(int first, int second)
        {
            int smaller = first > second ? second : first;
            int larger = first > second ? first : second;
            return RecursiveMultiply(smaller, larger);
        }

        private static int RecursiveMultiply(int smaller, int larger)
        {
            if (smaller == 0 || larger == 0)
            {
                return 0;
            }

            if(smaller == 1)
            {
                return larger;
            }

            var result = RecursiveMultiply(smaller / 2, larger) * 2;
            if (smaller % 2 != 0)
            {
                result += larger;
            }

            return result;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine(RecMultiply(31, 50));
            Console.ReadKey();
        }
    }
}
