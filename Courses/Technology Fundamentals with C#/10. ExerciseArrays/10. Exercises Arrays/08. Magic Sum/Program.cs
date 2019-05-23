using System;
using System.Linq;

namespace _08._Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[i] + numbers[j] == num)
                    {
                        Console.WriteLine($"{numbers[i]} {numbers[j]}");
                    }
                }
                
            }
        }
    }
}
