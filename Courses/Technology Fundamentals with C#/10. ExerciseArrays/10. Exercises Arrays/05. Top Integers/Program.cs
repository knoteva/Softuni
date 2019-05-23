using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            bool bigger = false;
            var result = new List<int>();

            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    int currEl = list[i];
                    int nextEl = list[j];

                    if (currEl <= nextEl)
                    {
                        bigger = false;
                        break;
                    }
                    else
                    {
                        bigger = true;
                    }
                }
                if (bigger)
                {
                    result.Add(list[i]);
                }
            }
            result.Add(list[list.Count - 1]);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
