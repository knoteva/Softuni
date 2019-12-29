using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        public Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }

        public string Name { get; }

        public string Species { get; }

        public int Size { get; }

        public decimal Price { get; }

        public void Eat()
        {
            throw new NotImplementedException();
        }
    }
}
