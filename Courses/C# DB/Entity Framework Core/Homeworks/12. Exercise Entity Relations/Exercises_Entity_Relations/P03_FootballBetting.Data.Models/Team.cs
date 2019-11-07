using P03_FootballBetting.Data.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        //TeamId, 
        //Name,
        //LogoUrl, 
        //Initials(JUV, LIV, ARS…), 
        //Budget,
        //PrimaryKitColorId,
        //SecondaryKitColorId, 
        //TownId

        [Key]
        public int TeamId { get; set; }

        [MaxLength(80)]
        [Required]
        public string Name { get; set; }

        [MaxLength(80)]
        [Required]
        public string LogoUrl { get; set; }

        [MaxLength(10)]
        [Required]
        public string Initials { get; set; }

        [Required]
        public decimal Budget { get; set; }

        [ForeignKey("Color")]
        [Required]
        public int PrimaryKitColorId { get; set; }
     
        public Color PrimaryKitColor { get; set; }

        [ForeignKey("Color")]
        [Required]
        public int SecondaryKitColorId { get; set; }

        public Color SecondaryKitColor { get; set; }

        [ForeignKey("Town")]
        [Required]
        public int TownId { get; set; }

        [Required]
        public Town Town { get; set; }        

        public ICollection<Game> HomeGames { get; set; } = new HashSet<Game>(); 

        public ICollection<Game> AwayGames { get; set; } = new HashSet<Game>();

        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}
