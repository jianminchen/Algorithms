using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    class CheckPermutation
    {
        // Given two strings check if one is a permutation of the other
        //public static void Main(string[] args)
        //{
        //    string first = "abbcz";
        //    string second = "cazbb";
        //    bool result = IsPermutation(first, second);
        //    Console.Write(result);
        //    Console.ReadKey();
        //}

        private static bool IsPermutation(string first, string second)
        {
            if(first == null || second == null || first.Length != second.Length)
            {
                return false;
            }

            int[] map = new int[256];
            foreach(char c in first)
            {
                map[c - 'a']++;
            }

            foreach(char c in second)
            {
                if(map[c-'a'] == 0)
                {
                    return false;
                }

                map[c - 'a']--;
            }

            foreach(int i in map)
            {
                if (i != 0)
                    return false;
            }

            return true;
        }
    }
}
