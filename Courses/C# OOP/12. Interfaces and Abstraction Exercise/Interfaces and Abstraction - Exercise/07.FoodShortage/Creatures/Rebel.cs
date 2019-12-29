using _07.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage.Creatures
{
    public class Rebel : Person, IBuyer
    {
        public string Group { get; set; }

        public Rebel(string name, int age, string group)
            : base(name, age)
        {
            this.Group = group;
        }

        public override void BuyFood()
        {
            this.Food += 5;
        }
    }
}
