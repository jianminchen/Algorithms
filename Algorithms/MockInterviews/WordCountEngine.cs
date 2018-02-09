using System;
using System.Collections.Generic;
using System.Text;

/*
 * Word Count Engine
Implement a document scanning function wordCountEngine, which receives a string document and returns a list of all unique words in it and their number of occurrences, sorted by the number of occurrences in a descending order. If two or more words have the same count, they should be sorted alphabetically (in an ascending order). Assume that all letters are in english alphabet. You function should be case-insensitive, so for instance, the words “Perfect” and “perfect” should be considered the same word.

The engine should strip out punctuation (even in the middle of a word) and use whitespaces to separate words.

Analyze the time and space complexities of your solution. Try to optimize for time while keeping a polynomial space complexity.

Examples:

input:  document = "Practice makes perfect. you'll only
                    get Perfect by practice. just practice!"

output: [ ["practice", "3"], ["perfect", "2"],
          ["by", "1"], ["get", "1"], ["just", "1"],
          ["makes", "1"], ["only", "1"], ["youll", "1"]  ]

 * */
class WordCountEngine
{
    public static string[,] GetWordCountEngine(string document)
    {
        // your code goes here
        if (string.IsNullOrEmpty(document))
        {
            return null;
        }

        Dictionary<string, int> occuranceMap = new Dictionary<string, int>();
        int maxOccuranceCount = 0;

        string[] tokens = document.ToLower().Split(' ');
        foreach (var token in tokens)
        {
            var sanitizedToken = GetSanitizedToken(token);
            if (!string.IsNullOrEmpty(sanitizedToken))
            {
                if (occuranceMap.ContainsKey(sanitizedToken))
                {
                    occuranceMap[sanitizedToken]++;

                    if (occuranceMap[sanitizedToken] > maxOccuranceCount)
                    {
                        maxOccuranceCount = occuranceMap[sanitizedToken];
                    }
                }
                else
                {
                    occuranceMap.Add(sanitizedToken, 1);
                }
            }
        }

        List<string>[] bucketMap = new List<string>[maxOccuranceCount];

        foreach (var pair in occuranceMap)
        {
            if (bucketMap[pair.Value - 1] == null)
            {
                List<string> list = new List<string>();
                list.Add(pair.Key);
                bucketMap[pair.Value - 1] = list;
            }
            else
            {
                bucketMap[pair.Value - 1].Add(pair.Key);
            }
        }

        string[,] output = new string[occuranceMap.Count, 2];

        int j = bucketMap.Length - 1;
        int i = 0;
        while (i < occuranceMap.Count && j >= 0)
        {
            if (bucketMap[j] != null)
            {
                foreach (var item in bucketMap[j])
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        output[i, 0] = item;
                        output[i, 1] = (j + 1).ToString();
                        i++;
                    }
                }
            }
            j--;
        }

        return output;
    }

    static string GetSanitizedToken(string token)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in token)
        {
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9'))
            {
                sb.Append(c);
            }
        }

        return sb.ToString();
    }

    //static void Main(string[] args)
    //{
    //    string input = "Practice makes perfect.you'll only get Perfect by practice. just practice!";
    //    var result = GetWordCountEngine(input);
    //    for(int i = 0; i < result.GetLength(0); i++)
    //    {
    //        Console.WriteLine(result[i, 0]);
    //        Console.WriteLine(result[i, 1]);
    //    }

    //    Console.ReadKey();
    //}

    /*
    Step 1: Extract tokens from the input sentence. Here we create words only from the list of chars allowed
            Add the word to the dictionary or increment count if it is already present
    Step 2: Traverse the dictionary and create a bucket array with the words at the index
    Step 3: to format it as the required output
    Take care of the alphabetical sorting of the words with same occurance

    */
}