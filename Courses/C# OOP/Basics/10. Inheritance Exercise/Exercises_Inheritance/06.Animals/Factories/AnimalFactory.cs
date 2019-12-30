using _06.Animals.Animals;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06.Animals.Factories
{
   public class AnimalFactory
    {
        public Animal CreateAnimal(string type, string name, int age, string gender)
        {
            type = type.ToLower();

            switch (type)
            {
                case "cat":
                    return new Cat(name, age, gender);
                case "kitten":
                    return new Kitten(name, age);
                case "tomcat":
                    return new Tomcat(name, age);
                case "dog":
                    return new Dog(name, age, gender);
                case "frog":
                    return new Frog(name, age, gender);
                default:
                    throw new ArgumentException("Invalid input!");
            }
        }
    }

}
