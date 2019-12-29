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
        private bool isAlive;
        private IRepository<IGun> gunRepository;

        protected Player(string name, int lifePoints)
        {
            Name = name;
            LifePoints = lifePoints;
            GunRepository = new GunRepository();
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
        public bool IsAlive => LifePoints == 0;

        //TODO
        //  public IRepository<IGun> GunRepository { get; private set; }
        public IRepository<IGun> GunRepository { get => gunRepository; private set => gunRepository = value; }

        public void TakeLifePoints(int points)
        {
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
