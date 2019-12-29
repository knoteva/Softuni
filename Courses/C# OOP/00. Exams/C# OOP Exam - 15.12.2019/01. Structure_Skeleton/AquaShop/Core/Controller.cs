using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<Aquarium> aquariums;

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != "FreshwaterAquarium" && aquariumType != "SaltwaterAquarium")
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            if (aquariumType == "FreshwaterAquarium")
            {
                aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquariums.Add(new SaltwaterAquarium(aquariumName));
            }

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != "Plant" && decorationType != "Ornament")
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            if (decorationType == "Plant")
            {
                decorations.Add(new Plant());
            }
            else if (decorationType == "Ornament")
            {
                decorations.Add(new Ornament());
            }

            return $"Successfully added {decorationType}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != "FreshwaterFish" && fishType != "SaltwaterFish")
            {
                throw new InvalidOperationException("Water not suitable.");
            }
            if (fishType == "FreshwaterFish")
            {
                aquariums.FirstOrDefault(x => x.Name == aquariumName).AddFish(new FreshwaterFish(fishName, fishSpecies, price));
            }
            else if (fishType == "SaltwaterFish")
            {
                aquariums.FirstOrDefault(x => x.Name == aquariumName).AddFish(new SaltwaterFish(fishName, fishSpecies, price));
            }

            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string CalculateValue(string aquariumName)
        {
            decimal result = 0;

            foreach (var aquarium in aquariums)
            {
                foreach (var fish in aquarium.Fish)
                {
                    result += fish.Price;
                }
            }
            foreach (var decoration in decorations.Models)
            {
                result += decoration.Price;
            }

            return result.ToString();
        }

        public string FeedFish(string aquariumName)
        {
            throw new NotImplementedException();
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
