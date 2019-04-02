using System;

namespace _03._Floating_Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            double a =  double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double eps = 0.000001;
            if (Math.Abs(a - b) >= eps)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");        
            }
        }
    }
}
