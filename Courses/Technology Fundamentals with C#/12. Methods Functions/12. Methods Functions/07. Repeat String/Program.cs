using System;
using System.Text;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int time = int.Parse(Console.ReadLine());
            string result = RepeatString(str, time);
            Console.WriteLine(result);
        }

        private static string RepeatString(string str, int time)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < time; i++)
            {
                builder.Append(str);
            }
            return builder.ToString();
        }
    }
}
