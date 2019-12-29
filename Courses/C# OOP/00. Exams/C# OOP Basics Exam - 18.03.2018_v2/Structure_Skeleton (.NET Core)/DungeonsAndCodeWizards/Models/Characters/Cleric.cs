using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Contracts;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Cleric : Character, IHealable
    {
        private const double baseHealth = 50;
        private const double baseArmor = 25;
        private const double baseAbilityPoints = 40;


        public Cleric(string name, Faction faction) 
            : base(name, baseHealth, baseArmor, baseAbilityPoints, new Backpack(), faction)
        {
        }
        public override double RestHealMultiplier => 0.5;
        public void Heal(Character character)
        {
            EnsureIsBothAlive(character);
            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException($"Cannot heal enemy character!");
            }
            character.Health += this.AbilityPoints;
        }
    }
}

//If the character the character is healing is from a different faction, throw an InvalidOperationException with the message “Cannot heal enemy character!”
//If both of those checks pass, the receiving character’s health increases by the healer’s ability points
