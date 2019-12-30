using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {

        private IPlayer mainPlayer;

        private ICollection<IPlayer> civilPlayers;

        private Queue<IGun> guns;

        //private IRepository<IGun> gunRepository;

        private INeighbourhood gangNeighbourhood;



        public Controller()
        {
            mainPlayer = new MainPlayer();

            civilPlayers = new List<IPlayer>();

            guns = new Queue<IGun>();

            //gunRepository = new GunRepository();

            gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddGun(string type, string name)
        {
            IGun gun = null;
            if (nameof(Pistol) == type)
            {
                gun = new Pistol(name);
            }
            else if ("Rifle" == type)
            {
                gun = new Rifle(name);
            }
            else
            {
                return $"Invalid gun type!";
            }

            guns.Enqueue(gun);
            return $"Successfully added {name} of type: {type}";
        }

        public string AddGunToPlayer(string name)
        {
            
            if (guns.Count == 0)
            {
                return $"There are no guns in the queue!";
            }
            var gun = guns.Dequeue();
            if (name == "Vercetti")
            {
                mainPlayer.GunRepository.Add(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }
            var civilPlayer = civilPlayers.FirstOrDefault(x => x.Name == name);

            if (civilPlayer == null)
            {
                return $"Civil player with that name doesn't exists!";
            }
            civilPlayer.GunRepository.Add(gun);
            return $"Successfully added {gun.Name} to the Civil Player: {name}";
            //•	If there no guns in the queue, return the following message: "There are no guns in the queue!"
            //•	If the name of the player is "Vercetti",  you need to add the gun to the main player's repository and return the following message: "Successfully added {gunName} to the Main Player: Tommy Vercetti"
            //•	If you receive a name which doesn't exist, you should return the following message: "Civil player with that name doesn't exists!"
            //•	If everything is successful, you should add the gun to the player's repository and return the following message: "Successfully added {gunName} to the Civil Player: {playerName}"
        }

        public string AddPlayer(string name)
        {
            var player = new CivilPlayer(name);
            civilPlayers.Add(player);
            return $"Successfully added civil player: {name}!";
        }

        public string Fight()
        {
            var message = string.Empty;
            int mainPlHealth = mainPlayer.LifePoints;
            int civilHealth = civilPlayers.Sum(p => p.LifePoints);
            gangNeighbourhood.Action(mainPlayer, civilPlayers);
            
            int mainPlHealthAfter = mainPlayer.LifePoints;
            int civilHealthAfter = civilPlayers.Sum(p => p.LifePoints);

            int deadCivilCount = civilPlayers.Count(x => !x.IsAlive);
            int aliveCivilCount = civilPlayers.Count(x => x.IsAlive);
            
            if (mainPlHealth == mainPlHealthAfter && civilHealth == civilHealthAfter)
            {
              message = $"Everything is okay!";
            }
            else
            {
                message = $"A fight happened:{Environment.NewLine}Tommy live points: {mainPlayer.LifePoints}!{Environment.NewLine}Tommy has killed: {deadCivilCount} players!{Environment.NewLine}Left Civil Players: {aliveCivilCount}!";
            }
            return message;
        }
    }
}
