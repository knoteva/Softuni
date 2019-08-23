using System;
using System.Linq;

namespace _02._Tasks_Planner_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
               .Split(' ')
               .Where(x => !string.IsNullOrWhiteSpace(x))
               .Select(int.Parse)
               .ToList();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string command = input.Split(" ")[0];
                if (command == "Complete")
                {
                    int index = int.Parse(input.Split(" ")[1]);
                    if (index >= 0 && index < list.Count)
                    {
                        int number = list[index];
                        list[index] = 0;
                    }
                }
                else if (command == "Change")
                {
                    int index = int.Parse(input.Split(" ")[1]);
                    int time = int.Parse(input.Split(" ")[2]);

                    if (index >= 0 && index < list.Count)
                    {
                        int number = list[index];
                        list[index] = time;
                    }
                }
                else if (command == "Drop")
                {
                    int index = int.Parse(input.Split(" ")[1]);
                    if (index >= 0 && index < list.Count)
                    {
                        int number = list[index];
                        list[index] = -1;
                    }
                }
                else if (command == "Count")
                {
                    string commandType = input.Split(" ")[1];
                    if (commandType == "Completed")
                    {

                        Console.WriteLine(list.Where(x => x == 0).Count());
                    }
                    else if (commandType == "Incomplete")
                    {
                        Console.WriteLine(list.Where(x => x > 0).Count());
                    }
                    else if (commandType == "Dropped")
                    {
                        Console.WriteLine(list.Where(x => x <= -1).Count());
                    }
                }
            }
            Console.WriteLine(string.Join(" ", list.Where(x => x > 0)));
        }
    }
}
