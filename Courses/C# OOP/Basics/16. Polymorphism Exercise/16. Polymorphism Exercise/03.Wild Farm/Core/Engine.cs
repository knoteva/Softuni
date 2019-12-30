using _03.Wild_Farm.Animals;
using _03.Wild_Farm.Animals.Birds.Factory;
using _03.Wild_Farm.Animals.Mammals.Factory;
using _03.Wild_Farm.Animals.Mammals.Felines.Factory;
using _03.Wild_Farm.Foods.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Wild_Farm.Core
{
    public class Engine
    {
        private BirdFactory birdFactory;
        private MammalFactory mammalFactory;
        private FelineFactory felineFactory;
        private FoodFactory foodFactory;
        private Animal animal;
        private List<Animal> animals;
        public Engine()
        {
            birdFactory = new BirdFactory();
            mammalFactory = new MammalFactory();
            felineFactory = new FelineFactory();
            foodFactory = new FoodFactory();
            animals = new List<Animal>();
        }
        public void Run()
        {
            //Birds – "{AnimalType} [{AnimalName}, {WingSize}, {AnimalWeight}, {FoodEaten}]"
            //Felines – "{AnimalType} [{AnimalName}, {Breed}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"
            //Mice and Dogs – "{AnimalType} [{AnimalName}, {AnimalWeight}, {AnimalLivingRegion}, {FoodEaten}]"

            //Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}";
            //Birds - "{Type} {Name} {Weight} {WingSize}";
            //Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}";



            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                
               
                    var animalInfo = input.Split(" ");
                    var animalType = animalInfo[0];
                    var animalName = animalInfo[1];
                    var animalWeight = double.Parse(animalInfo[2]);
                    var foodInfo = Console.ReadLine().Split(" ");
                    var foodType = foodInfo[0];
                    var foodQuantity = int.Parse(foodInfo[1]);
                    if (animalType == "Hen" || animalType == "Owl")
                    {
                        var wingSize = double.Parse(animalInfo[3]);
                        animal = birdFactory.CreateBird(animalType, animalName, animalWeight, wingSize);
                    }
                    else if (animalType == "Cat" || animalType == "Tiger")
                    {
                        var livingRegion = animalInfo[3];
                        var breed = animalInfo[4];
                        animal = felineFactory.CreateFeline(animalType, animalName, animalWeight, livingRegion, breed);
                    }
                    else if (animalType == "Dog" || animalType == "Mouse")
                    {
                        var livingRegion = animalInfo[3];
                        animal = mammalFactory.CreateMammal(animalType, animalName, animalWeight, livingRegion);
                    }
                    var food = foodFactory.CreateFood(foodType, foodQuantity);
                    animal.ProduceSound();
                    animal.Eat(food);
                    animals.Add(animal);
                    
                   // Console.WriteLine();
                

            }
            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
