using System;

namespace _03._Easter_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int pricePerNight = 0;

            switch (destination)
            {
                case "France":
                    if (dates == "21-23")
                    {
                        pricePerNight = 30;
                    }
                    else if (dates == "24-27")
                    {
                        pricePerNight = 35;
                    }
                    else
                    {
                        pricePerNight = 40;
                    }
                    break;
                case "Italy":
                    if (dates == "21-23")
                    {
                        pricePerNight = 28;
                    }
                    else if (dates == "24-27")
                    {
                        pricePerNight = 32;
                    }
                    else
                    {
                        pricePerNight = 39;
                    }
                    break;
                case "Germany":
                    if (dates == "21-23")
                    {
                        pricePerNight = 32;
                    }
                    else if (dates == "24-27")
                    {
                        pricePerNight = 37;
                    }
                    else
                    {
                        pricePerNight = 43;
                    }
                    break;

                default:
                    break;
            }
            Console.WriteLine($"Easter trip to {destination} : {pricePerNight * days:F2} leva.");
        }
    }
}
