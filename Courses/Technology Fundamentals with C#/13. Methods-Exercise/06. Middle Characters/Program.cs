using System;
using System.Linq;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            PrintMiddleChar(str);

        }

        private static void PrintMiddleChar(string str)
        {
            if (str.Length % 2 == 0)
            {
                Console.WriteLine($"{str[str.Length / 2 - 1]}{str[str.Length / 2]}");
            }
            else
            {
                Console.WriteLine($"{str[str.Length / 2]}");
            }
        }
    }
}
