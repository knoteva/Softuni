using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType("Performer")]
    public class ImportSongPerformersDtoXml
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [XmlElement("Age")]
        [Range(18, 70)]
        public int Age { get; set; }

        [XmlElement("NetWorth")]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335"), Required]
        public decimal NetWorth { get; set; }



        [XmlArray("PerformersSongs")]
        public ImportPerformersSongsDtoXml[] PerformersSongs { get; set; }
    }

    [XmlType("Song")]
    public class ImportPerformersSongsDtoXml
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }

    //<Performer>
    //  <FirstName>Peter</FirstName>
    //  <LastName>Bree</LastName>
    //  <Age>25</Age>
    //  <NetWorth>3243</NetWorth>
    //  <PerformersSongs>
    //    <Song id = "2" />
    //    < Song id="1" />
    //  </PerformersSongs>
    //</Performer>

}
