using System;

namespace _02.Divison
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int divis = 0;
            if (num % 2 == 0)
            {
                divis = 2;
            }
            if (num % 3 == 0)
            {
                divis = 3;
            }
            if (num % 6 == 0)
            {
                divis = 6;
            }
            if (num % 7 == 0)
            {
                divis = 7;
            }
            if (num % 10 == 0)
            {
                divis = 10;
            }
            if (divis == 0)
            {
                Console.WriteLine("Not divisible");
            }
            else
            {
                Console.WriteLine($"The number is divisible by {divis}");
            }
        }
    }
}
