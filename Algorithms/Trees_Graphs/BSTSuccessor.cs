using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees_Graphs
{
    /* Given a node in a BST get the successor of the node
     * */
    class BSTSuccessor
    {
        private class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public TreeNode Parent { get; set; }
            public TreeNode(int value)
            {
                this.Value = value;
            }
        }

        private static TreeNode Successor(TreeNode node)
        {
            // Case 1:
            // If node is null or node.Left == null && node.Right == null && node.Parent == null return null
            if(node == null ||
                (node.Left == null && node.Right == null && node.Parent == null))
            {
                return null;
            }

            // Case 2:
            // If node has right subtree then get the leftmost element in the right subtree
            if(node.Right != null)
            {
                return GetLeftMostElement(node.Right);
            }
            else
            {
                if(node.Parent == null)
                {
                    return null;
                }

                if (node.Parent.Left == node)
                {
                    return node.Parent;
                }
                
                // Case 3
                // Keep going up the chain till the node is a left child of its parent and then the parent is the successor of the current node
                TreeNode x = node.Parent;
                TreeNode y = node;

                while ((x != null && y != x.Left) || y == node.Parent)
                {
                    if(x.Parent == null && y == x.Right)
                    {
                        return null;
                    }

                    y = x;
                    x = x.Parent;
                }

                return y;
            }
        }

        private static TreeNode GetLeftMostElement(TreeNode node)
        {
            if(node == null || node.Left == null)
            {
                return node;
            }

            while(node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        //public static void Main(string[] args)
        //{
        //    /*
        //     *                         10
        //     *                     5          20
        //     *                   3   7     15     40
        //     * */
        //    // Positive case
        //    TreeNode root = new TreeNode(10);
        //    TreeNode l1Node1 = new TreeNode(5);
        //    l1Node1.Parent = root;
        //    TreeNode l1Node2 = new TreeNode(20);
        //    l1Node2.Parent = root;
        //    root.Left = l1Node1;
        //    root.Right = l1Node2;

        //    TreeNode l2Node1 = new TreeNode(3);
        //    l2Node1.Parent = root.Left;
        //    TreeNode l2Node2 = new TreeNode(7);
        //    l2Node2.Parent = root.Left;
        //    TreeNode l2Node3 = new TreeNode(15);
        //    l2Node3.Parent = root.Right;
        //    TreeNode l2Node4 = new TreeNode(40);
        //    l2Node4.Parent = root.Right;

        //    root.Left.Left = l2Node1;
        //    root.Left.Right = l2Node2;
        //    root.Right.Left = l2Node3;
        //    root.Right.Right = l2Node4;
        //    var result = Successor(root);  // expected 15
        //    //var result = Successor(l2Node2); // expected 10
        //    //var result = Successor(l2Node1); // expected 5
        //    //var result = Successor(l2Node4); //expected null

        //    Console.WriteLine(result != null ? result.Value.ToString() : "Null");
        //    Console.ReadKey();
        //}
    }
}
