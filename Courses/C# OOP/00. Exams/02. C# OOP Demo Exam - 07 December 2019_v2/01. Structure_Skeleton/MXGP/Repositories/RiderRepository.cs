using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            var rider = Data.FirstOrDefault(x => x.Name == name);
            return rider;
        }
    }
}
