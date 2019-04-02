using System;

namespace _05._Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            string result = "";
            for (int i = 0; i < lines; i++)
            {
                char ch = char.Parse(Console.ReadLine());
                result += Convert.ToChar(ch + key);
            }
            Console.WriteLine(result);
        }
    }
}
