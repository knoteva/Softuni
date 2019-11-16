using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("sale")]
    public class ExportSalesWithAppliedDiscountDto
    {
        [XmlElement("car")]
        public ExportCarsAttributeDto Car { get; set; }

        [XmlElement("discount")]
        public decimal Discount { get; set; }

        [XmlElement("customer-name")]
        public string CustomerName { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("price-with-discount")]
        public string PriceWithDiscount { get; set; }



        //        <?xml version = "1.0" encoding="utf-16"?>
        //<sales>
        //  <sale>
        //    <car make = "BMW" model="M5 F10" travelled-distance="435603343" />
        //    <discount>30.00</discount>
        //    <customer-name>Hipolito Lamoreaux</customer-name>
        //    <price>707.97</price>
        //    <price-with-discount>495.58</price-with-discount>
        //  </ExportSaleDiscount>
        //  ...
        //</sales>

    }
}