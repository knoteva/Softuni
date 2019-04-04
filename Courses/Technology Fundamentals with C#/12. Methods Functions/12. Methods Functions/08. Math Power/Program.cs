using System;
using System.Numerics;

namespace _08._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            int pow = int.Parse(Console.ReadLine());
            Console.WriteLine(MathPower(num, pow));
        }

        private static double MathPower(double num, int pow)
        {
            double result = num;
            for (int i = 1; i < pow; i++)
            {
                result *= num;
            }

            return result;
        }
    }
}
