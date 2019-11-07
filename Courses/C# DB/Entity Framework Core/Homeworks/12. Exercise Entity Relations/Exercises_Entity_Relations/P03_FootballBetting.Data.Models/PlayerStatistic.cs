using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        //GameId, 
        //PlayerId, 
        //ScoredGoals, 
        //Assists, 
        //MinutesPlayed

        [ForeignKey("Game")]
        [Required]
        public int GameId { get; set; }

        [Required]
        public Game Game { get; set; }

        [ForeignKey("Player")]
        [Required]
        public int PlayerId { get; set; }

        public Player Player { get; set; }

        [Required]
        public int ScoredGoals { get; set; }

        [Required]
        public int Assists { get; set; }

        [Required]
        public int MinutesPlayed { get; set; }
    }

}
