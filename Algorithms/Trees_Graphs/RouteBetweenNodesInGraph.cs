﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees_Graphs
{
    class RouteBetweenNodesInGraph
    {
        internal enum State { NotVisited, Visiting, Visited};

        public class Graph
        {
            public List<GraphNode> Nodes { get; set; }

            public Graph()
            {
                this.Nodes = new List<GraphNode>();
            }
        }

        public class GraphNode
        {
            public int Value { get; set; }
            public List<GraphNode> AdjacentNodes { get; set; } 
            public State State { get; set; }

            public GraphNode(int value)
            {
                this.Value = value;
                this.AdjacentNodes = new List<GraphNode>();
            }
        }

        //public static void Main(string[] args)
        //{
        //    Graph graph = new Graph();

        //    GraphNode node1 = new GraphNode(1);
        //    GraphNode node2 = new GraphNode(2);
        //    GraphNode node3 = new GraphNode(3);
        //    GraphNode node4 = new GraphNode(4);
        //    GraphNode node5 = new GraphNode(5);

        //    node1.AdjacentNodes.Add(node2);
        //    node1.AdjacentNodes.Add(node3);

        //    node2.AdjacentNodes.Add(node4);

        //    node4.AdjacentNodes.Add(node5);
        //    node4.AdjacentNodes.Add(node3);
        //    node5.AdjacentNodes.Add(node1);
        //    graph.Nodes.Add(node1);
        //    graph.Nodes.Add(node2);
        //    graph.Nodes.Add(node3);
        //    graph.Nodes.Add(node4);
        //    graph.Nodes.Add(node5);

        //    /*
        //     * 1 -> 2, 3
        //     * 2 -> 4
        //     * 4 -> 3,5
        //     * 5 -> 1
        //     * */

        //    bool result = Search(graph, node4, node1);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}

        static bool Search(Graph graph, GraphNode start, GraphNode end)
        {
            if (start == end)
                return true;

            //TODO implement the logic
            foreach(var node in graph.Nodes)
            {
                node.State = State.NotVisited;
            }

            Queue<GraphNode> queue = new Queue<GraphNode>();
            queue.Enqueue(start);
            while(queue.Count > 0)
            {
                GraphNode node = queue.Dequeue();
                if(node == end)
                { return true; }
                else
                {
                    node.State = State.Visited;
                    foreach(var adjacentNode in node.AdjacentNodes)
                    {
                        if(adjacentNode.State == State.NotVisited)
                        {
                            queue.Enqueue(adjacentNode);
                        }
                    }
                }
            }

            return false;
        }
    }
}
