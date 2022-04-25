using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6TaskB.Classes
{
    public class GraphNode
    {
        public string code; //data stored in the node 

        public LinkedList<string> adjList; //list of the IDs of the nodes that are adjacent


        public GraphNode(string code)
        {
            this.code = code;
            adjList = new LinkedList<string>();
        }

        public string Code
        {
            set { code = value; }
            get { return code; }
        }


        public void AddEdge(GraphNode to)
        {
            adjList.AddLast(to.code);
        }

        public void RemoveEdge(GraphNode to)
        {
            adjList.Remove(to.code);
        }

        public LinkedList<string> GetAdjList()
        {
            return adjList;
        }

    }
}
