using System;

namespace _7._TheatrePromotions
{
    class Program
    {
        static void Main(string[] args)
        {
            var day = Console.ReadLine().ToLower();
            var age = int.Parse(Console.ReadLine());
            var price = 0;
            if (day == "weekday")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    price = 12;
                }
                else
                {
                    price = 18;
                }
            }
            if (day == "weekend")
            {
                if ((age >= 0 && age <= 18) || (age > 64 && age <= 122))
                {
                    price = 15;
                }
                else
                {
                    price = 20;
                }
            }
            if (day == "holiday")
            {
                if ((age >= 0 && age <= 18))
                {
                    price = 5;
                }
                else if (age > 64 && age <= 122)
                {
                    price = 10;
                }
                else
                {
                    price = 12;
                }
            }
            if (age < 0 || age > 122)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine($"{price}$");
            }
        }
    }
}
