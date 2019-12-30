using MXGP.Models.Races.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            var racer = Data.FirstOrDefault(x => x.Name == name);
            return racer;
        }
    }
}
