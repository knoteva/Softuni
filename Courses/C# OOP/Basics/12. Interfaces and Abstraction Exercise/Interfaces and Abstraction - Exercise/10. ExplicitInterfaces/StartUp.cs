using System;
using System.Collections.Generic;

namespace _10._ExplicitInterfaces
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            List<Citizen> citizens = new List<Citizen>();
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string name = input.Split(" ")[0];
                string country = input.Split(" ")[1];
                int age = int.Parse(input.Split(" ")[2]);

                Citizen citizen = new Citizen(name, country, age);

                citizens.Add(citizen);
            }


            foreach (var citizen in citizens)
            {
                var person = (IPerson)citizen;
                var resident = (IResident)citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
