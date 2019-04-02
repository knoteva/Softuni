using System;
using System.Linq;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string correctPass = new string(userName.ToCharArray().Reverse().ToArray());
            int count = 0;
            while (true)
            {

                string inputPass = Console.ReadLine();
                if (inputPass == correctPass)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                else if (inputPass != correctPass)
                {
                    count++;
                    if (count < 4)
                    {
                        Console.WriteLine("Incorrect password. Try again.");
                    }
                    else
                    {
                        Console.WriteLine($"User {userName} blocked!");
                        break;
                    }                   
                }             
            }
        }
    }
}
