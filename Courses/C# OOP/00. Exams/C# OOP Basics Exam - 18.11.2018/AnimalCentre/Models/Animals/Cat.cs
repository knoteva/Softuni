using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int happiness, int energy, int procedureTime) 
            : base(name, happiness, energy, procedureTime)
        {
        }
        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Cat), Name, Happiness, Energy);
        }
    }
}
