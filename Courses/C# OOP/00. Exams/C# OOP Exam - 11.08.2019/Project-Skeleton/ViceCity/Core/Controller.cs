using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Repositories;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private const string MainPlayerNameKey = "Vercetti";
        private const string FullNameMainPlayer = "Tommy Vercetti";
        private const int InitialMainPlayerHealthPoints = 100;
        private readonly List<IPlayer> players;
        private readonly GunRepository gunRepository;
        private readonly GangNeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.players = new List<IPlayer>();
            this.players.Add(new MainPlayer());
            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
        }
        public string AddGun(string type, string name)
        {
            if (type != nameof(Pistol) && type != nameof(Rifle))
            {
                return "Invalid gun type!";
            }

            IGun gun = null;

            switch (type)
            {
                case "Rifle":
                    gun = new Rifle(name);
                    break;

                case "Pistol":
                    gun = new Pistol(name);
                    break;

                default:
                    break;
            }

            gunRepository.Add(gun);
            return $"Successfully added {gun.Name} of type: {gun.GetType().Name}";              
        }

        public string AddGunToPlayer(string name)
        {
            if (gunRepository.Models.Count == 0)
            {
                return $"There are no guns in the queue!";
            }

            if (name == MainPlayerNameKey)
            {
                IPlayer playerVercetti = players
                    .FirstOrDefault(
                    p => p.Name == FullNameMainPlayer && p.GetType().Name == nameof(MainPlayer));

                IGun gunVercetti = gunRepository.Models.FirstOrDefault(g => g.CanFire == true);
                gunRepository.Remove(gunVercetti);

                playerVercetti.GunRepository.Add(gunVercetti);
                return $"Successfully added {gunVercetti} to the Main Player: {gunVercetti.Name}"; 
            }

            if (players.FirstOrDefault(p => p.Name == name) == null)
            {
                return $"Civil player with that name doesn't exists!";
            }

            IPlayer player = players.FirstOrDefault(p => p.Name == name);
            IGun gun = gunRepository.Models.FirstOrDefault(g => g.CanFire == true);

            gunRepository.Remove(gun);
            player.GunRepository.Add(gun);

            return $"Successfully added {gun.Name} to the Civil Player: {player.Name}";
        }

        public string AddPlayer(string name)
        {
            IPlayer player = new CivilPlayer(name);
            this.players.Add(player);
            return $"Successfully added civil player: {player.Name}!";
        }

        public string Fight()
        {
            MainPlayer mainPlayer = (MainPlayer)this.players
               .FirstOrDefault(p => p.GetType().Name == nameof(MainPlayer));

            List<IPlayer> civilPlayers = this.players
                .Where(p => p.GetType().Name != nameof(MainPlayer))
                .ToList();

            this.gangNeighbourhood.Action(mainPlayer, civilPlayers);

            StringBuilder sb = new StringBuilder();

            if (civilPlayers.Any(p => p.IsAlive == true) &&
                mainPlayer.LifePoints == InitialMainPlayerHealthPoints)
            {
                sb.AppendLine($"Everything is okay");
            }
            else
            {
                sb.AppendLine($"A fight happened:");

                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");

                sb.AppendLine($"Tommy has killed: {civilPlayers.Where(p => p.IsAlive == false).Count()} players!");
                sb.AppendLine($"Left Civil Players: {civilPlayers.Where(p => p.IsAlive == true).Count()}!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
