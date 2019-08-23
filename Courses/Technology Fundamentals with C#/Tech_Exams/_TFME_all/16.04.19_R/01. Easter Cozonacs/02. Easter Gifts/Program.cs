using System;
using System.Linq;

namespace _02._Easter_Gifts
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split(" ")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
            string commandLine = "";

            while ((commandLine = Console.ReadLine()) != "No Money")
            {
                string command = commandLine.Split(" ")[0];
                string gift = commandLine.Split(" ")[1];

                if (command == "OutOfStock")
                {
                    list = list.Select(x => x.Replace(gift, "None")).ToList();

                }
                else if (command == "Required")
                {
                    int index = int.Parse(commandLine.Split(" ")[2]);
                    if (list.Count > index && index >= 0)
                    {
                        list.RemoveAt(index);
                        list.Insert(index, gift);
                    }

                }
                else if (command == "JustInCase")
                {
                    list.RemoveAt(list.Count - 1);
                    list.Add(gift);
                }
            }
            Console.WriteLine(string.Join(" ", list.Where(x => x != "None")));
        }
    }
}
