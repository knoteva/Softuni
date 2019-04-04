using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            PrintChars(first, second);
        }

        private static void PrintChars(char first, char second)
        {
            string result = "";
            char old = 'a';
            if (first > second)
            {
                old = second;
                second = first;
                first = old;
            }
            for (char i = (char)(first +1); i < second; i++)
            {
                result += i + " ";
            }
            Console.WriteLine(result);
        }
    }
}
