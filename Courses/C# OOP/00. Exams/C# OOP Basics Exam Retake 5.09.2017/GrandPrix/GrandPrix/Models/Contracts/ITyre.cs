using System;
using System.Collections.Generic;
using System.Text;

namespace HardTyre.Models.Contracts
{
    public interface ITyre
    {
        string Name { get; }
        double Hardness { get; }
        double Degradation { get; set; }

    }
}
