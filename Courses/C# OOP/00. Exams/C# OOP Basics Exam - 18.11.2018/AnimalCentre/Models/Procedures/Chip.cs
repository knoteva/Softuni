using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int removeHappiness = 5;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            CheckTime(procedureTime, animal);

            if (animal.IsChipped)
            {
                throw new ArgumentException("{animal name} is already chipped");
            }
            animal.Happiness -= removeHappiness;
            animal.IsChipped = true;
            procedureHistory.Add(animal);
        }
      
    }
}
