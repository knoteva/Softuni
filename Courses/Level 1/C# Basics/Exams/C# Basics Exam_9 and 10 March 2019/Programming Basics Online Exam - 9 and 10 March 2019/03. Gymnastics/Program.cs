using System;

namespace _03._Gymnastics
{
    class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            string part = Console.ReadLine();
            double points = 0;
            double percent = 0;

            switch (country)
            {
                case "Russia":
                    if (part == "ribbon")
                    {
                        points = 9.100 + 9.400;
                        percent = ((20 - points) / 20) * 100;
                    }
                    if (part == "hoop")
                    {
                        points = 9.300 + 9.800;
                        percent = ((20 - points) / 20) * 100;
                    }
                    if (part == "rope")
                    {
                        points = 9.600 + 9.000;
                        percent = ((20 - points) / 20) * 100;
                    }
                    break;
                case "Bulgaria":
                    if (part == "ribbon")
                    {
                        points = 9.600 + 9.400;
                        percent = ((20 - points) / 20) * 100;
                    }
                    if (part == "hoop")
                    {
                        points = 9.550 + 9.750;
                        percent = ((20 - points) / 20) * 100;
                    }
                    if (part == "rope")
                    {
                        points = 9.500 + 9.400;
                        percent = ((20 - points) / 20) * 100;
                    }
                    break;
                case "Italy":
                    if (part == "ribbon")
                    {
                        points = 9.200 + 9.500;
                        percent = ((20 - points) / 20) * 100;
                    }
                    if (part == "hoop")
                    {
                        points = 9.450 + 9.350;
                        percent = ((20 - points) / 20) * 100;
                    }
                    if (part == "rope")
                    {
                        points = 9.700 + 9.150;
                        percent = ((20 - points) / 20) * 100;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine($"The team of {country} get {points:F3} on {part}.\n{percent:F2}%");
        }
    }
}
