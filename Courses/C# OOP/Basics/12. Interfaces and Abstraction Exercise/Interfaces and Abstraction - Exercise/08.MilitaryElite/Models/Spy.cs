using _08.MilitaryElite.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        private int codeNumber;
        public Spy(int id, string firstName1, string lastName, int codeNumber)
            : base(id, firstName1, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber
        {
            get => codeNumber;
            private set
            {
                codeNumber = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Code Number: {CodeNumber}";
        }
    }
}
