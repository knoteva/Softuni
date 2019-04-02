using System;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfGroup = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string day = Console.ReadLine();
            double pricePerDay = 0.00;
            double TotalPrice = numberOfGroup;

            switch (groupType)
            {
                case "Students":
                    if (day == "Friday")
                    {
                        TotalPrice *= 8.45;
                    }
                    if (day == "Saturday")
                    {
                        TotalPrice *= 9.80;
                    }
                    if (day == "Sunday")
                    {
                        TotalPrice *= 10.46;
                    }
                    if (numberOfGroup >= 30)
                    {
                        TotalPrice *= 0.85;
                    }
                    break;
                case "Business":
                    if (day == "Friday")
                    {
                        TotalPrice *= 10.90;
                        if (numberOfGroup >= 100)
                        {
                            TotalPrice -= 10 * 10.90;
                        }
                    }
                    if (day == "Saturday")
                    {
                        TotalPrice *= 15.60;
                        if (numberOfGroup >= 100)
                        {
                            TotalPrice -= 10 * 15.60;
                        }
                    }
                    if (day == "Sunday")
                    {
                        TotalPrice *= 16;
                        if (numberOfGroup >= 100)
                        {
                            TotalPrice -= 10 * 16;
                        }
                    }
                    break;
                case "Regular":
                    if (day == "Friday")
                    {
                        TotalPrice *= 15;
                    }
                    if (day == "Saturday")
                    {
                        TotalPrice *= 20;
                    }
                    if (day == "Sunday")
                    {
                        TotalPrice *= 22.50;
                    }
                    if (numberOfGroup >= 10 && numberOfGroup <= 20)
                    {
                        TotalPrice *= 0.95;
                    }
                    break;
                default:
                    break;
            }

            Console.WriteLine($"Total price: {TotalPrice:F2}");
        }
    }
}
