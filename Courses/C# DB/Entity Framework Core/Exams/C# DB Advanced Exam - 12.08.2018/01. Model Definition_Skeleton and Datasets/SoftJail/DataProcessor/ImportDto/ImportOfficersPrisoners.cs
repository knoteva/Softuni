using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficersPrisonersDto
    {

        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
       [MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("Money")]
      [Required]
       [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [XmlElement("Position")]
       [Required]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [Required]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        [ForeignKey(nameof(Department)), Required]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public ImportPrisonerToOfficerDto[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class ImportPrisonerToOfficerDto
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }

}

//<Officer>
//  <Name>Paddy Weiner</Name>
//  <Money>2854.56</Money>
//  <Position>Guard</Position>
//  <Weapon>ChainRifle</Weapon>
//  <DepartmentId>3</DepartmentId>
//  <Prisoners>
//    <Prisoner id = "4" />
//    < Prisoner id= "1" />
//  </ Prisoners >
//</ Officer >


