using PlayersAndMonsters.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController managerController;

        public Engine()
        {
            managerController = new ManagerController();
        }


        public void Run()
        {
            //•	AddPlayer { player type} { player username}
            //•	AddCard { card type} { card name}
            //•	AddPlayerCard { username} { card name}
            //•	Fight { attack user} { enemy user}
            //•	Report
            var inputArgs = string.Empty;
            while ((inputArgs = Console.ReadLine()) != "Exit")
            {
                try
                {
                    var input = inputArgs.Split(" ");
                    var command = input[0];

                    if (command == "AddPlayer")
                    {
                        var palyerType = input[1];
                        var playerUsername = input[2];
                        Console.WriteLine(managerController.AddPlayer(palyerType, playerUsername));
                    }
                    else if (command == "AddCard")
                    {
                        var cardType = input[1];
                        var cardUsername = input[2];
                        Console.WriteLine(managerController.AddCard(cardType, cardUsername));
                    }
                    else if (command == "AddPlayerCard")
                    {
                        var username = input[1];
                        var cardName = input[2];
                        Console.WriteLine(managerController.AddPlayerCard(username, cardName));
                    }
                    else if (command == "Fight")
                    {
                        var attackUser = input[1];
                        var enemyUser = input[2];
                        Console.WriteLine(managerController.Fight(attackUser, enemyUser));
                    }
                    else if (command == "Report")
                    {
                        Console.WriteLine(managerController.Report());
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
