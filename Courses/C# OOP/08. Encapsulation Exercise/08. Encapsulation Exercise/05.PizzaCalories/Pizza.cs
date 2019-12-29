using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough { get => dough; set => dough = value; }
        public List<Topping> Toppings
        {
            get => toppings; set
            {
                toppings = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count() == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        private double GetCalories()
        {
            double doughCal = Dough.DoughCalories;
            double toppingCal = Toppings.Sum(c => c.ToppingCalories);
            return doughCal + toppingCal;
        }
        public override string ToString()
        {
            return $"{Name} - {GetCalories():F2} Calories.";
        }
    }
}
