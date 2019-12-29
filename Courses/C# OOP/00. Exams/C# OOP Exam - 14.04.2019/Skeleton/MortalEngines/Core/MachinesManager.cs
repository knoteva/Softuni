namespace MortalEngines.Core
{
    using Contracts;
    using MortalEngines.Entities;
    using MortalEngines.Entities.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MachinesManager : IMachinesManager
    {
        private IList<IPilot> pilots;
        private IList<IMachine> machines;


        public MachinesManager()
        {
            pilots = new List<IPilot>();
            machines = new List<IMachine>();
        }
        // 1. Има точки // OK
        public string HirePilot(string name)
        {
            if (pilots.Any(p => p.Name == name))
            {
                return $"Pilot {name} is hired already";
            }
            var pilot = new Pilot(name);
            pilots.Add(pilot);
            return $"Pilot {name} hired";
        }
        // 2. Има точки
        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(t => t.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }
            IMachine tank = new Tank(name, attackPoints, defensePoints);
            machines.Add(tank);
            return $"Tank {tank.Name} manufactured - attack: {tank.AttackPoints:F2}; defense: {tank.DefensePoints:F2}";
        }
        // 3. Има точки
        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (machines.Any(f => f.Name == name))
            {
                return $"Machine {name} is manufactured already";
            }
            IMachine fighter = new Fighter(name, attackPoints, defensePoints);
            machines.Add(fighter);
            return $"Fighter {fighter.Name} manufactured - attack: {fighter.AttackPoints:F2}; defense: {fighter.DefensePoints:F2}; aggressive: ON";
        }
        // 4. Няма точки
        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            var pilot = pilots.FirstOrDefault(p => p.Name == selectedPilotName);           
            if (pilot == null)
            {
                return $"Error:Pilot {selectedPilotName} could not be found";
            }
            var machine = machines.FirstOrDefault(m => m.Name == selectedMachineName);
            if (machine == null)
            {
                return $"Error:Machine {selectedMachineName} could not be found";
            }
            if (machine.Pilot != null)
            {
                return $"Error:Machine {selectedMachineName} is already occupied";
            }
            pilot.AddMachine(machine);
            machine.Pilot = pilot;         
            return $"Pilot {selectedPilotName} engaged machine {selectedMachineName}";
        }
        // 5. Няма точки
        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            var attackingMachine = machines.FirstOrDefault(am => am.Name == attackingMachineName);
            if (attackingMachine == null)
            {
                return $"Machine {attackingMachineName} could not be found";
            }
            var defendingMachine = machines.FirstOrDefault(dm => dm.Name == defendingMachineName);
            if (defendingMachine == null)
            {
                return $"Machine {defendingMachineName} could not be found";
            }
            if (attackingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {attackingMachineName} cannot attack or be attacked";
            }
            if (defendingMachine.HealthPoints <= 0)
            {
                return $"Dead machine {defendingMachineName} cannot attack or be attacked";
            }
            attackingMachine.Attack(defendingMachine);
            return $"Machine {defendingMachineName} was attacked by machine {attackingMachineName} - current health: {defendingMachine.HealthPoints:F2}";
        }
        // 6. Няма точки
        public string PilotReport(string pilotReporting)
        {
            var pilot = pilots.FirstOrDefault(p => p.Name == pilotReporting);
            if (pilot == null)
            {
                return $"Pilot {pilotReporting} could not be found";
            }
            return pilot.Report();
        }
        // 7. Няма точки
        public string MachineReport(string machineName)
        {
            var machine = machines.FirstOrDefault(p => p.Name == machineName);
            if (machine == null)
            {
                return $"Machine {machineName} could not be found";
            }
            return machine.ToString();
        }
        // 8. Има точки
        public string ToggleFighterAggressiveMode(string fighterName)
        {
            var machine = machines.FirstOrDefault(f => f.Name == fighterName);
            if (machine == null)
            {
                return $"Machine {fighterName} could not be found";
            }
            IFighter fighter = (IFighter)machine;
            fighter.ToggleAggressiveMode();
            return $"Fighter {fighter.Name} toggled aggressive mode";
        }
        // 9. Има точки
        public string ToggleTankDefenseMode(string tankName)
        {
            var machine = machines.FirstOrDefault(t => t.Name == tankName);
            if (machine == null)
            {
                return $"Machine {tankName} could not be found";
            }
            ITank tank = (ITank)machine;
            tank.ToggleDefenseMode();
            return $"Tank {tank.Name} toggled defense mode";
        }
    }
}