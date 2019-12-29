using System;
using System.Collections.Generic;
using System.Text;
using _03.Wild_Farm.Foods;

namespace _03.Wild_Farm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double increasingWeight = 0.25;

        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * increasingWeight;
                FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
