using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int initialOxygen = 70;
        private const int oxygenForDecrease = 5;
        public Biologist(string name) 
            : base(name, initialOxygen)
        {
        }
        public override void Breath()
        {
            if (Oxygen - oxygenForDecrease < 0)
            {
                Oxygen = 0;
            }
            Oxygen -= oxygenForDecrease;
        }
    }
}
