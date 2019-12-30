using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Mankind
{
    public class Student : Human
    {
        private string facultNumber;

        public Student(string firstName, string lastName, string facultNumber) : base(firstName, lastName)
        {
            FacultNumber = facultNumber;
        }

        public string FacultNumber
        {
            get => facultNumber; 
            set
            {
                if (value.Length < 5 || value.Length > 10 || !value.ToCharArray().All(char.IsLetterOrDigit))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                facultNumber = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"First Name: {FirstName}");
            sb.AppendLine($"Last Name: {LastName}");
            sb.AppendLine($"Faculty number: {FacultNumber}");
            return sb.ToString();
        }
    }
}
