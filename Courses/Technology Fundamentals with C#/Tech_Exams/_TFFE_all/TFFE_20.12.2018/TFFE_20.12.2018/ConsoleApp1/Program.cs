using System;
using System.Linq;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentString = Console.ReadLine();
            var numbers = new StringBuilder();
            var letters = new StringBuilder();
            var symbols = new StringBuilder();
            for (int i = 0; i < currentString.Length; i++)
            {
                if ((int)currentString[i] >= 48 && (int)currentString[i] <= 57)
                {
                    numbers.Append(currentString[i]);
                }
                else if (((int)currentString[i] >= 65 && (int)currentString[i] <= 90) || ((int)currentString[i] >= 97 && (int)currentString[i] <= 122))
                {
                    letters.Append(currentString[i]);
                }
                else if (((int)currentString[i] >= 33 && (int)currentString[i] <= 47) || ((int)currentString[i] >= 58 && (int)currentString[i] <= 64) || ((int)currentString[i] >= 91 && (int)currentString[i] <= 96) || ((int)currentString[i] >= 123 && (int)currentString[i] <= 126))
                {
                    symbols.Append(currentString[i]);
                }
            }
            Console.WriteLine(numbers);
            Console.WriteLine(letters);
            Console.WriteLine(symbols);
        }
    }
}