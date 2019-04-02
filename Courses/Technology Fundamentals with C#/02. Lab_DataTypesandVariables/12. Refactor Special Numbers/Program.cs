using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int current = 0;
            bool special = false;
            for (int ch = 1; ch <= number; ch++)
            {
                current = ch;
                while (ch > 0)
                {
                    sum += ch % 10;
                    ch = ch / 10;
                }
                special = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", current, special);
                sum = 0;
                ch = current;
            }

        }
    }
}
