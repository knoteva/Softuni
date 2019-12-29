namespace PlayersAndMonsters.Core
{
    using System;

    using Contracts;
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
            throw new NotImplementedException();
        }

        public string AddCard(string type, string name)
        {
            throw new NotImplementedException();
        }

        public string AddPlayerCard(string username, string cardName)
        {
            throw new NotImplementedException();
        }

        public string Fight(string attackUser, string enemyUser)
        {
            throw new NotImplementedException();
        }

        public string Report()
        {
            throw new NotImplementedException();
        }
    }
}
