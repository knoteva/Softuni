using MortalEngines.Core;
using System;

namespace MortalEngines
{
    public class StartUp
    {
        public static void Main()
        {
            var mm = new MachinesManager();

            var inputArgs = "";
            while ((inputArgs = Console.ReadLine()) != "Quit")
            {
                var input = inputArgs.Split(" ");
                var command = input[0];
                var name = input[1];
                //• HirePilot { name}
                //•	PilotReport { name}
                //•	ManufactureTank { name} { attack} { defense
                //•	ManufactureFighter { name} { attack} { defense}
                //•	MachineReport { name}
                //•	AggressiveMode { name}
                //•	DefenseMode { name}
                //•	Engage { pilot name} { machine name}
                //•	Attack { attacking machine name} { defending machine name}

                if (command == "HirePilot")
                {
                    Console.WriteLine(mm.HirePilot(name));
                }
                else if (command == "PilotReport")
                {
                    Console.WriteLine(mm.PilotReport(name));
                }
                else if (command == "ManufactureTank")
                {
                    var attack = double.Parse(input[2]);
                    var defense = double.Parse(input[3]);
                    Console.WriteLine(mm.ManufactureTank(name, attack, defense));
                }
                else if (command == "ManufactureFighter")
                {
                    var attack = double.Parse(input[2]);
                    var defense = double.Parse(input[3]);
                    Console.WriteLine(mm.ManufactureFighter(name, attack, defense));
                }
                else if (command == "MachineReport")
                {
                    Console.WriteLine(mm.MachineReport(name));
                }
                else if (command == "AggressiveMode")
                {
                    Console.WriteLine(mm.ToggleFighterAggressiveMode(name));
                }
                else if (command == "DefenseMode")
                {
                    Console.WriteLine(mm.ToggleTankDefenseMode(name));
                }
                else if (command == "Engage")
                {
                    var machineName = input[2];
                    Console.WriteLine(mm.EngageMachine(name, machineName));
                }
                else if (command == "Attack")
                {
                    var machineName = input[2];
                    Console.WriteLine(mm.AttackMachines(name, machineName));
                }
            }
        }
    }
}