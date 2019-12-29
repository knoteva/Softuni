using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; }

        public int Capacity { get; }

        public int Comfort { get; }

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public void AddDecoration(IDecoration decoration)
        {
            throw new NotImplementedException();
        }

        public void AddFish(IFish fish)
        {
            Fish.Add(fish);
        }

        public void Feed()
        {
            throw new NotImplementedException();
        }

        public string GetInfo()
        {
            return "aaaaa";
        }

        public bool RemoveFish(IFish fish)
        {
            return false;
        }
    }
}
