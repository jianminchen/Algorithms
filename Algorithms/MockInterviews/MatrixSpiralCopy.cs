using System;

class MatrixSpiralCopy
{
    public static int[] SpiralCopy(int[,] inputMatrix)
    {
        // your code goes here
        int rowLength = inputMatrix.GetLength(0);
        int colLength = inputMatrix.GetLength(1);

        int[] result = new int[(rowLength * colLength)];
        rowLength--;
        colLength--;
        int counter = 0;
        int i = 0;
        int j = 0;
        if (rowLength == 0 && colLength == 0)
        {
            result[counter] = inputMatrix[rowLength, colLength];
        }
        else
        {
            while (rowLength >= 0 && colLength >= 0 && counter < result.Length)
            {
                for (int x = j; x < colLength; x++)
                {
                    result[counter++] = inputMatrix[j, x];
                }

                for (int x = i; x < rowLength; x++)
                {
                    result[counter++] = inputMatrix[x, colLength];
                }

                for (int x = colLength; x > j; x--)
                {
                    result[counter++] = inputMatrix[rowLength, x];
                }

                for (int x = rowLength; x > i; x--)
                {
                    result[counter++] = inputMatrix[x, i];
                }

                i++;
                j++;
                rowLength--;
                colLength--;
            }
        }
        return result;
    }

    //static void Main(string[] args)
    //{
    //    //int[,] inputMatrix = new int[4, 5];
    //    //for (int i = 0; i < inputMatrix.GetLength(0); i++)
    //    //{
    //    //    for (int j = 0; j < inputMatrix.GetLength(1); j++)
    //    //    {
    //    //        inputMatrix[i, j] = inputMatrix.GetLength(1) * i + j;
    //    //    }
    //    //}

    //    //int[,] inputMatrix = new int[1, 1];
    //    //inputMatrix[0, 0] = 1;

    //    int[,] inputMatrix = new int[2, 5];
    //    for (int i = 0; i < inputMatrix.GetLength(0); i++)
    //    {
    //        for (int j = 0; j < inputMatrix.GetLength(1); j++)
    //        {
    //            inputMatrix[i, j] = inputMatrix.GetLength(1) * i + j;
    //        }
    //    }


    //    var result = SpiralCopy(inputMatrix);
    //    for (int i = 0; i < result.Length; i++)
    //    {
    //        Console.WriteLine(result[i]);
    //    }
    //}
}

