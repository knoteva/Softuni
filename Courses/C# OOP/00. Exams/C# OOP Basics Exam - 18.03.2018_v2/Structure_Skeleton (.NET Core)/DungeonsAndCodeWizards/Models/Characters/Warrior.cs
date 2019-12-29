using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Contracts;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public class Warrior : Character, IAttackable
    {
        //The Warrior class always has 100 Base Health, 50 Base Armor, 40 Ability Points, and a Satchel as a bag.
        private const double baseHealth = 100;
        private const double baseArmor = 50;
        private const double baseAbilityPoints = 40;

        public Warrior(string name, Faction faction) 
            : base(name, baseHealth, baseArmor, baseAbilityPoints, new Satchel(), faction)
        {
        }

        public void Attack(Character character)
        {
            EnsureIsBothAlive(character);
            if (this == character)
            {
                throw new InvalidOperationException($"Cannot attack self!");
            }
            if (this.Faction == character.Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {Faction} faction!");
            }
            character.TakeDamage(this.AbilityPoints);
        }
    }
}
//If the character they are trying to attack is the same character, throw an InvalidOperationException with the message “Cannot attack self!”
//If the character the character is attacking is from the same faction, throw an ArgumentException with the message “Friendly fire! Both characters are from {faction} faction!”
//If all of those checks pass, the receiving character takes damage with hit points equal to the attacking character’s ability points.
