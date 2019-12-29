using System;
using System.Collections.Generic;
using System.Text;

namespace HardTyre.Models.Contracts
{
    public interface IDriver
    {
        string Name { get; }
        double TotalTime { get; }
        ICar Car { get; }
        double FuelConsumptionPerKm {get;}
        double Speed { get; }

    }


}
