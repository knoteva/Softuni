using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel
{
    public class PriceCalculator
    {
        public PriceCalculator(decimal pricePerDay, int numberOfDays, Season season, DiscountType discountType)
        {
            PricePerDay = pricePerDay;
            NumberOfDays = numberOfDays;
            Season = season;
            DiscountType = discountType;
        }

        public decimal PricePerDay { get; set; }

        public int NumberOfDays { get; set; }

        public Season Season { get; set; }

        public DiscountType DiscountType { get; set; }

        public decimal CalculatePrice()
        {
            decimal price = this.NumberOfDays * PricePerDay * (decimal)Season;
            price -= price * ((decimal)DiscountType / 100);
            return price;
        }
    }
}
