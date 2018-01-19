using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    class RotateMatrix
    {
        public static void Main(string[] args)
        {
            int[,] input = new int[4, 4];
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    input[i, j] = count++;
                }
            }

            Rotate(input, 4, 4);

            Console.ReadKey();
        }

        private static void Rotate(int[,] input, int rows, int cols)
        {
            for (int layer = 0; layer < (rows / 2); layer++)
            {
                int first = layer;
                int last = rows - 1 - layer;
                for (int i = first; i < last; i++)
                {
                    int offset = i - first;
                    int temp = input[first, i];
                    input[first, i] = input[last - offset, first];
                    input[last - offset, first] = input[last, last - offset];
                    input[last, last - offset] = input[i, last];
                    input[i, last] = temp;
                }
            }

        }
    }
}
