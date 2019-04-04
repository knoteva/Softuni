using System;
using System.Collections.Generic;

namespace methodsOrFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstX = double.Parse(Console.ReadLine());
            double firstY = double.Parse(Console.ReadLine());
            double secondX = double.Parse(Console.ReadLine());
            double secondY = double.Parse(Console.ReadLine());
            CenterPoint(firstX, firstY, secondX, secondY);



        }
        static void CenterPoint(double x1, double y1, double x2, double y2)
        {
            if (Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2)) < Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2)))
                Console.WriteLine($"({x1}, {y1})");
            else
                Console.WriteLine($"({x2}, {y2})");

        }
    }
}