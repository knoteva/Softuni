using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage
    {
        private List<Product> products;
        private Vehicle[] garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            Name = name;
            Capacity = capacity;
            GarageSlots = garageSlots;
            products = new List<Product>();
            garage = new Vehicle[GarageSlots];
            FillGarageWithInitialVehicles(vehicles);
        }    

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int GarageSlots { get; private set; }
        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();
        public bool IsFull => Products.Sum(p => p.Weight) >= Capacity;
        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(garage);

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }
            Vehicle vehicle = garage[garageSlot];
            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }
            return vehicle;
        }
        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = GetVehicle(garageSlot);
            int foundGarageSlotIndex = deliveryLocation.AddVehicleToGarage(vehicle);
            garage[garageSlot] = null;
            return foundGarageSlotIndex;
        }
        public int UnloadVehicle(int garageSlot)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }
            Vehicle vehicle = GetVehicle(garageSlot);
            int count = 0;
            while (!IsFull && !vehicle.IsEmpty)
            {
                Product product = vehicle.Unload();
                products.Add(product);
                count++;
            }
            return count;
        }

        private int AddVehicleToGarage(Vehicle vehicle)
        {
            int freeFarafeIndex = Array.IndexOf(garage, null);
            if (freeFarafeIndex == -1)
            {
                throw new InvalidOperationException("No room in garage!");
            }
            garage[freeFarafeIndex] = vehicle;
            return freeFarafeIndex;
        }

        private void FillGarageWithInitialVehicles(IEnumerable<Vehicle> vehicles)
        {
            int index = 0;
            foreach (var vehicle in vehicles)
            {
                garage[index] = vehicle;
                index++;
            }

        }
    }
}
