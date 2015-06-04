using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPlaceToHide
{
    class Network
    {
        public Graph makeGraph(int verticesCount)
        {

            /*
             * 0 - A
             * 1 - B
             * 2 - C
             * 3 - D
             * 4 - E
             * 5 - F
             */

            Graph graph = new Graph(6);
            GraphEdge edge;

            edge = new GraphEdge(0, 1, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(0, 2, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(1, 2, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(1, 4, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(4, 1, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(2, 3, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(1, 3, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(3, 1, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(2, 4, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(4, 2, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(4, 3, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(4, 5, 1);
            graph.addEdge(edge);

            edge = new GraphEdge(5, 4, 1);
            graph.addEdge(edge);

            return graph;
        }

        public int[,] generateCapacities(int size, int minVal, int maxVal)
        {
            Random rand = new Random();
            int[,] capacity = new int[size, size];

            capacity[0, 1] = rand.Next(minVal, maxVal);
            capacity[0, 2] = rand.Next(minVal, maxVal);
            capacity[1, 2] = rand.Next(minVal, maxVal);
            capacity[1, 3] = capacity[3, 1] = rand.Next(minVal, maxVal);
            capacity[1, 4] = capacity[4, 1] = rand.Next(minVal, maxVal);
            capacity[2, 3] = rand.Next(minVal, maxVal);
            capacity[2, 4] = capacity[4, 2] = rand.Next(minVal, maxVal);
            capacity[4, 3] = rand.Next(minVal, maxVal);
            capacity[4, 5] = capacity[5, 4] = rand.Next(minVal, maxVal);

            return capacity;
        }
    }
}
