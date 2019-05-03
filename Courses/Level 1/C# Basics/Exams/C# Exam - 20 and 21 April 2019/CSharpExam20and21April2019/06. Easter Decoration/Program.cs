using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Easter_Decoration
{
    class Program
    {
        static void Main(string[] args)
        {
            int clients = int.Parse(Console.ReadLine());
            int count = 0;
            double amount = 0;
            var avg = new List<double>();

            for (int i = 0; i < clients; i++)
            {
                string product;
                while ((product = Console.ReadLine()) != "Finish")
                {
                    if (product == "basket")
                    {
                        amount += 1.50;
                    }
                    else if(product == "wreath")
                    {
                        amount += 3.80;
                    }
                    else if (product== "chocolate bunny")
                    {
                        amount += 7.00;
                    }
                    count++;
                }
                if (count % 2 == 0)
                {
                    amount *= 0.8;
                }
                Console.WriteLine($"You purchased {count} items for {amount:F2} leva.");
                avg.Add(amount);
                count = 0;
                amount = 0;
            }
            Console.WriteLine($"Average bill per client is: {avg.Average()} leva.");
        }
    }
}
