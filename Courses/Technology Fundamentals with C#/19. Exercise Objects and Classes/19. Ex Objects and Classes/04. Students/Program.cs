using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> articles = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ");
                articles.Add(new Student(data));
            }
            articles = articles.OrderByDescending(x => x.Grade).ToList();
            articles.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public double Grade { get; set; }

        public Student(string[] data)
        {
            FirstName = data[0];
            SecondName = data[1];
            Grade = double.Parse(data[2]);
        }

        public override string ToString()
        {
            return $"{FirstName} {SecondName}: {Grade:F2}";
        }
    }
}
