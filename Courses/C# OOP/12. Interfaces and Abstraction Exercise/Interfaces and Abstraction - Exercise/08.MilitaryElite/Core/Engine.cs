using _08.MilitaryElite.Contacts;
using _08.MilitaryElite.Enums;
using _08.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08.MilitaryElite.Core
{
    public class Engine
    {
        private List<ISoldier> soldiers;
        private ISoldier soldier;
        public Engine()
        {
            soldiers = new List<ISoldier>();
        }

        public ISoldier Soldier { get => soldier; set => soldier = value; }

        public void Run()
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var inputArgs = input.Split();
                //Private <id> <firstName> <lastName> <salary>
                //LieutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>
                //Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>
                //Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>
                //Spy <id> <firstName> <lastName> <codeNumber>
                string type = inputArgs[0];
                var id = int.Parse(inputArgs[1]);
                var firstName = inputArgs[2];
                var lastName = inputArgs[3];

                if (type == "Private")
                {
                    var salary = decimal.Parse(inputArgs[4]);
                    soldier = GetPrivateSoldier(id, firstName, lastName, salary);
                  
                }
                else if (type == "LieutenantGeneral")
                {
                    var salary = decimal.Parse(inputArgs[4]);
                    soldier = GetLieutenantGeneral(id, firstName, lastName, salary, inputArgs);
                }
                else if (type == "Engineer")
                {
                    var salary = decimal.Parse(inputArgs[4]);
                    soldier = GetEngineer(id, firstName, lastName, salary, inputArgs);
                }
                else if (type == "Commando")
                {
                    var salary = decimal.Parse(inputArgs[4]);
                    soldier = GetCommando(id, firstName, lastName, salary, inputArgs);
                }
                else if (type == "Spy")
                {
                    var codeNumber = int.Parse(inputArgs[4]);
                    soldier = GetSpy(id, firstName, lastName, codeNumber);
                }
                if (soldier != null)
                {
                    soldiers.Add(soldier);
                }             
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
        {
            ISpy spy = new Spy(id, firstName, lastName, codeNumber);
            return spy;
        }

        private ISoldier GetCommando(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
        {
            var corspAsString = inputArgs[5];
            if (!Enum.TryParse(corspAsString, out Corps corps))
            {
                return null;
            }

            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < inputArgs.Length; i += 2)
            {
                string missionCodeName = inputArgs[i];
                string stateString = inputArgs[i + 1];
                if (!Enum.TryParse(stateString, out State state))
                {
                    continue;
                }

                IMission mission = new Mission(missionCodeName, state);
                commando.Missions.Add(mission);
            }
            return commando;
        }

        private ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
        {
            var corspAsString = inputArgs[5];
            if (!Enum.TryParse(corspAsString, out Corps corps))
            {
                return null;
            }

            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);
            
            for (int i = 6; i < inputArgs.Length; i += 2)
            {
                string partName = inputArgs[i];
                int repairHours = int.Parse(inputArgs[i + 1]);
                IRepair repair = new Repair(partName, repairHours);
                engineer.Repairs.Add(repair);
            }
            return engineer;
        }

        private ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
        {
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);
            for (int i = 5; i < inputArgs.Length; i++)
            {
                int privateId = int.Parse(inputArgs[i]);
                IPrivate privateSoldier = (IPrivate)soldiers.FirstOrDefault(x => x.Id == privateId);
                lieutenantGeneral.Privates.Add(privateSoldier);
            }
            return lieutenantGeneral;
        }

        private ISoldier GetPrivateSoldier(int id, string firstName, string lastName, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, firstName, lastName, salary);
            return privateSoldier;
        }
    }
}
