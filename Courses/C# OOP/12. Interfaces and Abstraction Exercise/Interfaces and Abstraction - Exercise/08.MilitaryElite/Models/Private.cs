using _08.MilitaryElite.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        private decimal salary;
        public Private(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName)
        {
            Salary = salary;
        }

        //TODO Add validation
        public decimal Salary
        {
            get => salary; 
            private set
            {
                salary = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"Salary: {Salary:F2}";
        }
    }
}
