using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.BorderControl
{
    public class Engine
    {
        public void Run()
        {

            var citizens = new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];

                    Citizen citizen = new Citizen(name, age, id);

                    citizens.Add(citizen);
                }
                else if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    Robot robot = new Robot(model, id);

                    citizens.Add(robot);
                }
            }

            string fakeId = Console.ReadLine();

            List<IIdentifiable> citizensWithFakeIds = citizens
                .Where(c => c.Id.EndsWith(fakeId))
                .ToList();

            foreach (var citizen in citizensWithFakeIds)
            {
                Console.WriteLine(citizen.Id);
            }

        }
    }
}
