using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            Console.WriteLine(Substract(first, second, third));
        }

        private static int Sum(int first, int second)
        {
            int sum = first + second;
            return sum;
        }
        private static int Substract(int first, int second, int third)
        {
            int sub = Sum(first, second) - third;
            return sub;
        }
    }
}
