using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Procedures
{
    public class NailTrim : Procedure
    {
        private const int removeHappiness = 7;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);
            animal.Happiness -= removeHappiness;
            procedureHistory.Add(animal);
        }
    }
}
