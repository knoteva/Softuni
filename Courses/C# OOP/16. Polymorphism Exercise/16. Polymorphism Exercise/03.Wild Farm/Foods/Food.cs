using _03.Wild_Farm.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Wild_Farm.Foods
{
    public abstract class Food : IFood
    {
        private int quantity;

        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity
        {
            get => quantity; 
            // TODO Add validation
            set
            {
                quantity = value;
            }
        }
    }
}
