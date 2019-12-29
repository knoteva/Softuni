using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Storages
{
   public class Warehouse : Storage
    {      
            private const int WarehouseCenterCapacity = 10;
            private const int WarehouseCenterGarageSlots = 10;
            private static readonly Vehicle[] DefaultVehicle = new Vehicle[]
            {
            new Semi(),
            new Semi(),
            new Semi()
            };
            public Warehouse(string name)
                : base(name, WarehouseCenterCapacity, WarehouseCenterGarageSlots, DefaultVehicle)
            {
            }      
    }
}
