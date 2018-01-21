using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees_Graphs
{
    class BSTFromSortedArray
    {
        private class Node
        {
            public int Value { get; set; }
            public Node LeftChild { get; set; }
            public Node RightChild { get; set; }
        }

        private static Node CreateBST(int[] input, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            Node midNode = new Node();
            midNode.Value = input[mid];
            midNode.LeftChild = CreateBST(input, start, mid - 1);
            midNode.RightChild = CreateBST(input, mid + 1, end);

            return midNode;
        }

        //public static void Main(string[] args)
        //{
        //    int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //    Node root = CreateBST(input, 0, 8);

        //    Console.ReadKey();
        //}
    }
}
