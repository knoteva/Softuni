using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private List<IMotorcycle> Models { get; set; }

        public MotorcycleRepository()
        {
            this.Models = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IMotorcycle> GetAll()
        {
            return this.Models.AsReadOnly();
        }

        public IMotorcycle GetByName(string name)
        {
            var motorcycle = Models.Find(x => x.Model == name);
            return motorcycle;
        }

        public bool Remove(IMotorcycle model)
        {
            return Models.Remove(model);
        }
    }
}
