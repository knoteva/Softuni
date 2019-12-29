using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models.Items
{
    public class ArmorRepairKit : Item
    {
        private const int initalWeight = 10;

        public ArmorRepairKit()
            : base(initalWeight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            EnsureIAlive(character);
            character.Armor = character.BaseArmor;
        }
    }
}
