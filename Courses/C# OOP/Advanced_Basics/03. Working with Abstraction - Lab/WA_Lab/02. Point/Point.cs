using System;
using System.Collections.Generic;
using System.Text;

namespace Point
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int[] pointCoordinates)
        {
            this.X = pointCoordinates[0];
            this.Y = pointCoordinates[1];
        }
    }
}

