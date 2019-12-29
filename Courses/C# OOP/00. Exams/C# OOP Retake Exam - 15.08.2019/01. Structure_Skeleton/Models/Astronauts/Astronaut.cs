using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private const int oxygenForDecrease = 10;
        private  string name; 
        private  double oxygen;
        private  bool canBreath;
        private  IBag bag;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;
            Bag = new Backpack();
        }

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                name = value;
            }
        }
        public double Oxygen
        {
            get => oxygen; 
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");

                }
                oxygen = value;
            }
        }
        public bool CanBreath => Oxygen > 0;
        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
            if (Oxygen - oxygenForDecrease < 0)
            {
                Oxygen = 0;
            }
            Oxygen -= oxygenForDecrease;
        }
    }
}
