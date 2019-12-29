using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class PoisonPotion :Item
    {
        private const int initalWeight = 5;

        public PoisonPotion() 
            : base(initalWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            EnsureIAlive(character);
            character.Health -= 20;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
