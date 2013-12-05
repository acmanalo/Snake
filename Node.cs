using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// Node holds and X and Y coordinates of an object for the game
    /// Implements IEquatable for use with .Contains in food generation
    /// </summary>
    class Node : IEquatable<Node>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Node()
        {
            X = 0;
            Y = 0;
        }

        public Node(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Constructor for using a tempory node as a reference
        public Node(Node node)
        {
            X = node.X;
            Y = node.Y;
        }

        public bool Equals(Node otherNode)
        {
            if (this.X == otherNode.X && this.Y == otherNode.Y)
                return true;
            return false;
        }
    }
}
