using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int initialBulletsPerBarrel = 10;
        private const int initialTotalBullets = 100;
        private const int initialPistolDamage = 1;
        public Pistol(string name) 
            : base(name, initialBulletsPerBarrel, initialTotalBullets)
        {
        }
        //TODO Implement the method
        public override int Fire()
        {
            if (BulletsPerBarrel - initialPistolDamage <= 0 && TotalBullets > 0)
            {
                BulletsPerBarrel--;
                BulletsPerBarrel = initialBulletsPerBarrel;
                TotalBullets -= initialBulletsPerBarrel;
                return initialPistolDamage;
            }

            if (CanFire == true)
            {
                BulletsPerBarrel--;
                return initialPistolDamage;
            }

            return 0;
        }
    }
}
