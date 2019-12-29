using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double baseHealthPoints = 200;
        private bool aggressiveMode;

        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, baseHealthPoints)
        {
            ToggleAggressiveMode();
        }

        public bool AggressiveMode { get => aggressiveMode; private set => aggressiveMode = value; }

        public void ToggleAggressiveMode()
        {
            if (AggressiveMode == false)
            {
                AggressiveMode = true;
                AttackPoints += 50;
                DefensePoints -= 25;
            }
            else
            {
                AggressiveMode = false;
                AttackPoints -= 50;
                DefensePoints += 25;
            }
        }
        public override string ToString()
        {
            var onOff = AggressiveMode == true ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $" *Aggressive: {onOff}";
        }
    }
}
