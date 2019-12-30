using _08.MilitaryElite.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Repair : IRepair
    {
        private string partName;
        private int hoursWorked;

        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public string PartName
        {
            get => partName; 
            set
            {
                partName = value;
            }
        }
        public int HoursWorked
        {
            get => hoursWorked; 
            set
            {
                hoursWorked = value;
            }
        }
        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
