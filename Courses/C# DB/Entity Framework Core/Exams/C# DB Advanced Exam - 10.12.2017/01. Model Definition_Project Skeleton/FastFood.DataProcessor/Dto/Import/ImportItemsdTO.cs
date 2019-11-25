using FastFood.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DataProcessor.Dto.Import
{
    public class ImportItemsDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Category { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335"), Required]
        public decimal Price { get; set; }
    }
}
