using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Song")]
    public class ImportSongsDtoXml
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("Duration")]
        public string Duration { get; set; }

        [Required]
        [XmlElement("CreatedOn")]
        public string CreatedOn { get; set; }

        [Required]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [ForeignKey(nameof(Album))]
        [XmlElement("AlbumId")]
        public int? AlbumId { get; set; }

        [ForeignKey(nameof(Writer)), Required]
        [XmlElement("WriterId")]
        public int WriterId { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335"), Required]
        [XmlElement("Price")]
        public decimal Price { get; set; }

    }

    //  <Song>
    //  <Name>What Goes Around</Name>
    //  <Duration>00:03:23</Duration>
    //  <CreatedOn>21/12/2018</CreatedOn>
    //  <Genre>Blues</Genre>
    //  <AlbumId>2</AlbumId>
    //  <WriterId>2</WriterId>
    //  <Price>12</Price>
    //</Song>

}
