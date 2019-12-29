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
            var managerController = new ManagerController();
            var reader = new Reader();
            var writer = new Writer();           
            var engine = new Engine(managerController, reader, writer);
            engine.Run();
        }
    }
}