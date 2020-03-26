using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra_s_Algorithm
{
    class Vertex
    {
        private Vertex father;
        private int distance;
        private int id;
    

        public Vertex(int n)
        {
            father = null;
            distance = 0;
            id = n;
        }

        public int GetDistance()
        {
            return distance;
        }

        public Vertex GetFather()
        {
            return father;
        }

        public int GetId()
        {
            return id;
        }

        public void SetFather(Vertex f)
        {
            father = f;
        }

        public void SetDistance(int d)
        {
            distance = d;
        }

    }
}
