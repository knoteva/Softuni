namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly IPlayerFactory playerFactory;
        private readonly ICardFactory cardFactory;

        private readonly IPlayerRepository playerRepository;
        private readonly ICardRepository cardRepository;

        private readonly IBattleField battleField;
        public ManagerController()
        {
            playerFactory = new PlayerFactory();
            cardFactory = new CardFactory();

            playerRepository = new PlayerRepository();
            cardRepository = new CardRepository();

            battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var player = this.playerFactory.CreatePlayer(type, username);
            if (player == null)
            {
                return string.Empty;
            }
            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            var card = this.cardFactory.CreateCard(type, name);
            if (card == null)
            {
                return string.Empty;
            }
            cardRepository.Add(card);
            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.playerRepository.Find(attackUser);
            var enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            return string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);
        }

        public string Report()
        {
            var result = new StringBuilder();

            foreach (var player in this.playerRepository.Players)
            {
                result.AppendLine(string.Format(ConstantMessages.PlayerReportInfo, player.Username, player.Health, player.CardRepository.Count));

                if (player.CardRepository.Count > 0)
                {
                    foreach (var card in player.CardRepository.Cards)
                    {
                        result.AppendLine(string.Format(ConstantMessages.CardReportInfo, card.Name, card.DamagePoints));
                    }
                }
                result.AppendLine(ConstantMessages.DefaultReportSeparator);
            }


            return result.ToString().Trim();
        }
    }
}
