using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();

            graph.addNode("A");
            graph.addNode("B");
            graph.addNode("C");
            graph.addNode("D");

            graph.addEdge("A", "B");
            graph.addEdge("B", "D");
            graph.addEdge("D", "C");
            graph.addEdge("A", "C");

            graph.print();
            Console.WriteLine("==== Depth First Traversal With Recursion ====");
            graph.traverseDepthFirstUsingRecursion("A");

            Console.WriteLine("==== Depth First Traversal With Iteration ====");
            graph.traverseDepthFirstUsingIteration("A");

            Console.WriteLine("==== Breadth First Traversal With Iteration ====");
            graph.traverseBreadthFirstUsingIteration("A");

            Console.ReadLine();
        }
    }
}
