using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Hashing
{
    class LRUHash
    {
        private int capacity;
        private int currentCount = 0;
        private LinkedListNode head;
        private LinkedListNode tail;

        public class LinkedListNode
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public LinkedListNode Previous { get; set; }
            public LinkedListNode Next { get; set; }
        }

        Dictionary<int, LinkedListNode> map;

        public LRUHash(int capacity)
        {
            this.map = new Dictionary<int, LinkedListNode>();
            this.capacity = capacity;
        }

        public int get(int key)
        {
            int result = -1;
            if (this.map.ContainsKey(key))
            {
                result = this.map[key].Value;
            }
            else
            {
                return result;
            }

            //move the node to the head
            if (currentCount > 1)
            {
                LinkedListNode node = this.map[key];
                LinkedListNode previous = node.Previous;

                if (previous != null)
                {
                    previous.Next = node.Next;
                    if (node.Next == null)
                    {
                        tail = previous;
                    }
                }

                node.Previous = null;
                node.Next = head;
                head = node;
            }

            return result;
        }

        public void set(int key, int value)
        {
            if (this.currentCount == this.capacity)
            {
                // we need to evict some entries
                LinkedListNode node = this.tail;
                LinkedListNode previousNode = node.Previous;
                if (previousNode != null)
                {
                    previousNode.Next = null;
                    this.tail = previousNode;
                }
                else
                {
                    if(node.Next == null)
                    {
                        this.head = null;
                        this.tail = null;
                    }
                    else
                    {
                        this.head = node.Next;
                        node.Next = null;
                    }
                }

                this.currentCount--;
                this.map.Remove(node.Key);
            }

            if (this.map.ContainsKey(key))
            {
                this.map[key].Value = value;
                //move the node to the front of the list
            }
            else
            {
                LinkedListNode node = new LinkedListNode();
                node.Key = key;
                node.Value = value;
                node.Previous = null;
                node.Next = this.head;
                if(this.head != null)
                {
                    this.head.Previous = node;
                }
                this.head = node;
                if (this.currentCount == 0)
                {
                    this.tail = node;
                }
                this.currentCount++;
                this.map.Add(key, node);
            }
        }

        //public static void Main(string[] args)
        //{
        //    //6 2 S 2 1 S 1 1 S 2 3 S 4 1 G 1 G 2

        //    LRUHash hash = new LRUHash(2);
        //    hash.set(2, 1);
        //    hash.set(1, 1);
        //    hash.set(2, 3);
        //    hash.set(4, 1);
        //    var result = hash.get(1); // should return -1;
        //    Console.WriteLine(result);
        //    result = hash.get(2);  // should return -1 as it must have been evicted from cache
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
    }
}
