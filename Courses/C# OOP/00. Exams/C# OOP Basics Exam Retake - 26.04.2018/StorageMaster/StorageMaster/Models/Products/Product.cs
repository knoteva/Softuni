using StorageMaster.Models.Products.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public abstract class Product : IProduct
    {
        private double price;
        private double weight;

        protected Product(double price, double weight)
        {
            Price = price;
            Weight = weight;
        }

        public double Price
        {
            get => price;
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                price = value;
            }
        }
        public double Weight { get => weight; private set => weight = value; }
    }
}
