using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const int capacityTruck = 5;
        public Truck()
            : base(capacityTruck)
        {
        }
    }
}
