using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split(" ");
            var students = new List<Student>();

            while (command[0] != "end")
            {
                Student student = new Student();
                student.FirstName = command[0];
                string firstname = command[0];
                student.LastName = command[1];
                student.Age = int.Parse(command[2]);
                student.City = command[3];
                if (!students.Contains(Student.FirstName))
                {

                }
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
