using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class Engine
    {
        private DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrEmpty(input))
            {
                string[] inputArgs = input.Split();

                string command = inputArgs[0];
                string[] args = inputArgs.Skip(1).ToArray();

                string result = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            result = dungeonMaster.JoinParty(args);
                            break;
                        case "AddItemToPool":
                            result = dungeonMaster.AddItemToPool(args);
                            break;
                        case "PickUpItem":
                            result = dungeonMaster.PickUpItem(args);
                            break;
                        case "UseItem":
                            result = dungeonMaster.UseItem(args);
                            break;
                        case "UseItemOn":
                            result = dungeonMaster.UseItemOn(args);
                            break;
                        case "GiveCharacterItem":
                            result = dungeonMaster.GiveCharacterItem(args);
                            break;
                        case "GetStats":
                            result = dungeonMaster.GetStats();
                            break;
                        case "Attack":
                            result = dungeonMaster.Attack(args);
                            break;
                        case "Heal":
                            result = dungeonMaster.Heal(args);
                            break;
                        case "EndTurn":
                            result = dungeonMaster.EndTurn(args);
                            break;
                        case "IsGameOver":
                            dungeonMaster.IsGameOver();
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Invalid Operation: " + ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Parameter Error: " + ex.Message);      
                }
                
                if (dungeonMaster.IsGameOver())
                {
                    break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Final stats:");
            Console.WriteLine(dungeonMaster.GetStats());
        }
    }
}
