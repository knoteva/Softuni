namespace PointInRectangle
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int[] coordinates = Console.ReadLine()
           .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .ToArray();

            Rectangle rect = new Rectangle(coordinates[0], coordinates[1], coordinates[2], coordinates[3]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] pointCoordinates = Console.ReadLine()
                    .Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                Point point = new Point(pointCoordinates[0], pointCoordinates[1]);

                Console.WriteLine(rect.Contaians(point));
            }
        }
    }
}
