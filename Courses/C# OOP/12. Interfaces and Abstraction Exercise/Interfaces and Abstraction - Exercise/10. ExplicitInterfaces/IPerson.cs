using System;
using System.Collections.Generic;
using System.Text;

namespace _10._ExplicitInterfaces
{
    public interface IPerson
    {
        string Name { get; }
        string Country { get; }
        string GetName();
    }
}
