namespace PointInRectangle
{
    public class Rectangle
    {
        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public Rectangle(int topX, int topY, int bottomX, int bottomY)
        {
            TopLeft = new Point(topX, topY);
            BottomRight = new Point(bottomX, bottomY);
        }

        public bool Contaians(Point point)
        {
            bool contains = TopLeft.X <= point.X && point.X <= BottomRight.X &&
                TopLeft.Y <= point.Y && point.Y <= BottomRight.Y;

            return contains;
        }
    }
}
