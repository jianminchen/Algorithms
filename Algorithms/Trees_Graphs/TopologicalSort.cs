using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees_Graphs
{
    /*
     * You are given a list of projects and a list of dependencies (which is a list of pairs of
projects, where the second project is dependent on the first project). All of a project's dependencies
must be built before the project is. Find a build order that will allow the projects to be built. If there
is no valid build order, return an error.
EXAMPLE
Input:
projects: a, b, c, d, e, f
dependencies: (a, d), (f, b), (b, d), (f, a), (d, c)
Output: f, e, a, b, d, c
     * */
    class TopologicalSort
    {
        public enum State { NotVisisted, Visiting, Visited };
        internal class GraphNode
        {
            public char Value { get; set; }
            public List<GraphNode> Dependents { get; set; }
            public State State { get; set; }

            public GraphNode(char value)
            {
                this.Value = value;
                this.Dependents = new List<GraphNode>();
            }
        }
        
        internal class Graph
        {
            public List<GraphNode> Nodes { get; set; }

            public Graph()
            {
                this.Nodes = new List<GraphNode>();
            }
        }

        static Graph BuildGraph(char[] projects, List<Tuple<char,char>> dependencies)
        {
            Dictionary<char, GraphNode> map = new Dictionary<char, GraphNode>();
            foreach(char element in projects)
            {
                if(!map.ContainsKey(element))
                {
                    GraphNode node = new GraphNode(element);
                    map.Add(element, node);
                }
            }

            foreach(var pair in dependencies)
            {
                if(!map.ContainsKey(pair.Item1))
                {
                    GraphNode node = new GraphNode(pair.Item1);
                    map.Add(pair.Item1, node);
                }

                if (!map.ContainsKey(pair.Item2))
                {
                    GraphNode node = new GraphNode(pair.Item2);
                    map.Add(pair.Item2, node);
                }

                GraphNode project = map[pair.Item1];
                GraphNode dependent = map[pair.Item2];
                project.Dependents.Add(dependent);
            }

            Graph graph = new Graph();
            foreach(var item in map.Values)
            {
                graph.Nodes.Add(item);
            }

            return graph;
        }

        static char[] Sort(Graph graph)
        {
            List<char> sortedProjects = new List<char>();
            if(graph == null)
            {
                return sortedProjects.ToArray();
            }

            Stack<GraphNode> stack = new Stack<GraphNode>();
            foreach(var project in graph.Nodes)
            {
                if(project.State != State.Visited && project.Dependents.Count == 0)
                {
                    sortedProjects.Add(project.Value);
                    project.State = State.Visited;
                }

                if (project.State != State.Visited)
                {
                    project.State = State.Visiting;
                    stack.Push(project);
                    while (stack.Count > 0)
                    {
                        if (stack.Peek().Dependents.Count() != 0)
                        {
                            bool dependendAdded = false;
                            foreach (var dependent in stack.Peek().Dependents)
                            {
                                if (dependent.State == State.NotVisisted)
                                {
                                    dependendAdded = true;
                                    dependent.State = State.Visiting;
                                    stack.Push(dependent);
                                }
                            }

                            // If all dependents have been visited
                            if (dependendAdded == false)
                            {
                                GraphNode node = stack.Pop();
                                node.State = State.Visited;
                                sortedProjects.Add(node.Value);
                            }
                        }
                        else
                        {
                            GraphNode node = stack.Pop();
                            node.State = State.Visited;
                            sortedProjects.Add(node.Value);
                        }
                    }
                }
            }

            sortedProjects.Reverse();
            return sortedProjects.ToArray();
        }

        static void Main(string[] args)
        {
            //char[] projects = new char[6] { 'a', 'b', 'c', 'd', 'e', 'f' };
            //List<Tuple<char, char>> dependencies = new List<Tuple<char, char>>();
            //dependencies.Add(new Tuple<char, char>('a', 'd'));
            //dependencies.Add(new Tuple<char, char>('f', 'b'));
            //dependencies.Add(new Tuple<char, char>('b', 'd'));
            //dependencies.Add(new Tuple<char, char>('f', 'a'));
            //dependencies.Add(new Tuple<char, char>('d', 'c'));

            //// output f e a b d c

            // case 2
            char[] projects = new char[7] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            List<Tuple<char, char>> dependencies = new List<Tuple<char, char>>();
            dependencies.Add(new Tuple<char, char>('f', 'c'));
            dependencies.Add(new Tuple<char, char>('f', 'b'));
            dependencies.Add(new Tuple<char, char>('f', 'a'));
            dependencies.Add(new Tuple<char, char>('b', 'a'));
            dependencies.Add(new Tuple<char, char>('c', 'a'));
            dependencies.Add(new Tuple<char, char>('b', 'e'));
            dependencies.Add(new Tuple<char, char>('a', 'e'));
            dependencies.Add(new Tuple<char, char>('d', 'g'));

            // output f e a b d c
            var graph = BuildGraph(projects, dependencies);
            var result = Sort(graph);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
