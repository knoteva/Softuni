using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
   public class Country
    {
        //CountryId, 
        //Name

        [Key]
        public int CountryId { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        public ICollection<Town> Towns { get; set; } = new HashSet<Town>();

    }
}
