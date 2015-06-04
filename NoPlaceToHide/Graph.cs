using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPlaceToHide
{
    class GraphEdge : IComparable<GraphEdge>
    {
        public int first { get; private set; }
        public int second { get; private set; }

        public int weight { get; private set; }

        public GraphEdge(int first, int second, int weight)
        {
            this.first = first;
            this.second = second;
            this.weight = weight;
        }

        public int either()
        {
            return first;
        }
        public int other(int vertex)
        {
            if (vertex == first) return second;
            else if (vertex == second) return first;
            else throw new ApplicationException("wrong argument");
        }

        int IComparable<GraphEdge>.CompareTo(GraphEdge other)
        {
            if (this.weight < other.weight) return -1;
            else if (this.weight > other.weight) return 1;
            else return 0;
        }
    }


    class Graph
    {

        List<GraphEdge>[] _adj;
        public int edgesCount { get; private set; }

        public Graph(int verticesCount)
        {
            if (verticesCount < 0) throw new ArgumentException();
            _adj = new List<GraphEdge>[verticesCount];
            edgesCount = 0;

            for (int i = 0; i < verticesCount; i++)
            {
                _adj[i] = new List<GraphEdge>();
            }
        }

        public void addEdge(GraphEdge edge)
        {
            int v = edge.either();
            validateVertex(v);
            _adj[v].Add(edge);
            edgesCount++;
        }

        public IEnumerable<GraphEdge> adj(int v)
        {
            validateVertex(v);
            return _adj[v];
        }

        public GraphEdge[] edges()
        {
            List<GraphEdge> edges = new List<GraphEdge>();
            for (int i = 0; i < _adj.Length; i++)
            {
                foreach (var edge in _adj[i])
                {
                    edges.Add(edge);
                }
            }

            return edges.ToArray();

        }

        public int vertciesCount()
        {
            return _adj.Count();
        }

        private void validateVertex(int v)
        {
            if (v < 0 || v > _adj.Count())
                throw new IndexOutOfRangeException("vertex " + v + " is not between 0 and " + _adj.Count());
        }

    }
}
