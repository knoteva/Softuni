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

        protected Bag()
        {
            this.Capacity = defaultCapacity;
            this.items = new List<Item>();
        }

        protected Bag(int capacity)
            :this()
        {
            this.Capacity = capacity;
        }

        public int Capacity
        {
            get { return capacity; }
            private set { capacity = value; }
        }

        public IReadOnlyCollection<Item> Items
        {
            get { return this.items.AsReadOnly(); }
        }

        public int Load => this.Items.Sum(x => x.Weight);

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            var item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);

            return item;
        }
    }
}
