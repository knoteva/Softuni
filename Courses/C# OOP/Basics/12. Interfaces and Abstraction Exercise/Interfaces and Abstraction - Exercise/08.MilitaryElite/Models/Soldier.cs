using _08.MilitaryElite.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public abstract class Soldier : ISoldier
    {
        private int id;
        private string firstName;
        private string lastName;


        public Soldier(int id, string firstName, string lastName) 
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id
        {
            get => id; 
            private set
            {
                id = value;
            }
        }
        //TODO Add validations
        public string FirstName
        {
            get => firstName; 
            private set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get => lastName; 
            private set
            {
                lastName = value;
            }
        }
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} ";
        }
    }
}
