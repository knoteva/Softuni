using _08.MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.MilitaryElite.Contacts
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }
        void CompleteMission();
    }
}
