using System;
using System.Linq;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            if (PasswordLength(pass) && PasswordLetDig(pass) && PasswordAtLeast(pass))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!PasswordLength(pass))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!PasswordLetDig(pass))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!PasswordAtLeast(pass))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }
        private static bool PasswordLength(string pass)
        {
            bool valid = true;
            if (pass.Length < 6 || pass.Length > 10)
            {
                valid = false;
            }
            return valid;
        }

        private static bool PasswordLetDig(string pass)
        {
            bool valid = pass.All(Char.IsLetterOrDigit);

            return valid;
        }

        private static bool PasswordAtLeast(string pass)
        {
            bool valid = true;
            int count = pass.Count(x => Char.IsDigit(x));
            if (count < 2)
            {
                valid = false;
            }
            return valid;
        }
    }
}
