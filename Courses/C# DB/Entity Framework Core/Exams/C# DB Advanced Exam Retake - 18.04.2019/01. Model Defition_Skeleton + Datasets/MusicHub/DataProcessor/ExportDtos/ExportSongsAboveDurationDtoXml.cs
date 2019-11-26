using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ExportDtos
{
    [XmlType("Song")]
    public class ExportSongsAboveDurationDtoXml
    {
        [XmlElement("SongName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string SongName { get; set; }

        [XmlElement("Writer")]
        [Required]
        public string Writer { get; set; }

        [XmlElement("Performer")]
        [Required]
        public string Performer { get; set; }

        [XmlElement("AlbumProducer")]
        public string AlbumProducer { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }
    }
}


  //<Song>
  //  <SongName>Away</SongName>
  //  <Writer>Norina Renihan</Writer>
  //  <Performer>Lula Zuan</Performer>
  //  <AlbumProducer>Georgi Milkov</AlbumProducer>
  //  <Duration>00:05:35</Duration>
  //</Song>
