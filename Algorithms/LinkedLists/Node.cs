using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.LinkedLists
{
    internal class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node(int value)
        {
            this.Data = value;
            this.Next = null;
        }
    }
}
