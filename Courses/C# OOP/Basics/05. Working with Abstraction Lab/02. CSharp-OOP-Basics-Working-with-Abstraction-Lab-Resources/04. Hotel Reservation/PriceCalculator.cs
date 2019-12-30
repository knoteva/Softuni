using System;
using System.Globalization;

namespace HotelReservation
{
    public class PriceCalculator
    {
        private decimal pricePerNight;
        private int nights;
        private Seasons season;
        private Discounts discount;

        public PriceCalculator(string command)
        {
            var splitCommand = command.Split();
            pricePerNight = decimal.Parse(splitCommand[0], CultureInfo.InvariantCulture);
            nights = int.Parse(splitCommand[1]);
            season = Enum.Parse<Seasons>(splitCommand[2]);

            discount = Discounts.None;
            if (splitCommand.Length > 3)
            {
                discount = Enum.Parse<Discounts>(splitCommand[3]);
            }
        }

        public string CalculatePrice()
        {
            var tempTotal = pricePerNight * nights * (int)season;
            var discountPercentage = (100m - (int)discount) / 100m;
            var totalPrice = tempTotal * discountPercentage;
            return totalPrice.ToString("F2");
        }
    }
}
