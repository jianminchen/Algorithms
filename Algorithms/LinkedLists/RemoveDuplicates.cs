using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedLists
{
    class RemoveDuplicates
    {
        private static void RemoveDups(Node head)
        {
            HashSet<int> map = new HashSet<int>();
            Node current = head;
            Node previous = current;
            while(current != null)
            {
                if(map.Contains(current.Data))
                {
                    previous.Next = current.Next;
                }
                else
                {
                    map.Add(current.Data);
                    previous = current;
                }
                
                current = current.Next;
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

        //    RemoveDups(head);
        //    while(head != null)
        //    {
        //        Console.WriteLine(head.Data);
        //        head = head.Next;
        //    }

        //    Console.ReadKey();
        //}
    }
}
