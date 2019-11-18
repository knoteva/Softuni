﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.Data.Models
{
    public class Game
    {
        //•	Id – integer, Primary Key
        //•	Name – text(required)
        //•	Price – decimal (non-negative, minimum value: 0) (required)
        //•	ReleaseDate – Date(required)
        //•	DeveloperId – integer, foreign key(required)
        //•	Developer – the game’s developer(required)
        //•	GenreId – integer, foreign key(required)
        //•	Genre – the game’s genre(required)
        //•	Purchases - collection of type Purchase
        //•	GameTags - collection of type GameTag.Each game must have at least one tag.

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        //Purchases
        public ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();

        //GameTags
        public ICollection<GameTag> GameTags { get; set; } = new HashSet<GameTag>();
    }
}
