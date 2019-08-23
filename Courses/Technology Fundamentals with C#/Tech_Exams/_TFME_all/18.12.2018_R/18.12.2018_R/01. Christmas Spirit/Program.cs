using System;

namespace _01._Christmas_Spirit
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int cost = 0;
            int spirit = 0;

            int ornamentSet = 2;
            int skirt = 5;
            int garlands = 3;
            int lights = 15;
                

            for (int i = 1; i <= days; i++)
            {
                if (i % 11 == 0)
                {
                    quantity += 2;
                }

                if (i % 2 == 0)
                {
                    cost += ornamentSet * quantity;
                    spirit += 5;
                }
                if (i % 3 == 0)
                {
                    cost += skirt * quantity + garlands * quantity;
                    spirit += 13;
                }
                if (i % 5 == 0)
                {
                    cost += lights * quantity;
                    spirit += 17;

                    if (i % 3 == 0)
                    {
                        spirit += 30;
                    }
                }
                if (i % 10 == 0)
                {
                    cost += skirt + garlands + lights;
                    spirit -= 20;                  
                }              
            }
            if (days % 10 == 0)
            {
                spirit -= 30;
            }
            Console.WriteLine($"Total cost: {cost}");
            Console.WriteLine($"Total spirit: {spirit}");
        }
    }
}
