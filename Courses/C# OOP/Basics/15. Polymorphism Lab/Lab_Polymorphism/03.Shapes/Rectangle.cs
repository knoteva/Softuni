using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double sideA;
        private double sideB;
        public Rectangle(double sideA, double sideB)
        {
            this.sideA = sideA;
            this.sideB = sideB;
        }

        public override double CalculatePerimeter()
        {
            return this.sideA * 2 + this.sideB * 2;
        }
        public override double CalculateArea()
        { 
            return this.sideA * this.sideB;
        }
        public sealed override string Draw()
        { 
            return base.Draw() + "Rectangle";
        }
    }
}
