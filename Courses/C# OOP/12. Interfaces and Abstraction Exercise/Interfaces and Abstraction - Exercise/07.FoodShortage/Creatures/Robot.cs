using _07.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage.Creatures
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }
    }
}
