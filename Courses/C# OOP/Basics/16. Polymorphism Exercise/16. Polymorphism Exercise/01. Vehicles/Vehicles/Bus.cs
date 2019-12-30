using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Vehicles
{
    public class Bus : Vehicle
    {
        private const double notEmptyConditionConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double thankCapacity) 
            :base(fuelQuantity, fuelConsumption, thankCapacity)
        {
        }

        public override void Drive(double distance)
        {
            double currentFuelComsumtion = FuelConsumption;
            if (!IsVehicleEmpty)
            {
                currentFuelComsumtion += notEmptyConditionConsumption;
            }
            double neededFuel = distance * currentFuelComsumtion;
            if (FuelQuantity < neededFuel)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            FuelQuantity -= neededFuel;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }
    }
}
