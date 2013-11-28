using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Node
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Node()
        {
            X = 0;
            Y = 0;
        }

        public Node(Node node)
        {
            X = node.X;
            Y = node.Y;
        }
    }
}
