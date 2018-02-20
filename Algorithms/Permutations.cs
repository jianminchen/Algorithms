using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Permutations
    {
        //public static void Main(string[] args)
        //{
        //    List<int> input = new List<int>();
        //    input.AddRange(new int[] { 1, 2, 1, 3});
        //    var result = GetPermutations(input);
        //    Console.ReadKey();
        //}

        private static List<List<int>> GetPermutations(List<int> input)
        {
            List<List<int>> output = new List<List<int>>();
            GetPermutationsRecursive(input.ToArray(), 0, input.Count() - 1, output);
            return output;
        }

        private static void GetPermutationsRecursive(int[] input, int start, int end, List<List<int>> output)
        {
            if(start == end)
            {
                output.Add(input.ToList());
            }

            for(int i = start; i <= end; i++)
            {
                if(CanRunPermutations(input, start, i))
                {
                    Swap(input, start, i);
                    GetPermutationsRecursive(input, start + 1, end, output);
                    Swap(input, start, i);
                }
            }
        }

        private static bool CanRunPermutations(int[] input, int first, int second)
        {
            if(first == second)
            {
                return true;
            }
            else
            {
                for(int i = first; i < second; i++)
                {
                    if(input[i] == input[second])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void Swap(int[] input, int first, int second)
        {
            int temp = input[first];
            input[first] = input[second];
            input[second] = temp;
        }
    }
}
