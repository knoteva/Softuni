using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Car")]
    public class ImportCarsDto
    {
        //<Car>
        //  <make>Opel</make>
        //  <model>Astra</model>
        //  <TraveledDistance>516628215</TraveledDistance>
        //  <parts>
        //    <partId id = "39" />
        //    < partId id="62"/>
        //    <partId id = "72" />
        //  </ parts >
        //</ Car >

        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartDto[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class PartDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}
