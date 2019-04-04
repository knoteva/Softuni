using System;
using System.Collections.Generic;

namespace _03._House_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var result = new List<string>();

            for (int i = 0; i < lines; i++)
            {               
                string[] tokkens = Console.ReadLine().Split();
                string name = tokkens[0];
                string command = tokkens[2];
                if (command == "going!")
                {
                    if (result.Contains(name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        result.Add(name);
                    }
                }
                if (command == "not")
                {
                    if (!result.Contains(name))
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                    else
                    {
                        result.Remove(name);
                    }
                }
            }
            Console.WriteLine(string.Join("\n", result));
        }
    }
}
