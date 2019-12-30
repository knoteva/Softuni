namespace RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(" ");
            int n = int.Parse(firstLine[0]);
            int m = int.Parse(firstLine[1]);
            var rectangles = new List<Rectangle>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                string id = input[0];
                double width = double.Parse(input[1]);
                double height = double.Parse(input[2]);
                double horizontal = double.Parse(input[3]);
                double vertical = double.Parse(input[4]);
                var rectangle = new Rectangle(id, width, height, horizontal, vertical);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split(" ");
                string firstId = input[0];
                string secondtId = input[1];

                Rectangle firstRectangle = rectangles.FirstOrDefault(x => x.Id == firstId);
                Rectangle seconfRectangle = rectangles.FirstOrDefault(x => x.Id == secondtId);

                if (firstRectangle.Intersect(seconfRectangle))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}
