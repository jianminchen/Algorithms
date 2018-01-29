using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees_Graphs
{
    class CommonAncestorsBinaryTree
    {
        internal class TreeNode
        {
            public int Value { get; set;}
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public TreeNode Parent { get; set; }

            public TreeNode(int value, TreeNode parent)
            {
                this.Value = value;
                this.Parent = parent;
            }
        }

        internal static TreeNode CommonAncestor(TreeNode root, TreeNode first, TreeNode second)
        {
            if(first == null || second == null)
            {
                return null;
            }

            int firstDepth = GetDepth(first);
            int secondDepth = GetDepth(second);
            int delta = firstDepth - secondDepth;
            TreeNode lowerDepth;
            TreeNode higherDepth;
            higherDepth = delta >= 0 ? first : second;
            lowerDepth = delta < 0 ? first:second;

            higherDepth = GoUpBy(higherDepth, Math.Abs(delta));

            // Now the depths are same so traverse up till we find a common ancestor 
            while(lowerDepth != null && higherDepth != null)
            {
                if(lowerDepth == higherDepth)
                {
                    return lowerDepth;
                }

                lowerDepth = lowerDepth.Parent;
                higherDepth = higherDepth.Parent;
            }

            return null;
        }

        private static TreeNode GoUpBy(TreeNode node, int delta)
        {
            for(int i = 0; i < delta; i++)
            {
                node = node.Parent;
            }

            return node;
        }

        private static int GetDepth(TreeNode node)
        {
            int depth = 0;
            while(node != null)
            {
                depth++;
                node = node.Parent;
            }

            return depth;
        }

        public static void Main(string[] args)
        {
            /*
             *                      20
             *           10                 30
             *       5       15
             *    3     58        47
             * */

            TreeNode root = new TreeNode(20, null);
            TreeNode l1_1 = new TreeNode(10, root);
            TreeNode l1_2 = new TreeNode(30, root);
            root.Left = l1_1;
            root.Right = l1_2;

            TreeNode l2_1 = new TreeNode(5, l1_1);
            TreeNode l2_2 = new TreeNode(15, l1_1);
            l1_1.Left = l2_1;
            l1_1.Right = l2_1;

            TreeNode l3_1 = new TreeNode(3, l2_1);
            TreeNode l3_2 = new TreeNode(58, l2_1);
            TreeNode l3_3 = new TreeNode(47, l2_2);
            l2_1.Left = l3_1;
            l2_1.Right = l3_2;
            l2_2.Right = l3_3;

            //var result = CommonAncestor(root, l3_1, l3_3);
            var result = CommonAncestor(root, l3_1, l1_2);
            Console.WriteLine(result.Value);

            Console.ReadKey();
        }
    }
}
