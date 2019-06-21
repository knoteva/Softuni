using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            var students = new List<Student>();

            while ((command = Console.ReadLine()) != "end")
            {
                Student student = new Student
                {
                    FirstName = command.Split(" ")[0],
                    LastName = command.Split(" ")[1],
                    Age = int.Parse(command.Split(" ")[2]),
                    City = command.Split(" ")[3]
                };
                students.Add(student);
            }
            string city = Console.ReadLine();

            students = students
                    .Where(s => s.City == city)
                    .ToList();
            foreach (var s in students)
            {
                Console.WriteLine($"{s.FirstName} {s.LastName} is {s.Age} years old.");
            }

        }

        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string City { get; set; }

        }
    }
}
