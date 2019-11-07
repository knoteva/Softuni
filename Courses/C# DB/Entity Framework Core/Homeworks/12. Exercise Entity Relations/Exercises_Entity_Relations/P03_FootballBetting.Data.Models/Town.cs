using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Town
    {
        //TownId, 
        //Name

        [Key]
        public int TownId { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [ForeignKey("Country")]
        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}
