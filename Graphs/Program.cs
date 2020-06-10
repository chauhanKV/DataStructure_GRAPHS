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
            graph.addEdge("A", "B");
            graph.addEdge("A", "C");
            graph.removeEdge("A", "B");
            graph.removeNode("B");
            graph.addNode("D");
            graph.addEdge("D", "A");
            graph.print();

            Console.ReadLine();
        }
    }
}
