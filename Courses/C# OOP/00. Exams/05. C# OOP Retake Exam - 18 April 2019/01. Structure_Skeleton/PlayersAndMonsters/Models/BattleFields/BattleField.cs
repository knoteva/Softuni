using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException($"Player is dead!");
            }
            IsBeginer(attackPlayer);
            IsBeginer(enemyPlayer);

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(x => x.HealthPoints).Sum();
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(x => x.HealthPoints).Sum();

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum());
               
                if (enemyPlayer.IsDead)
                {
                    break;
                }
                 attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Select(x => x.DamagePoints).Sum());
            }
        }

        private static void IsBeginer(IPlayer player)
        {
            if (player is Beginner)
            // if (attackPlayer.GetType().Name == "Beginner")
            {
                player.Health += 40;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}

//•	If one of the users is dead, throw new ArgumentException with message "Player is dead!"
//•	If the player is a beginner, increase his health with 40 points and increase all damage points of all cards for the user with 30.
//•	Before the fight, both players get bonus health points from their deck.
//•	Attacker attacks first and after that the enemy attacks.If one of the players is dead you should stop the fight.
