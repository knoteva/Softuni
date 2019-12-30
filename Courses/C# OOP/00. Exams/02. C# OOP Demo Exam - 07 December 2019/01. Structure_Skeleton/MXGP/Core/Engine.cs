using MXGP.Core.Contracts;
using MXGP.IO;
using MXGP.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IChampionshipController controller;


        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
            controller = new ChampionshipController();
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split();
                if (input[0] == "End")
                {
                    Environment.Exit(0);
                }
                try
                {
                    if (input[0] == "CreateRider")
                    {
                        writer.WriteLine(controller.CreateRider(input[1]));
                    }
                    else if (input[0] == "CreateMotorcycle")
                    {
                        writer.WriteLine(controller.CreateMotorcycle(input[1], input[2], int.Parse(input[3])));
                    }
                    else if (input[0] == "AddMotorcycleToRider")
                    {
                        writer.WriteLine(controller.AddMotorcycleToRider(input[1], input[2]));
                    }
                    else if (input[0] == "AddRiderToRace")
                    {
                        writer.WriteLine(controller.AddRiderToRace(input[1], input[2]));
                    }
                    else if (input[0] == "CreateRace")
                    {
                        writer.WriteLine(controller.CreateRace(input[1], int.Parse(input[2])));
                    }
                    else if (input[0] == "StartRace")
                    {
                        writer.WriteLine(controller.StartRace(input[1]));
                    }
                    //•	CreateMotorcycle { motorcycle type} { model} { horsepower}
                    //•	AddMotorcycleToRider { rider name} { motorcycle name}
                    //•	AddRiderToRace { race name}  { rider name}
                    //•	CreateRace { name} { laps}
                    //•	StartRace { race name}


                }
                catch (ArgumentException ax)
                {
                    writer.WriteLine(ax.Message);
                }
                catch (InvalidOperationException ix)
                {
                    writer.WriteLine(ix.Message);
                }
                catch (NullReferenceException nx)
                {
                    writer.WriteLine(nx.Message);
                }
           
            }
            
        }
    }
}
