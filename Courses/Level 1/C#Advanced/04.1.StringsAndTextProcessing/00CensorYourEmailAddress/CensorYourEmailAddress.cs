using System;

class CensorYourEmailAddress
{
    static void Main()
    {
        string email = Console.ReadLine();
        string input = Console.ReadLine();
        int length = email.IndexOf('@');
        string replace = new string('*', length);
        input = input.Replace(email, replace);
        Console.WriteLine(input);
    }
}

