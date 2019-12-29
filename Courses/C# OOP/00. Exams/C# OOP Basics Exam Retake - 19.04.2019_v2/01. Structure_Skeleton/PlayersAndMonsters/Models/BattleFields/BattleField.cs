using PlayersAndMonsters.Models.BattleFields.Contracts;
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
                throw new ArgumentException("Player is dead!");
            }

            GetBeginnerBonus(attackPlayer);
            GetBeginnerBonus(enemyPlayer);

            GetBonusFromDeck(attackPlayer);
            GetBonusFromDeck(enemyPlayer);
            //•	If one of the users is dead, throw new ArgumentException with message "Player is dead!"
            //•	If the player is a beginner, increase his health with 40 points and increase all damage points of all cards for the user with 30.
            //•	Before the fight, both players get bonus health points from their deck.
            //•	Attacker attacks first and after that the enemy attacks.If one of the players is dead you should stop the fight.


            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));
                if (enemyPlayer.IsDead)
                {
                    break;
                }
                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));
            }
        }

        private void GetBeginnerBonus(IPlayer player)
        {
            if (player.GetType().Name == "Beginner")
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }

        private void GetBonusFromDeck(IPlayer player)
        {
            var bonus = player.CardRepository.Cards.Sum(c => c.HealthPoints);
            player.Health += bonus;
        }
    }
}