using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
               .Split("|")
               .Where(s => !string.IsNullOrWhiteSpace(s))
               .ToList();
            double budget = double.Parse(Console.ReadLine());
            var items = new List<double>();

            for (int i = 0; i < list.Count; i++)
            {
                string item = list[i].Split("->")[0];
                double price = double.Parse(list[i].Split("->")[1]);
                if (item == "Clothes" && price <= 50 && budget >= price)
                {
                    budget -= price;
                    items.Add(price * 1.4);
                }
                else if (item == "Shoes" && price <= 35 && budget >= price)
                {
                    budget -= price;
                    items.Add(price * 1.4);
                }
                else if (item == "Accessories" && price <= 20.5 && budget >= price)
                {
                    budget -= price;
                    items.Add(price * 1.4);
                }
            }
            foreach (var price in items)
            {
                Console.Write($"{price:F2} ");
            }
            Console.WriteLine();

            double profit = items.Sum() - items.Sum() / 1.4;

            Console.WriteLine($"Profit: {profit:F2}");

            double a = budget + items.Sum(x => x);
            if (a >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }
        }
    }
}
