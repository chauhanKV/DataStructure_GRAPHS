using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph
    {
        private class Node {

            private string label;
            public Node(string label)
            {
                this.label = label;
            }

            public string toString()
            {
                return label;
            }
        }

        Dictionary<string, Node> nodes = new Dictionary<string, Node>();
        Dictionary<Node, List<Node>> adjacencyList = new Dictionary<Node, List<Node>>();

        public void addNode(string label)
        {
            var node = new Node(label);
            if (!nodes.ContainsKey(label))
            {
                nodes.Add(label, node);
            }
            adjacencyList.Add(node, new List<Node>());
        }

        public void addEdge(string from, string to)
        {
            if (!nodes.ContainsKey(from))
            {
                Console.WriteLine(from + " does not exist in graph");
                return;
            }

            if (!nodes.ContainsKey(to))
            {
                Console.WriteLine(to + " does not exist in graph");
                return;
            }

            var fromNode = new Node("");
            var toNode = new Node("");
            nodes.TryGetValue(from, out fromNode);
            nodes.TryGetValue(to, out toNode);

            var nodeList = new List<Node>();
            adjacencyList.TryGetValue(fromNode, out nodeList);
            nodeList.Add(toNode);
        }

        public void print()
        {
            foreach (var source in adjacencyList.Keys)
            {
                var targets = new List<Node>();
                adjacencyList.TryGetValue(source, out targets);
                var targetKeys = new StringBuilder();
                foreach (var target in targets)
                {
                    targetKeys.Append(target.toString());
                }
                if (!string.IsNullOrEmpty(targetKeys.ToString()))
                    Console.WriteLine(source.toString() + " is connected to " + targetKeys);
            }
        }

        public void removeNode(string label)
        {
            var node = new Node(label);

            // First Remove all connections in adjacencyList
            foreach (var n in adjacencyList.Values)
            {
                if (n.Contains(node))
                    n.Remove(node);
            }

            // Remove from Adjacency List
            if (adjacencyList.ContainsKey(node))
                adjacencyList.Remove(node);

            // Remove Node itself
            if (nodes.ContainsKey(label))
                nodes.Remove(label);
        }

        public void removeEdge(string from, string to)
        {
            var fromNode = new Node("");
            var toNode = new Node("");
            nodes.TryGetValue(from, out fromNode);
            nodes.TryGetValue(to, out toNode);

            if (!nodes.ContainsKey(from) || !nodes.ContainsKey(to))
                return;

            // Get Node List for From node
            var fromNodeList = new List<Node>();
            adjacencyList.TryGetValue(fromNode, out fromNodeList);

            // Remove ToNode from FromNodeList
            if (fromNodeList != null)
                fromNodeList.Remove(toNode);
        }
    }
}
