using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    class CheckWaterFlow
    {
        public static int[][] CheckWaterFlowMethod(int[,] input)
        {
            if(input == null || (input.GetLength(0) == 0 && input.GetLength(1) == 0))
            {
                return new int[0][];
            }

            // check if water flows into Pacific
            var pacificResult = CheckPacific(input);

            // check if water flows into Atlantic
            var atlanticResult = CheckAtlantic(input);

            // get the intersection and return as result
            List<int[]> output = new List<int[]>();
            for (int i = 0; i < input.GetLength(0); i++)
            {
                for(int j = 0; j< input.GetLength(1); j++)
                {
                    if ((pacificResult[i,j] == atlanticResult[i,j]) && pacificResult[i,j] == true)
                    {
                        output.Add(new int[2] { i, j });
                    }
                }
            }

            return output.ToArray();
        }

        public static bool[,] CheckPacific(int[,] input)
        {
            bool[,] pacificMap = new bool[input.GetLength(0), input.GetLength(1)];
            bool[,] visited = new bool[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                pacificMap[i, 0] = true;
                visited[i, 0] = true;
            }

            for (int i = 0; i < input.GetLength(1); i++)
            {
                pacificMap[0, i] = true;
                visited[0, i] = true;
            }

            CheckRecursive(input, pacificMap, visited, 1, 1);

            return pacificMap;
        }

        public static void CheckRecursive(int[,] input, bool[,] map, bool[,] visited, int i, int j)
        {
            visited[i, j] = true;
            if(i-1 >= 0)
            {
                if(visited[i-1,j] == false)
                {
                    CheckRecursive(input, map, visited, i - 1, j);
                }

                if (map[i - 1, j] == true && input[i - 1, j] <= input[i, j])
                {
                    map[i, j] = true;
                }
            }

            if (j - 1 >= 0 )
            {
                if (visited[i, j-1] == false)
                {
                    CheckRecursive(input, map, visited, i, j - 1);
                }
                
                if(map[i, j - 1] == true && input[i, j - 1] <= input[i, j])
                {
                    map[i, j] = true;
                }
            }

            if (i + 1 < input.GetLength(0))
            {
                if (visited[i+1, j] == false)
                {
                    CheckRecursive(input, map, visited, i + 1, j);
                }

                if (map[i + 1, j] == true && input[i + 1, j] <= input[i, j])
                {
                    map[i, j] = true;
                }
            }

            if (j + 1 < input.GetLength(1))
            {
                if (visited[i, j+1] == false)
                {
                    CheckRecursive(input, map, visited, i, j + 1);
                }

                if (map[i, j + 1] == true && input[i, j + 1] <= input[i, j])
                {
                    map[i, j] = true;
                }
            }
        }

        public static bool[,] CheckAtlantic(int[,] input)
        {
            bool[,] atlanticMap = new bool[input.GetLength(0), input.GetLength(1)];
            bool[,] visited = new bool[input.GetLength(0), input.GetLength(1)];

            for (int i = 0; i < input.GetLength(0); i++)
            {
                atlanticMap[i, input.GetLength(1)-1] = true;
                visited[i, input.GetLength(1) - 1] = true;
            }

            for (int i = 0; i < input.GetLength(1); i++)
            {
                atlanticMap[input.GetLength(0)-1, i] = true;
                visited[input.GetLength(0) - 1, i] = true;
            }

            CheckRecursive(input, atlanticMap, visited, 0, 0);

            return atlanticMap;
        }

        
//        public static void Main(string[] args)
//        {
//            int[,] input = new int[5, 5] 
//            { { 1, 2, 2, 3, 5 }, 
//              { 3, 2, 3, 4, 4 }, 
//              { 2, 4, 5, 3, 1 }, 
//              { 6, 7, 1, 4, 5 }, 
//              { 5, 1, 1, 2, 4 } };
///*
//  Pacific ~   ~   ~   ~   ~ 
//       ~  1   2   2   3  (5) *
//       ~  3   2   3  (4) (4) *
//       ~  2   4  (5)  3   1  *
//       ~ (6) (7)  1   4   5  *
//       ~ (5)  1   1   2   4  *
//          *   *   *   *   * Atlantic
          
//return [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
//*/
//            var result = CheckWaterFlowMethod(input);
//            Console.ReadKey();
//        }
    }    
}
