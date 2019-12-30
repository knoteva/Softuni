using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Vehicles
{
    public class Car : Vehicle
    {
        private const double airConditionConsumption = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double thankCapacity) 
            : base(fuelQuantity, fuelConsumption, thankCapacity)
        {
            FuelConsumption += airConditionConsumption;
        }
    }
}
