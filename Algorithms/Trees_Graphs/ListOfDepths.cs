using Algorithms.LinkedLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees_Graphs
{
    /*
     * Given a binary tree, design an algorithm which creates a linked list of all the nodes
       at each depth (e.g., if you have a tree with depth D, you'll have D linked lists).
     * */
    class ListOfDepths
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

        private static List<List<TreeNode>> GetLevelLists(TreeNode root)
        {
            List<List<TreeNode>> lists = new List<List<TreeNode>>();
            GetLevelLists(root, lists, 0);
            return lists;
        }

        private static void GetLevelLists(TreeNode node, List<List<TreeNode>> lists, int level)
        {
            if(node == null)
            {
                return;
            }

            if(lists.Count() == level)
            {
                lists.Add(new List<TreeNode>());
            }

            lists[level].Add(node);

            GetLevelLists(node.Left, lists, level + 1);
            GetLevelLists(node.Right, lists, level + 1);
        }

        public static void Main(string[] args)
        {
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

            var result = GetLevelLists(root);

            Console.ReadKey();
        }
    }
}
