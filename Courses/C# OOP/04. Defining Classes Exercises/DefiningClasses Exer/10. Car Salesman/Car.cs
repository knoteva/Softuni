using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private double? weight;
        private string color;

        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }

        public string Model { get => model; set => model = value; }
        public Engine Engine { get => engine; set => engine = value; }
        public double? Weight { get => weight; set => weight = value; }
        public string Color { get => color; set => color = value; }


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine($"{Model}:");
            builder.Append(Engine);
            builder.AppendLine($"  Weight: {(Weight == null ? "n/a" : Weight.ToString())}");
            builder.Append($"  Color: {(Color == null ? "n/a" : Color)}");

            return builder.ToString();
        }
    }
}
