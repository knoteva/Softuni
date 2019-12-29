using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Characters.Enums;
using DungeonsAndCodeWizards.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    public class DungeonMaster
    {
        private List<Character> characters;
        private Stack<Item> items;
        private int rounds;
        public DungeonMaster()
        {
            characters = new List<Character>();
            items = new Stack<Item>();
        }


        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            if (!Enum.TryParse(faction, out Faction factionResult))
            {
                throw new ArgumentException($"Invalid faction \"{faction}\"!");
            }

            Character character;
            if (characterType == "Warrior")
            {
                character = new Warrior(name, factionResult);
            }
            else if (characterType == "Cleric")
            {
                character = new Cleric(name, factionResult);
            }
            else
            {
                throw new ArgumentException($"Invalid character type \"{ characterType }\"!");
            }
            characters.Add(character);
            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item;

            if (itemName == "ArmorRepairKit")
            {
                item = new ArmorRepairKit();
            }
            else if (itemName == "HealthPotion")
            {
                item = new HealthPotion();
            }
            else if (itemName == "PoisonPotion")
            {
                item = new PoisonPotion();
            }
            else
            {
                throw new ArgumentException($"Invalid item \"{itemName}\"!");
            }

            items.Push(item);
            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            var character = GetCharacter(characterName);
            if (items.Count == 0)
            {
                throw new InvalidOperationException($"No items left in pool!");
            }

            var item = items.Pop();

            character.Bag.AddItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = GetCharacter(characterName);

            var item = character.Bag.GetItem(itemName);

            character.UseItem(item);
            return $"{characterName} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            var giver = GetCharacter(giverName);
            var receiver = GetCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);
            return $"{giverName} used {itemName} on {receiverName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];
            var giver = GetCharacter(giverName);
            var receiver = GetCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);

            receiver.ReceiveItem(item);

            return $"{giverName} gave {receiverName} {itemName}.";
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            foreach (var ch in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                var alive = ch.IsAlive ? "Alive" : "Dead";
                sb.AppendLine($"{ch.Name} - HP: {ch.Health}/{ch.BaseHealth}, AP: {ch.Armor}/{ch.BaseArmor}, Status: {alive}");
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            var attacker = GetCharacter(attackerName);
            var receiver = GetCharacter(receiverName);
            var sb = new StringBuilder();
           
            if (attacker is Cleric)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
            ((Warrior)attacker).Attack(receiver);

            sb.Append($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! ");

            sb.AppendLine($"{ receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }
            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];
            var healer = GetCharacter(healerName);
            var healingReceiver = GetCharacter(healingReceiverName);
            var sb = new StringBuilder();

            if (healer is Warrior)
            {
                throw new ArgumentException($"{healerName} cannot heal!");
            }

           ((Cleric)healer).Heal(healingReceiver);
            return $"{healer.Name} heals {healingReceiverName} for {healer.AbilityPoints}! {healingReceiverName} has {healingReceiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            var sb = new StringBuilder();
            foreach (var ch in characters.Where(x => x.IsAlive == true))
            {
                var h = ch.Health;
                ch.Rest();
                sb.AppendLine($"{ch.Name} rests ({h} => {ch.Health})");               
            }
            if (characters.Count(x => x.IsAlive) <= 1)
            {
                rounds++;
            }
            return sb.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (rounds > 1)
            {
                return true;
            }
            return false;
        }


        private Character GetCharacter(string characterName)
        {
            var character = characters.FirstOrDefault(n => n.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}
