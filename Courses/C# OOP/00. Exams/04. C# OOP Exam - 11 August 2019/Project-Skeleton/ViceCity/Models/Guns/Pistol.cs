using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun, IGun
    {
        //Has 10 bullets per barrel and 100 total bullets.
        private const int initialBulletsPerBarrel = 10;
        private const int initialTotalBullets = 100;
        private const int initialPistolDamage = 1;

        public Pistol(string name) 
            : base(name, initialBulletsPerBarrel, initialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (BulletsPerBarrel - initialPistolDamage <= 0 && TotalBullets > 0)
            {
                BulletsPerBarrel -= initialPistolDamage;
                BulletsPerBarrel = initialBulletsPerBarrel;
                TotalBullets -= initialBulletsPerBarrel;
                return initialPistolDamage;
            }

            if (CanFire == true)
            {
                BulletsPerBarrel -= initialPistolDamage;
                return initialPistolDamage;
            }

            return 0;
        }
    }
}
