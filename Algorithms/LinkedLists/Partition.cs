using System;

namespace Algorithms.LinkedLists
{
    /*
     * Partition: Write code to partition a linked list around a value x, 
     * such that all nodes less than x come before all nodes greater than or equal to x. 
     * If xis contained within the list the values of x only need to be after the elements less 
     * than x (see below). The partition element x can appear anywhere in the "right partition";
     * it does ****not**** need to appear between the left and right partitions. 
     * EXAMPLE Input: 3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition= 5] 
     * Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8 
     * */
    class Partition
    {
        private static void PartitionList(Node head, int value)
        {
            Node first = head;
            Node second = head;
            while (second != null && first != null)
            {
                if (second.Data < value)
                {
                    int temp = first.Data;
                    first.Data = second.Data;
                    second.Data = temp;
                    first = first.Next;
                }

                second = second.Next;
            }
        }

        public static void Main(string[] args)
        {
            // Construct linked list
            Node head = new Node(7);
            head.Next = new Node(3);
            head.Next.Next = new Node(2);
            head.Next.Next.Next = new Node(8);
            head.Next.Next.Next.Next = new Node(4);
            head.Next.Next.Next.Next.Next = new Node(5);
            head.Next.Next.Next.Next.Next.Next = new Node(1);

            PartitionList(head, 5);
            while (head != null)
            {
                Console.WriteLine(head.Data);
                head = head.Next;
            }

            Console.ReadKey();
        }
    }
}
