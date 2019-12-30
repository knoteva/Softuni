using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    class RiderRepository : IRepository<IRider>
    {
        private List<IRider> Models { get; set; }

        public RiderRepository()
        {
            this.Models = new List<IRider>();
        }

        public void Add(IRider model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IRider> GetAll()
        {
            return this.Models.AsReadOnly();
        }

        public IRider GetByName(string name)
        {
            var rider = Models.Find(x => x.Name == name);
            return rider;
        }

        public bool Remove(IRider model)
        {
            return Models.Remove(model);
        }
    }
}
