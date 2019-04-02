using System;

namespace _01._Integer_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int divide = int.Parse(Console.ReadLine());
            int multiply = int.Parse(Console.ReadLine());
            long result = (first + second) / divide * multiply;
            Console.WriteLine(result);
        }
    }
}
