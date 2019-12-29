using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int initialBulletsPerBarrel = 50;
        private const int initialTotalBullets = 500;
        private const int initialRifelDamage = 5;

        public Rifle(string name) 
            : base(name, initialBulletsPerBarrel, initialTotalBullets)
        {
        }

        //TODO Implement the method
        public override int Fire()
        {
            if (BulletsPerBarrel - initialRifelDamage <= 0 && TotalBullets > 0)
            {
                BulletsPerBarrel -= initialRifelDamage;
                BulletsPerBarrel = initialBulletsPerBarrel;
                TotalBullets -= initialBulletsPerBarrel;
                return initialRifelDamage;
            }

            if (CanFire == true)
            {
                BulletsPerBarrel -= initialRifelDamage;
                return initialRifelDamage;
            }

            return 0;
        }
    }
}
