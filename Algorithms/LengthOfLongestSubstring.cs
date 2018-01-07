using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    class LengthOfLongestSubstr
    {
        // length of longest substr with unique characters

        //public static void Main(string[] args)
        //{
        //    string input = "aabcdagkabcdlpo";
        //    Solution solution = new Solution();
        //    var result = solution.LengthOfLongestSubstring(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}

        public class Solution
        {
            public int LengthOfLongestSubstring(string s)
            {
                int maxLength = 0;
                int length = 0;
                if (!string.IsNullOrWhiteSpace(s))
                {
                    for (int i = 0; i < s.Length; i++)
                    {
                        HashSet<char> table = new HashSet<char>();
                        table.Add(s[i]);
                        length = 1;

                        for (int j = i + 1; j < s.Length; j++)
                        {
                            if (table.Contains(s[j]))
                            {
                                break;
                            }
                            else
                            {
                                table.Add(s[j]);
                                length++;
                            }
                        }

                        if (length > maxLength)
                        {
                            maxLength = length;
                        }
                    }

                }

                return maxLength;
            }
        }
    }
}
