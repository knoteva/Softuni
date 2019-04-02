using System;

namespace _08._Town_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string population = Console.ReadLine();
            string area = Console.ReadLine();
            Console.WriteLine($"Town {name} has population of {population} and area {area} square km.");
        }
    }
}
