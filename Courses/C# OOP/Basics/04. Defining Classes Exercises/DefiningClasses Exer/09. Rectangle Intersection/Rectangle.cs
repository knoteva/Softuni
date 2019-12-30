using System;

namespace RectangleIntersection
{
    public class Rectangle
    {
        private string id;
        private double width;
        private double height;
        private double x;
        private double y;

        public Rectangle(string id, double width, double height, double horizontal, double vertical)
        {
            Id = id;
            Width = width;
            Height = height;
            X = horizontal;
            Y = vertical;
        }

        public string Id { get => id; set => id = value; }
        public double Width { get => width; set => width = value; }
        public double Height { get => height; set => height = value; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }

        internal bool Intersect(Rectangle seconfRectangle)
        {
            if (X + Width < seconfRectangle.X || seconfRectangle.X + seconfRectangle.Width < X || Y + Height < seconfRectangle.Y || seconfRectangle.Y + seconfRectangle.Height < Y)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
