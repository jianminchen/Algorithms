using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    /*
     * Given two strings, S1 and S2, write code to check if S2 is a rotation of S1
     * */
    class IsRotation
    {
        private static bool IsRotated(string s1, string s2)
        {
            if(string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2))
            {
                return false;
            }

            if(s1.Length != s2.Length)
            {
                return false;
            }

            string temp = s1 + s1;
            if (temp.Contains(s2))
                return true;
            else
                return false;
        }

        //public static void Main(string[] args)
        //{
        //    string s1 = "helloworld";
        //    string s2 = "worlhdello";
        //    bool result = IsRotated(s1, s2);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
