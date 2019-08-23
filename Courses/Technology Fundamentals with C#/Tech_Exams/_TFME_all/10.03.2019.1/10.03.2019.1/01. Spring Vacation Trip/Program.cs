using System;

namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int groupOfPeople = int.Parse(Console.ReadLine());
            double fuelPricePerKm = double.Parse(Console.ReadLine());
            double foodExpensesPerPersonForDay = double.Parse(Console.ReadLine());
            double priceRoom  = double.Parse(Console.ReadLine());

            double food = groupOfPeople * foodExpensesPerPersonForDay * days;
            double hotel = priceRoom * groupOfPeople * days;
            if (groupOfPeople > 10)
            {
                hotel *= 0.75;
            }
            double expenses = food + hotel;

            for (int i = 1; i <= days; i++)
            {
                double travelledDistance = double.Parse(Console.ReadLine());
                expenses += travelledDistance * fuelPricePerKm;
                if (i % 3 == 0 || i % 5 == 0)
                {
                    expenses *= 1.4;
                }
                if (i % 7 == 0)
                {
                    expenses -= expenses / groupOfPeople;
                }
                if (budget < expenses)
                {
                    double money = expenses - budget;
                    Console.WriteLine($"Not enough money to continue the trip. You need {money:F2}$ more.");
                    return;
                }
            }
            double left = budget - expenses;
            Console.WriteLine($"You have reached the destination. You have {left:F2}$ budget left.");
        }
    }
}
