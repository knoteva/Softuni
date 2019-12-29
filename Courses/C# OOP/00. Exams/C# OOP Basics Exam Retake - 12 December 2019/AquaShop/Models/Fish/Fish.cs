using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private int size;
        private decimal price;

        protected Fish(string name, string species, decimal price)
        {
            this.name = name;
            this.species = species;
            this.price = price;
        }

        protected Fish(string name, string species, decimal price, int size)
        {
            Name = name;
            Species = species;
            Price = price;
            Size = size;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Fish name cannot be null or empty.");
                }
                name = value;
            }
        }

        public string Species
        {
            get => species;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Fish species cannot be null or empty.");
                }
                species = value;
            }
        }

        //TODO
        public int Size { get; protected set; }

        public decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Fish price cannot be below or equal to 0.");
                }
                price = value;
            }
        }

        public abstract void Eat();

    }
}
