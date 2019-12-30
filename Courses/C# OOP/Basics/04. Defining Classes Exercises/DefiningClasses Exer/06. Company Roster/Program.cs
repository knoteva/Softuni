using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster
{
    public class Program
    {
        static void Main(string[] args)
        {    
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ");

                string name = input[0];
                decimal salary = decimal.Parse(input[1]);
                string position = input[2];
                string department = input[3];

                Employee employee = new Employee(name, salary, position, department);

                if (input.Length == 5)
                {
                    if (input[4].Contains("@"))
                    {
                        employee.Email = input[4];
                    }
                    else
                    {
                        employee.Age = int.Parse(input[4]);
                    }
                }
                else if (input.Length == 6)
                {
                    employee.Email = input[4];
                    employee.Age = int.Parse(input[5]);
                }
                employees.Add(employee);
            }
            var topDepartment = employees.GroupBy(x => x.Department)
                //.ToDictionary(x => x.Key, y => y.Select(s => s))
                .OrderByDescending(x => x.Average(y => y.Salary))
                .FirstOrDefault();
            Console.WriteLine($"Highest Average Salary: {topDepartment.Key}");

            foreach (var empl in topDepartment.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{empl.Name} {empl.Salary:F2} {empl.Email} {empl.Age}");
            }
        }
    }
}
