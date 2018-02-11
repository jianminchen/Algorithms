using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * Time Planner
Implement a function meetingPlanner that given the availability, slotsA and slotsB, of two people and a meeting duration dur, returns the earliest time slot that works for both of them and is of duration dur. If there is no common time slot that satisfies the duration requirement, return null.

Time is given in a Unix format called Epoch, which is a nonnegative integer holding the number of seconds that have elapsed since 00:00:00 UTC, Thursday, 1 January 1970.

Each person’s availability is represented by an array of pairs. Each pair is an epoch array of size two. The first epoch in a pair represents the start time of a slot. The second epoch is the end time of that slot. The input variable dur is a positive integer that represents the duration of a meeting in seconds. The output is also a pair represented by an epoch array of size two.

In your implementation assume that the time slots in a person’s availability are disjointed, i.e, time slots in a person’s availability don’t overlap. Further assume that the slots are sorted by slots’ start time.

Implement an efficient solution and analyze its time and space complexities.

Examples:

input:  slotsA = [[10, 50], [60, 120], [140, 210]]
        slotsB = [[0, 15], [60, 70]]
        dur = 8
output: [60, 68]

input:  slotsA = [[10, 50], [60, 120], [140, 210]]
        slotsB = [[0, 15], [60, 70]]
        dur = 12
output: null # since there is no common slot whose duration is 12

     * 
     * */
    class TimePlanner
    {
        public static int[] MeetingPlanner(int[,] slotsA, int[,] slotsB, int dur)
        {
            // your code goes here
            if (slotsA == null || slotsB == null || slotsA.GetLength(0) == 0 || slotsB.GetLength(0) == 0)
            {
                return new int[0];
            }

            int i = 0;
            int j = 0;
            int maxStart;
            int minEnd;
            int overlap;
            while (i < slotsA.GetLength(0) && j < slotsB.GetLength(0))
            {
                // get the overlap
                maxStart = slotsA[i, 0] > slotsB[j, 0] ? slotsA[i, 0] : slotsB[j, 0];
                minEnd = slotsA[i, 1] > slotsB[j, 1] ? slotsB[j, 1] : slotsA[i, 1];

                //maxstart = 6
                //minend = 11
                overlap = minEnd - maxStart;

                if (overlap >= dur)
                {
                    return new int[2] { maxStart, maxStart + dur };
                }

                if (slotsA[i, 1] == slotsB[j, 1])
                {
                    j++;
                    i++;
                }
                else if (slotsA[i, 1] > slotsB[j, 1])
                {
                    j++;
                }
                else
                {
                    i++;
                }
            }

            return new int[0];
        }

        //static void Main(string[] args)
        //{
        //    int[,] slotsA = new int[3, 2] { { 10, 50 }, { 60, 120 }, { 140, 210 } };
        //    int[,] slotsB = new int[2, 2] { { 0,15 }, { 60, 70 } };
        //    int dur = 8;
        //    var result = MeetingPlanner(slotsA, slotsB, dur);
        //    Console.WriteLine(result[0]);
        //    Console.WriteLine(result[1]);
        //    Console.ReadKey();
        //}

        /*
        slots of A
        slots of B
        duration

        trying to find the first common slot of A and B which has the duration available
        duration = 8
        slotA      10,50   60,120   140, 210
        delta      50      60       70
        slotB      0,15    60,70
        delta      15      10
        overlap    5       10       -
        solution is overlap 10 


        */
    }
}
