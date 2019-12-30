using System;
using System.Collections.Generic;
using System.Text;
using _03.Wild_Farm.Foods;

namespace _03.Wild_Farm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double increasingWeight = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            Weight += food.Quantity * increasingWeight;
            FoodEaten += food.Quantity;
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
