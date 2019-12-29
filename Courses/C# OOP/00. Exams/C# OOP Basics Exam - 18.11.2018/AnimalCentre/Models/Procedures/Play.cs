using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Play : Procedure
    {
        private const int addHappiness = 12;
        private const int removeEnergy = 6;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);
            animal.Happiness += addHappiness;
            animal.Energy -= removeEnergy;
            procedureHistory.Add(animal);
        }
    }
}

