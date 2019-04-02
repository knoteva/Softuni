using System;

namespace _03._WorldSnookChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            string stage = Console.ReadLine();
            string ticket = Console.ReadLine();
            int ticketCount = int.Parse(Console.ReadLine());
            string picture = Console.ReadLine();
            double ticketPrice = 0;

            switch (stage)
            {
                case "Quarter final":
                    if (ticket == "Standard")
                    {
                        ticketPrice = 55.50;
                    }
                    if (ticket == "Premium")
                    {
                        ticketPrice = 105.20;
                    }
                    if (ticket == "VIP")
                    {
                        ticketPrice = 118.90;
                    }
                    break;
                case "Semi final":
                    if (ticket == "Standard")
                    {
                        ticketPrice = 75.88;
                    }
                    if (ticket == "Premium")
                    {
                        ticketPrice = 125.22;
                    }
                    if (ticket == "VIP")
                    {
                        ticketPrice = 300.40;
                    }
                    break;
                case "Final":
                    if (ticket == "Standard")
                    {
                        ticketPrice = 110.10;
                    }
                    if (ticket == "Premium")
                    {
                        ticketPrice = 160.66;
                    }
                    if (ticket == "VIP")
                    {
                        ticketPrice = 400.00;
                    }
                    break;
                default:
                    break;
            }

            double totalPrice = ticketPrice * ticketCount;
            if (totalPrice > 4000)
            {
                totalPrice *= 0.75;
            }
            else if(totalPrice > 2500)
            {
                totalPrice *= 0.90;
            }
            if (totalPrice < 4000 && picture == "Y")
            {
                totalPrice += ticketCount * 40;
            }
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
