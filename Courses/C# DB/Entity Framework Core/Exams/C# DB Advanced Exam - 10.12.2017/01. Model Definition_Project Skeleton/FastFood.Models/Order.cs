using FastFood.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FastFood.Models
{
    public class Order
    {
        //•	Id – integer, Primary Key
        //•	Customer – text(required)
        //•	DateTime – date and time of the order(required)
        //•	Type – OrderType enumeration with possible values: “ForHere, ToGo(default: ForHere)” (required)
        //•	TotalPrice – decimal value(calculated property, (not mapped to database), required)
        //•	EmployeeId – integer, foreign key
        //•	Employee – The employee who will process the order(required)
        //•	OrderItems – collection of type OrderItem
        
        public int Id { get; set; }

        [Required]
        public string Customer { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [NotMapped, Required]
        public decimal TotalPrice => this.OrderItems.Sum(s => s.Item.Price * s.Quantity);

        [ForeignKey(nameof(Employee)), Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();


    }
}
