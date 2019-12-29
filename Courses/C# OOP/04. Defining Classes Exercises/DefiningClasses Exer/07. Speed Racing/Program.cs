using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
   public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumptionFor1km = double.Parse(input[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End")
            {
                string carModel = commands.Split(" ")[1];
                double amountOfKm = double.Parse(commands.Split(" ")[2]);

                Car car = cars.First(c => c.Model == carModel);

                if (!car.Drive(amountOfKm))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
            cars.ForEach(Console.WriteLine);
        }
    }
}
