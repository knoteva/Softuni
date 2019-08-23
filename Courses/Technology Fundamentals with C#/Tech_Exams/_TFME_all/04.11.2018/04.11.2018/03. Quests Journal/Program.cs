using System;
using System.Linq;

namespace _03._Quests_Journal
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine()
               .Split(", ")
               .Where(s => !string.IsNullOrWhiteSpace(s))
               .ToList();
            string input;

            while ((input = Console.ReadLine()) != "Retire!")
            {
                string command = input.Split(" - ")[0];
                string quest = input.Split(" - ")[1];

                if (command == "Start")
                {
                    if (!list.Contains(quest))
                    {
                        list.Add(quest);
                    }
                }
                else if (command == "Complete")
                {
                    if (list.Contains(quest))
                    {
                        list.Remove(quest);
                    }
                }
                else if (command == "Side Quest")
                {                   
                    string sideQuest = quest.Split(":")[1];
                    quest = quest.Split(":")[0];
                    if (list.Contains(quest) && !list.Contains(sideQuest))
                    {
                        int index = list.IndexOf(quest);
                        list.Insert(index + 1, sideQuest);
                    }
                }
                else if (command == "Renew")
                {
                    if (list.Contains(quest))
                    {
                        list.Remove(quest);
                        list.Add(quest);
                    }
                }
            }
                Console.WriteLine(string.Join(", ", list));
        }
    }
}
