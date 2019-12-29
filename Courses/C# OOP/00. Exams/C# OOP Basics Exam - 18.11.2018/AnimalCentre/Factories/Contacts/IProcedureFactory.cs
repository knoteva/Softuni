using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Factories.Contacts
{
    public interface IProcedureFactory
    {
        IProcedure CreateProcedure(string type);
    }
}
