using _03.Wild_Farm.Animals;
using _03.Wild_Farm.Animals.Birds.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Wild_Farm.Animals.Birds
{
    public abstract class Bird : Animal, IBird
    {
        private double wingSize;

        public Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize
        {
            get => wingSize; 
            set
            {
                wingSize = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
