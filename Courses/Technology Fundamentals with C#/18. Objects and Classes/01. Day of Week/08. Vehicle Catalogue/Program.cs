using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleCatalogue catalogue = new VehicleCatalogue()
            {
                Trucks = new List<Truck>(),
                Cars = new List<Car>()
            };
            while(true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] data = input.Split('/');
                string type = data[0];
                if (type == "Truck")
                {
                    catalogue.Trucks.Add(AddTruck(data));
                }
                else {
                    catalogue.Cars.Add(AddCar(data));
                }
            }
            if (catalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (var car in catalogue.Cars.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (var truck in catalogue.Trucks.OrderBy(x => x.Brand))
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }          
        }

        public static Truck AddTruck(string[] data)
        {
            return new Truck
            {
                Brand = data[1],
                Model = data[2],
                Weight = int.Parse(data[3])
            };
        }
        public static Car AddCar(string[] data)
        {
            return new Car
            {
                Brand = data[1],
                Model = data[2],
                HorsePower = int.Parse(data[3])
            };
        }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class VehicleCatalogue
    {
        public List<Truck> Trucks { get; set; }
        public List<Car> Cars { get; set; }
    }
}
