namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;

        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;

        private IBattleField battleField;

        public ManagerController(IPlayerRepository playerRepository, ICardRepository cardRepository, IPlayerFactory playerFactory, ICardFactory cardFactory, IBattleField battleField)
        {
            this.playerRepository = playerRepository;
            this.cardRepository = cardRepository;
            this.playerFactory = playerFactory;
            this.cardFactory = cardFactory;
            this.battleField = battleField;
        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);
            playerRepository.Add(player);
            return $"Successfully added player of type {type} with username: {username}";
        }

        public string AddCard(string type, string name)
        {
            var card = cardFactory.CreateCard(type, name);
            cardRepository.Add(card);
            return $"Successfully added card of type {type}Card with name: {name}";
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var user = this.playerRepository.Find(username);
            var card = cardRepository.Find(cardName);
            user.CardRepository.Add(card);

            return $"Successfully added card: {cardName} to user: {username}";
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = playerRepository.Find(attackUser);
            var enemy = playerRepository.Find(enemyUser);
            battleField.Fight(attacker, enemy);
            return $"Attack user health {attacker.Health} - Enemy user health {enemy.Health}";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var player in this.playerRepository.Players)
            {
                //sb.AppendLine($"Username: {player.Username} - Health: {player.Health} – Cards {player.CardRepository.Count}");
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Count}");
                foreach (var card in player.CardRepository.Cards)
                {
                    //sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                    sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                }
                //sb.AppendLine($"###");
                sb.AppendLine($"###");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
