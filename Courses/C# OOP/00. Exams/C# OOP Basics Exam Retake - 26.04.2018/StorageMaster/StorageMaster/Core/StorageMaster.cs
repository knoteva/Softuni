using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private Dictionary<string, Stack<Product>> products;
        private Dictionary<string, Storage> storages;
        private List<Vehicle> vehicles;
        private Vehicle currentVehicle;

        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private VehicleFactory vehicleFactory;
        public StorageMaster()
        {
            products = new Dictionary<string, Stack<Product>>();
            storages = new Dictionary<string, Storage>();
            vehicles = new List<Vehicle>();
            productFactory = new ProductFactory();
            storageFactory = new StorageFactory();
            vehicleFactory = new VehicleFactory();
        }
        public string AddProduct(string type, double price)
        {
            Product product = productFactory.CreateProduct(type, price);
            if (!products.ContainsKey(type))
            {
                products.Add(type, new Stack<Product>());
            }
            products[type].Push(product);
            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageFactory.CreateStorage(type, name);
            storages.Add(name, storage);
            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = storages[storageName];
            currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedProductsCount = 0;
            foreach (var productName in productNames)
            {
                if (currentVehicle.IsFull)
                {
                    break;
                }
                if (!products.ContainsKey(productName) || products[productName].Count == 0)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }
                Product product = products[productName].Pop();
                currentVehicle.LoadProduct(product);
                loadedProductsCount++;
            }
            return $"Loaded {loadedProductsCount}/{productNames.Count()} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!storages.ContainsKey(sourceName))
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (!storages.ContainsKey(destinationName))
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage sourceStorage = storages[sourceName];
            Vehicle vehicle = sourceStorage.GetVehicle(sourceGarageSlot);
            Storage destinationStorage = storages[destinationName];
            int destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = storages[storageName];
            int productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count();
            int unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = storages[storageName];
        }

        public string GetSummary()
        {
            throw new NotImplementedException();
        }

    }
}
