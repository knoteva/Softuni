using _03.Wild_Farm.Animals.Mammals.Contatcs;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Wild_Farm.Animals.Mammals
{
    public abstract class Mammal : Animal, IMammal
    {
        private string livingRegion;
        public Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion
        {
            get => livingRegion; 
            set
            {
                livingRegion = value;
            }
        }

        
    }
}
