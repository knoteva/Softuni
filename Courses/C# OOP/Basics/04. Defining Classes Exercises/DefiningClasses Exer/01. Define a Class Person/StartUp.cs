using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //Family family = new Family();
            List<Person> family = new List<Person>();
            int minAge = 30;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                string name = input[0];
                int age = int.Parse(input[1]);
                Person person = new Person(name, age);
                //family.AddMember(person);
                family.Add(person);
            }
            //Person oldestMember = family.GetOldestMember();
            //Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");

            var result = family.Where(x => x.Age > minAge)
                .OrderBy(x => x.Name);

            foreach (var person in result)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
