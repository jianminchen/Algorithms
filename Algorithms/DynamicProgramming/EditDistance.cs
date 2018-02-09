using System;

class EditDistance
{
    public static int minDistance(string A, string B)
    {
        int[,] table = new int[A.Length + 1, B.Length + 1];

        for (int i = 0; i <= A.Length; i++)
        {
            for (int j = 0; j <= B.Length; j++)
            {
                if (i == 0)
                {
                    table[i, j] = j;
                }
                else if (j == 0)
                {
                    table[i, j] = i;
                }
                else if (A[i-1] == B[j-1])
                {
                    table[i, j] = table[i-1, j-1];
                }
                else
                {
                    table[i, j] = 1 + Math.Min(Math.Min(table[i, j-1], table[i-1, j]), table[i-1, j-1]);
                }
            }
        }

        return table[A.Length, B.Length];
    }

    //public static void Main(string[] args)
    //{
    //    string first = "sunday";
    //    string second = "saturday";

    //    Console.WriteLine(minDistance(first, second));
    //    Console.ReadKey();
    //}
}
