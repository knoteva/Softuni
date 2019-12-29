using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        private const double airConditionConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double thankCapacity) 
            : base(fuelQuantity, fuelConsumption, thankCapacity)
        {
            FuelConsumption += airConditionConsumption;
        }
    }
}
