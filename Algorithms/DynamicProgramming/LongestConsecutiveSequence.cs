using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    class LongestConsecutiveSequence
    {
        public static int longestConsecutive(List<int> A)
        {
            if (A == null || A.Count() == 0)
            {
                return 0;
            }

            int max = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (var element in A)
            {
                if (map.ContainsKey(element))
                {
                    continue;
                }

                var prevSum = map.ContainsKey(element - 1) ? map[element - 1] : 0;
                var nextSum = map.ContainsKey(element + 1) ? map[element + 1] : 0;
                var currentSum = prevSum + nextSum + 1;

                if (currentSum > max)
                {
                    max = currentSum;
                }

                int i = 1;
                while (map.ContainsKey(element - i))
                {
                    map[element - i] = currentSum;
                    i++;
                }

                i = 1;
                while (map.ContainsKey(element + i))
                {
                    map[element + i] = currentSum;
                    i++;
                }

                map[element] = currentSum;
            }

            return max;
        }

        //public static void Main(string[] args)
        //{
        //    int[] input = new int[] { 100, 4, 200, 1, 3, 2 };
        //    var result = longestConsecutive(input.ToList());
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
