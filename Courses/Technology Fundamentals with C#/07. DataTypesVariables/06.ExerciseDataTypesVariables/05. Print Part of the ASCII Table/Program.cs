using System;

namespace _05._Print_Part_of_the_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            string result = "";
            for (int i = first; i <= second; i++)
            {
                result += (char)i + " ";
            }
            Console.WriteLine(result);
        }
    }
}
