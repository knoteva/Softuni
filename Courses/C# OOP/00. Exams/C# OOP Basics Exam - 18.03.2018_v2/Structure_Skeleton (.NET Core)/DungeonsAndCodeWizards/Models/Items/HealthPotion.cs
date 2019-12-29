using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class HealthPotion : Item
    {
        private const int initalWeight = 5;

        public HealthPotion()
            : base(initalWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            EnsureIAlive(character);
            character.Health += 20;
        }
    }
}
