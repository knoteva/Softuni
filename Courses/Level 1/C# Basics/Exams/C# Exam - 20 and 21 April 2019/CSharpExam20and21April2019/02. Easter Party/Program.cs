using System;

namespace _02._Easter_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int guests = int.Parse(Console.ReadLine());
            double kuvert = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            if (guests >= 10 && guests <= 15)
            {
                kuvert *= 0.85;
            }
            else if (guests >= 16 && guests <= 20)
            {
                kuvert *= 0.8;
            }
            else if(guests >= 21)
            {
                kuvert *= 0.75;
            }
            double neededMoney = guests * kuvert + budget * 0.1;
            if (neededMoney <= budget)
            {
                budget -= neededMoney;
                Console.WriteLine($"It is party time! {budget:F2} leva left.");
            }
            else
            {
                neededMoney -= budget;
                Console.WriteLine($"No party! {neededMoney:F2} leva needed.");
            }
        }
    }
}
