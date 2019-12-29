using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Vehicles
{
    public class Semi : Vehicle
    {
        private const int capacitySemi = 10;
        public Semi()
            : base(capacitySemi)
        {
        }
    }
}
