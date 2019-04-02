using System;

namespace _9.SumofOddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;
            var num = 0;
            for (int i = 1; i <= n; i++)
            {
                num = 2 * i - 1;
                Console.WriteLine(num);
                sum += num;
            }
            Console.WriteLine($"Sum: {sum}");


        }
    }
}
