using System;

namespace ConvertToDouble
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                var number = ReadDouble();
                Console.WriteLine(number);
            }
            catch (Exception ex)
              when(ex is FormatException || ex is OverflowException)
            {
            }
        }

        private static double ReadDouble()
        {
            try
            {
                string input = Console.ReadLine();
                var number = Convert.ToDouble(input);
                return number;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
