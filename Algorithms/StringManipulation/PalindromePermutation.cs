using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringManipulation
{
    class PalindromePermutation
    {
        //static void Main(string[] args)
        //{
        //    string input = "t3atco121cabb32";

        //    bool result = IsPalindromePermutationOptimized(input);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}

        internal static bool IsPalindromePermutation(string input)
        {
            var map = BuildMap(input);
            bool foundOdd = false;
            foreach (char key in map.Keys)
            {
                if (map[key] % 2 != 0)
                {
                    if (foundOdd == true)
                    {
                        return false;
                    }
                    else
                    {
                        foundOdd = true;
                    }
                }
            }

            return true;
        }

        internal static Dictionary<char, int> BuildMap(string input)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (map.ContainsKey(c))
                {
                    map[c]++;
                }
                else
                {
                    map.Add(c, 1);
                }
            }

            return map;
        }

        internal static bool IsPalindromePermutationOptimized(string input)
        {
            int bitVector = CreateBitVector(input);

            if ((bitVector & (bitVector - 1)) == 0)
            {
                //check atmost 1 bit is set
                return true;
            }
            return false;
        }

        internal static int CreateBitVector(string input)
        {
            int bitVector = 0;
            foreach (char c in input)
            {
                int bitPosition = c - '0';
                bitVector = ToggleBit(bitVector, bitPosition);
            }

            return bitVector;
        }

        internal static int ToggleBit(int bitVector, int bitPosition)
        {
            int mask = 1 << bitPosition;
            if ((bitVector & mask) == 0)
            {
                //bit is not set
                bitVector |= mask;
            }
            else
            {
                //bit is set
                bitVector = bitVector & ~mask;
            }

            return bitVector;
        }
    }
}
