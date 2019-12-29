using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName
        {
            get => firstName; 
            set
            {
                if (!char.IsUpper(value[0]) || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: firstName");
                }
                if (value.Length <= 3)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
                }
                firstName = value;
            }
        }
        
        public string LastName
        {
            get => lastName; 
            set
            {
                if (!char.IsUpper(value[0]) || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: lastName");
                }
                lastName = value;
                if (value.Length <= 2)
                {
                    throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName ");
                }
            }
        }
        
    }
}
