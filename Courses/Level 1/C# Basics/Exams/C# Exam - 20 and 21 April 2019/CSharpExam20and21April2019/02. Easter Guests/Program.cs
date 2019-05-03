using System;

namespace _02._Easter_Guests
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int kozunaci = (int)Math.Ceiling(guests / 3.00);
            int eggs = guests * 2;
            double result =  kozunaci* 4.00 + eggs * 0.45;
            
            if (result <= (double)budget)
            {
                budget -= result;
                Console.WriteLine($"Lyubo bought {kozunaci} Easter bread and {eggs} eggs.");
                Console.WriteLine($"He has {budget:F2} lv. left.");
            }
            else
            {
                result -= budget;
                Console.WriteLine($"Lyubo doesn't have enough money.");
                Console.WriteLine($"He needs {result:F2} lv. more.");
            }
        }
    }
}
