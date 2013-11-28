using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        const int THICKNESS = 16;
        const int GRID_WIDTH = 20;
        const int GRID_HEIGHT = 20;
        enum Dir {Up, Down, Left, Right};

        Dir heading = Dir.Right;

        Node food = new Node();
        Node previousNode = new Node();     // holds the most recently popped node
        LinkedList<Node> snakeBody = new LinkedList<Node>();

        public Form1()
        {
            InitializeComponent();
            
            // add snake head to the list
            snakeBody.AddFirst(new Node());

            gameTimer.Interval = 1000 / 4;
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();

            GenerateFood();
        }


        private void Update(object sender, EventArgs e)
        {
            MoveSnake();
            AteFood();
            canvasPB.Invalidate();
            if (Collision())
            {
                gameTimer.Stop();
                MessageBox.Show("Game Over.");
                return;
            }
        }

        private void canvasPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            foreach (Node segment in snakeBody)
            {
                canvas.FillRectangle(Brushes.White, segment.X * THICKNESS, segment.Y * THICKNESS,
                    THICKNESS, THICKNESS);
            }
            canvas.FillRectangle(Brushes.Red, food.X * THICKNESS, food.Y * THICKNESS, THICKNESS, THICKNESS);
        }

        private void MoveSnake()
        {
            previousNode.X = snakeBody.Last.Value.X;        // Store the last node
            previousNode.Y = snakeBody.Last.Value.Y;

            // grab the current head node and store it 
            Node nextNode = new Node(snakeBody.First.Value);

            nextNode = AdvanceNode(nextNode);

            // add the next node to the beginning list
            snakeBody.AddFirst(nextNode);

            snakeBody.RemoveLast();
        }

        private Node AdvanceNode(Node node)
        {
            Node temp = new Node(node.X, node.Y);

            // calculate where the next node will be based on the current head node and direction
            if      (heading == Dir.Up)     { temp.Y--; }
            else if (heading == Dir.Down)   { temp.Y++; }
            else if (heading == Dir.Left)   { temp.X--; }
            else if (heading == Dir.Right)  { temp.X++; }

            return temp;
        }

        private void GenerateFood()
        {
            Random random = new Random();

            // repeat the generation of food nodes until one is generated that is not in the body
            // Could also implement recursively (WHICH ONE IS BETTER?)/////////////////////////////////////
            do
            {
                food.X = random.Next(0, GRID_WIDTH);
                food.Y = random.Next(0, GRID_HEIGHT);
            } while (snakeBody.Contains(food));
        }

        // check if the head is the same coordinate as the food
        // call after the head position is updated
        private void AteFood()
        {
            Node snakeHead = new Node(snakeBody.First.Value);
            if (snakeHead.X == food.X && snakeHead.Y == food.Y)
            {
                // add the most recently popped off node back to the tail
                snakeBody.AddLast(previousNode);

                // Generate a new food
                GenerateFood();
            }
        }

        // Handle the keydown even, update the heading
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if      (e.KeyCode == Keys.Up)      { heading = Dir.Up; }
            else if (e.KeyCode == Keys.Down)    { heading = Dir.Down; }
            else if (e.KeyCode == Keys.Left)    { heading = Dir.Left; }
            else if (e.KeyCode == Keys.Right)   { heading = Dir.Right; }
        }

        // Check if there was a collision with either wall or body
        private bool Collision()
        {
            Node snakeHead = new Node(snakeBody.First.Value);

            // Wall collision
            if (snakeHead.X == GRID_WIDTH || snakeHead.X < 0 || snakeHead.Y == GRID_HEIGHT || snakeHead.Y < 0)
                return true;
            
            // Collision with own body
            snakeHead = AdvanceNode(snakeHead);
            foreach (var segment in snakeBody.Skip(1))
            {
                if (segment.X == snakeHead.X && segment.Y == snakeHead.Y)
                    return true;
            }

            return false;
        }

        
    }
}
