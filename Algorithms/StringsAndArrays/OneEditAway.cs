using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringManipulation
{
    class OneEditAway
    {
        //public static void Main(string[] args)
        //{
        //    string first = "a";
        //    string second = "a";

        //    bool result = IsOneEditAway(first, second);
        //    Console.Write(result);   
        //    Console.ReadKey();
        //}

        internal static bool IsOneEditAway(string first, string second)
        {
            if (Math.Abs(first.Length - second.Length) > 1)
            {
                return false;
            }

            bool foundDifference = false;
            string s1 = first.Length > second.Length ? second : first;
            string s2 = first.Length > second.Length ? first : second;
            // s1 <= s2

            int i = 0;
            int j = 0;
            while (i < s1.Length && j < s2.Length)
            {
                if (s1[i] != s2[j])
                {
                    if (foundDifference == true)
                    {
                        return false;
                    }

                    foundDifference = true;
                    if (s1.Length == s2.Length)
                    {
                        i++;
                    }
                }
                else
                {
                    i++;
                }

                j++;
            }

            return true;
        }
    }
}
