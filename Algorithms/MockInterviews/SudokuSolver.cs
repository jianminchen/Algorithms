namespace Algorithms.MockInterviews
{
    using System;
    using System.Collections.Generic;

    class Solution
    {
        public static List<int> GetCandidates(char[,] board, int row, int col)
        {
            HashSet<int> map = new HashSet<int>();
            for (int i = 1; i < 10; i++)
            {
                map.Add(i);
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                char element = board[i, col];
                int number = element - '0';
                if (element != '.')
                {
                    if (map.Contains(number))
                    {
                        map.Remove(number);
                    }
                }
            }

            for (int i = 0; i < board.GetLength(1); i++)
            {
                char element = board[row, i];
                int number = element - '0';
                if (element != '.')
                {
                    if (map.Contains(number))
                    {
                        map.Remove(number);
                    }
                }
            }

            List<int> candidates = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                if (map.Contains(i))
                {
                    candidates.Add(i);
                }
            }

            return candidates;
        }
        
        public static bool SudokuSolve(char[,] board)
        {
            // your code goes here
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            List<int> candidates = null;
            int minRow = 0;
            int minCol = 0;
            int min = 10;
            bool emptyCell = false;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i, j] == '.')
                    {
                        emptyCell = true;
                        var tempCandidates = GetCandidates(board, i, j);
                        if (tempCandidates.Count < min)
                        {
                            candidates = tempCandidates;
                            min = tempCandidates.Count;
                            minRow = i;
                            minCol = j;
                        }
                    }
                }
            }
            if (emptyCell == false)
            {
                return true;
            }

            if (candidates == null || candidates.Count == 0)
            {
                return false;
            }

            foreach (var element in candidates)
            {
                board[minRow, minCol] = GetChar(element);
                if (SudokuSolve(board) == true)
                {
                    return true;
                }
            }

            return false;
        }
        
        static char GetChar(int element)
        {
            switch (element)
            {
                case 1:
                    return '1';
                case 2:
                    return '2';
                case 3:
                    return '3';
                case 4:
                    return '4';
                case 5:
                    return '5';
                case 6:
                    return '6';
                case 7:
                    return '7';
                case 8:
                    return '8';
                case 9:
                    return '9';
            }

            return '0';
        }

        static void Main(string[] args)
        {
            char[,] board = new char[,]  {{ '.', '8', '9', '.', '4', '.', '6', '.', '5' },
                                          { '.', '7', '.', '.', '.', '8', '.', '4', '1' },
                                          { '5', '6', '.', '9', '.', '.', '.', '.', '8' },
                                          { '.', '.', '.', '7', '.', '5', '.', '9', '.' },
                                          { '.', '9', '.', '4', '.', '1', '.', '5', '.' },
                                          { '.', '3', '.', '9', '.', '6', '.', '1', '.' },
                                          { '8', '.', '.', '.', '.', '.', '.', '.', '7' },
                                          { '.', '2', '.', '8', '.', '.', '.', '6', '.' },
                                          { '.', '.', '6', '.', '7', '.', '.', '8', '.' }};
            // output expected false

            bool result = SudokuSolve(board);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
