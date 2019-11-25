﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FastFood.DataProcessor.Dto.Import
{
    public class ImportEmployeesDto
    {

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(15, 80)]
        public int Age { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Position { get; set; }
    }
}
