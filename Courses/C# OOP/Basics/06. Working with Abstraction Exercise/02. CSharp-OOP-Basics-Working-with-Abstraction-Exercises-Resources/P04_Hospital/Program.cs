using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        static List<Department> departments;
        static List<Doctor> doctors;
        public static void Main()
        {
            doctors = new List<Doctor>();
            departments = new List<Department>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] commandArgs = command.Split();
                var departmentName = commandArgs[0];
                var firstName = commandArgs[1];
                var lastName = commandArgs[2];
                var patient = commandArgs[3];

                Department department = GetDepartment(departmentName);
                Doctor doctor = GetDoctor(firstName, lastName);

                bool isFreePlace = department.Rooms.Sum(x => x.Patients.Count()) < 60;

                if (isFreePlace)
                {
                    int targetRoom = 0;
                    doctor.Patients.Add(patient);
                    
                    for (int room = 0; room < department.Rooms.Count; room++)
                    {
                        if (department.Rooms[room].Patients.Count < 3)
                        {
                            targetRoom = room;
                            break;
                        }
                    }
                    department.Rooms[targetRoom].Patients.Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    var department = GetDepartment(args[0]);

                    foreach (var room in department.Rooms.Where(x => x.Patients.Count > 0))
                    {
                        foreach (var patient in room.Patients)
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    var department = GetDepartment(args[0]);
                    foreach (var patient in department.Rooms[room - 1].Patients.OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }                   
                }
                else
                {
                    string firstName = args[0];
                    string lastName = args[1];
                    var doctor = GetDoctor(firstName, lastName);
                    foreach (var patient in doctor.Patients.OrderBy(x => x))
                    {
                        Console.WriteLine(patient);
                    }
                }
                command = Console.ReadLine();
            }
        }

        private static Doctor GetDoctor(string firstName, string lastName)
        {
            var doctor = doctors.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (doctor == null)
            {
                doctor = new Doctor(firstName, lastName);
                doctors.Add(doctor);
            }
            return doctor;
        }

        private static Department GetDepartment(string departmentName)
        {
            var department = departments.FirstOrDefault(x => x.Name == departmentName);
            if (department == null)
            {
                department = new Department(departmentName);
                departments.Add(department);
                for (int i = 0; i < 20; i++)
                {
                    department.Rooms.Add(new Room());
                }
            }
            return department;
        }
    }
}
