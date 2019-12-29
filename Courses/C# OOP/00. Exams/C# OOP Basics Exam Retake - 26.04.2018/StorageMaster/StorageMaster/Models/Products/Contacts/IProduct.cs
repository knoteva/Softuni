using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Models.Products.Contacts
{
    public interface IProduct
    {
        double Price { get; }
        double Weight { get; }
    }
}
