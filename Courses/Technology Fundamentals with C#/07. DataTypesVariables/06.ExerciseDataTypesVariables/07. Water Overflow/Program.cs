using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int liters = 0;
            for (int i = 0; i < lines; i++)
            {
                int liter = int.Parse(Console.ReadLine());
                if (liter + liters <= 255)
                {
                    liters += liter;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            Console.WriteLine(liters);
        }
    }
}
