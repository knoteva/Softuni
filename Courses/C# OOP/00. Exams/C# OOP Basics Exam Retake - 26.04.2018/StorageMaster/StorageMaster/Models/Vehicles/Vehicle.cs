using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private int capacity;
        private List<Product> trunk;

        protected Vehicle(int capacity)
        {
            Capacity = capacity;
            trunk = new List<Product>();
        }

        public int Capacity { get; private set; }
        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();
        public bool IsFull => Trunk.Sum(t => t.Weight) >= Capacity;
        public bool IsEmpty => Trunk.Count == 0;

        public void LoadProduct(Product product)
        {
            if (IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            trunk.Add(product);
        }
        public Product Unload()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("No products left in vehicle!");
            }
            var lastProductCount = trunk.Count - 1;
            Product product = trunk[lastProductCount];
            trunk.RemoveAt(lastProductCount);
            return product;
        }
    }
}
