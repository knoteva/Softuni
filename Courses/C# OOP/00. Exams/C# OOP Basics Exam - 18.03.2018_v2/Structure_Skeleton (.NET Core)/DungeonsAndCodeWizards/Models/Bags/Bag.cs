using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private const int defaultCapacity = 100;
        private int capacity;
        private List<Item> items;
        //= new List<Item>();

        protected Bag()
        {
            Capacity = defaultCapacity;
            this.items = new List<Item>();
        }
        protected Bag(int capacity)
            :this()
        {
            Capacity = capacity;
        }   
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        private int Load => this.items.Sum(i => i.Weight);
        public void AddItem(Item item)
        {
            if (Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException($"Bag is full!");
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException($"Bag is empty!");
            }

            var item = items.FirstOrDefault(x => x.GetType().Name == name);

            if (!items.Contains(item))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            items.Remove(item);
            return item;
        }
        //If no items exist in the bag, throw an InvalidOperationException with the message “Bag is empty!”
        //If an item with that name doesn’t exist in the bag, throw an ArgumentException with the message “No item with name { name } in bag!”
        //If both checks pass, the item is removed from the bag and returned to the caller.

    }
}

