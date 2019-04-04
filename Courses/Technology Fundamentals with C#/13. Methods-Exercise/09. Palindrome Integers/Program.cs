using System;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int num = 0;
            int t = 0;
            int r = 0;
            int sum = 0;
            while (command != "END")
            {
                num = int.Parse(command);
                ChekPolindrom(num, t, r, sum);
                command = Console.ReadLine();
            }
            
        }

        private static void ChekPolindrom(int num, int t, int r, int sum)
        {
            for (t = num; num != 0; num = num / 10)
            {
                r = num % 10;
                sum = sum * 10 + r;
            }
            if (t == sum)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }
    }
}
