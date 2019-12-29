using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AnimalCentre.Models.Hotel
{
    public class Hotel : IHotel
    {
        private int capacity;
        private Dictionary<string, IAnimal> animals;

        public Hotel()
        {
            Capacity = 10;
            animals = new Dictionary<string, IAnimal>();
        }

        public int Capacity { get => capacity; set => capacity = value; }
        public IReadOnlyDictionary<string, IAnimal> Animals => new ReadOnlyDictionary<string, IAnimal>(animals);

        public void Accommodate(IAnimal animal)
        {
            if (Capacity == 0)
            {
                throw new InvalidOperationException($"Not enough capacity");
            }
            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
            animals.Add(animal.Name, animal);
            Capacity--;
        }

        public void Adopt(string animalName, string owner)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");               
            }

            IAnimal animal = animals[animalName];
            animal.IsAdopt = true;
            animal.Owner = owner;
            animals.Remove(animalName);
            capacity++;

        }
    }
}
