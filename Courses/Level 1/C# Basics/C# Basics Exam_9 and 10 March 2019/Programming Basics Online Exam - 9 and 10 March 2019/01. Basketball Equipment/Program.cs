using System;

namespace _01._Basketball_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            int fee = int.Parse(Console.ReadLine());

            double a = fee * 0.6;
            double b = a * 0.8;
            double c = b / 4.00;
            double d = c / 5;
            double price = fee + a + b + c + d;
            Console.WriteLine($"{price:F2}");

        }
    }
}
