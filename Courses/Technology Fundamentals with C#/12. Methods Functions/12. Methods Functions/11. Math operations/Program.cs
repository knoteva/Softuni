using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string oper = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculate(a, oper, b));
        }

        private static double Calculate(int a, string operat, int b)
        {
            double result = 0.00;
            switch (operat)
            {
                case "/":
                    result = (double)a / b; 
                break;
                case "*":
                    result = a * b;
                    break;
                case "+":
                    result = a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                default:
                break;
            }
            return result;
        }
    }
}
