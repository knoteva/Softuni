using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            Orders(type, quantity);
        }

        private static void Orders(string type, int quantity)
        {
            double result = 0.00;
            switch (type)
            {
                case "coffee":
                    result = quantity * 1.50;
                    break;
                case "water":
                    result = quantity * 1.00;
                    break;
                case "coke":
                    result = quantity * 1.40;
                    break;
                case "snacks":
                    result = quantity * 2.00;
                    break;
                default:
                    break;

            }
            Console.WriteLine($"{result:F2}");
        }
    }
}
