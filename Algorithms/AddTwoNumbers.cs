using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    class AddTwoNumbers
    {
        //static void Main(string[] args)
        //{
        //    ListNode l1 = new ListNode(5);
        //    ListNode l1Head = l1;
        //    l1.next = new ListNode(4);
        //    l1 = l1.next;
        //    l1.next = new ListNode(3);
        //    l1 = l1.next;
        //    l1.next = new ListNode(7);
        //    l1 = l1.next;
        //    l1.next = new ListNode(9);
        //    l1 = l1.next;

        //    ListNode l2 = new ListNode(5);
        //    ListNode l2Head = l2;
        //    l2.next = new ListNode(6);
        //    l2 = l2.next;
        //    l2.next = new ListNode(7);
        //    l2 = l2.next;

        //    Solution solution = new Solution();
        //    var result = solution.AddTwoNumbers(l1Head, l2Head);
        //    while (result != null)
        //    {
        //        Console.WriteLine(result.val);
        //        result = result.next;
        //    }
        //    Console.ReadKey();
        //}

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class Solution
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                if (l1 == null) return l2;
                if (l2 == null) return l1;

                int l1Length = GetLength(l1);
                int l2Length = GetLength(l2);
                ListNode head = l1Length > l2Length ? l1 : l2;
                ListNode current = head;
                int carry = 0;
                while(current != null)
                {
                    int tempResult = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
                    current.val = tempResult % 10;
                    carry = tempResult / 10;
                    if (current.next == null && carry > 0)
                    {
                        current.next = new ListNode(0);
                    }

                    current = current.next;
                    l1 = l1 != null ? l1.next : null;
                    l2 = l2 != null ? l2.next : null;
                }


                return head;
            }

            private static int GetLength(ListNode l)
            {
                int length = 0;
                while (l != null)
                {
                    l = l.next;
                    length++;
                }

                return length;
            }
        }
    }
}
