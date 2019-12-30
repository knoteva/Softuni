namespace P01_RawData
{
    public class Cargo
    {
        private int weight;
        private string type;

        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public int Weight { get => weight; set => weight = value; }
        public string Type { get => type; set => type = value; }
    }
}
