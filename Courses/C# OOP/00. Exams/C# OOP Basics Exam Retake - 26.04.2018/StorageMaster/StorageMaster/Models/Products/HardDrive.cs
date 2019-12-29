using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products
{
    public class HardDrive : Product
    {
        private const double weightHardDrive = 1;
        public HardDrive(double price)
            : base(price, weightHardDrive)
        {
        }
    }
}
