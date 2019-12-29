using Cars.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Cars
{
    public class Tesla : Car, ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery) 
            : base(model, color)
        {
            Battery = battery;
        }

        public int Battery { get; set; }

        public override string ToString()
        {
            return $"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteries" +
                Environment.NewLine +
                base.ToString();
        }
    }
}
