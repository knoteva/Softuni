using _03.Wild_Farm.Animals.Contacts;
using _03.Wild_Farm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Wild_Farm.Animals
{
    public abstract class Animal : IBird
    {
        private string name;
        private double weight;        
        private int foodEaten;

        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name
        {
            get => name; 
            set
            {
                name = value;
            }
        }
        public double Weight
        {
            get => weight; 
            set
            {
                weight = value;
            }
        }
        public int FoodEaten
        {
            get => foodEaten; 
            set
            {
                foodEaten = value;
            }
        }

        public abstract void ProduceSound();
        public abstract void Eat(Food food);

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, ";
        }
    }
}
