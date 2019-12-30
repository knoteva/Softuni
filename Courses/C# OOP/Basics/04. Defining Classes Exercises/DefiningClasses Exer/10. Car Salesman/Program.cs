namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var engines = new List<Engine>();
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries); ;
                string model = input[0];
                double power = double.Parse(input[1]);
                Engine engine = new Engine(model, power);

                if (input.Length == 3)
                {
                    if (input[2].All(Char.IsDigit))
                    {
                        double displacement = double.Parse(input[2]);
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        string efficiency = input[2];
                        engine.Efficiency = efficiency;
                    }
                }
                else if (input.Length == 4)
                {
                    double displacement = double.Parse(input[2]);
                    string efficiency = input[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries); ;
                string model = input[0];

                Engine engine = engines.First(e => e.Model == input[1]);
                Car car = new Car(model, engine);

                if (input.Length == 3)
                {
                    if (input[2].All(Char.IsDigit))
                    {
                        double weight = double.Parse(input[2]);
                        car.Weight = weight;
                    }
                    else
                    {
                        string color = input[2];
                        car.Color = color;
                    }
                }
                else if (input.Length == 4)
                {
                    double weight = double.Parse(input[2]);
                    string color = input[3];
                    car.Weight = weight;
                    car.Color = color;
                }
                cars.Add(car);
            }
            cars.ForEach(Console.WriteLine);
        }
    }
}
