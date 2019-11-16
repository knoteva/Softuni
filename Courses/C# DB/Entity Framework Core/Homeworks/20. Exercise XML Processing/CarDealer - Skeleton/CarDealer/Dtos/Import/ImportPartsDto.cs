using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Part")]
    public class ImportPartsDto
    {
        //       <Part>
        //    <name>Bonnet/hood</name>
        //    <price>1001.34</price>
        //    <quantity>10</quantity>
        //    <supplierId>17</supplierId>
        //</Part>

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("quantity")]
        public int Quantity { get; set; }

        [XmlElement("supplierId")]
        public int SupplierId { get; set; }
    }
}
