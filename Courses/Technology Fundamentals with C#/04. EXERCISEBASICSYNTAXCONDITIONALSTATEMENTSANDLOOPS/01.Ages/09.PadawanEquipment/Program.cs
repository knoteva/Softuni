using System;

namespace _09.PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double sabersPrice = double.Parse(Console.ReadLine());
            double robesPrice = double.Parse(Console.ReadLine());
            double beltsPrice = double.Parse(Console.ReadLine());
            int freeBelts = students / 6;
            double neededMoney = sabersPrice * Math.Ceiling(students * 1.1) + robesPrice * (students) + beltsPrice * (students - freeBelts);
            if (money >= neededMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {neededMoney:F2}lv.");
            }
            else
            {
                neededMoney -= money;
                Console.WriteLine($"Ivan Cho will need {neededMoney:F2}lv more.");
            }
            
        }
    }
}
