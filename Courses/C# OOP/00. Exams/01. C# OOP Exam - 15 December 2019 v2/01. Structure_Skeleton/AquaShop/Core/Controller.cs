using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private readonly DecorationRepository decorationRepository;

        private readonly ICollection<IAquarium> aquariums;
        private readonly ICollection<IFish> fishes;

        public Controller()
        {
            this.decorationRepository = new DecorationRepository();
            aquariums = new List<IAquarium>();
            fishes = new List<IFish>();
        }



        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                throw new InvalidOperationException($"Invalid aquarium type.");
            }
            aquariums.Add(aquarium);
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            //Creates a decoration of the given type and adds it to the DecorationRepository.Valid types are: "Ornament" and "Plant".If the decoration type is invalid, throw an InvalidOperationException with message:
            //•	"Invalid decoration type."
            //The method should return the following string if the operation is successful:
            //•	"Successfully added {decorationType}."

            IDecoration decoration;
            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException($"Invalid decoration type.");
            }

            decorationRepository.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            //Adds the desired Fish to the Aquarium with the given name.Valid Fish types are: "FreshwaterFish", "SaltwaterFish".
            //If the Fish type is invalid, you have to throw an InvalidOperationException with the following message "Invalid Fish type.".
            //If no errors are thrown, return one of the following messages:
            //•	"Water not suitable." - if the Fish cannot live in the Aquarium
            //•	"Successfully added {fishType} to {aquariumName}." - if the Fish is added successfully in the Aquarium

            IFish fish = null;
            var fishTypeAq = string.Empty;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                fishTypeAq = "FreshwaterAquarium";
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
                fishTypeAq = "SaltwaterAquarium";
            }
            else
            {
                throw new InvalidOperationException($"Invalid fish type.");
            }

            var aquarium = aquariums.FirstOrDefault(t => t.GetType().Name == fishTypeAq && t.Name == aquariumName);
            if (aquarium == null)
            {
                return $"Water not suitable.";
            }
            aquarium.AddFish(fish);
            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            //Calculates the value of the Aquarium with the given name. It is calculated by the sum of all Fish’s and Decorations’ prices in the Aquarium.
            //Return a string in the following format:
            //•	"The value of Aquarium {aquariumName} is {value}."
            //o The value should be formatted to the 2nd decimal place!
            var aquarium = aquariums.FirstOrDefault(n => n.Name == aquariumName);
            var value = aquarium.Fish.Sum(p => p.Price) + aquarium.Decorations.Sum(p => p.Price);
            return $"The value of Aquarium {aquariumName} is {value:F2}.";
        }

        // TODO not ok. 
        public string FeedFish(string aquariumName)
        {
            var aquarium = aquariums.FirstOrDefault(n => n.Name == aquariumName);

            //TODO can be null?

            aquarium.Feed();
            return $"Fish fed: {aquarium.Fish.Count()}";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorationRepository.FindByType(decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException($"There isn't a decoration of type {decorationType}.");
            }

            var aquarium = aquariums.FirstOrDefault(n => n.Name == aquariumName);
            //TODO check Aquarium?
            aquarium.AddDecoration(decoration);
            decorationRepository.Remove(decoration);
            return $"Successfully added {decorationType} to {aquariumName}.";

            //Adds the desired Decoration to the Aquarium with the given name.You have to remove the Decoration from the DecorationRepository if the insert is successful.
            //If there is no such decoration, you have to throw an InvalidOperationException with the following message:
            //•	"There isn’t a decoration of type {decorationType}."
            //If no errors are thrown, return a string with the following message "Successfully added {decorationType} to {aquariumName}.".

        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
