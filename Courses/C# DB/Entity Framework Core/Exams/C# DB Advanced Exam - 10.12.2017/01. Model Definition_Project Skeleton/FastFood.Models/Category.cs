using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.Models
{
    public class Category
    {
        //•	Id – integer, Primary Key
        //•	Name – text with min length 3 and max length 30 (required)
        //•	Items – collection of type Item

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; } = new HashSet<Item>();
    }
}
