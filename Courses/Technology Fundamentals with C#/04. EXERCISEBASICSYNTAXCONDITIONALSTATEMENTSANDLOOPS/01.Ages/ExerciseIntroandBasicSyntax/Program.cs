using System;

namespace novitezadachi
{
    class Program
    {
        static void Main(string[] args)
        {
            double N1 = double.Parse(Console.ReadLine());
            double N2 = double.Parse(Console.ReadLine());
            char vid = char.Parse(Console.ReadLine());
            double result = 0;

            if (vid == '+')
            {
                result = N1 + N2;

                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} + {N2} = " + result + " - " + "even");
                }
                else if (result % 2 == 1)
                {
                    Console.WriteLine($"{N1} + {N2} = " + result + " - " + "odd");
                }

            }
            else if (vid == '-')
            {
                result = N1 - N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} - {N2} = " + result + " - " + "even");
                }
                else if (result % 2 == 1)
                {
                    Console.WriteLine($"{N1} - {N2} = " + result + " - " + "odd");
                }
            }
            else if (vid == '*')
            {
                result = N1 * N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} * {N2} = " + result + " - " + "even");
                }
                else if (result % 2 == 1)
                {
                    Console.WriteLine($"{N1} * {N2} = " + result + " - " + "odd");
                }
            }
            else if (vid == '/')
            {
                if (N2 > 0)
                {
                    result = N1 / N2;
                    Console.WriteLine($"{N1} / {N2} = {result:f2}");
                }
                else if (N2 == 0)
                {
                    result = N1 / N2;
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }
            else if (vid == '%')
            {
                if (N2 > 0)
                {
                    result = N1 % N2;
                    //Console.WriteLine($"{N1} % {N2} = {result}");
                }
                else if (N2 == 0)
                {
                    result = N1 % N2;
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }
        }
    }
}