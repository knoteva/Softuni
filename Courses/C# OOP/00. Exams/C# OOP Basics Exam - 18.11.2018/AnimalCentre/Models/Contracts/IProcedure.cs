using System.Collections.Generic;

namespace AnimalCentre.Models.Contracts
{
    public interface IProcedure
    {
        List<IAnimal> ProcedureHistory {get;}
        string History();
        void DoService(IAnimal animal, int procedureTime);
    }
}
