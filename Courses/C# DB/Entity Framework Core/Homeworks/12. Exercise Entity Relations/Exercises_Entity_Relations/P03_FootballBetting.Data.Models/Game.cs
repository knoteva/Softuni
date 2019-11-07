using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        //GameId, 
        //HomeTeamId, 
        //AwayTeamId, 
        //HomeTeamGoals, 
        //AwayTeamGoals, 
        //DateTime, 
        //HomeTeamBetRate, 
        //AwayTeamBetRate, 
        //DrawBetRate, 
        //Result)

        [Key]
        public int GameId { get; set; }

        [ForeignKey("Team")]
        [Required]
        public int HomeTeamId { get; set; }
     
        public Team HomeTeam { get; set; }

        [ForeignKey("Team")]
        [Required]
        public int AwayTeamId { get; set; }
       
        public Team AwayTeam { get; set; }

        [Required]
        public int HomeTeamGoals { get; set; }

        [Required]
        public int AwayTeamGoals { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public double HomeTeamBetRate { get; set; }

        [Required]
        public double AwayTeamBetRate { get; set; }

        [Required]
        public double DrawBetRate { get; set; }

        [Required]
        public string Result { get; set; }

        //public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();

        public ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();

    }
}
