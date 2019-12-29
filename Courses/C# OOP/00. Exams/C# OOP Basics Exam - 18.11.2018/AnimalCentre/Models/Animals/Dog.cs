using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int happiness, int energy, int procedureTime) 
            : base(name, happiness, energy, procedureTime)
        {
        }
        public override string ToString()
        {
            return string.Format(base.ToString(), nameof(Dog), Name, Happiness, Energy);
        }
    }
}
