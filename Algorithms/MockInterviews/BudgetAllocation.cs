using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    /*
     * The awards committee of your alma mater (i.e. your college/university) asked for your assistance with a budget allocation problem they’re facing. Originally, the committee planned to give N research grants this year. However, due to spending cutbacks, the budget was reduced to newBudget dollars and now they need to reallocate the grants. The committee made a decision that they’d like to impact as few grant recipients as possible by applying a maximum cap on all grants. Every grant initially planned to be higher than cap will now be exactly cap dollars. Grants less or equal to cap, obviously, won’t be impacted.
       Given an array grantsArray of the original grants and the reduced budget newBudget, write a function findGrantsCap that finds in the most efficient manner a cap such that the least number of recipients is impacted and that the new budget constraint is met (i.e. sum of the N reallocated grants equals to new
     * */
    class BudgetAllocation
    {
        private static double FindGrantsCap(double[] input, double newBudget)
        {
            double currentBudget = 0;
            foreach(var currentGrant in input)
            {
                currentBudget += currentGrant;
            }

            int n = input.Length;
            Array.Sort(input);
            double[] newInput = new double[input.Length + 1];
            for(int i = 0;i<n; i++)
            {
                newInput[i] = input[n - 1 - i];
            }
            newInput[n] = 0;

            double surplus = currentBudget - newBudget;

            if(surplus <= 0)
            {
                return input[n - 1];
            }

            int count = 0;
            for (int i =0; i <n;i++)
            {
                surplus -= (i + 1) * (newInput[i] - newInput[i + 1]);
                if (surplus <= 0)
                    break;
                count++;
            }
            return newInput[count+1] + (-surplus / (count + 1));
        }

        public static void Main(string[] args)
        {
            double[] input = new double[] { 2, 100, 50, 120, 1000 };
            double newBudget = 190;
            var result = FindGrantsCap(input, 190);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
