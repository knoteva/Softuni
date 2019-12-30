namespace Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            List<Person> persons = new List<Person>();

            while ((input = Console.ReadLine()) != "End")
            {
                string personName = input.Split(" ")[0];
                string type = input.Split(" ")[1];

                if (!persons.Any(p => p.Name == personName))
                {
                    persons.Add(new Person(personName));
                }
                Person person = persons.Where(p => p.Name == personName).First();
                switch (type)
                {
                    case "company":
                        var companyName = input.Split(" ")[2];
                        var department = input.Split(" ")[3];
                        var salary = decimal.Parse(input.Split(" ")[4]);
                        var company = new Company(companyName, department, salary);
                        person.Company = company;
                        break;
                    case "pokemon":
                        var pokemonName = input.Split(" ")[2];
                        var pokemonType = input.Split(" ")[3];
                        var pokemon = new Pokemon(pokemonName, pokemonType);
                        person.Pokemon.Add(pokemon);
                        break;
                    case "parents":
                        var parentName = input.Split(" ")[2];
                        var parentBirthday = input.Split(" ")[3];
                        var parent = new Parent(parentName, parentBirthday);
                        person.Parent.Add(parent);
                        break;
                    case "children":
                        var childName = input.Split(" ")[2];
                        var childBirthday = input.Split(" ")[3];
                        var child = new Child(childName, childBirthday);
                        person.Child.Add(child);
                        break;
                    case "car":
                        var carModel = input.Split(" ")[2];
                        var carSpeed = int.Parse(input.Split(" ")[3]);
                        var car = new Car(carModel, carSpeed);
                        person.Car = car;
                        break;
                    default:
                        break;
                }
            }
            string personF = Console.ReadLine();

            Person resPerson = persons.Where(x => x.Name == personF).First();

            Console.WriteLine($"{personF}");
            Console.WriteLine($"Company:");
            if (resPerson.Company != null)
            {
                Console.WriteLine($"{resPerson.Company}");
            }
            Console.WriteLine($"Car:");
            if (resPerson.Car != null)
            {
                Console.WriteLine($"{resPerson.Car}");
            }
            Console.WriteLine($"Pokemon:");
            resPerson.Pokemon.ForEach(p => Console.WriteLine(p));
            Console.WriteLine($"Parents:");
            resPerson.Parent.ForEach(p => Console.WriteLine(p));
            Console.WriteLine($"Children:");
            resPerson.Child.ForEach(p => Console.WriteLine(p));
        }
    }
}
