using System;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new SoftUniContext();
            using (context)
            {   // 03
                //Console.WriteLine(GetEmployeesFullInformation(context));
                // 04
                //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
                //05
                //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
                //06
                //Console.WriteLine(AddNewAddressToEmployee(context));
                //07
                //Console.WriteLine(GetEmployeesInPeriod(context));
                //08
                //Console.WriteLine(GetAddressesByTown(context));
                //09
                //Console.WriteLine(GetEmployee147(context));
                //10
                //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
                //11
                //Console.WriteLine(GetLatestProjects(context));
                //12
                //Console.WriteLine(IncreaseSalaries(context));
                //13
                //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
                //14
                //Console.WriteLine(DeleteProjectById(context));
                //15
                Console.WriteLine(RemoveTown(context));
            }
        }

        // 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            //Now we can use the SoftUniContext to extract data from our database. Your first task is to extract all employees and return their first, last and middle name, their job title and salary, rounded to 2 symbols after the decimal separator, all of those separated with a space. Order them by employee id.
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();
            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        // 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary,
                })
                .OrderBy(x => x.FirstName)
                .Where(x => x.Salary > 50000)
                .ToList();
            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        // 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    DepartmentName = e.Department.Name,
                    e.Salary,
                    e.FirstName,
                    e.LastName
                })
                .Where(d => d.DepartmentName == "Research and Development")
                .OrderBy(s => s.Salary)
                .ThenByDescending(f => f.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        // 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            //context.Addresses.Add(address);
            var nakov = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            nakov.Address = address;
            context.SaveChanges();
            var employeesAddress = context.Employees
                .OrderByDescending(a => a.AddressId)
                .Select(a => a.Address.AddressText)
                .Take(10)
                .ToList();
            var sb = new StringBuilder();

            foreach (var employeeAddress in employeesAddress)
            {
                sb.AppendLine($"{employeeAddress}");
            }
            return sb.ToString().TrimEnd();
        }

        // 7
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(p => p.EmployeesProjects.Any(s => s.Project.StartDate.Year >= 2001 && s.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    EmployeesFullName = e.FirstName + " " + e.LastName,
                    ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate,
                        EndDate = p.Project.EndDate
                    })

                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeesFullName} - Manager: {employee.ManagerFullName}");
                foreach (var project in employee.Projects)
                {
                    //6/1/2002 12:00:00 AM
                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var endDate = project.EndDate == null ? "not finished" : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    sb.AppendLine($"--{project.ProjectName} - {startDate} - {endDate}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        // 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            // Find all addresses, ordered by the number of employees who live there (descending), then by town name (ascending), and finally by address text (ascending). Take only the first 10 addresses. For each address return it in the format "<AddressText>, <TownName> - <EmployeeCount> employees"

            //Example
            //Output
            //163 Nishava Str, ent A, apt. 1, Sofia - 3 employees

            var addresses = context.Addresses
                .Select(a => new
                {
                    Address = a.AddressText,
                    EmployeesCount = a.Employees.Count,
                    TownName = a.Town.Name

                })
                .OrderByDescending(a => a.EmployeesCount)
                .ThenBy(t => t.TownName)
                .ThenBy(a => a.Address)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.Address}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        // 9
        public static string GetEmployee147(SoftUniContext context)
        {
            //Get the employee with id 147.Return only his/ her first name, last name, job title and projects(print only their names). The projects should be ordered by name(ascending).Format of the output.

            //    Example
            //Linda Randall -Production Technician
            //    HL Touring Handlebars

            var employees = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    EmployeesFullName = e.FirstName + " " + e.LastName,
                    JobTitle = e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(p => new
                    {
                        ProjectName = p.Project.Name,
                    })
                        .OrderBy(p => p.ProjectName)
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.EmployeesFullName} - {employee.JobTitle}");
                foreach (var project in employee.Projects)
                //foreach (var project in employee.Projects.OrderBy(x => x.ProjectName))
                {
                    sb.AppendLine($"{project.ProjectName}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        // 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            //Find all departments with more than 5 employees.Order them by employee count(ascending), then by department name(alphabetically). 
            //    For each department, print the department name and the manager’s first and last name on the first row.
            //    Then print the first name, the last name and the job title of every employee on a new row.
            //    Order the employees by first name(ascending), then by last name(ascending).
            //    Format of the output: For each department print it in the format "<DepartmentName> - <ManagerFirstName>  <ManagerLastName>" and for each employee print it in the format "<EmployeeFirstName> <EmployeeFirstName> - <JobTitle>".

            //    Example
            //Engineering – Terri Duffy
            //Gail Erickson - Design Engineer
            //    Jossef Goldberg - Design Engineer
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .Select(d => new
                {
                    EmployeesCount = d.Employees.Count,
                    DepartmentName = d.Name,
                    ManagerFullName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees
                        .Select(e => new
                        {
                            EmployeeFullName = e.FirstName + " " + e.LastName,
                            JobTitle = e.JobTitle 
                        })
                        .OrderBy(e => e.EmployeeFullName)
                })
                .OrderBy(d => d.EmployeesCount)
                .ThenBy(d => d.DepartmentName)
                .ToList();

            var sb = new StringBuilder();
            foreach (var department in departments)
            {
               sb.AppendLine($"{department.DepartmentName} - {department.ManagerFullName}");
               foreach (var employee in department.Employees)
               {
                   sb.AppendLine($"{employee.EmployeeFullName} - {employee.JobTitle}");
               }
            }
            return sb.ToString().TrimEnd();
        }

        // 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            //Write a program that return information about the last 10 started projects. Sort them by name lexicographically and return their name, description and start date, each on a new row.Format of the output
            //    Constraints
            //Use date format: "M/d/yyyy h:mm:ss tt".
            //    Example
            //Output
            //All - Purpose Bike Stand
            //    Research, design and development of All - Purpose Bike Stand. Perfect all-purpose bike stand for working on your bike at home.Quick - adjusting clamps and steel construction.
            //9 / 1 / 2005 12:00:00 AM
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                  ProjectStartDate = p.StartDate,
                  ProjectName = p.Name,
                  ProjectDescription = p.Description
                })
                .OrderBy(p => p.ProjectName)
                .ToList();
            var sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.ProjectName}");
                sb.AppendLine($"{project.ProjectDescription}");
                sb.AppendLine($"{project.ProjectStartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }
            return sb.ToString().TrimEnd();
        }

        // 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" ||
                            e.Department.Name == "Marketing" || e.Department.Name == "Information Services");
                //.Select( e => new
                //{
                //    Salary = e.Salary
                //});
                
            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
                
            }
            context.SaveChanges();

            var employeesToPrint = employees
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FullName);

            var sb = new StringBuilder();
            foreach (var employee in employeesToPrint)
            {
                sb.AppendLine($"{employee.FullName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        // 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                    
                })
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }
            return sb.ToString().TrimEnd();
        }

        // 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectForRemove = context.Projects.Find(2);
            var targetEmployeeProject = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(targetEmployeeProject);
            context.Projects.Remove(projectForRemove);
            context.SaveChanges();

            var projects = context.Projects
                .Select(p => new
                {
                    p.Name
                })
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        // 15
        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => e.Address.Town.Name == "Seattle")
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            var addresses = context.Addresses
                .Where(t => t.Town.Name == "Seattle");
            int count = addresses.Count();

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }

            var towns = context.Towns
                .Where(t => t.Name == "Seattle");
            foreach (var town in towns)
            {
                context.Towns.Remove(town);
            }

            context.SaveChanges();
            return $"{count} addresses in Seattle were deleted";
        }
    }
}
