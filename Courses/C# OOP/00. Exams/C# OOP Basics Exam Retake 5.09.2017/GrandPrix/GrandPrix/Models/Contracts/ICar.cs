using System;
using System.Collections.Generic;
using System.Text;

namespace HardTyre.Models.Contracts
{
    public interface ICar
    {
        int Hp { get; }
        double FuelAmount { get; }
        ITyre Tyre { get; }
    }
}
