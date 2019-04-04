using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
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

            while (line != "end")
            {
                string[] commands = line.Split();
                if (commands[0] == "Delete")
                {
                    numbers.RemoveAll(item => item == int.Parse(commands[1]));
                }
                if (commands[0] == "Insert")
                {
                    numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1])); 
                }
                line = Console.ReadLine();            
           }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
