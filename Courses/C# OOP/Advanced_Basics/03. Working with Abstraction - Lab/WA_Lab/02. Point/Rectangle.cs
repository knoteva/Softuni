namespace Point
{
    using System.Drawing;
    public class Rectangle
    {
        private int topLeftX;
        private int topLeftY;
        private int bottomRightX;
        private int bottomRightY;

        public Rectangle(int[] rectangleCoordinates)
        {
            this.topLeftY = rectangleCoordinates[1];
            this.topLeftX = rectangleCoordinates[0];
            this.bottomRightX = rectangleCoordinates[2];
            this.bottomRightY = rectangleCoordinates[3];
        }

        public bool Contains(Point point)
        {
            bool inside = point.X >= topLeftX && point.Y >= topLeftY &&
                          point.X <= bottomRightX && point.Y <= bottomRightY;

            return inside;
        }
    }

}
