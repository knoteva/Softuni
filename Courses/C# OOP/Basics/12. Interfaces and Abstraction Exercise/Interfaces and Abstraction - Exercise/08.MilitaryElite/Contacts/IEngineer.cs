using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contacts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; set; }
    }
}
