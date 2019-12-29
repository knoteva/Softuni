using _07.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage.Creatures
{

    public class Citizen : Person, IIdentifiable, Food, IBuyer
    {
        public string Id { get; set; }

        public string Birthday { get; set; }

        public Citizen(string name, int age, string id, string birthday)
            : base(name, age)
        {
            this.Id = id;
            this.Birthday = birthday;
        }

        public override void BuyFood()
        {
            this.Food += 10;
        }
    }
}
