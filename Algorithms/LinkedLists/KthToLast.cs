using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedLists
{
    class KthToLast
    {
        private class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int value)
            {
                this.Data = value;
                this.Next = null;
            }
        }

        private static Node KthFromLast(Node head, int k)
        {
            Node first = head;
            Node second = head;

            //Move second k spaces apart from first
            for(int i = 0; i < k; i++)
            {
                if (second == null)
                {
                    return null;
                }
                else
                    second = second.Next;
            }

            while(second != null)
            {
                first = first.Next;
                second = second.Next;
            }

            return first;
        }

        //public static void Main(string[] args)
        //{
        //    // Construct linked list
        //    Node head = new Node(5);
        //    head.Next = new Node(3);
        //    head.Next.Next = new Node(5);
        //    head.Next.Next.Next = new Node(1);
        //    head.Next.Next.Next.Next = new Node(3);
        //    head.Next.Next.Next.Next.Next = new Node(5);
        //    head.Next.Next.Next.Next.Next.Next = new Node(7);

        //    var result = KthFromLast(head, 4);
        //    if (result != null)
        //    {
        //        Console.WriteLine(result.Data);
        //    }
        //    else
        //        Console.WriteLine("null");

        //    Console.ReadKey();
        //}
    }
}
