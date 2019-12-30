using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var currGun in mainPlayer.GunRepository.Models)
            {
                foreach (var currCivilPlayer in civilPlayers)
                {
                    while (currGun.CanFire && currCivilPlayer.IsAlive)
                    {
                        currCivilPlayer.TakeLifePoints(currGun.Fire());
                    }
                    if (!currGun.CanFire)
                    {
                        break;
                    }
                }
            }

            foreach (var currCivilPlayer in civilPlayers)
            {
                if (!currCivilPlayer.IsAlive)
                {
                    continue;
                }
                foreach (var currGun in currCivilPlayer.GunRepository.Models)
                {
                    while (currGun.CanFire && mainPlayer.IsAlive)
                    {
                        mainPlayer.TakeLifePoints(currGun.Fire());
                    }
                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }
                if (!mainPlayer.IsAlive)
                {
                    break;
                }
            }
        }
    }
}
