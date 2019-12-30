using _03.Wild_Farm.Animals.Mammals.Felines.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Wild_Farm.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal, IFeline
    {
        private string breed;
        public Feline(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed
        {
            get => breed; 
            set
            {
                breed = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
