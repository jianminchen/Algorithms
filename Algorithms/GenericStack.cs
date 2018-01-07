using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class GenericStack
    {
        //public static void Main(string[] args)
        //{
        //    Stack<int> intStack = new Stack<int>();
        //    intStack.Push(5);
        //    intStack.Push(4);
        //    intStack.Push(3);
        //    foreach(var item in intStack)
        //    {
        //        Console.WriteLine(((Node<int>)item).Item);
        //    }
        //    Console.ReadKey();
        //}

        public class Stack<T> : IEnumerable
        {
            private Node<T> Top { get; set; }

            public bool IsEmpty()
            {
                return Top == null;
            }

            public void Push(T item)
            {
                Node<T> currentTop = Top;
                Top = new Node<T>();
                Top.Item = item;
                Top.Next = currentTop;
            }

            public T Pop()
            {
                if (!IsEmpty())
                {
                    Node<T> item = Top;
                    Top = Top.Next;
                    return item.Item;
                }
                else
                {
                    return default(T);
                }
            }

            public IEnumerator GetEnumerator()
            {
                Node<T> iterator = Top;
                while(iterator != null)
                {
                    Node<T> temp = iterator;
                    iterator = iterator.Next;
                    yield return temp;
                }
            }
        }

        public class Node<T>
        {
            public T Item { get; set; }
            public Node<T> Next { get; set; }
        }
    }
}
