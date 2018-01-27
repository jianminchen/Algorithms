using System;

/*
 * The car manufacturer Honda holds their distribution system in the form of a tree (not necessarily binary). The root is the company itself, and every node in the tree represents a car distributor that receives cars from the parent node and ships them to its children nodes. The leaf nodes are car dealerships that sell cars direct to consumers. In addition, every node holds an integer that is the cost of shipping a car to it.

Take for example the tree below:

alt

A path from Honda’s factory to a car dealership, which is a path from the root to a leaf in the tree, is called a Sales Path. The cost of a Sales Path is the sum of the costs for every node in the path. For example, in the tree above one Sales Path is 0→3→0→10, and its cost is 13 (0+3+0+10).

Honda wishes to find the minimal Sales Path cost in its distribution tree. Given a node rootNode, write an function getCheapestCost that calculates the minimal Sales Path cost in the tree.

Implement your function in the most efficient manner and analyze its time and space complexities.

For example:

Given the rootNode of the tree in diagram above

Your function would return:

7 since it’s the minimal Sales Path cost (there are actually two Sales Paths in the tree whose cost is 7: 0→6→1 and 0→3→2→1→1)
 * */
class GetCheapestCost
{
    public class Node
    {
        public int Cost { get; set; }
        public Node[] Children { get; set; }
        //public Node parent;
    }

    public static int getCheapestCost(Node rootNode)
    {
        if (rootNode == null)
        {
            return 0;
        }

        if (rootNode.Children == null || rootNode.Children.Length == 0)
        {
            return rootNode.Cost;
        }

        // your code goes here
        int minCost = int.MaxValue;
        foreach (var child in rootNode.Children)
        {
            var childMinCost = rootNode.Cost + getCheapestCost(child);
            if (childMinCost < minCost)
            {
                minCost = childMinCost;
            }
        }

        return minCost;
    }

    //static void Main(string[] args)
    //{
    //    Node rootNode = new Node();
    //    rootNode.cost = 0;
    //    rootNode.children = new Node[2];

    //    Node firstChild = new Node();
    //    firstChild.cost = 5;
    //    firstChild.children = new Node[1];
    //    firstChild.children[0] = new Node();
    //    firstChild.children[0].cost = 4;

    //    Node secondChild = new Node();
    //    secondChild.cost = 6;
    //    secondChild.children = new Node[1];
    //    secondChild.children[0] = new Node();
    //    secondChild.children[0].cost = 1;

    //    rootNode.children[0] = firstChild;
    //    rootNode.children[1] = secondChild;

    //    var result = getCheapestCost(rootNode);
    //    Console.WriteLine(result);
    //}
}

