using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.MockInterviews
{
    class BSTSuccessorSearch
    {
        public class Node
        {
            public int value;
            public Node left;
            public Node right;
            public Node parent;

            public Node(int value, Node parent)
            {
                this.value = value;
                this.left = null;
                this.right = null;
                this.parent = parent;
            }
        }

        public static Node findInOrderSuccessor(Node inputNode)
        {
            // your code goes here

            if (inputNode == null)
            {
                return null;
            }

            if (inputNode.right != null)
            {
                return GetSmallestElement(inputNode.right);
            }
            else if (inputNode.right == null)
            {
                while (inputNode.parent != null)
                {
                    if (inputNode == inputNode.parent.right)
                    {
                        inputNode = inputNode.parent;
                    }
                    else
                    {
                        if (inputNode.parent == null)
                        {
                            return null;
                        }
                        else
                        {
                            return inputNode.parent;
                        }
                    }
                    inputNode = inputNode.parent;
                }
            }

            return inputNode;
        }

        private static Node GetSmallestElement(Node node)
        {
            if (node.left != null)
            {
                return GetSmallestElement(node.left);
            }

            return node;
        }

        //static void Main(string[] args)
        //{
        //    // test findInOrderSuccessor here
        //    Node root = new Node(20, null);
        //    Node result = findInOrderSuccessor(root);
        //    Console.Write(result);
        //}
    }
}
