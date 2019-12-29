using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class Fitness : Procedure
    {
        private const int removeHappiness = 3;
        private const int addEnergy = 10;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);
            animal.Happiness -= removeHappiness;
            animal.Energy += addEnergy;
            procedureHistory.Add(animal);
        }
    }
}
