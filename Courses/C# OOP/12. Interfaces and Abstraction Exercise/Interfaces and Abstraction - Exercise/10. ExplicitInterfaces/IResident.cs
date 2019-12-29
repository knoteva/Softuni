using System;
using System.Collections.Generic;
using System.Text;

namespace _10._ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; }
        int Age { get; }
        string GetName();
    }
}
