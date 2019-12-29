using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models.Characters;
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
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private Stack<Item> items;
        private int rounds;

        public DungeonMaster()
        {
            this.characters = new List<Character>();
            this.items = new Stack<Item>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            string faction = args[0];
            string characterType = args[1];
            string name = args[2];

            var character = this.characterFactory.CreateCharacter(faction, characterType, name);

            this.characters.Add(character);

            return $"{name} joined the party!";
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = this.itemFactory.CreateItem(itemName);

            this.items.Push(item);

            return $"{itemName} added to pool.";
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];
            Character character = GetCharacter(characterName);

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }

            var item = this.items.Pop();
            character.Bag.AddItem(item);

            return $"{characterName} picked up {item.GetType().Name}!";
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            var character = GetCharacter(characterName);
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return $"{character.Name} used {itemName}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverCharacterName = args[0];
            string reciverCharacterName = args[1];
            string itemName = args[2];

            var giver = GetCharacter(giverCharacterName);
            var receiver = GetCharacter(reciverCharacterName);

            var item = giver.Bag.GetItem(itemName);
            giver.UseItemOn(item, receiver);

            return $"{giverCharacterName} used {itemName} on {reciverCharacterName}.";
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverCharacterName = args[0];
            string reciverCharacterName = args[1];
            string itemName = args[2];

            var giver = GetCharacter(giverCharacterName);
            var receiver = GetCharacter(reciverCharacterName);

            var item = giver.Bag.GetItem(itemName);
            receiver.ReceiveItem(item);

            return $"{giverCharacterName} gave {reciverCharacterName} {itemName}.";
        }

        public string GetStats()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                //TODO fix format
                sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {(character.IsAlive ? "Alive" : "Dead")}");
            }

            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            string giverCharacterName = args[0];
            string reciverCharacterName = args[1];

            var attacker = GetCharacter(giverCharacterName);
            var receiver = GetCharacter(reciverCharacterName);

            if (attacker is Cleric)
            {
                throw new ArgumentException($"{attacker.Name} cannot attack!");
            }

            ((Warrior)attacker).Attack(receiver);

            sb.AppendLine(string.Format("{0} attacks {1} for {2} hit points! {1} has {3}/{4} HP and {5}/{6} AP left!",
                attacker.Name, receiver.Name, attacker.AbilityPoints, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                sb.AppendLine($"{receiver.Name} is dead!");
            }

            return sb.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string giverCharacterName = args[0];
            string reciverCharacterName = args[1];

            var healer = GetCharacter(giverCharacterName);
            var receiver = GetCharacter(reciverCharacterName);

            if (healer is Warrior)
            {
                throw new ArgumentException($"{giverCharacterName} cannot heal!");
            }

            ((Cleric)healer).Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
        }

        public string EndTurn(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var character in characters.Where(x => x.IsAlive))
            {
                var healthBefore = character.Health;
                character.Rest();
                sb.AppendLine($"{character.Name} rests ({healthBefore} => {character.Health})");
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
            var character = this.characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }

            return character;
        }
    }
}
