using _07.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage.Creatures
{
    public class Pet : Food
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}
