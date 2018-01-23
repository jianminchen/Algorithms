using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees_Graphs
{
    /* Given a binary tree check if the tree is balanced, i.e at every node the difference in the height of left subtree and right subtree should
     * not be greater than 1
     * */
    class BalancedBinaryTree
    {
        private class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public TreeNode(int value)
            {
                this.Value = value;
            }
        }

        private static bool IsBalanced(TreeNode node, out int height)
        {
            if(node == null)
            {
                height = 0;
                return true;
            }

            int leftHeight;
            bool leftBalanced = IsBalanced(node.Left, out leftHeight);

            int rightHeight;
            bool rightBalanced = IsBalanced(node.Right, out rightHeight);

            height = Math.Max(leftHeight, rightHeight) + 1;
            return Math.Abs(leftHeight - rightHeight) > 1 ? false : true;
        }

        public static void Main(string[] args)
        {
            // Positive case
            TreeNode root = new TreeNode(10);
            TreeNode l1Node1 = new TreeNode(15);
            TreeNode l1Node2 = new TreeNode(20);
            root.Left = l1Node1;
            root.Right = l1Node2;

            TreeNode l2Node1 = new TreeNode(25);
            TreeNode l2Node2 = new TreeNode(30);
            TreeNode l2Node3 = new TreeNode(35);
            TreeNode l2Node4 = new TreeNode(40);

            root.Left.Left = l2Node1;
            root.Left.Right = l2Node2;
            root.Right.Left = l2Node3;
            root.Right.Right = l2Node4;

            int height = 0;
            bool result = IsBalanced(root, out height);

            Console.WriteLine(result);
            Console.ReadKey();

            // Negative case
            TreeNode secondRoot = new TreeNode(10);
            TreeNode secondl1Node1 = new TreeNode(15);
            TreeNode secondl1Node2 = new TreeNode(15);
            secondRoot.Left = secondl1Node1;
            secondRoot.Right = secondl1Node2;

            TreeNode secondl2Node1 = new TreeNode(25);
            TreeNode secondl2Node2 = new TreeNode(30);
           
            secondRoot.Left.Left = secondl2Node1;
            secondRoot.Left.Right = secondl2Node2;

            TreeNode secondl3Node1= new TreeNode(30);

            secondRoot.Left.Left.Left = secondl3Node1;

            height = 0;
            result = IsBalanced(secondRoot, out height);

            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
