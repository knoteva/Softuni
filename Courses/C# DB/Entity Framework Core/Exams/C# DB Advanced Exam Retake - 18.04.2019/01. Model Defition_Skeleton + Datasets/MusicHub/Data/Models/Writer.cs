using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Writer
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string Pseudonym { get; set; }

        public ICollection<Song> Songs { get; set; } = new HashSet<Song>();

        //•	Id – integer, Primary Key
        //•	Name– text with min length 3 and max length 20 (required)
        //•	Pseudonym – text, consisting of two words separated with space and each word must start with one upper letter and continue with many lower-case letters(Example: "Freddie Mercury")
        //•	Songs – collection of type Song

    }
}
