using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
namespace ScratchPad
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Queue<int> myQueue = new Queue<int>();
        //    myQueue.Enqueue(5);
        //    myQueue.Enqueue(6);
        //    myQueue.Enqueue(7);
        //    var value = myQueue.Dequeue();
        //    Console.WriteLine(value);
        //    value = myQueue.Dequeue();
        //    Console.WriteLine(value);
        //    myQueue.Enqueue(8);
        //    myQueue.Enqueue(9);
        //    value = myQueue.Dequeue();
        //    Console.WriteLine(value);
        //    value = myQueue.Dequeue();
        //    Console.WriteLine(value);
        //    value = myQueue.Dequeue();
        //    Console.WriteLine(value);
        //    value = myQueue.Dequeue();
        //    Console.WriteLine(value);
        //    Console.ReadKey();
        //}
    }
    public class Queue<T>
    {
        private Stack<T> firstStack { get; set; }
        private Stack<T> secondStack { get; set; }
        public Queue()
        {
            this.firstStack = new Stack<T>();
            this.secondStack = new Stack<T>();
        }
        public void Enqueue(T item)
        {
            this.firstStack.Push(item);
        }
        public T Dequeue()
        {
            T item = default(T);
            if (this.secondStack.IsEmpty())
            {
                while (!this.firstStack.IsEmpty())
                {
                    this.secondStack.Push(this.firstStack.Pop());
                }
            }
            item = this.secondStack.Pop();
            return item;
        }
    }
    public class Stack<T>
    {
        private Node<T> Top { get; set; }
        public bool IsEmpty()
        {
            return this.Top == null;
        }
        public void Push(T item)
        {
            Node<T> currentTop = this.Top;
            this.Top = new Node<T>(item);
            this.Top.Next = currentTop;
        }
        public T Pop()
        {
            T value = default(T);
            if (this.Top != null)
            {
                value = this.Top.Value;
                this.Top = this.Top.Next;
            }
            return value;
        }
    }
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node(T value)
        {
            this.Value = value;
            this.Next = null;
        }
    }
}