using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        public string Type
        {
            get => type;
            set
            {
                switch (value.ToLower())
                {
                    case "meat":
                    case "veggies":
                    case "cheese":
                    case "sauce":
                        type = value.ToLower();
                        break;
                    default:
                        throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
            }
        }
        public double Weight
        {
            get => weight; 
            set
            {
                if (value < 1 || value > 50)
                {
                    var t = Type[0].ToString().ToUpper() + Type.Substring(1);
                    throw new ArgumentException($"{t} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double ToppingCalories { get => this.CalculateToppingCalories(); }

        public double CalculateToppingCalories()
        {
            double topppingModifier = Type == "meat" ? 1.2 : Type == "veggies" ? 0.8 : Type == "cheese"? 1.1: 0.9;
            return 2 * Weight * topppingModifier;
        }
    }
}
