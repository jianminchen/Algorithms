using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * Drone Flight Planner
You’re an engineer at a disruptive drone delivery startup and your CTO asks you to come up with an efficient algorithm that calculates the minimum amount of energy required for the company’s drone to complete its flight. You know that the drone burns 1 kWh (kilowatt-hour is an energy unit) for every mile it ascends, and it gains 1 kWh for every mile it descends. Flying sideways neither burns nor adds any energy.

Given an array route of 3D points, implement a function calcDroneMinEnergy that computes and returns the minimal amount of energy the drone would need to complete its route. Assume that the drone starts its flight at the first point in route. That is, no energy was expended to place the drone at the starting point.

For simplicity, every 3D point will be represented as an integer array whose length is 3. Also, the values at indexes 0, 1, and 2 represent the x, y and z coordinates in a 3D point, respectively.

Explain your solution and analyze its time and space complexities.

Example:

input:  route = [ [0,   2, 10],
                  [3,   5,  0],
                  [9,  20,  6],
                  [10, 12, 15],
                  [10, 10,  8] ]

output: 5 # less than 5 kWh and the drone would crash before the finish
          # line. More than `5` kWh and it’d end up with excess energy


        Key part here is that the height is by z axis and also you need to find the minimum energy you need to start with so that you can complete the journey
     
        An easy solution is just to find the max z value and get the difference between that and start z value.
         * * */
    class DroneFlightPlanner
    {
        public static int CalcDroneMinEnergy(int[,] route)
        {
            if (route == null || route.GetLength(0) == 0)
            {
                return -1; // assuming it is error
            }

            // your code goes here
            int minEnergy = Int32.MaxValue;
            int currentEnergy = 0;
            for (int i = 1; i < route.GetLength(0); i++)
            {
                int currentValue = route[i, 2];
                int previousValue = route[i - 1, 2];
                if (currentValue > previousValue)
                {
                    currentEnergy -= (currentValue - previousValue);
                }
                else
                {
                    currentEnergy += (previousValue - currentValue);
                }

                if (currentEnergy < minEnergy)
                {
                    minEnergy = currentEnergy;
                }
            }

            if (minEnergy < 0)
            {
                minEnergy = -1 * minEnergy;
            }
            else
            {
                minEnergy = 0;
            }

            return minEnergy;
        }

        //static void Main(string[] args)
        //{
        //    int[,] input = new int[,] {{0,   2, 10 },
        //          { 3, 5, 0},
        //          { 9, 20, 6 },
        //          { 10, 12, 15},
        //          { 10, 10, 8 } };
        //    Console.WriteLine(CalcDroneMinEnergy(input));
        //    Console.ReadKey();
        //}
    }
}
