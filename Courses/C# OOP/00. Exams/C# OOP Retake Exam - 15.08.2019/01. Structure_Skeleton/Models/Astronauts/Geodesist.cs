using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const int initialOxygen = 50;

        public Geodesist(string name)
            : base(name, initialOxygen)
        {
        }
    }
}
