using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            var people = new List<Person>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split(" ");
                people.Add(CreatePerson(data));
            }

            people = people.OrderBy(x => x.Age).ToList();
            people.ForEach(x => Console.WriteLine(x.ToString()));
        }

        public static Person CreatePerson(string[] data)
        {
            string name = data[0];
            string id = data[1];
            int age = int.Parse(data[2]);

            return new Person
            {
                Name = name,
                Id = id,
                Age = age,
                People = new List<string>()
            };
        }
    }
    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public List<string> People { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
}
