using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int capacity = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                
                
                string[] tokens = command.Split();
                if (tokens[0] == "Add")
                {
                    numbers.Add(int.Parse(tokens[1]));
                }
                else
                {
                    int token = int.Parse(tokens[0]);
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        if (numbers[i] + token <= capacity)
                        {
                        numbers[i] += token;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
