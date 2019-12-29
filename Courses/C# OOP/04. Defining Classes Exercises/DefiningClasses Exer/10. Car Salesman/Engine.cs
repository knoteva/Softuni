using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private double power;
        private double? displacement;
        private string efficiency;

        public Engine(string model, double power)
        {
            Model = model;
            Power = power;
        }

        public string Model { get => model; set => model = value; }
        public double Power { get => power; set => power = value; }
        public double? Displacement { get => displacement; set => displacement = value; }
        public string Efficiency { get => efficiency; set => efficiency = value; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"  {Model}:");
            builder.AppendLine($"    Power: {Power}");
            builder.AppendLine($"    Displacement: {(Displacement == null ? "n/a" : Displacement.ToString())}");
            builder.AppendLine($"    Efficiency: {(Efficiency == null ? "n/a" : Efficiency.ToString())}");

            return builder.ToString();
        }
    }
}
