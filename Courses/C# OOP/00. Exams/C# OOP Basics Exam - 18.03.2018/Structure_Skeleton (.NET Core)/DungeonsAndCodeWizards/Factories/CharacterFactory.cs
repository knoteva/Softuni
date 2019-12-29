using DungeonsAndCodeWizards.Models.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {
        public Character CreateCharacter(string faction, string characterType, string name)
        {
            if (!Enum.TryParse(faction, out Faction factionResult))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            switch (characterType)
            {
                case "Warrior":
                    return new Warrior(name, factionResult);
                case "Cleric":
                    return new Cleric(name, factionResult);
                default:
                    throw new ArgumentException($"Invalid character type \"{characterType}\"!");
            }
        }
    }
}
