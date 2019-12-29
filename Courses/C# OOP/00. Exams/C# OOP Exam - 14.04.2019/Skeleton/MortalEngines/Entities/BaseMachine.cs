using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;
        private IList<string> targets;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            Name = name;
            //pilot = new Pilot();
            AttackPoints = attackPoints;
            DefensePoints = defensePoints;
            HealthPoints = healthPoints;
            targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be null or empty.");
                }
                name = value;
            }
        }
        public IPilot Pilot
        {
            get => pilot;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                pilot = value;
            }
        }
        public double AttackPoints { get => attackPoints; protected set => attackPoints = value; }
        public double DefensePoints { get => defensePoints; protected set => defensePoints = value; }
        public double HealthPoints { get => healthPoints; set => healthPoints = value; }
        public IList<string> Targets { get => targets; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null");
            }
            double attackPoints = AttackPoints - target.DefensePoints;
            target.HealthPoints -= attackPoints;
            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }
            targets.Add(target.Name);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            string targetsToPrint;
            if (targets.Count == 0)
            {
                targetsToPrint = "None";
            }
            else
            {
                targetsToPrint = string.Join(",", targets);
            }
            sb.AppendLine($"- {Name}")
                .AppendLine($" *Type: {GetType().Name}")
                .AppendLine($" *Health: {HealthPoints:F2}")
                .AppendLine($" *Attack: {AttackPoints:F2}")
                .AppendLine($" *Defense: {DefensePoints:F2}")
                .AppendLine(" *Targets: " + targetsToPrint);
            return sb.ToString().TrimEnd();
        }
    }
}
