using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    class BasicRegexParser
    {
        /*
         * Basic Regex Parser
Implement a regular expression function isMatch that supports the '.' and '*' symbols. The function receives two strings - text and pattern - and should return true if the text matches the pattern as a regular expression. For simplicity, assume that the actual symbols '.' and '*' do not appear in the text string and are used as special symbols only in the pattern string.

In case you aren’t familiar with regular expressions, the function determines if the text and pattern are the equal, where the '.' is treated as a single a character wildcard (see third example), and '*' is matched for a zero or more sequence of the previous letter (see fourth and fifth examples). For more information on regular expression matching, see the Regular Expression Wikipedia page.

Explain your algorithm, and analyze its time and space complexities.

Examples:

input:  text = "aa", pattern = "a"
output: false

input:  text = "aa", pattern = "aa"
output: true

input:  text = "abc", pattern = "a.c"
output: true

input:  text = "abbb", pattern = "ab*"
output: true

input:  text = "acd", pattern = "ab*c."
output: true
         */
        public static bool IsMatch(string text, string pattern)
        {
            return IsMatchHelper(text, pattern, 0, 0);
        }

        public static bool IsMatchHelper(string text, string pattern, int textIndex, int patternIndex)
        {
            // Base cases
            if(textIndex >= text.Length)
            {
                if(patternIndex >= pattern.Length)
                {
                    return true;
                }
                else
                {
                    if(patternIndex + 1 < pattern.Length && pattern[patternIndex + 1] == '*')
                    {
                        return IsMatchHelper(text, pattern, textIndex, patternIndex + 2);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (patternIndex >= pattern.Length && textIndex < text.Length)
            {
                return false;
            }
            else if(patternIndex + 1 < pattern.Length && pattern[patternIndex + 1] == '*')
            {
                if(pattern[patternIndex] == '.' || pattern[patternIndex] == text[textIndex])
                {
                    return IsMatchHelper(text, pattern, textIndex + 1, patternIndex) ||
                           IsMatchHelper(text, pattern, textIndex, patternIndex + 2);
                }
                else
                {
                    return IsMatchHelper(text, pattern, textIndex, patternIndex + 2);
                }
            }
            else if (pattern[patternIndex] == '.' || pattern[patternIndex] == text[textIndex])
            {
                return IsMatchHelper(text, pattern, textIndex + 1, patternIndex + 1);
            }
            else
            {
                return false;
            }
        }
        

        public static void Main(string[] args)
        {
            /*
                Test cases
                ""   "" expected true
                "aa" "a" expected false
                "bb" "bb"  expected true
                "" "a*" expected true
                "abbdbb" "ab*d" expected false
                "aba"  "a.a"  expected true
                "acd" "ab*c" expected true
                "abaa" "a.*a*" expected true                
            */
        string text = "";
            string pattern = "a*";
            var result = IsMatch(text, pattern);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
