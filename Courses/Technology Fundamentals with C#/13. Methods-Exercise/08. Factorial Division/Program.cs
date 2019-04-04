using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            Console.WriteLine($"{CalculateFactorial(first, second):F2}");
        }

        private static double CalculateFactorial(int first, int second)
        {
            double result1 = 1;
            double result2 = 1;
            for (int i = 1; i <= first; i++)
            {
                result1 = result1 * i;
            }
            for (int i = 1; i <= second; i++)
            {
                result2 = result2 * i;
            }
            return result1 / result2;

        }
    }
}
