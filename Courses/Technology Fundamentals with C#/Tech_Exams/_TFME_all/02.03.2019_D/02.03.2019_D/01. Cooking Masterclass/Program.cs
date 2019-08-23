using System;

namespace _01._Cooking_Masterclass
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = double.Parse(Console.ReadLine());
            double apronPrice = double.Parse(Console.ReadLine());
            int freeFloor = students / 5;
            double spentMoney = flourPrice * (students - freeFloor) + eggPrice * students * 10 + apronPrice * Math.Ceiling(students * 1.2);



            if (budget - spentMoney >= 0)
            {
                Console.WriteLine($"Items purchased for {spentMoney:F2}$.");
            }
            else
            {
                Console.WriteLine($"{spentMoney - budget:F2}$ more needed.");
            }
        }
    }
}
