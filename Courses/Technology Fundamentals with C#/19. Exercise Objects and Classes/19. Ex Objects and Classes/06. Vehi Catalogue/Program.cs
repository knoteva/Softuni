using System;
using System.Linq;
using System.Collections.Generic;

namespace _01_Messaging
{
    class Program
    {
        static void Main()
        {
            var catalogue = new List<VehicleCatalogue>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ");
                catalogue.Add(new VehicleCatalogue(data));
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (var vehicle in catalogue)
                {
                    if (vehicle.Model == input)
                    {
                        if (vehicle.Type == "car")
                        {
                            Console.WriteLine("Type: Car");
                        }
                        else
                        {
                            Console.WriteLine("Type: Truck");
                        }
                        Console.WriteLine($"Model: {vehicle.Model}");
                        Console.WriteLine($"Color: {vehicle.Color}");
                        Console.WriteLine($"Horsepower: {vehicle.Horsepower}");
                    }
                }
            }
        }
    }

    class VehicleCatalogue
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double Horsepower { get; set; }

        public VehicleCatalogue(string[] data)
        {
            Type = data[0].ToLower();
            Model = data[1];
            Color = data[2];
            Horsepower = double.Parse(data[3]);
        }
    }
}