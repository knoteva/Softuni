using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IManagerController managerController;
        private IReader reader;
        private IWriter writer;

    
        public Engine(IManagerController managerController, IReader reader, IWriter writer)
        {
            this.managerController = managerController;
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string inputArgs;
            string output = string.Empty;
            while ((inputArgs = Console.ReadLine()) != "Exit")
            {
                try
                {
                    var input = inputArgs.Split(" ");
                    string command = input[0];

                    if (command == "AddPlayer")
                    {
                        var playerType = input[1];
                        var playerUsername = input[2];
                        output = managerController.AddPlayer(playerType, playerUsername);
                    }
                    else if (command == "AddCard")
                    {
                        var cardType = input[1];
                        var cardName = input[2];
                        output = managerController.AddCard(cardType, cardName);

                    }
                    else if (command == "AddPlayerCard")
                    {
                        var username = input[1];
                        var cardName = input[2];
                        output = managerController.AddPlayerCard(username, cardName);
                    }
                    else if (command == "Fight")
                    {
                        var attackUser = input[1];
                        var enemyUser = input[2];
                        output = managerController.Fight(attackUser, enemyUser);
                    }
                    else if (command == "Report")
                    {
                        output = managerController.Report();
                    }
                    if (output != string.Empty)
                    {
                        this.writer.WriteLine(output);
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

