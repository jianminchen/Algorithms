using System;
using System.Text;

class DecryptMessages
{
    /*
     * Decrypt Message
An infamous gang of cyber criminals named “The Gray Cyber Mob”, which is behind many hacking attacks and drug trafficking, has recently become a target for the FBI. After intercepting some of their messages, which looked like complete nonsense, the agency learned that they indeed encrypt their messages, and studied their method of encryption.

Their messages consist of lowercase latin letters only, and every word is encrypted separately as follows:

Convert every letter to its ASCII value. Add 1 to the first letter, and then for every letter from the second one to the last one, add the value of the previous letter. Subtract 26 from every letter until it is in the range of lowercase letters a-z in ASCII. Convert the values back to letters.

For instance, to encrypt the word “crime”

Decrypted message:	c	r	i	m	e
Step 1:	99	114	105	109	101
Step 2:	100	214	319	428	529
Step 3:	100	110	111	116	113
Encrypted message:	d	n	o	t	q
     * */
    public static string Decrypt(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            return word;
        }

        int[] encrypted = GetAsciiValues(word);
        int[] decrypted = new int[word.Length];
        decrypted[0] = ((word[0] - 1) < 'a') ? 'z' : (word[0] - 1);
        int prevSum = decrypted[0] + 1;
        for (int i = 1; i < word.Length; i++)
        {
            int n = 0;
            int tempDecrypted = 0;
            int temp = encrypted[i] - prevSum;
            while (tempDecrypted < 'a')
            {
                tempDecrypted = temp + (n * 26);
                n++;
            }

            decrypted[i] = tempDecrypted;
            prevSum += decrypted[i];
        }

        string result = GetString(decrypted);
        return result;
    }

    static int[] GetAsciiValues(string word)
    {
        int[] wordMap = new int[word.Length];
        int i = 0;
        foreach (char c in word)
        {
            wordMap[i] = (int)c;
            i++;
        }

        return wordMap;
    }

    static string GetString(int[] asciiValues)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < asciiValues.Length; i++)
        {
            sb.Append((char)asciiValues[i]);
        }

        return sb.ToString();
    }

    /*
    D[0] 
    E[0]
    z - 122    97-122
    124 - 26 = 98  b   b could come from z
    a   97 +1 = 98  = b  could come from a

    getting the first letter: -1 with cyclic rotation

    first + 1 + second = encryptedSecond
    second = encryptedSecond -first -1;

    E[i] = prevSum + D[i] - (26 *n);
    D[i] = E[i] + (26 * n) - E[i-1];  n => 0 - 25
    x + 100 - (n* 26) = 110
    x = 110 + (n * 26) - 100
    x = 10 + (n * 26)   97 -122  
    x = 114 = r

    xo + (99 + 115) - (n * 26) = 111
    xo = 111 - 99 - 115 + (n * 26)
    D[i] = (E[i] - prevsum + (n * 26))   in the range 97-122



    d     n     o    t    q
    c       
    99

    If i == 0
       D[i] = E[i] - 1  // special handle
    else
      D[i] = E[i] - D[i-1] - 1;

    */
    public static void Main(string[] args)
    {
        string result = Decrypt("dnotq");
        Console.WriteLine(result);
        Console.ReadKey();
    }
}

