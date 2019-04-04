using System;

namespace _04._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {

            int line = int.Parse(Console.ReadLine());
            PrintTriangle(line);
        }
        static void PrintTriangle(int n)
        {
            for (int line = 1; line <= n; line++)
                PrintLine(1, line);

            for (int line = n; line >= 1; line--)
                PrintLine(1, line - 1);
        }

        private static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

        }
    }
}
