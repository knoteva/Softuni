using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private const int initialSize = 3;

        public FreshwaterFish(string name, string species, decimal price)
            : base(name, species, price, initialSize)
        {
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
