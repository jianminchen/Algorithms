using System;
using System.Collections.Generic;

class FlattenDictionary
{
    /*
    Flatten a Dictionary
A dictionary is a type of data structure that is supported natively in all major interpreted languages such as JavaScript, Python, Ruby and PHP, where it’s known as an Object, Dictionary, Hash and Array, respectively. In simple terms, a dictionary is a collection of unique keys and their values. The values can typically be of any primitive type (i.e an integer, boolean, double, string etc) or other dictionaries (dictionaries can be nested). However, for this exercise assume that values are either an integer, a string or another dictionary.
Given a dictionary dict, write a function flattenDictionary that returns a flattened version of it .
If you’re using a compiled language such Java, C++, C#, Swift and Go, you may want to use a Map/Dictionary/Hash Table that maps strings (keys) to a generic type (e.g. Object in Java, AnyObject in Swift etc.) to allow nested dictionaries.

Example:

input:  dict = {
            "Key1" : "1",
            "Key2" : {
                "a" : "2",
                "b" : "3",
                "c" : {
                    "d" : "3",
                    "e" : "1"
                }
            }
        }

output: {
            "Key1" : "1",
            "Key2.a" : "2",
            "Key2.b" : "3",
            "Key2.c.d" : "3",
            "Key2.c.e" : "1"
        }
    */

    public static Dictionary<string, string> Flatten(Dictionary<string, object> dict)
    {
        // your code goes here
        Dictionary<string, string> output = new Dictionary<string, string>();
        foreach (KeyValuePair<string, object> pair in dict)
        {
            FlattenDictionaryRecursive(pair.Key, pair, output);
        }

        return output;
    }

    public static void FlattenDictionaryRecursive(string currentKey, KeyValuePair<string, object> pair, Dictionary<string, string> output)
    {
        if (pair.Value is Dictionary<string, object>)
        {
            Dictionary<string, object> temporaryBuffer = pair.Value as Dictionary<string, object>;
            foreach (KeyValuePair<string, object> innerPair in temporaryBuffer)
            {
                string newCurrentKey;

                if (string.IsNullOrEmpty(innerPair.Key))
                {
                    newCurrentKey = currentKey;
                }
                else if (string.IsNullOrEmpty(currentKey))
                {
                    newCurrentKey = innerPair.Key;
                }
                else
                {
                    newCurrentKey = currentKey + "." + innerPair.Key;
                }

                FlattenDictionaryRecursive(newCurrentKey, innerPair, output);
            }
        }
        else if (pair.Value is int)
        {
            output.Add(currentKey, ((int)pair.Value).ToString());
        }
        else
        {
            output.Add(currentKey, (string)pair.Value);
        }
    }

    static void Main(string[] args)
    {
        Dictionary<string, object> input = new Dictionary<string, object>();
        input.Add("Key1", "1");
        Dictionary<string, object> thirdDictionary = new Dictionary<string, object>();
        Dictionary<string, object> fourthDictionary = new Dictionary<string, object>();
        fourthDictionary.Add("d", "3");
        fourthDictionary.Add("e", "1");

        thirdDictionary.Add("a", "2");
        thirdDictionary.Add("b", "3");
        thirdDictionary.Add("c", fourthDictionary);
        input.Add("Key2", thirdDictionary);

        var result = Flatten(input);
        foreach (var pair in result)
        {
            Console.WriteLine("{0} : {1}", pair.Key, pair.Value);
        }
        Console.ReadKey();
    }
}