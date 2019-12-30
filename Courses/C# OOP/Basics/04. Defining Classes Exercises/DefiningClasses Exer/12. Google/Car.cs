namespace Google
{
    public class Car
    {
        private string carModel;
        private int carSpeed;

        public Car(string carModel, int carSpeed)
        {
            CarModel = carModel;
            CarSpeed = carSpeed;
        }

        public string CarModel { get => carModel; set => carModel = value; }
        public int CarSpeed { get => carSpeed; set => carSpeed = value; }

        public override string ToString()
        {
            return $"{CarModel} {CarSpeed}";
        }
    }
}
