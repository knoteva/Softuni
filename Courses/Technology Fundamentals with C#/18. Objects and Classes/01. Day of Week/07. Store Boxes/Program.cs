using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] information = input.Split();

                boxes.Add(new Box(information));
            }
            boxes.OrderByDescending(x => x.PriceBox).ToList().ForEach(x => Console.WriteLine(x.ToString()));
        }

        class Item
        {
            public string ItemName { get; set; }
            public decimal ItemPrice { get; set; }
        }

        class Box
        {
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int Quantity { get; set; }
            public decimal PriceBox { get; set; }
            public Box(string[] data)
            {
                SerialNumber = data[0];
                Item = new Item()
                {
                    ItemName = data[1],
                    ItemPrice = decimal.Parse(data[3])
                };
                Quantity = int.Parse(data[2]);
                PriceBox = Quantity * Item.ItemPrice;
            }
            public override string ToString()
            {
                string output = $"{SerialNumber}{Environment.NewLine}-- {Item.ItemName} - ${Item.ItemPrice:f2}: {Quantity}{Environment.NewLine}-- ${PriceBox:f2}";

                return output;
            }
        }
    }
}
