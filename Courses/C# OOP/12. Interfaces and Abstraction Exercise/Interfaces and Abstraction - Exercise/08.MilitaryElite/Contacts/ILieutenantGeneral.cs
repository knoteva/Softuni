using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contacts
{
    public interface ILieutenantGeneral : IPrivate
    {
        ICollection<IPrivate> Privates { get; set; }
    }
}
