using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    // Algorithm to determine if a string has all unique characters
    class IsUnique
    {
        //public static void Main(string[] args)
        //{
        //    string input = "abtrcgkasinzxwy";
        //    bool result = UniqueEfficient(input);
        //    Console.Write(result);
        //    Console.ReadKey();
        //}

        internal static bool Unique(string input)
        {
            bool[] charSet = new bool[128];
            foreach(char c in input)
            {
                if(charSet[c-'a'] == true)
                {
                    return false;
                }
                else
                {
                    charSet[c - 'a'] = true;
                }
            }

            return true;
        }

        internal static bool UniqueEfficient(string input)
        {
            int checker = 0;
            foreach(char c in input)
            {
                int value = c - 'a';
                if ((checker & (1<<value)) > 0)
                {
                    return false;
                }

                checker |= (1 << value);
            }

            return true;
        }
    }
}
