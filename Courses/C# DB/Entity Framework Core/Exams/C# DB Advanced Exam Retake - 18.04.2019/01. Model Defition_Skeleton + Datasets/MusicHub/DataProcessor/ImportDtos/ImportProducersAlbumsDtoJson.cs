using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicHub.DataProcessor.ImportDtos
{
    class ImportProducersAlbumsDtoJson
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Pseudonym")]
        public string Pseudonym { get; set; }

        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("Albums")]
        public ICollection<ImportAlbumDto> ProducerAlbums { get; set; }
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