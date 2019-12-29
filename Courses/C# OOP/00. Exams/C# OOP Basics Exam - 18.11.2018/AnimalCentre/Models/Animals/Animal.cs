using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;
        private bool isAdopt;
        private bool isChipped;
        private bool isVaccinated;

        public Animal(string name, int happiness, int energy, int procedureTime)
        {
            Name = name;
            Happiness = happiness;
            Energy = energy;
            ProcedureTime = procedureTime;
            Owner = "Centre";
            IsAdopt = false;
            IsChipped = false;
            IsVaccinated = false;           
        }

        public string Name { get => name; private set => name = value; }
        public int Happiness
        {
            get => happiness; 
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("ArgumentException: Invalid happiness");
                    return;
                }
                happiness = value;
            }
        }
        public int Energy
        {
            get => energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("ArgumentException: Invalid energy");
                    return;
                }
                energy = value;
            }
        }
        public int ProcedureTime { get => procedureTime; set => procedureTime = value; }
        public string Owner { get => owner; set => owner = value; }
        public bool IsAdopt { get => isAdopt; set => isAdopt = value; }
        public bool IsChipped { get => isChipped; set => isChipped = value; }
        public bool IsVaccinated { get => isVaccinated; set => isVaccinated = value; }

        public override string ToString()
        {
            return "    Animal type: {0} - {1} - Happiness: {2} - Energy: {3}";
        }
    }
}
