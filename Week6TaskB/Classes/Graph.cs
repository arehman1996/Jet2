using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6TaskB.Classes
{
    public class Graph
    {
        public LinkedList<GraphNode> nodes;

        public int edgeCount;


        public Graph()
        {
            nodes = new LinkedList<GraphNode>();
        }

        public void AddNode(string code)
        {
            nodes.AddLast(new GraphNode(code));
        }

        public GraphNode GetNodeByID(string code)
        {
            foreach (GraphNode n in nodes)
            {
                if (n.code == code)
                {
                    return n;
                }
            }

            return null;
        }

        public void AddEdge(string from, string to)
        {
            GraphNode n1 = GetNodeByID(from);
            GraphNode n2 = GetNodeByID(to);

            n1.AddEdge(n2);

            edgeCount = edgeCount + 1;
        }



        public void RemoveEdge(string from, string to)
        {

            GraphNode n1 = GetNodeByID(from);
            GraphNode n2 = GetNodeByID(to);

            n1.RemoveEdge(n2);

            edgeCount = edgeCount - 1;
        }

        public GraphNode findNodeInGraph(string s)
        {
            foreach (GraphNode n in nodes)
            {
                if (n.code == s)
                {
                    return n;
                }
            }
            return null;    
        }

        public void DepthFirstTraverse(string startID, ref List <string> visited)
        {
            LinkedList<string> adj;
            Stack<string> toVisit = new Stack<string>();

            GraphNode current = new GraphNode(startID);

            toVisit.Push(startID);

            while (toVisit.Count != 0)
            {
                string id;
                id = toVisit.Pop(); // get ID of current node from toVisit  (use Pop)


                visited.Add(id); // store ID of the current node as “visited” 


                GraphNode n = findNodeInGraph(id);

                adj = n.GetAdjList(); // get adjacency list of the current node (use method from GraphNode)


                
                foreach (string t in adj)
                {
                    if (visited.Any(t.Contains) == false && toVisit.Any(t.Contains) == false)
                    {
                         toVisit.Push(t);
                    }
                    
                }

            }
        }

    }
}

