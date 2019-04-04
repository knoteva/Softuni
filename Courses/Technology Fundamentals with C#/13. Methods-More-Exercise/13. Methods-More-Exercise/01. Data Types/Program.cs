using System;

namespace _01._Data_Types
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string num = Console.ReadLine();

            switch (type)
            {
                case "int":
                    Console.WriteLine(ReadInt(int.Parse(num)));
                    break;
                case "real":
                    Console.WriteLine($"{ReadInt(double.Parse(num)):F2}");
                    break;
                case "string":
                    Console.WriteLine(ReadInt(num));
                    break;

                default:
                    break;
            }
        }

        private static int ReadInt(int num)
        {
            return num * 2;
        }
        private static double ReadInt(double num)
        {
            double result = num * 1.5;
            return result;
        }
        private static string ReadInt(string input)
        {
            string result = "$" + input + "$";
            return result;
        }
    }
}
