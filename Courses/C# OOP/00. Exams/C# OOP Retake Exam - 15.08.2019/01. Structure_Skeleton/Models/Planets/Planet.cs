using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private readonly List<string> items;
        private string name;
        public Planet(string name)
        {
            items = new List<string>();
            Name = name;
        }

        public ICollection<string> Items => items.AsReadOnly();

        public string Name
        {
            get => name; 
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }
                name = value;
            }
        }

        public void AddItems(string[] planetItems)
        {
            foreach (var item in planetItems)
            {
                this.items.Add(item);
            }
        }

        public void RemoveItem(string item)
        {
            this.items.Remove(item);
        }
    }
}
