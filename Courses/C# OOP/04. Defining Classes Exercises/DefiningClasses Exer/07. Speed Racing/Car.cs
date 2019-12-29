using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionFor1km;
        private double distanceTravelled;

        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionFor1km = fuelConsumptionFor1km;
        }

        public string Model { get => model; set => model = value; }
        public double FuelAmount { get => fuelAmount; set => fuelAmount = value; }
        public double FuelConsumptionFor1km { get => fuelConsumptionFor1km; set => fuelConsumptionFor1km = value; }
        public double DistanceTravelled { get => distanceTravelled; set => distanceTravelled = value; }

        public bool Drive(double distance)
        {
            if (distance * FuelConsumptionFor1km <= FuelAmount)
            {
                FuelAmount -= FuelConsumptionFor1km * distance;
                DistanceTravelled += distance;
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {DistanceTravelled}";
        }
    }
}
