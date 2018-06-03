using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    class CheckWaterFlow
    {
        public static int[,] CheckWaterFlowMethod(int[,] input)
        {
            if(input == null || (input.GetLength(0) == 0 && input.GetLength(1) == 0))
            {
                return new int[0, 0];
            }

            // check if water flows into Pacific
            var pacificResult = CheckPacific(input);

            // check if water flows into Atlantic

            // get the intersection and return as result

            return null;
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

            CheckPacificRecursive(input, pacificMap, visited, 1, 1);

            return pacificMap;
        }

        public static void CheckPacificRecursive(int[,] input, bool[,] map, bool[,] visited, int i, int j)
        {
            visited[i, j] = true;
            if(i-1 > 0 && visited[i-1, j] == false)
            {
                CheckPacificRecursive(input, map, visited, i - 1, j);
                if(map[i - 1, j] == true && input[i - 1, j] <= input[i, j])
                {
                    map[i, j] = true;
                }
            }

            if (j - 1 > 0 && visited[i, j-1] == false)
            {
                CheckPacificRecursive(input, map, visited, i, j-1);
                if(map[i, j - 1] == true && input[i, j - 1] <= input[i, j])
                {
                    map[i, j] = true;
                }
            }

            if (i + 1 < input.GetLength(0) && visited[i + 1, j] == false)
            {
                CheckPacificRecursive(input, map, visited, i + 1, j);
                if(map[i + 1, j] == true && input[i + 1, j] <= input[i, j])
                {
                    map[i, j] = true;
                }
            }

            if (j + 1 < input.GetLength(1) && visited[i, j+1] == false)
            {
                CheckPacificRecursive(input, map, visited, i , j+1);
                if (map[i, j + 1] == true && input[i, j + 1] <= input[i, j])
                {
                    map[i, j] = true;
                }
            }
        }

        //public static void Main(string[] args)
        //{
        //    int[,] input = new int[5, 5] { {1,6,5,6,1 }, {10,5,8,10,1 }, {9,4,3,2,1 }, {10,12,14,15,16 }, {13,14,15,15,15 } };
        //    var result = CheckWaterFlowMethod(input);
        //    Console.ReadKey();
        //}
    }    
}
