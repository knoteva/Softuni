using Cars.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Cars
{
    public class Car : ICar
    {
        public Car(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public string Start()
        {
            return "Engine start";
        }
        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Start()}{Environment.NewLine}{this.Stop()}";
        }
    }
}


