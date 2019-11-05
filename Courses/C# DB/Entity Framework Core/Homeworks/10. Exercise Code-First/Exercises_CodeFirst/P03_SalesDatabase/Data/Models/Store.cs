using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Store
    {
        //StoreId
        //Name(up to 80 characters, unicode)
        //Sales

        //[Key]
        public int StoreId { get; set; }
       
        //[Required]
        //[MaxLength(80)]
        public string Name { get; set; }

        public ICollection<Sale> Sales { get; set; }

    }
}
