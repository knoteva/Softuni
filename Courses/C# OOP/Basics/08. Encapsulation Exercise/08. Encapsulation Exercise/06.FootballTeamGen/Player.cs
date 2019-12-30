using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGen
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private double skillLevel;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
            skillLevel = (endurance + sprint + dribble + passing + shooting) / 5.0;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Endurance
        {
            get => endurance;
            set
            {

                ValidateStat(value, nameof(this.Endurance));
                endurance = value;
            }
        }

        public int Sprint
        {
            get => sprint;
            set
            {
                ValidateStat(value, nameof(this.Sprint));
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            set
            {
                ValidateStat(value, nameof(this.Dribble));
                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            set
            {
                ValidateStat(value, nameof(this.Passing));
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            set
            {
                ValidateStat(value, nameof(this.Shooting));
                shooting = value;
            }
        }
        public double SkillLevel
        {
            get
            {
                return this.skillLevel;
            }
        }

        private void ValidateStat(double statValue, string statName)
        {
            if (statValue < 0 || statValue > 100)
            {
                throw new ArgumentException($"{statName} should be between 0 and 100.");
            }
        }
    }
}
