using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Prisoner")]
    public class ExportPrisonersInboxDto
    {
        [Required]
        [XmlElement("Id")]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public ExportEncryptedMessagesDto[] EncryptedMessages { get; set; }


        //<Prisoner>
        //  <Id>2</Id>
        //  <Name>Diana Ebbs</Name>
        //  <IncarcerationDate>1963-08-21</IncarcerationDate>
        //  <EncryptedMessages>
        //    <Message>
        //      <Description>.kcab draeh ton evah llits I dna  , skeew 2 tuoba ni si esaeler mubla ehT .dnuoranrut rof skeew 6-4 sekat ynapmoc DC eht dias yllanigiro eH.gnitiaw llits ma I</Description>
        //    </public ExportGameDto Game { get; set; }>
        //    <Message>
        //      <Description>.emit ruoy ekat ot uoy ekil lliw ew dna krow ruoy ekil I.hsur on emit ruoy ekat , enif si tahT</Description>
        //    </Message>
        //  </EncryptedMessages>
        //</Prisoner>

    }
    [XmlType("Message")]
    public class ExportEncryptedMessagesDto
    {
        [Required]
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
