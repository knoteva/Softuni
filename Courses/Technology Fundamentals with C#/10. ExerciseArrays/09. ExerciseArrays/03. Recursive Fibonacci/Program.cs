using System;

namespace RecursiveFibonaci
{
    // 85 ot 100 , no memorization
    class Program
    {
        static void Main(string[] args)
        {

            int i = 0, c;
            long n = long.Parse(Console.ReadLine());
            int result = 0;
            for (c = 1; c <= n + 1; c++)
            {
                result = FibonacciFunction(i);
                i++;
            }
            Console.WriteLine(result);

        }

        public static int FibonacciFunction(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            else
            {
                return (FibonacciFunction(n - 1) + FibonacciFunction(n - 2));
            }
        }

    }
}