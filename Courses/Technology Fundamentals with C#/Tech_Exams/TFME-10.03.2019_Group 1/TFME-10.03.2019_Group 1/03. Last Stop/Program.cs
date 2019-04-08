using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Last_Stop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string commandLine = "";
            while ((commandLine = Console.ReadLine()) != "END")
            {
                string command = commandLine.Split(" ")[0];
                //Console.WriteLine(command);

                if (command == "Hide")
                {
                    int num = int.Parse(commandLine.Split(" ")[1]);
                    if (numbers.Contains(num))
                    {
                        numbers.Remove(num);
                    }
                }

                if (command == "Reverse")
                {
                    numbers.Reverse();
                }

                if (command == "Switch")
                {
                    int num1 = int.Parse(commandLine.Split(" ")[1]);
                    int num2 = int.Parse(commandLine.Split(" ")[2]);
                    if (numbers.Contains(num1) && numbers.Contains(num2))
                    {
                        int index1 = numbers.IndexOf(num1);
                        int index2 = numbers.IndexOf(num2);
                        numbers.RemoveAt(index1);
                        numbers.Insert(index1, num2);
                        numbers.RemoveAt(index2);
                        numbers.Insert(index2, num1);
                    }
                }

                if (command == "Insert")
                {
                    int desiredIndex = int.Parse(commandLine.Split(" ")[1]) + 1;
                    int num = int.Parse(commandLine.Split(" ")[2]);
                    if (numbers.Count > desiredIndex && desiredIndex >= 0)
                    {
                        numbers.Insert(desiredIndex, num);
                    }
                }

                if (command == "Change")
                {
                    int num1 = int.Parse(commandLine.Split(" ")[1]);
                    int num2 = int.Parse(commandLine.Split(" ")[2]);
                    if (numbers.Contains(num1))
                    {
                        int index = numbers.IndexOf(num1);
                        //Console.WriteLine(index);
                        numbers.RemoveAt(index);
                        numbers.Insert(index, num2);
                    }
                }

            }
          Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
