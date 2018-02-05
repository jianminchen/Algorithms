using System;

class PancakeSort
{
    public static void Flip(int[] arr, int k)
    {
        if (arr == null || arr.Length == 0)
        {
            return;
        }

        int i = 0;
        int j = k;
        while (i < j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++;
            j--;
        }
    }

    public static int[] Sort(int[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int indexOfMaxElement = GetMaxElementIndex(arr, i);
            Flip(arr, indexOfMaxElement);
            Flip(arr, i);
        }

        return arr;
    }

    private static int GetMaxElementIndex(int[] arr, int start)
    {
        int maxElement = 0;
        int indexOfMaxElement = 0;
        for (int i = start; i >= 0; i--)
        {
            if (arr[i] > maxElement)
            {
                maxElement = arr[i];
                indexOfMaxElement = i;
            }
        }

        return indexOfMaxElement;
    }

    //static void Main(string[] args)
    //{
    //    int[] arr = new int[5] { 1, 5, 4, 3, 2 };
    //    var result = Sort(arr);
    //    foreach (var element in result)
    //    {
    //        Console.WriteLine(element);
    //    }

    //    Console.ReadKey();
    //}
}

