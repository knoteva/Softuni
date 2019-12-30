﻿using System;
using System.Linq;

namespace Hotel
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var items = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            decimal pricePerDay = decimal.Parse(items[0]);
            int numberOfDays = int.Parse(items[1]);
            Season season = (Season)Enum.Parse(typeof(Season), items[2]);
            DiscountType discountType = DiscountType.None;

            if (items.Count == 4)
            {
                discountType = (DiscountType)Enum.Parse(typeof(DiscountType), items[3]);
            }

            PriceCalculator calculator = new PriceCalculator(pricePerDay, numberOfDays, season, discountType);
            Console.WriteLine($"{calculator.CalculatePrice():F2}");
        }
    }
}
