using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        public Engine(IReader reader, IWriter writer, IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        public void Run()
        {
            while (true)
            {
                var line = reader.ReadLine();

                if (line == "Exit")
                {
                    break;
                }
                try
                {
                    var commandParts = line.Split(" ");
                    var command = commandParts[0];
                    var output = string.Empty;
                    switch (command)
                    {
                        case "AddPlayer":
                            string typeUser = commandParts[1];
                            string username = commandParts[2];
                            output = managerController.AddPlayer(typeUser, username);
                            break;
                        case "AddCard":
                            string typeCard = commandParts[1];
                            string nameCard = commandParts[2];
                            output = managerController.AddCard(typeCard, nameCard);
                            break;
                        case "AddPlayerCard":
                            string type = commandParts[1];
                            string user = commandParts[2];
                            output = managerController.AddPlayerCard(type, user);
                            break;
                        case "Fight":
                            string attackUser = commandParts[1];
                            string enemyUser = commandParts[2];
                            output = managerController.Fight(attackUser, enemyUser);
                            break;
                        case "Report":
                            output = managerController.Report();
                            break;
                        default:
                            break;
                    }
                    writer.WriteLine(output);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                

                
            }
        }
    }
}
