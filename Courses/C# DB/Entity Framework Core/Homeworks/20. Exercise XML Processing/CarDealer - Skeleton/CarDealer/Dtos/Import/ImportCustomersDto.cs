using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Customer")]
    public class ImportCustomersDto
    {
        //<Customer>
        //    <name>Emmitt Benally</name>
        //    <birthDate>1993-11-20T00:00:00</birthDate>
        //    <isYoungDriver>true</isYoungDriver>
        //</Customer>

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
