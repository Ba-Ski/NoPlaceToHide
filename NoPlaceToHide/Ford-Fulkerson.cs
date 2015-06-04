using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoPlaceToHide
{


    class FordFulkerson
    {

        public int getMaximumFlow(Graph graph, int[,] capacity, ref int[,] flow, int s, int t)
        {


            //int[,] flow = new int[graph.vertciesCount(), graph.vertciesCount()];


            while (3 < 5)
            {
                int[] parent = new int[graph.vertciesCount()];
                int[] pathCapacity = new int[graph.vertciesCount()];

                bool theEnd = false;

                for (int i = 0; i < graph.vertciesCount(); i++)
                {
                    parent[i] = -1;
                }

                Queue<int> queue = new Queue<int>();

                parent[s] = s;
                pathCapacity[s] = int.MaxValue;
                queue.Enqueue(s);

                while (queue.Count != 0 && !theEnd)
                {
                    int u = queue.Dequeue();
                    foreach (var edge in graph.adj(u))
                    {
                        int v = edge.other(u);
                        if (parent[v] == -1 && flow[u, v] < capacity[u, v])
                        {
                            parent[v] = u;
                            pathCapacity[v] = Math.Min(pathCapacity[u], capacity[u, v] - flow[u, v]);
                            if (v != t)
                                queue.Enqueue(v);

                            else
                            {

                                while (parent[v] != v)
                                {
                                    u = parent[v];
                                    flow[u, v] += pathCapacity[t];
                                    flow[v, u] -= pathCapacity[t];
                                    v = u;
                                }
                                theEnd = true;
                                break;
                            }
                        }
                    }
                }



                if (parent[t] == -1)
                {
                    int resFlow = 0;
                    for (int i = 0; i < graph.vertciesCount(); i++)
                        resFlow += flow[s, i];

                    return resFlow;
                }




            }
        }


    }
}
