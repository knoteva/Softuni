using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("customer")]
    public class ExportTotalSalesByCustomerDto
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; }

        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }

        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }


        //        <?xml version = "1.0" encoding="utf-16"?>
        //<customers>
        //  <customer full-name="Taina Achenbach" bought-cars="1" spent-money="5588.17" />
        //  <customer full-name="Johnette Derryberry" bought-cars="1" spent-money="2694.84" />
        //  <customer full-name="Jimmy Grossi" bought-cars="1" spent-money="2366.38" />
        // ...
        //</customers>

    }
}
