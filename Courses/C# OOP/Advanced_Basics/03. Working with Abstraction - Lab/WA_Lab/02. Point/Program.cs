using System;
using System.Linq;

namespace Point
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rectangleCoordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var newRectangle = new Rectangle(rectangleCoordinates);

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                CheckingCoordinates(newRectangle);
            }
        }

        private static void CheckingCoordinates(Rectangle newRectangle)
        {
            int[] pointCoordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var newPoint = new Point(pointCoordinates);

            Console.WriteLine(newRectangle.Contains(newPoint));
        }
    }
}
