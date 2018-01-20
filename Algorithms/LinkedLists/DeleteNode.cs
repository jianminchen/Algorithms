using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedLists
{
    class DeleteNode
    {
        private static void Delete(Node node)
        {
            //cannot be the last node as we are given access to only the node to be deleted
            if(node == null || node.Next == null)
            {
                return;
            }
            else
            {
                node.Data = node.Next.Data;
                node.Next = node.Next.Next;
            }
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

        //    Delete(head.Next.Next);
        //    while (head != null)
        //    {
        //        Console.WriteLine(head.Data);
        //        head = head.Next;
        //    }

        //    Console.ReadKey();
        //}

    }
}
