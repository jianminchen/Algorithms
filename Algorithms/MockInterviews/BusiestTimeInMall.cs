using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{/*
    Busiest Time in The Mall
The Westfield Mall management is trying to figure out what the busiest moment at the mall was last year. You’re given data extracted from the mall’s door detectors. Each data point is represented as an integer array whose size is 3. The values at indices 0, 1 and 2 are the timestamp, the count of visitors, and whether the visitors entered or exited the mall (0 for exit and 1 for entrance), respectively. Here’s an example of a data point: [ 1440084737, 4, 0 ].
Note that time is given in a Unix format called Epoch, which is a nonnegative integer holding the number of seconds that have elapsed since 00:00:00 UTC, Thursday, 1 January 1970.
Given an array, data, of data points, write a function findBusiestPeriod that returns the time at which the mall reached its busiest moment last year. The return value is the timestamp, e.g. 1480640292. Note that if there is more than one period with the same visitor peak, return the earliest one.
Assume that the array data is sorted in an ascending order by the timestamp. Explain your solution and analyze its time and space complexities.
Example:
input:  data = [ [1487799425, 14, 1], 
                 [1487799425, 4,  0],
                 [1487799425, 2,  0],
                 [1487800378, 10, 1],
                 [1487801478, 18, 0],
                 [1487801478, 18, 1],
                 [1487901013, 1,  0],
                 [1487901211, 7,  1],
                 [1487901211, 7,  0] ]

output: 1487800378 # since the increase in the number of people
                   # in the mall is the highest at that point

    */
    class BusiestTimeInMall
    {
        public static int FindBusiestPeriod(int[,] data)
        {
            int rows = data.GetLength(0);
            int busiestTime = 0;
            int maxNumberOfPeople = 0;
            int totalNumberOfPeopleInMall = 0;
            int i = 0;
            while(i < rows)
            {
                int time = data[i, 0];
                int j = i;
                int numberOfPeople = 0;
                while (j < rows && data[j,0] == time)
                {
                    int action = data[j, 2];
                    if(action == 0)
                    {
                        numberOfPeople -= data[j, 1];
                    }
                    else
                    {
                        numberOfPeople += data[j, 1];
                    }

                    j++;
                }

                i = j;
                totalNumberOfPeopleInMall += numberOfPeople;
                if(totalNumberOfPeopleInMall > maxNumberOfPeople)
                {
                    maxNumberOfPeople = totalNumberOfPeopleInMall;
                    busiestTime = time;
                }
            }

            return busiestTime;
        }

        //static void Main(string[] args)
        //{
        //    int[,] input = new int[,]{{1487799425, 14, 1 },
        //         { 1487799425, 4, 0 },
        //         { 1487799425, 2, 0 },
        //         { 1487800378, 10, 1 },
        //         { 1487801478, 18, 0 },
        //         { 1487801478, 18, 1 },
        //         { 1487901013, 1,  0 },
        //         { 1487901211, 7,  1 },
        //         { 1487901211, 7,  0 }};

        //    var busiestTime = FindBusiestPeriod(input);
        //    Console.WriteLine(busiestTime);
        //    Console.ReadKey();
        //}
    }
}
