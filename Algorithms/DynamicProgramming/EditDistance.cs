using System;

class EditDistance
{
    public static int minDistance(string A, string B)
    {
        if (string.IsNullOrEmpty(A))
        {
            return B.Length;
        }
        if (string.IsNullOrEmpty(B))
        {
            return A.Length;
        }

        int[,] table = new int[A.Length + 1, B.Length + 1];

        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < B.Length; j++)
            {

                if (A[i] == B[j])
                {
                    table[i + 1, j + 1] = table[i, j];
                }
                else
                {
                    table[i + 1, j + 1] = 1 + Math.Min(table[i + 1, j], table[i, j + 1]);
                }
            }
        }

        return table[A.Length, B.Length];
    }

    //public static void Main(string[] args)
    //{
    //    string first = "toast";
    //    string second = "best";

    //    Console.WriteLine(minDistance(first, second));
    //    Console.ReadKey();
    //}
}
