using System;
using System.Linq;

namespace _02._Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
                .Split("&")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Finished!")
            {
                string command = input.Split(" ")[0];
                string name = input.Split(" ")[1];

                if (command == "Bad")
                {
                    if (!list.Contains(name))
                    {
                        list.Insert(0, name);

                    }
                }
                else if (command == "Good")
                {
                    if (list.Contains(name))
                    {
                        list.Remove(name);
                    }
                }
                else if (command == "Rename")
                {
                    string oldName = input.Split(" ")[1];
                    string newName = input.Split(" ")[2];

                    if (list.Contains(oldName) && !list.Contains(newName))
                    {
                        int index = list.IndexOf(oldName);
                        list.Remove(oldName);
                        list.Insert(index, newName);
                    }
                }
                else if (command == "Rearrange")
                {
                    if (list.Contains(name))
                    {
                        list.Remove(name);
                        list.Add(name);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", list));
        }
    }
}
