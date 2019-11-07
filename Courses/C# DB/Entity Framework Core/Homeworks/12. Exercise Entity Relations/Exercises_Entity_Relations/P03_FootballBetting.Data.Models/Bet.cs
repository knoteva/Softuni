using P03_FootballBetting.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Bet
    {
        //BetId, 
        //Amount, 
        //Prediction, 
        //DateTime, 
        //UserId, 
        //GameId


        [Key]
        public int BetId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public Prediction Prediction { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        [Required]
        public User User { get; set; }

        [ForeignKey("Game")]
        [Required]
        public int GameId { get; set; }

        [Required]
        public Game Game { get; set; }
    }
}
