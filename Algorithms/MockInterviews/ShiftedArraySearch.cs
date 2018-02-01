using System;

class ShiftedArraySearch
{
    /*
     * A sorted array of distinct integers shiftArr is shifted to the left by an unknown offset and you don’t have a pre-shifted copy of it. For instance, the sequence 1, 2, 3, 4, 5 becomes 3, 4, 5, 1, 2, after shifting it twice to the left.

Given shiftArr and an integer num, implement a function shiftedArrSearch that finds and returns the index of num in shiftArr. If num isn’t in shiftArr, return -1. Assume that the offset doesn’t equal to 0 (i.e. assume the array is shifted at least once) or to arr.length - 1 (i.e. assume the shifted array isn’t fully reversed).

Explain your solution and analyze its time and space complexities.

Example:

input:  shiftArr = [9, 12, 17, 2, 4, 5], num = 2 # shiftArr is the
                                                 # outcome of shifting
                                                 # [2, 4, 5, 9, 12, 17]
                                                 # three times to the left

output: 3 # 

     * */

    public static int ShiftedArrSearch(int[] shiftArr, int num)
    {
        // your code goes here

        if (shiftArr == null || shiftArr.Length == 0)
        {
            return -1;
        }

        int start = 0;
        int end = shiftArr.Length - 1;
        int mid = start + (end - start) / 2;
        while (start <= end)
        {
            if (num == shiftArr[mid])
            {
                return mid;
            }

            if (shiftArr[start] < shiftArr[mid])  //case 1
            {
                if (num >= shiftArr[start] && num < shiftArr[mid])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            else  //if(shiftArr[start] > shiftArr[mid])  // case 2
            {
                if (num > shiftArr[mid] && num <= shiftArr[end])
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            mid = start + (end - start) / 2;
        }

        return -1;
    }

    //case 1:  9 12 17 2 4 5    num = 4
    // num = 12
    //case 2:  17 2 4 5 9 12
    //case 3:  4 5 9 12 17 2


    static void Main(string[] args)
    {
        int[] input = new int[2] { 1, 2 };
        var result = ShiftedArrSearch(input, 2);
        Console.WriteLine(result);
    }
}
/*
[0,1,2,3,4,5], 1  exp = 1

[1,2,3,4,5,0], 0 exp = 5
 
[9,12,17,2,4,5], 17 exp = 2
 
[9,12,17,2,4,5,6], 4 exp = 4
*/
