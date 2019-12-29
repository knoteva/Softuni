using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Core
{
    public class Engine : IEngine
    {
        private AnimalCentre animalCentre;

        public Engine()
        {
            animalCentre = new AnimalCentre();
        }
        public void Run()
        {
            string inputArgs = string.Empty;
            while ((inputArgs = Console.ReadLine()) != "End")
            {
                //• RegisterAnimal { type} { name} { energy} { happiness} { procedureTime}

                //•	Chip { name} { procedureTime}
                //•	Vaccinate { name} { procedureTime}
                //•	Fitness { name} { procedureTime}
                //•	Play { name} { procedureTime}
                //•	DentalCare { name} { procedureTime}
                //•	NailTrim { name} { procedureTime}

                //•	Adopt { animal name} { owner}
                //•	History { procedureType}
                try
                {
                    var input = inputArgs.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var command = input[0];
                    if (command == "RegisterAnimal")
                    {
                        string type = input[1];
                        string name = input[2];
                        int energy = int.Parse(input[3]);
                        int happiness = int.Parse(input[4]);
                        int procedureTime = int.Parse(input[5]);
                      
                            Console.WriteLine(animalCentre.RegisterAnimal(type, name, happiness, energy, procedureTime));

                       
                    }
                   else if (command != "History" && command != "Adopt" && command != "RegisterAnimal")
                    {
                        var name = input[1];
                        var procedureTime = int.Parse(input[2]);

                        if (command == "Chip")
                        {
                            Console.WriteLine(animalCentre.Chip(name, procedureTime));
                        }
                        else if (command == "Vaccinate")
                        {
                            Console.WriteLine(animalCentre.Vaccinate(name, procedureTime));
                        }
                        else if (command == "Fitness")
                        {
                            Console.WriteLine(animalCentre.Fitness(name, procedureTime));
                        }
                        else if (command == "Play")
                        {
                            Console.WriteLine(animalCentre.Play(name, procedureTime));
                        }
                        else if (command == "DentalCare")
                        {
                            Console.WriteLine(animalCentre.DentalCare(name, procedureTime));
                        }
                        else if (command == "NailTrim")
                        {
                            Console.WriteLine(animalCentre.NailTrim(name, procedureTime));
                        }
                    }

                    //•	Adopt { animal name} { owner}
                    //•	History { procedureType}
                    else if (command == "Adopt")
                    {
                        string name = input[1];
                        string owner = input[2];
                        Console.WriteLine(animalCentre.Adopt(name, owner));
                    }
                    else if (command == "History")
                    {
                        string procedureType = input[1];
                        Console.WriteLine(animalCentre.History(procedureType));
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"ArgumentException: {ex.Message}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"InvalidOperationException: {ex.Message}");
                }
            }
            Console.WriteLine(animalCentre.AllAdoptedAnimals());
        }
    }
}
