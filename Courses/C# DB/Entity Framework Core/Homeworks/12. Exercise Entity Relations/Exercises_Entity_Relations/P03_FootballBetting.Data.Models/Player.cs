using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Player
    {
        //PlayerId, 
        //Name, 
        //SquadNumber, 
        //TeamId,
        //PositionId, 
        //IsInjured

        [Key]
        public int PlayerId { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int SquadNumber { get; set; }

        [ForeignKey("Team")]
        [Required]
        public int TeamId { get; set; }

        public Team Team { get; set; }

        [ForeignKey("Position")]
        [Required]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        [Required]
        public bool IsInjured { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();
    }
}
