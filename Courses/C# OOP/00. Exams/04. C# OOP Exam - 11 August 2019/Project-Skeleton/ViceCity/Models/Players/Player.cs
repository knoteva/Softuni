using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string name;
        private int lifePoints;
        private IRepository<IGun> gunRepository;

        protected Player(string name, int lifePoints)
        {
            Name = name;
            LifePoints = lifePoints;
            this.gunRepository = new GunRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or a whitespace!");
                }
                name = value;
            }
        }             

        public int LifePoints
        {
            get => lifePoints;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player life points cannot be below zero!");
                }
                lifePoints = value;
            }
        }

        public IRepository<IGun> GunRepository => this.gunRepository; 

        public bool IsAlive => LifePoints > 0;

        public void TakeLifePoints(int points)
        {
            //TODO Sgould we throw error if points < 0?
            if (LifePoints - points < 0)
            {
                LifePoints = 0;
            }
            else
            {
                LifePoints -= points;
            }
        }
    }
}
