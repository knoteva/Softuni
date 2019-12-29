using System;
using System.Collections.Generic;

namespace Shapes
{
   public class StartUp
    {
        public static void Main(string[] args)
        {
            var shapes = new List<Shape>();

            shapes.Add(new Circle(3.5));
            shapes.Add(new Rectangle(3.5, 1.2));
            shapes.Add(new Rectangle(1.5, 1.5));
            shapes.Add(new Rectangle(3.4, 1.5));
            shapes.Add(new Circle(3.6));

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.Draw());
            }
        }
    }
}
