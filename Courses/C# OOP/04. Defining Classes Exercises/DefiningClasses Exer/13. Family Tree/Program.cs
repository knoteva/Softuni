namespace FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static List<Person> people;
        static List<string> relationships;
        public static void Main(string[] args)
        {
            string mainPersonInfo = Console.ReadLine();

            var input = string.Empty;
            people = new List<Person>();
            relationships = new List<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (!input.Contains("-"))
                {
                    AddMember(input);
                    continue;
                }
                relationships.Add(input);
            }

            foreach (var item in relationships)
            {
                string[] inputArgs = item.Split(" - ");
                Person parent = GetPerson(inputArgs[0]);
                Person child = GetPerson(inputArgs[1]);

                if (!parent.Children.Contains(child))
                {
                    parent.Children.Add(child);
                }
                if (!child.Parents.Contains(parent))
                {
                    child.Parents.Add(parent);
                }
            }
            Print(mainPersonInfo);
        }

        private static void Print(string mainPersonInfo)
        {
            Person mainPerson = GetPerson(mainPersonInfo);
            Console.WriteLine($"{mainPerson.Name} {mainPerson.Birthday}");
            Console.WriteLine($"Parents:");
            foreach (var parent in mainPerson.Parents)
            {
                Console.WriteLine($"{parent.Name} {parent.Birthday}");
            }
            Console.WriteLine($"Children:");
            foreach (var child in mainPerson.Children)
            {
                Console.WriteLine($"{child.Name} {child.Birthday}");
            }
        }

        private static Person GetPerson(string input)
        {
            if (input.Contains("/"))
            {
                return people.FirstOrDefault(x => x.Birthday == input);
            }
            return people.FirstOrDefault(x => x.Name == input);
        }

        private static void AddMember(string input)
        {
            string name = input.Split(" ")[0] + " " + input.Split(" ")[1];
            string birthday = input.Split(" ")[2];
            var person = new Person(name, birthday);
            people.Add(person);
        }
    }
}
