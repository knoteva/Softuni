using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Order")]
    public class ImportOrdersDto
    {

        [XmlElement("Customer")]
        [Required]
        public string Customer { get; set; }

        [XmlElement("Employee")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Employee { get; set; }

        [XmlElement("DateTime")]
        [Required]
        public string DateTime { get; set; }

        [XmlElement("Type")]
        [Required]
        public string Type { get; set; }

        [XmlArray("Items")]
        public ImportItemDto[] Items { get; set; }
    }

    [XmlType("Item")]
    public class ImportItemDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("Quantity")]
        [Range(15, 2147483647)]
        public int Quantity { get; set; }

        //<Name>Quarter Pounder</Name>
        //<Quantity>2</Quantity>

    }
}
