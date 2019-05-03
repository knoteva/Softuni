using System;

namespace _03._Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            string color = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            int price = 0;

            switch (size)
            {
                case "Large":
                    if (color == "Red")
                    {
                        price = 16;
                    }
                    else if (color == "Green")
                    {
                        price = 12;
                    }
                    else
                    {
                        price = 9;
                    }
                    break;
                case "Medium":
                    if (color == "Red")
                    {
                        price = 13;
                    }
                    else if (color == "Green")
                    {
                        price = 9;
                    }
                    else
                    {
                        price = 7;
                    }
                    break;
                case "Small":
                    if (color == "Red")
                    {
                        price = 9;
                    }
                    else if (color == "Green")
                    {
                        price = 8;
                    }
                    else
                    {
                        price = 5;
                    }
                    break;

                default:
                    break;
            }
            Console.WriteLine($"{price * quantity * 0.65:F2} leva.");
        }
    }
}
