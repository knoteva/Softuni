using _08.MilitaryElite.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            Privates = new List<IPrivate>();
        }

        //TODO Add readonly collection
        public ICollection<IPrivate> Privates { get; set; }
        public override string ToString()
        {
            return base.ToString() + $"\nPrivates:{(Privates.Count == 0 ? "" : "\n")}  {string.Join("\n  ", Privates)}";
        }
    }
}
