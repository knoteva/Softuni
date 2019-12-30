using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Vehicles.Contracts
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption {get;}      
        double ThankCapacity { get; }
        bool IsVehicleEmpty { get; set; }
        void Drive(double distance);
        void Refuel(double fuel);
    }
}
