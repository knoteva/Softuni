using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var list = new List<int>();

            for (int i = 0; i < lines; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }
            Console.WriteLine(string.Join(" ", list));
            Console.WriteLine(list.Sum());
        }
    }
}