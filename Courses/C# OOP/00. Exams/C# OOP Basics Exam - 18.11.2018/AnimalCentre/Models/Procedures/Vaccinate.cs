using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Vaccinate : Procedure
    {
        private const int removeEnergy = 5;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);
            animal.Energy -= removeEnergy;
            animal.IsVaccinated = true;
            procedureHistory.Add(animal);
        }
    }
}
