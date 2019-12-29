using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IAnimal> procedureHistory;

        protected Procedure()
        {
            ProcedureHistory = new List<IAnimal>();
        }

        public List<IAnimal> ProcedureHistory { get => procedureHistory; set => procedureHistory = value; }

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetType().Name);
            foreach (var animal in ProcedureHistory)
            {
                sb.AppendLine($"    Animal type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }
            return sb.ToString().TrimEnd();
        }

        public abstract void DoService(IAnimal animal, int procedureTime);

        protected void CheckTime(int time, IAnimal animal)
        {
            if (time <= animal.ProcedureTime)
            {
                animal.ProcedureTime -= time;
            }
            else
            {
                throw new ArgumentException("Animal doesn't have enough procedure time");
            }
        }
    }
}
