using System;

class LargestSmallerBSTKey
{
    /*
     * Largest Smaller BST Key
Given a root of a Binary Search Tree (BST) and a number num, implement an efficient function findLargestSmallerKey that finds the largest key in the tree that is smaller than num. If such a number doesn’t exist, return -1. Assume that all keys in the tree are nonnegative.

Analyze the time and space complexities of your solution.
     * */
    public class Node
    {
        public Node left;
        public Node right;
        public int key;
        public Node parent;
    }

    public class BinarySearchTree
    {
        public Node root;

        public int findLargestSmallerKey(Node rootNode, int num)
        {
            // your code goes here

            return FindLargestSmallerKeyRecursive(rootNode, num, -1);
        }

        /*    rootNode = 20
              num = 25
              largestSmallerKey = 20  should have been 14

        */
        private static int FindLargestSmallerKeyRecursive(Node rootNode, int num, int largestSmallerKey)
        {
            if (rootNode == null)
            {
                return largestSmallerKey;
            }

            if (rootNode.key > largestSmallerKey && rootNode.key < num)
            {
                largestSmallerKey = rootNode.key;
            }

            if (num <= rootNode.key)
            {
                return FindLargestSmallerKeyRecursive(rootNode.left, num, largestSmallerKey);
            }
            else
            {
                return FindLargestSmallerKeyRecursive(rootNode.right, num, largestSmallerKey);
            }
        }

        //  inserts a new node with the given number in the
        //  correct place in the tree
        public void insert(int key)
        {

            // 1) If the tree is empty, create the root
            if (this.root == null)
            {
                this.root = new Node();
                this.root.key = key;
                return;
            }

            // 2) Otherwise, create a node with the key
            //    and traverse down the tree to find where to
            //    to insert the new node
            Node currentNode = this.root;
            Node newNode = new Node();
            newNode.key = key;

            while (currentNode != null)
            {
                if (key < currentNode.key)
                {
                    if (currentNode.left == null)
                    {
                        currentNode.left = newNode;
                        newNode.parent = currentNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.left;
                    }
                }
                else
                {
                    if (currentNode.right == null)
                    {
                        currentNode.right = newNode;
                        newNode.parent = currentNode;
                        break;
                    }
                    else
                    {
                        currentNode = currentNode.right;
                    }
                }
            }
        }
    }

    /*********************************************
     * Driver program to test above function     *
     *********************************************/

    //public static void Main(String[] args)
    //{

    //    // Create a Binary Search Tree
    //    BinarySearchTree bst = new BinarySearchTree();
    //    bst.insert(20);
    //    bst.insert(9);
    //    bst.insert(25);
    //    bst.insert(5);
    //    bst.insert(12);
    //    bst.insert(11);
    //    bst.insert(14);

    //    int result = bst.findLargestSmallerKey(bst.root, 20);
    //    Console.WriteLine("Largest smaller number is " + result);
    //    Console.ReadKey();
    //}
}

