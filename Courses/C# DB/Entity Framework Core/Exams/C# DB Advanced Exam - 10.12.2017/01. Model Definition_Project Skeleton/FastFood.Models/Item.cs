using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FastFood.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [ForeignKey(nameof(Category)), Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335"), Required]
        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();


        //•	Id – integer, Primary Key
        //•	Name – text with min length 3 and max length 30 (required, unique)
        //•	CategoryId – integer, foreign key
        //•	Category – the item’s category(required)
        //•	Price – decimal (non-negative, minimum value: 0.01, required)
        //•	OrderItems – collection of type OrderItem

    }
}
