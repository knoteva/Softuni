using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> counts = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            string str = Console.ReadLine();
            string result = "";

            for (int num = 0; num < counts.Count; num++)
            {
                int index = counts[num].ToString().Sum(c => c - '0');
                if (index >= str.Length)
                {
                    index -= str.Length;
                }
                result += str[index];
                str = str.Remove(index, 1);
            }
            Console.WriteLine(result);
        }
    }
}
