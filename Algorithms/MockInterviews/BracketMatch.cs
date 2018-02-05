using System;

class BracketMatch
{
    public static int GetBracketMatch(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return 0;
        }

        int countUnmatchedOpeningBrackets = 0;
        int countUnmatchedClosingBrackets = 0;
        foreach (char c in text)
        {
            if (c == '(')
            {
                countUnmatchedOpeningBrackets++;
            }
            else if (c == ')')
            {
                if (countUnmatchedOpeningBrackets > 0)
                {
                    countUnmatchedOpeningBrackets--;
                }
                else
                {
                    countUnmatchedClosingBrackets++;
                }
            }
        }

        return countUnmatchedOpeningBrackets + countUnmatchedClosingBrackets;
    }

    //static void Main(string[] args)
    //{
    //    string input = "())(";
    //    var result = GetBracketMatch(input);
    //    Console.WriteLine(result);
    //    Console.ReadKey();
    //}
}
