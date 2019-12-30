using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IRider> riders;

        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            riders = new List<IRider>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {Name} cannot be less than 5 symbols.");
                }
                name = value;
            }
        }

        public int Laps
        {
            get => laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException($"Laps cannot be less than 1.");
                }
                laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            //•	If a Rider is null throw an ArgumentNullException with message "Rider cannot be null."
            //•	If a Rider cannot participate in the Race(the Rider doesn't own a Motorcycle) throw an ArgumentException with message 
            // "Rider {rider name} could not participate in race."
            //•	If the Rider already exists in the Race throw an ArgumentNullException with message: "Rider {rider name} is already added in {race name} race."
            if (rider == null)
            {
                throw new ArgumentNullException($"Rider cannot be null.");
            }
            if (!rider.CanParticipate)
            {
                throw new ArgumentException($"Rider {rider.Name} could not participate in race.");
            }
            if (riders.Contains(rider))
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {Name} race.");
            }
            riders.Add(rider);
        }
    }
}
