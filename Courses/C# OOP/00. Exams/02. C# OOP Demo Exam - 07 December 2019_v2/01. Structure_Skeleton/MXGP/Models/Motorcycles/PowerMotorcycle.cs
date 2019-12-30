using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private int horsePower;
        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, 450)
        {
        }

        public override int HorsePower 
        {
            get => horsePower;
            protected set
            {
                //Minimum horsepower is 70 and maximum horsepower is 100.
                if (value < 70 || value > 100)
                {
                    throw new ArgumentException($"Invalid horse power: {HorsePower}.");
                }
                horsePower = value;
            }
        }
    }
}
