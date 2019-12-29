namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var tires = new List<Tire>();
                //“<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>
                Engine engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                Cargo cargo = new Cargo(int.Parse(input[3]), input[4]);
                for (int j = 0; j < 4; j +=2)
                {
                    double pressure = double.Parse(input[5 + j]);
                    int age = int.Parse(input[6 + j]);                   
                    Tire tire = new Tire(age, pressure);
                    tires.Add(tire);
                }

                Car car = new Car(input[0], engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();
            List<Car> resultCars = new List<Car>();

            if (command == "fragile")
            {
                resultCars = cars.Where(x => x.Tires.Any(y => y.Pressure < 1) && x.Cargo.CargoType == "fragile").ToList();
            }
            if (command == "flamable")
            {
                //x => x.Cargo.CargoType == "flamable"
                resultCars = cars.Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250).ToList();
            }
            resultCars.ForEach(Console.WriteLine);
        }
    }
}
