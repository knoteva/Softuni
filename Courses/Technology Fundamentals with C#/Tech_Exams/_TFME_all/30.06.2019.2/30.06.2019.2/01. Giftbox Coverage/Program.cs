using System;

namespace _01._Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            int sheetsNumber = int.Parse(Console.ReadLine());
            double sheetArea = double.Parse(Console.ReadLine());

            side *= side * 6.0;
            int smallSheets = sheetsNumber / 3;
            int normalShhets = sheetsNumber - smallSheets;
            double totalArea = normalShhets * sheetArea + smallSheets * (sheetArea * 0.25);
            double percentage = totalArea / side * 100;

            Console.WriteLine($"You can cover {percentage:F2}% of the box.");
        }
    }
}
