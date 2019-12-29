using _01._Vehicles.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double thankCapacity;
        private double fuelQuantity;
        private double fuelConsumption;
        
       
        protected Vehicle(double fuelQuantity, double fuelConsumption, double thankCapacity)
        {
            ThankCapacity = thankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            
        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set
            {
                if (value > ThankCapacity)
                {
                    value = 0;
                }
                fuelQuantity = value;
            }
        }
        // TODO Add validation
        public double FuelConsumption
        {
            get => fuelConsumption; 
            set
            {
                fuelConsumption = value;
            }
        }

        public double ThankCapacity
        {
            get => thankCapacity; 
            set
            {
                thankCapacity = value;
            }
        }
        public bool IsVehicleEmpty { get; set; }

        public virtual void Drive(double distance)
        {          
            double neededFuel = distance * FuelConsumption;
            if (FuelQuantity < neededFuel)
            {
                 throw new ArgumentException($"{GetType().Name} needs refueling");
            }                    
            FuelQuantity -= neededFuel;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }

        public void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }
            if (FuelConsumption + fuel > ThankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }
            if (this is Truck)
            {
                fuel *= 0.95;
            }
            FuelQuantity += fuel;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
