using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        protected const double defaultRestHealMultiplier = 0.2;

        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double armor;
        private double abilityPoints;

        private Bag bag;
        private Faction faction;
        private bool isAlive;
        public double restHealMultiplier;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            IsAlive = true;
            RestHealMultiplier = defaultRestHealMultiplier;
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            Faction = faction;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public double BaseHealth
        {
            get { return baseHealth; }
            private set { baseHealth = value; }
        }

        public double Health
        {
            get { return health; }
            set
            {
                if (value > BaseHealth)
                {
                    health = BaseHealth;
                }
                else if (value <= 0)
                {
                    health = 0;
                    IsAlive = false;
                }
                else
                {
                    health = value;
                }

            }
        }

        public double BaseArmor
        {
            get { return baseArmor; }
            private set { baseArmor = value; }
        }

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value > BaseArmor)
                {
                    armor = BaseArmor;
                }
                else if (value <= 0)
                {
                    armor = 0;
                }
                else
                {
                    armor = value;
                }

            }
        }

        public double AbilityPoints
        {
            get { return abilityPoints; }
            private set { abilityPoints = value; }
        }

        public Bag Bag
        {
            get { return bag; }
            private set { bag = value; }
        }

        public Faction Faction
        {
            get { return faction; }
            private set { faction = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

        public virtual double RestHealMultiplier
        {
            get { return restHealMultiplier; }
            private set { restHealMultiplier = value; }
        }

        protected void EnsureIsAlive()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException($"Must be alive to perform this action!");
            }
        }

        protected void EnsureIsBothAlive(Character character)
        {
            if (!this.IsAlive || !character.IsAlive)
            {
                throw new InvalidOperationException($"Must be alive to perform this action!");
            }
        }

        public void TakeDamage(double hitPoints)
        {
            EnsureIsAlive();
            if (Armor - hitPoints >= 0)
            {
                Armor -= hitPoints;
            }
            else
            {
                var reminder = hitPoints - Armor;
                Armor = 0;
                Health -= reminder;
            }

        }

        public void Rest()
        {
            EnsureIsAlive();
   
            Health += BaseHealth * RestHealMultiplier;
        }

        public void UseItem(Item item)
        {
            EnsureIsAlive();
            item.AffectCharacter(this);
        }

        public void UseItemOn(Item item, Character character)
        {
            EnsureIsBothAlive(character);
            item.AffectCharacter(character);
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            EnsureIsBothAlive(character);
            character.ReceiveItem(item);
        }

        public void ReceiveItem(Item item)
        {
            EnsureIsAlive();
            Bag.AddItem(item);
        }
    }
}

