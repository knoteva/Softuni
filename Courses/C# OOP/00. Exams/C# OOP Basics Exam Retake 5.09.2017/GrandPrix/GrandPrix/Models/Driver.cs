using HardTyre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardTyre.Models
{
    public class Driver : IDriver
    {
        private string name;

        private double totalTime;

        private ICar car;

        private double fuelConsumptionPerKm ;

        private double speed;

        public Driver(string name, double totalTime, ICar car, double fuelConsumptionPerKm, double speed)
        {
            Name = name;
            TotalTime = totalTime;
            Car = car;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            Speed = (car.Hp + car.Tyre.Degradation) / car.FuelAmount;
        }

        public string Name { get => name; set => name = value; }
        public double TotalTime { get => totalTime; set => totalTime = value; }
        public ICar Car { get => car; set => car = value; }
        public double FuelConsumptionPerKm { get => fuelConsumptionPerKm; set => fuelConsumptionPerKm = value; }
        public double Speed { get => speed; set => speed = value; }
    }
}
