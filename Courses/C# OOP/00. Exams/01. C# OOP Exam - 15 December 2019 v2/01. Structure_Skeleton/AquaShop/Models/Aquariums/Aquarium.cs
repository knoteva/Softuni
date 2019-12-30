using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations = new List<IDecoration>();
            fish = new List<IFish>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Aquarium name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Capacity { get; private set; }

        public ICollection<IDecoration> Decorations => decorations.AsReadOnly();

        public ICollection<IFish> Fish => fish.AsReadOnly();

        public int Comfort => this.Decorations.Sum(c => c.Comfort);


        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            //FreshwaterFish, SaltwaterFish
            string fishType;
            if (fish.GetType().Name == "FreshwaterFish")
            {
                fishType = "Freshwater";
            }
            else
            {
                fishType = "Saltwater";
            }
            //FreshwaterAquarium, SaltwaterAquarium
            string aquariumType;
            if (this.GetType().Name == "FreshwaterAquarium")
            {
                aquariumType = "Freshwater";
            }
            else
            {
                aquariumType = "Saltwater";
            }

            if (Capacity <= 0 || fishType != aquariumType)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            Capacity--;
            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var f in this.fish)
            {
                f.Eat();
            }
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();

            //{aquariumName} ({aquariumType}):
            //Fish: { fishName1}, { fishName2}, { fishName3} (…) / none
            //Decorations: { decorationsCount}
            //Comfort: { aquariumComfort}
            sb.AppendLine($"{Name} ({this.GetType().Name}):");
            if (this.fish.Count() == 0)
            {
                sb.AppendLine($"Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", this.fish.Select(n => n.Name))}");             
            }
            sb.AppendLine($"Decorations: {decorations.Count()}");
            sb.AppendLine($"Comfort: {Comfort}");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
