namespace PlayersAndMonsters.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {

        private IPlayerFactory playerFactory;
        private ICardFactory cardFactory;

        private IPlayerRepository playerRepository;
        private ICardRepository cardRepository;

        private IBattleField battleField;

        public ManagerController()
        {
            playerFactory = new PlayerFactory();
            cardFactory = new CardFactory();

            playerRepository = new PlayerRepository();
            cardRepository = new CardRepository();

            battleField = new BattleField();
        }
        // 1. 1 тест
        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);
            if (player == null)
            {
                return string.Empty;
            }
            playerRepository.Add(player);
            return $"Successfully added player of type {type} with username: {username}";
        }
        // 2. 1 тест
        public string AddCard(string type, string name)
        {
            var card = cardFactory.CreateCard(type, name);
            if (card == null)
            {
                return string.Empty;
            }
            cardRepository.Add(card);
            return $"Successfully added card of type {type}Card with name: {name}";
        }
        // 3. 1 тест
        public string AddPlayerCard(string username, string cardName)
        {
            var player = playerRepository.Find(username);
            var card = cardRepository.Find(cardName);
            player.CardRepository.Add(card);
            return $"Successfully added card: {cardName} to user: {username}";
        }
        // 4. 2 теста
        public string Fight(string attackUser, string enemyUser)
        {
            var attackPlayer = playerRepository.Find(attackUser);
            var enemyPlayer = playerRepository.Find(enemyUser);
            battleField.Fight(attackPlayer, enemyPlayer);
            return $"Attack user health {attackPlayer.Health} - Enemy user health {enemyPlayer.Health}";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var player in playerRepository.Players)
            {
                sb.AppendLine($"Username: {player.Username} - Health: {player.Health} - Cards {player.CardRepository.Cards.Count}");
                if (player.CardRepository.Cards.Count > 0)
                {
                    foreach (var card in player.CardRepository.Cards)
                    {
                        sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
                    }                   
                }
                sb.AppendLine($"###");
            }           
            return sb.ToString().Trim();
        }
    }
}
