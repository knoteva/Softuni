using AnimalCentre.Factories;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Hotel;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalCentre.Core
{
    public class AnimalCentre
    {
        //private Dictionary<string, IAnimal> animals;
        private Dictionary<string, IProcedure> procedureHistory;
        private Dictionary<string, List<string>> ownerAnimals;
        private IHotel hotel;
        private AnimalFactory animalFactory;
        private ProcedureFactory procedureFactory;

        public AnimalCentre()
        {
            ownerAnimals = new Dictionary<string, List<string>>();
            hotel = new Hotel();
            animalFactory = new AnimalFactory();
            procedureFactory = new ProcedureFactory();
            procedureHistory = new Dictionary<string, IProcedure>()
            {
                {"Chip", new Chip() },
                {"DentalCare", new DentalCare() },
                {"Fitness", new Fitness() },
                {"NailTrim", new NailTrim() },
                {"Play", new Play() },
                {"Vaccinate", new Vaccinate() },
            };
        }


        private bool AnimalExists(string name)
        {
            if (this.hotel.Animals.Any(a => a.Key == name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            var animal = this.animalFactory.CreateAnimal(type, name, energy, happiness, procedureTime);

            this.hotel.Accommodate(animal);

            return $"Animal {animal.Name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            var animal = hotel.Animals[name];
            //var chip = new Chip();
            //chip.DoService(animal, procedureTime);
            //procedureHistory.Add(chip.GetType().Name, chip);
            procedureHistory["Chip"].DoService(animal, procedureTime);
            return $"{animal.Name} had chip procedure";
        }

        public string Vaccinate(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            var animal = hotel.Animals[name];
            //var vaccinate = new Vaccinate();
            //vaccinate.DoService(animal, procedureTime);
            //procedureHistory.Add(vaccinate.GetType().Name, vaccinate);
            procedureHistory["Vaccinate"].DoService(animal, procedureTime);
            return $"{animal.Name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            var animal = hotel.Animals[name];
            //var fitness = new Fitness();
            //fitness.DoService(animal, procedureTime);
            //procedureHistory.Add(fitness.GetType().Name, fitness);
            procedureHistory["Fitness"].DoService(animal, procedureTime);
            return $"{animal.Name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            var animal = hotel.Animals[name];
            //var play = new Play();
            //play.DoService(animal, procedureTime);
            //procedureHistory.Add(play.GetType().Name, play);
            procedureHistory["Play"].DoService(animal, procedureTime);
            return $"{animal.Name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            var animal = hotel.Animals[name];
            //var dentalCare = new DentalCare();
            //dentalCare.DoService(animal, procedureTime);
            //procedureHistory.Add(dentalCare.GetType().Name, dentalCare);
            procedureHistory["DentalCare"].DoService(animal, procedureTime);
            return $"{animal.Name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            if (!AnimalExists(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
            var animal = hotel.Animals[name];
            //var nailTrim = new NailTrim();
            //nailTrim.DoService(animal, procedureTime);
            //procedureHistory.Add(nailTrim.GetType().Name, nailTrim);
            procedureHistory["NailTrim"].DoService(animal, procedureTime);
            return $"{animal.Name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            if (!AnimalExists(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
            var animal = hotel.Animals[animalName];

            if (!ownerAnimals.ContainsKey(owner))
            {
                ownerAnimals.Add(owner, new List<string>());
            }
            ownerAnimals[owner].Add(animalName);
            hotel.Adopt(animalName, owner);
            if (animal.IsChipped)
            {
                return $"{owner} adopted animal with chip";
            }
            return $"{owner} adopted animal without chip";
        }

        public string History(string type)
        {
            return procedureHistory[type].History();
        }

        public string AllAdoptedAnimals()
        {
            var sb = new StringBuilder();
            foreach (var owner in ownerAnimals.OrderBy(x => x.Key))
            {
                sb.Append($"--Owner: {owner.Key}{Environment.NewLine}");
                var animalNames = string.Join(" ", owner.Value);
                sb.AppendLine($"    - Adopted animals: {animalNames}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
