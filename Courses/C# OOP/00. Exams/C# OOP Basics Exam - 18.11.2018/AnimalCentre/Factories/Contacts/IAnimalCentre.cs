using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Factories.Contacts
{
    public interface IAnimalCentre
    {
        IAnimal CreateAnimal(string type, string name, int happiness, int energy, int procedureTime);
    }
}
