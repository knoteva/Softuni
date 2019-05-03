using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Easter_Bake
{
    class Program
    {
        static void Main(string[] args)
        {
            int kozunaci = int.Parse(Console.ReadLine());
            var maxSugar = new List<int>();
            var maxFlour = new List<int>();
            int currSugar = 0;
            int currFlour = 0;
            for (int i = 0; i < kozunaci; i++)
            {
                currSugar = int.Parse(Console.ReadLine());
                currFlour = int.Parse(Console.ReadLine());
                maxSugar.Add(currSugar);
                maxFlour.Add(currFlour);
            }

            int sugar = (int)Math.Ceiling(maxSugar.Sum() / 950.00);
            int flour = (int)Math.Ceiling(maxFlour.Sum() / 750.00);
            Console.WriteLine($"Sugar: {sugar}");
            Console.WriteLine($"Flour: {flour}");
            Console.WriteLine($"Max used flour is {maxFlour.Max()} grams, max used sugar is {maxSugar.Max()} grams.");
        }
    }
}
