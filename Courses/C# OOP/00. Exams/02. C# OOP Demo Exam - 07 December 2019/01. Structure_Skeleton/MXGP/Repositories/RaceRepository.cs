using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    class RaceRepository : IRepository<IRace>
    {
        
        private List<IRace> Models { get; set; }

        public RaceRepository()
        {
            this.Models = new List<IRace>();
        }

        public void Add(IRace model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.Models.AsReadOnly();
        }

        public IRace GetByName(string name)
        {
            var racer = Models.Find(x => x.Name == name);
            return racer;
        }

        public bool Remove(IRace model)
        {
            return Models.Remove(model);
        }
    }
}
