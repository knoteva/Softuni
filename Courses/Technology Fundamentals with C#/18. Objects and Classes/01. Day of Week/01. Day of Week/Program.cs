using System;
using System.Globalization;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = Console.ReadLine();
            int day = int.Parse(date.Split("-")[0]);
            int month = int.Parse(date.Split("-")[1]);
            int year = int.Parse(date.Split("-")[2]);
            Console.WriteLine(new DateTime(year, month, day).DayOfWeek);
            //Console.WriteLine(DateTime.ParseExact(date, "d-M-yyyy" , CultureInfo.InvariantCulture).DayOfWeek);
        }
    }
}
