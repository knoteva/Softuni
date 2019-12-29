using AnimalCentre.Factories.Contacts;
using AnimalCentre.Models.Animals;
using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Factories
{
    class AnimalFactory : IAnimalCentre
    {
        public IAnimal CreateAnimal(string type, string name, int happiness, int energy, int procedureTime)
        {
            var animalType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
            var animal = (IAnimal)Activator.CreateInstance(animalType, name, happiness, energy, procedureTime);
            return animal;
            //switch (type)
            //{
            //    case "Cat":
            //        return new Cat(name, happiness, energy, procedureTime);
            //    case "Dog":
            //        return new Dog(name, happiness, energy, procedureTime);
            //    case "Lion":
            //        return new Lion(name, happiness, energy, procedureTime);
            //    case "Pig":
            //        return new Pig(name, happiness, energy, procedureTime);

            //    default:
            //        throw new ArgumentException($"Invalid animal");
            //}
        }
    }
}
