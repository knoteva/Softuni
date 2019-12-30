using _09.CollectionHierarchy.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _09.CollectionHierarchy.Models
{
    public abstract class Collection : IAdd
    {
        private List<string> list;
        public Collection()
        {
            list = new List<string>();
        }

        protected IList<string> List
        {
            get
            {
                return this.list;
            }
        }

        public abstract int Add(string element);
      
    }
}
