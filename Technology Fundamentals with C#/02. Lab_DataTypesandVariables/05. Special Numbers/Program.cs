using System;
using System.Linq;

namespace _05._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
           int num = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= num; i++)
            {
                sum = i.ToString().Sum(c => c - '0');
                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                }
                else {
                    Console.WriteLine($"{i} -> False");
                }
            }
        }
    }
}
