using AnimalCentre.Factories.Contacts;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AnimalCentre.Factories
{
    class ProcedureFactory : IProcedureFactory
    {
        public IProcedure CreateProcedure(string type)
        {
            var procedureType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == type);
            var procedure = (IProcedure)Activator.CreateInstance(procedureType);
            return procedure;
            //switch (type)
            //{
            //    case "Chip":
            //        return new Chip();
            //    case "DentalCare":
            //        return new DentalCare();
            //    case "Fitness":
            //        return new Fitness();
            //    case "NailTrim":
            //        return new NailTrim();
            //    case "Play":
            //        return new Play();
            //    case "Vaccinate":
            //        return new Vaccinate();
            //    default:
            //        throw new ArgumentException($"Invalid procedure");
            //}
        }
    }
}
