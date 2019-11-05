using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        //ProductId
        //Name(up to 50 characters, unicode)
        //Quantity(real number)
        //Price
        //Sales

        //[Key]
        public int ProductId { get; set; }
        
        //[Required]
        //[MaxLength(50)]
        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public string Description { get; set; }
    }
}
