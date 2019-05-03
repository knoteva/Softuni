using System;

namespace _04._Easter_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggs = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            int leftEggs = 0;

            while (true)
            {
                if (command =="Close")
                {
                    Console.WriteLine($"Store is closed!");
                    Console.WriteLine($"{leftEggs} eggs sold.");
                    return;
                }

                int quantity = int.Parse(Console.ReadLine());

                if (command == "Buy")
                {
                    if (eggs >= quantity)
                    {
                        eggs -= quantity;
                        leftEggs += quantity;
                    }
                    else
                    {
                        Console.WriteLine($"Not enough eggs in store!");
                        Console.WriteLine($"You can buy only {eggs}.");
                        return;
                    }
                    
                }
                else if (command == "Fill")
                {
                    eggs += quantity;
                }
                command = Console.ReadLine();
            }
        }
    }
}
