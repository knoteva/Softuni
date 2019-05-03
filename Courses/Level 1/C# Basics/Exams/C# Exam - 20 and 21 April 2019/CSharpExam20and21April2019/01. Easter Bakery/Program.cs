using System;

namespace _01._Easter_Bakery
{
    class Program
    {
        static void Main(string[] args)
        {
            double flourPerKg = double.Parse(Console.ReadLine());
            double flourKg = double.Parse(Console.ReadLine());
            double sugarKg = double.Parse(Console.ReadLine());
            int eggs = int.Parse(Console.ReadLine());
            int maq = int.Parse(Console.ReadLine());
            double result = flourPerKg * 0.75 * sugarKg + flourPerKg * 1.1 * eggs + flourPerKg * flourKg + flourPerKg * 0.75 * 0.2 * maq;
            Console.WriteLine($"{result:F2}");
        }
    }
}
