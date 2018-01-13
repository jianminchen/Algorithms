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
        public static void Main(string[] args)
        {
            string input = "abtrcgksinzxwy";
            bool result = Unique(input);
            Console.Write(result);
            Console.ReadKey();
        }

        internal static bool Unique(string input)
        {
            bool[] charSet = new bool[128];
            foreach(char c in input)
            {
                if(charSet[c-0] == true)
                {
                    return false;
                }
                else
                {
                    charSet[c - 0] = true;
                }
            }

            return true;
        }
    }
}
