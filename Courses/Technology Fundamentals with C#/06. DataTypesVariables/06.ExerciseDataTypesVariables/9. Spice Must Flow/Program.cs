using System;

namespace _9._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            int count = 0;
            int result = -26;
            while (input >= 100)
            {
                result += input - 26;
                count++;
                input -= 10;
            }
            Console.WriteLine(count);
            if (count > 0)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
