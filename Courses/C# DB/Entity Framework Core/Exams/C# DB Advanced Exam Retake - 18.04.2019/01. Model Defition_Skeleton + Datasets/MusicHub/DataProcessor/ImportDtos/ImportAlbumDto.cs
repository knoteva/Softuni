using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportAlbumDto
    {
        [JsonProperty("Name")]
        [MinLength(3), MaxLength(40), Required]
        public string Name { get; set; }

        [JsonProperty("ReleaseDate")]
        [Required]
        public string ReleaseDate { get; set; }
    }
}


  //{
  //  "Name": "Ab Pittham",
  //  "Pseudonym": null,
  //  "PhoneNumber": null,
  //  "Albums": []
  //},
  //{
  //  "Name": "Georgi Milkov",
  //  "Pseudonym": "Gosho Goshev",
  //  "PhoneNumber": "+359 899 345 045",
  //  "Albums": [
  //    {
  //      "Name": "Fight and flight",
  //      "ReleaseDate": "05/11/2018"
  //    },
  //    {
  //      "Name": "Cherry",
  //      "ReleaseDate": "09/06/2018"
  //    },
  //    {
  //      "Name": "No history",
  //      "ReleaseDate": "05/03/2019"
  //    }
  //  ]
  //},