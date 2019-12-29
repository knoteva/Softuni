using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public string Name 
        { 
            get => name;

            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money
        { 
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }
        public List<Product> Products { get => products; set => products = value; }

        public void AddProduct(Product product)
        {
            decimal cost = product.Cost;

            if (cost > this.Money)
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
            else
            {
                Products.Add(product);
                Money -= cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
        }

        public override string ToString()
        {
            if (Products.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }
            return $"{Name} - {string.Join(", ", Products.Select(x => x.ToString()))}";
        }
    }
}
