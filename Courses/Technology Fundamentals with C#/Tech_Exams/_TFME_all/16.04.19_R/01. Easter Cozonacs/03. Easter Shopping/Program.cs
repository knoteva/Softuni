using System;
using System.Linq;

namespace _03._Easter_Shopping
{
    class Program
    {
        static void Main(string[] args)
        {
            var shops = Console.ReadLine()
                .Split(" ")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" ");
                var command = line[0];

                if (command == "Include")
                {
                    string shop = line[1];
                    shops.Add(shop);
                }
                else if (command == "Visit")
                {
                    int numberOfShops = int.Parse(line[2]);

                    if (line[1] == "first")
                    {
                        if (shops.Count >= numberOfShops)
                        {
                            shops.RemoveRange(0, numberOfShops);
                        }
                        
                    }
                    else if (line[1] == "last")
                    {
                        if (shops.Count >= numberOfShops)
                        {
                            shops.Reverse();
                            shops.RemoveRange(0, numberOfShops);
                            shops.Reverse();
                        }
                    }
                }
                else if (command == "Prefer")
                {
                    int index1 = int.Parse(line[1]);
                    int index2 = int.Parse(line[2]);
                    if (shops.ElementAtOrDefault(index1) != null && shops.ElementAtOrDefault(index2) != null)
                    {
                        string shop1 = shops[index1];
                        string shop2 = shops[index2];
                        shops.RemoveAt(index1);
                        shops.Insert(index1, shop2);
                        shops.RemoveAt(index2);
                        shops.Insert(index2, shop1);

                    }
                }
                else if (command == "Place")
                {
                    string shop = line[1];
                    int index = int.Parse(line[2]) + 1;
                    if (shops.ElementAtOrDefault(index) != null)
                    {
                        shops.Insert(index, shop);
                    }
                }
            }
            Console.WriteLine($"Shops left:");
            Console.WriteLine(string.Join(" ", shops));

        }
    }
}
