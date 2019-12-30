using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.BirthdayCelebrations
{
    public class Engine
    {
        public void Run()
        {
            var citizens = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                var type = tokens[0];
                if (type == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthday = tokens[4];

                    Citizen citizen = new Citizen(name, age, id, birthday);

                    citizens.Add(citizen);
                }
                else if(type == "Pet") 
                {
                    string petName = tokens[1];
                    string petBirthdate = tokens[2];

                    Pet pet = new Pet(petName, petBirthdate);
                    citizens.Add(pet);
                }
                //else if (type == "Robot")
                //{
                //    string model = tokens[1];
                //    string id = tokens[2];

                //    Robot robot = new Robot(model, id);

                //    citizens.Add(robot);
                //}
            }

            string birthdays = Console.ReadLine();

            List<IBirthable> allBirthdays = citizens
                .Where(c => c.Birthday.EndsWith(birthdays))
                .ToList();

            foreach (var birthday in allBirthdays)
            {
                Console.WriteLine(birthday.Birthday);
            }

        }
    }
}
