using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.StringsAndArrays
{
    class MaxRoomsInHotel
    {
        private static int CheckRooms(int[] arrival, int[] departure, int numberOfRooms)
        {
            Array.Sort(arrival);
            Array.Sort(departure);
            int i = 0;
            int j = 0;
            int maxRooms = 0;
            int currentRooms = 0;
            while (i < arrival.Length && j < departure.Length)
            {
                if (arrival[i] < departure[j])
                {
                    currentRooms++;
                    i++;
                }
                else if (arrival[i] > departure[j])
                {
                    currentRooms--;
                    j++;
                }
                else
                {
                    i++;
                    j++;
                }

                if (currentRooms > maxRooms)
                {
                    maxRooms = currentRooms;
                }
            }

            return maxRooms <= numberOfRooms ? 1 : 0;
        }

        //public static void Main(string[] args)
        //{
        //    /*Arrivals:   [1 3 5]
        //Departures: [2 6 8]
        //K: 1*/
        //    int[] arrival = new int[] { 1, 3, 5 };
        //    int[] departure = new int[] { 2, 6, 8 };
        //    var result = CheckRooms(arrival, departure, 1);
        //    Console.Write(result);
        //    Console.ReadKey();
        //}
    }
}
