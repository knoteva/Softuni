namespace HotelReservation
{
    using System;
    public class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var priceCalculator = new PriceCalculator(command);
            var totalPrice = priceCalculator.CalculatePrice();
            Console.WriteLine(totalPrice);
        }
    }
}
