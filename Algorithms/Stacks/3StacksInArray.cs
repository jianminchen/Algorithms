using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Stacks
{
    class _3StacksInArray
    {
        public class MultiStack
        {
            private int numStacks;
            private int stackSize;
            private int[] values;
            private int[] stackTops;

            public MultiStack(int stackSize, int numStacks)
            {
                this.numStacks = numStacks;
                this.stackSize = stackSize;
                this.stackTops = new int[numStacks];
                this.values = new int[numStacks * stackSize];
            }

            public bool IsFull(int stackNum)
            {
                if(this.stackTops[stackNum] == this.stackSize)
                {
                    return true;
                }

                return false;
            }

            public bool IsEmpty(int stackNum)
            {
                if(this.stackTops[stackNum] == 0)
                {
                    return true;
                }

                return false;
            }

            public void Push(int value, int stackNum)
            {
                if(this.IsFull(stackNum))
                {
                    throw new InvalidOperationException(string.Format("stack {0} is full", stackNum));
                }

                this.stackTops[stackNum]++;
                this.values[((stackNum * this.stackSize) + this.stackTops[stackNum]) - 1] = value;
            }

            public int Pop(int stackNum)
            {
                if (this.IsEmpty(stackNum))
                {
                    throw new InvalidOperationException(string.Format("stack {0} is empty", stackNum));
                }

                var value = this.values[((stackNum * this.stackSize) + this.stackTops[stackNum]) - 1];
                this.values[((stackNum * this.stackSize) + this.stackTops[stackNum]) - 1]  = 0;
                this.stackTops[stackNum]--;

                return value;
            }
        }

        public static void Main(string[] args)
        {
            MultiStack multiStack = new MultiStack(5, 3);
            multiStack.Push(6, 2);
            multiStack.Push(11, 1);
            multiStack.Push(1, 0);
            multiStack.Pop(2);
            multiStack.Push(6, 1);
            multiStack.Push(11, 2);
            multiStack.Push(1, 0);
            multiStack.Pop(2);
            multiStack.Pop(1);
            multiStack.Push(6, 2);
            multiStack.Push(11, 0);
            multiStack.Push(1, 1);
            multiStack.Push(6, 2);
            multiStack.Push(11, 0);
            multiStack.Push(1, 1);

            Console.ReadKey();
        }
    }
}
