namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IPlayerRepository playerRepository = new PlayerRepository();
            ICardRepository cardRepository = new CardRepository();
            IPlayerFactory playerFactory = new PlayerFactory();
            ICardFactory cardFactory = new CardFactory();
            IBattleField battleField = new BattleField();
            
            var managerController = new ManagerController(playerRepository, cardRepository, playerFactory, cardFactory, battleField);
           
            IReader reader = new Reader();
            IWriter writer = new Writer();
            var engine = new Engine(reader, writer, managerController);
            engine.Run();
        }
    }
}