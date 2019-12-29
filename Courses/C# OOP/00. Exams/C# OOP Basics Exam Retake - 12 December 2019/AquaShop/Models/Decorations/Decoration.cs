using AquaShop.Models.Decorations.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public abstract class Decoration : IDecoration
    {
        private int comfort;
        private decimal price;

        protected Decoration(int comfort, decimal price)
        {
            Comfort = comfort;
            Price = price;
        }
        //TODO
        public int Comfort
        {
            get;
            private set;
        }
        //|TODO 
        public decimal Price
        {
            get;
            private set;
        }
    }
}
