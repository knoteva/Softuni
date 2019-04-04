using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] commands = line.Split();
                ExecuteCommand(numbers, commands);
                line = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void ExecuteCommand(List<int> numbers, string[] commands)
        {
            if (commands[0] == "Add")
            {
                numbers.Add(int.Parse(commands[1]));
            }
            else if (commands[0] == "Insert")
            {
                int index = int.Parse(commands[2]);
                if (index >= 0 && index < numbers.Count)
                {
                    numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            else if (commands[0] == "Remove")
            {
                int index = int.Parse(commands[1]);
                if (index >= 0 && index < numbers.Count)
                {
                    numbers.RemoveAt(index);
                }
                else
                {
                    Console.WriteLine("Invalid index");
                }
            }
            else if (commands[1] == "left")
            {
                for (int i = 0; i < int.Parse(commands[2]); i++)
                {
                    int tempNum = numbers[0];
                    numbers.Add(tempNum);
                    numbers.RemoveAt(0);
                }
            }
            else if (commands[1] == "right")
            {
                for (int i = 0; i < int.Parse(commands[2]); i++)
                {
                    numbers.Insert(0, numbers[numbers.Count - 1]);
                    numbers.RemoveAt(numbers.Count - 1);
                }
            }
            //Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
