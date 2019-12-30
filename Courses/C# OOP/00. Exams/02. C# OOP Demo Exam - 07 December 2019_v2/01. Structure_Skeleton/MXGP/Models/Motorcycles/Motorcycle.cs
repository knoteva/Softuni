using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;

        }

        //o If the model is null, whitespace or less than 4 symbols, throw an ArgumentException with message "Model {model} cannot be less than 4 symbols."
        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException($"Model {Model} cannot be less than 4 symbols.");
                }
                model = value;
            }
        }

        //o	Every type of motorcycle has different range of valid horsepower. If the horsepower is not in the valid range, throw an ArgumentException with message "Invalid horse power: {horsepower}."
        public abstract int HorsePower { get; protected set; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps)
        {
            //cubic centimeters / horsepower * laps
            return CubicCentimeters / HorsePower * laps;
        }
    }
}
