using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_CarsSalesman
{
    class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                int power = int.Parse(parameters[1]);

                int displacement = -1;

                var engine = new Engine(model, power);
                if (parameters.Length == 3 && int.TryParse(parameters[2], out displacement))
                {                   
                    engine.Displacement = displacement;
                }
                else if (parameters.Length == 3)
                {
                    string efficiency = parameters[2];
                    engine.Efficiency = efficiency;
                }
                else if (parameters.Length == 4)
                {
                    string efficiency = parameters[3];
                    engine.Displacement = int.Parse(parameters[2]);
                    engine.Efficiency = efficiency;                  
                }
                engines.Add(engine);
            }
            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = parameters[0];
                string engineModel = parameters[1];
                Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

                int weight = -1;

                var car = new Car(model, engine);
                if (parameters.Length == 3 && int.TryParse(parameters[2], out weight))
                {
                    car.Weight = weight;
                }
                else if (parameters.Length == 3)
                {
                    string color = parameters[2];
                    car.Color = color;
                }
                else if (parameters.Length == 4)
                {
                    string color = parameters[3];
                    car.Weight = int.Parse(parameters[2]);
                    car.Color = color;                   
                }
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }

}
