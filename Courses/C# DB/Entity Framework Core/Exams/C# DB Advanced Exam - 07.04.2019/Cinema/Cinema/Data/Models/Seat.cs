using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cinema.Data.Models
{
    public class Seat
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Hall)), Required] 
        public int HallId { get; set; }
        public Hall Hall { get; set; }
    }
}
