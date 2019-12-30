using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy.Models
{
    public class AddCollection : Collection
    {
       // public AddCollection()
       //: base()
       // { }

        public override int Add(string element)
        {
            this.List.Add(element);

            return this.List.Count - 1;
        }
    }
}
