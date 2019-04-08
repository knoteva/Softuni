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
                .ToList();
            double budget = double.Parse(Console.ReadLine());
            double profit = 0;
            var items = new List<double>();

            for (int i = 0; i < list.Count; i++)
            {
                string type = list[i].Split("->")[0];
                double price = double.Parse(list[i].Split("->")[1]);
                if (type == "Clothes" && price <= 50.00 && budget - price >= 0)
                {
                    budget -= price;
                    items.Add(price * 1.4);
                }
                if (type == "Shoes" && price <= 35.00 && budget - price >= 0)
                {
                    budget -= price;
                    items.Add(price * 1.4);
                }
                if (type == "Accessories" && price <= 20.50 && budget - price >= 0)
                {
                    budget -= price;
                    items.Add(price * 1.4);          }
            }

            foreach (var number in items)
            {
                Console.Write($"{number:f2} ");
            }
            Console.WriteLine();

            profit = items.Sum() - items.Sum() / 1.4;

            Console.WriteLine($"Profit: {profit:F2}");
          
            if (budget + items.Sum(x => x) >= 150)
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
