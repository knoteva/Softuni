using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Pilot :  IPilot
    {
        private string name;
        private IList<IMachine> machines;
        public Pilot(string name)
        {
            Name = name;
            Machines = new List<IMachine>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be null or empty string.");
                }
                name = value;
            }
        }

        public IList<IMachine> Machines { get => machines; set => machines = value; }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new NullReferenceException("Null machine cannot be added to the pilot.");
            }
            machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name} - {machines.Count} machines");
            foreach (var machine in machines)
            {
                sb.AppendLine(machine.ToString());               
            }
            return sb.ToString().TrimEnd();
        }
    }
}
