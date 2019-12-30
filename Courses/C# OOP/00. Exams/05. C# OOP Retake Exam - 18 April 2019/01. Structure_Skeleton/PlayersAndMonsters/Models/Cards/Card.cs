using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private string name;
        private int damagePoints;
        private int healthPoints;

        protected Card(string name, int damagePoints, int healthPoints)
        {
            Name = name;
            DamagePoints = damagePoints;
            HealthPoints = healthPoints;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"Card's name cannot be null or an empty string.");
                }
                name = value;
            }
        }

        public int DamagePoints
        {
            get => damagePoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Card's damage points cannot be less than zero.");
                }
                damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => healthPoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Card's HP cannot be less than zero.");
                }
                healthPoints = value;
            }
        }
    }
}


//•	Name – string (If the card name is null or empty throw an ArgumentException with message "Card's name cannot be null or an empty string.") 
//•	DamagePoints – int (If the damage points are below zero, throw an ArgumentException with message "Card's damage points cannot be less than zero.") 
//•	HealthPoints - int (If the health points are below zero, throw an ArgumentException with message "Card's HP cannot be less than zero.") 
