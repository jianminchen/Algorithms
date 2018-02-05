using System;

class SentenceReverse
{
    public static char[] ReverseWords(char[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            return arr;
        }

        int startIndex = 0;
        int endIndexOfWord = 0;
        while (startIndex < arr.Length)
        {
            endIndexOfWord = startIndex;
            while (endIndexOfWord < arr.Length && arr[endIndexOfWord] != ' ')
            {
                endIndexOfWord++;
            }

            int nextWordStartIndex = endIndexOfWord;
            while (nextWordStartIndex < arr.Length && arr[nextWordStartIndex] == ' ')
            {
                nextWordStartIndex++;
            }

            int startIndexOfWord = startIndex;

            endIndexOfWord--;
            while (endIndexOfWord < arr.Length && startIndexOfWord < endIndexOfWord)
            {
                Swap(arr, startIndexOfWord, endIndexOfWord);
                startIndexOfWord++;
                endIndexOfWord--;
            }

            startIndex = nextWordStartIndex;
        }

        // tcefrep   sekam  ecitcarp

        startIndex = 0;
        endIndexOfWord = arr.Length - 1;
        while (startIndex < endIndexOfWord)
        {
            Swap(arr, startIndex, endIndexOfWord);
            startIndex++;
            endIndexOfWord--;
        }
        // practice makes perfect
        return arr;
    }

    private static void Swap(char[] arr, int startIndex, int endIndex)
    {
        char tempBuffer = arr[startIndex];
        arr[startIndex] = arr[endIndex];
        arr[endIndex] = tempBuffer;
    }

    static void Main(string[] args)
    {
        char[] input = new char[22] { 'p', 'e', 'r', 'f', 'e', 'c', 't', ' ', 'm', 'a', 'k', 'e', 's', ' ', 'p', 'r', 'a', 'c', 't', 'i', 'c', 'e' };
        var result = ReverseWords(input);
        foreach (char character in result)
        {
            Console.WriteLine(character);
        }

        Console.ReadKey();
    }


    /*
    problem statement: reverse words in a sentence
    input is an array of words
    perfect -> tcefrep  makes->sekam  
    tcefrep   sekam  ecitcarp
    practice makes perfect
    */
}

