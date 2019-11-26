using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportWritersDtoJson
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]      
        public string Name { get; set; }

        [JsonProperty("Pseudonym")]
        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string Pseudonym { get; set; }
    }
}
