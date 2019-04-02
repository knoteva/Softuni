using System;

namespace _04.PrintandSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            string str = "";
            int sum = 0;
            for (int i = start; i <= end; i++)
            {
                str += i + " ";
                sum += i;
            }
            Console.WriteLine(str);
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
