using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    public class Worker : Human
    {
        private double weekSalary;
        private double workHoursPerDay;
        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay) : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public double WeekSalary
        {
            get => weekSalary; 
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                weekSalary = value;
            }
        }
        public double WorkHoursPerDay
        {
            get => workHoursPerDay; 
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                workHoursPerDay = value;
            }
        }

        private double GetSalaryPerHour()
        {
            return WeekSalary / (WorkHoursPerDay * 5.0);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {FirstName}");
            sb.AppendLine($"Last Name: {LastName}");
            sb.AppendLine($"Week Salary: {WeekSalary:F2}");
            sb.AppendLine($"Hours per day: {WorkHoursPerDay:F2}");
            sb.AppendLine($"Salary per hour: {GetSalaryPerHour():F2}");
            return sb.ToString();
        }
    }
}
