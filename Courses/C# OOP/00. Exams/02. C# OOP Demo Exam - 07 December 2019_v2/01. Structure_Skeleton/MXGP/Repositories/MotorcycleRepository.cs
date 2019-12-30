using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            var motorcycle = Data.FirstOrDefault(x => x.Model == name);
            return motorcycle;
        }
    }
}
