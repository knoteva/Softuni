using System;
using System.Collections.Generic;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var list1 = new List<int>();
            var list2 = new List<int>();
            for (int i = 1; i <= lines; i++)
            {
                var input = Console.ReadLine().Split(" ");
                if (i % 2 != 0)
                {
                    list1.Add(int.Parse(input[0]));
                    list2.Add(int.Parse(input[1]));
                }
                else
                {
                    list1.Add(int.Parse(input[1]));
                    list2.Add(int.Parse(input[0]));
                }
            }
            Console.WriteLine(string.Join(" ", list1));
            Console.WriteLine(string.Join(" ", list2));
        }
    }
}
