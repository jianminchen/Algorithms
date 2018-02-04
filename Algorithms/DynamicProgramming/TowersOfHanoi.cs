using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    class TowersOfHanoi
    {
        public static void Move(Stack<int> first, Stack<int> third, Stack<int> second, int numberOfDisks)
        {
            if(numberOfDisks == 0)
            {
                return;
            }
            Move(first, second, third, numberOfDisks - 1);
            third.Push(first.Pop());
            Move(second, third, first, numberOfDisks - 1);
        }

        public static void Main(string[] args)
        {
            Stack<int> first = new Stack<int>();
            Stack<int> second = new Stack<int>();
            Stack<int> third = new Stack<int>();

            first.Push(1);
            first.Push(2);
            first.Push(3);
            first.Push(4);
            first.Push(5);

            Move(first, third, second, first.Count);
            Console.ReadKey();
        }
    }
}
