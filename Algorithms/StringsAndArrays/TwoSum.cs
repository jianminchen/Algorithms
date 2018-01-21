using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class TwoSum
    {
        //static void Main(string[] args)
        //{
        //    int[] input = { 13};
        //    int target = 13;

        //    Solution solution = new Solution();
        //    int[] result = solution.TwoSum(input, target);
        //    if(result != null)
        //    {
        //        Console.WriteLine(result[0]);
        //        Console.WriteLine(result[1]);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Not found");
        //    }

        //    Console.ReadKey();
        //}

        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                if (nums != null)
                {
                    Dictionary<int, int> table = new Dictionary<int, int>();
                    for (int i = 0; i < nums.Length; i++)
                    {
                        int diff = target - nums[i];
                        if (!table.ContainsKey(diff))
                        {
                            table.Add(diff, i);
                        }
                    }

                    int[] result = new int[2];

                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (table.ContainsKey(nums[i]) && i != table[nums[i]])
                        {
                            result[1] = table[nums[i]];
                            result[0] = i;
                            return result;
                        }
                    }
                }

                return null;
            }
        }
    }
}
