using System;
using System.Collections.Generic;
using System.Linq;

namespace Dijkstra_s_Algorithm
{
    class Program
    {

        static List<LinkedList<Tuple<int, Vertex>>> initGraph() // sets the graph in a data structure that can be handled
        {
            List<LinkedList<Tuple<int, Vertex>>> graph = new List<LinkedList<Tuple<int, Vertex>>>();
            List<Vertex> vertices = new List<Vertex>();

            for (int i = 0; i < 6; i++)
            {
                graph.Add(new LinkedList<Tuple<int, Vertex>>());
                vertices.Add(new Vertex(i));
            }

            graph[0].AddLast(new Tuple<int, Vertex>(0, vertices[0]));
            graph[0].AddLast(new Tuple<int, Vertex>(14, vertices[2]));
            graph[0].AddLast(new Tuple<int, Vertex>(9, vertices[3]));
            graph[0].AddLast(new Tuple<int, Vertex>(7, vertices[5]));

            graph[1].AddLast(new Tuple<int, Vertex>(0, vertices[1]));
            graph[1].AddLast(new Tuple<int, Vertex>(6, vertices[4]));
            graph[1].AddLast(new Tuple<int, Vertex>(9, vertices[2]));

            graph[2].AddLast(new Tuple<int, Vertex>(0, vertices[2]));
            graph[2].AddLast(new Tuple<int, Vertex>(9, vertices[1]));
            graph[2].AddLast(new Tuple<int, Vertex>(2, vertices[3]));
            graph[2].AddLast(new Tuple<int, Vertex>(14, vertices[0]));

            graph[3].AddLast(new Tuple<int, Vertex>(0, vertices[3]));
            graph[3].AddLast(new Tuple<int, Vertex>(11, vertices[4]));
            graph[3].AddLast(new Tuple<int, Vertex>(10, vertices[5]));
            graph[3].AddLast(new Tuple<int, Vertex>(9, vertices[0]));
            graph[3].AddLast(new Tuple<int, Vertex>(2, vertices[2]));

            graph[4].AddLast(new Tuple<int, Vertex>(0, vertices[4]));
            graph[4].AddLast(new Tuple<int, Vertex>(15, vertices[5]));
            graph[4].AddLast(new Tuple<int, Vertex>(11, vertices[3]));
            graph[4].AddLast(new Tuple<int, Vertex>(6, vertices[1]));

            graph[5].AddLast(new Tuple<int, Vertex>(0, vertices[5]));
            graph[5].AddLast(new Tuple<int, Vertex>(7, vertices[0]));
            graph[5].AddLast(new Tuple<int, Vertex>(10, vertices[3]));
            graph[5].AddLast(new Tuple<int, Vertex>(15, vertices[4]));

            return graph;
        }

        static List<Vertex> Dijkstra(int src, int dst, List<LinkedList<Tuple<int, Vertex>>> graph) // finds shortest path
        {
            List<Vertex> unused = new List<Vertex>();
            List<Vertex> res = new List<Vertex>();
            LinkedListNode<Tuple<int, Vertex>> curr;
            int i = 0, d = 0, mind = 0;
            Vertex p;

            for (i = 0; i < graph.Count; i++) // filling the list of unused vertices
            {
                unused.Add(graph[i].First.Value.Item2);
            }

            while (unused.Count != 0)
            {
                curr = graph[src].First;
                p = curr.Value.Item2;
                d = curr.Value.Item2.GetDistance();
                unused.Remove(p);
                curr = curr.Next;
                while (curr != null)
                {
                    if ((d + curr.Value.Item1 < curr.Value.Item2.GetDistance() || curr.Value.Item2.GetDistance() == 0) && unused.Contains(curr.Value.Item2))
                    {
                        curr.Value.Item2.SetDistance(d + curr.Value.Item1);
                        curr.Value.Item2.SetFather(p);
                    }
                    curr = curr.Next;
                }

                curr = graph[src].First;
                curr = curr.Next;
                mind = -1;
                while (curr != null) // deciding where to go next;
                {
                    if ((mind > curr.Value.Item2.GetDistance() || mind == -1) && unused.Contains(curr.Value.Item2))
                    {
                        mind = curr.Value.Item2.GetDistance();
                        src = curr.Value.Item2.GetId();
                    }
                    curr = curr.Next;
                }
                if (mind == -1 && unused.Count != 0) // if the next vertex lies somewhere else in the graph, go to it
                {
                    src = unused.First().GetId();
                }

            }

            p = graph[dst].First.Value.Item2;
            while (p != null)   // get the parent of each vertex starting from the destination vertex
            {
                res.Add(p);
                p = p.GetFather();
            }
            res.Reverse(); // reversing the result path so its better printable
            return res;
        }
        static void Main(string[] args)
        {
            List<LinkedList<Tuple<int, Vertex>>> graph = initGraph(); // initiating graph
            List<Vertex> path = Dijkstra(0, 1, graph); 

            Console.WriteLine("The results of the algorithm: \n");

            Console.Write((char)(path.First().GetId() + 'a'));  // printing the path
            for (int i = 1; i < path.Count; i++)
            {
                Console.Write(" -> " + (char)(path[i].GetId() + 'a'));
            }
            Console.WriteLine();
        }
    }
}
