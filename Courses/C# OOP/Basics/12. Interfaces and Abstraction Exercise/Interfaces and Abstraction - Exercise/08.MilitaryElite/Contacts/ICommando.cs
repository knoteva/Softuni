using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contacts
{
    public interface ICommando : ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; set; }
    }
}
