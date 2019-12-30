using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle: Motorcycle
    {
        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, 125)
        {
        }

        public override int HorsePower
        {
            get => horsePower;
            protected set
            {
                //Minimum horsepower is 70 and maximum horsepower is 100.
                if (value < 50 || value > 69)
                {
                    throw new ArgumentException($"Invalid horse power: {HorsePower}.");
                }
                horsePower = value;
            }
        }
    }
}
