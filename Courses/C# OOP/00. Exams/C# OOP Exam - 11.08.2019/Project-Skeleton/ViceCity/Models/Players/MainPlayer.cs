using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const int initialLifePoints = 100;
        private const string initialName = "Tommy Vercetti";
        public MainPlayer() 
            : base(initialName, initialLifePoints)
        {
        }
    }
}
