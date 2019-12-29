using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double baseHealthPoints = 100;
        private bool defenseMode;
        public Tank(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, baseHealthPoints)
        {
            ToggleDefenseMode();
        }

        public bool DefenseMode { get => defenseMode; private set => defenseMode = value; }

        public void ToggleDefenseMode()
        {
            if (DefenseMode == false)
            {
                DefenseMode = true;
                AttackPoints -= 40;
                DefensePoints += 30;
            }
            else
            {
                DefenseMode = false;
                AttackPoints += 40;
                DefensePoints -= 30;
            }
        }
        public override string ToString()
        {
            var onOff = DefenseMode == true ? "ON" : "OFF";
            var result = base.ToString() + Environment.NewLine + $" *Defense: {onOff}";
            return result.TrimEnd();
        }
    }
}
