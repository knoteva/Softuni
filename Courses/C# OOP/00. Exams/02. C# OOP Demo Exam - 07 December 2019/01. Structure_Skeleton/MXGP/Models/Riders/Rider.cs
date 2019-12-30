using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;
        private IMotorcycle motorcycle;
        private int numberOfWins;
        private bool canParticipate;

        public Rider(string name)
        {
            Name = name;
            Motorcycle = motorcycle;
            NumberOfWins = numberOfWins;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {name} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate =>  Motorcycle != null;


        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException("Motorcycle cannot be null.");
            }

            Motorcycle = motorcycle;

            canParticipate = true;
        }

        public void WinRace()
        {
            numberOfWins++;
        }
    }
}
