using System;
namespace Shapes
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void Draw()
        {
            Console.WriteLine(new string('*', this.Width));
            for (int row = 0; row < this.Height - 2; row++)
            {
                Console.Write("*");
                Console.Write(new string(' ', this.Width - 2));
                Console.WriteLine("*");
            }
            Console.WriteLine(new string('*', this.Width));
        }
    }
}