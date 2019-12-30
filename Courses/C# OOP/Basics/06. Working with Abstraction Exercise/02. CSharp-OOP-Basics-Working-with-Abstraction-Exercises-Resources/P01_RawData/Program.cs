namespace P01_RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class RawData
    {
        public static void Main(string[] args)
        {
            var cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];


                int engineSpeed = int.Parse(parameters[1]);
                int enginePower = int.Parse(parameters[2]);

                int cargoWeight = int.Parse(parameters[3]);
                string cargoType = parameters[4];

                var tires = new List<Tire>();
                for (int j = 0; j < 4; j += 2)
                {
                    double pressure = double.Parse(parameters[5 + j]);
                    int age = int.Parse(parameters[6 + j]);
                    Tire tire = new Tire(age, pressure);
                    tires.Add(tire);
                }

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                List<Car> fragile = cars
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .ToList();

                fragile.ForEach(Console.WriteLine);
            }
            else
            {
                List<Car> flamable = cars
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .ToList();

                flamable.ForEach(Console.WriteLine);
            }
        }
    }
}
