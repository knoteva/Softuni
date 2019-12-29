using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            Vehicle vehicle = null;
            switch (type)
            {
                case "Semi":
                    vehicle = new Semi();
                    break;
                case "Truck":
                    vehicle = new Truck();
                    break;
                case "Van":
                    vehicle = new Van();
                    break;
                default:
                    throw new InvalidOperationException("Invalid vehicle type!");
            }
            return vehicle;
        }
    }
}
