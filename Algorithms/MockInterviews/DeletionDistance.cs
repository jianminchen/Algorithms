using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    class DeletionDistance
    {
        public static int DeletionDistance(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2))
            {
                return 0;
            }
            else if (string.IsNullOrEmpty(str1))
            {
                return str2.Length;
            }
            else if (string.IsNullOrEmpty(str2))
            {
                return str1.Length;
            }

            if (str1[str1.Length - 1] == str2[str2.Length - 1])
            {
                return DeletionDistance(str1.Substring(0, str1.Length - 1), str2.Substring(0, str2.Length - 1));
            }
            else
            {
                return 1 + Math.Min(DeletionDistance(str1.Substring(0, str1.Length - 1), str2),
                                 DeletionDistance(str1, str2.Substring(0, str2.Length - 1)));
            }
        }

        static void Main(string[] args)
        {
            string str1 = "dog";
            string str2 = "frog";

            var deletionDistance = DeletionDistance(str1, str2);
            Console.WriteLine(deletionDistance);

        }
    }
}
