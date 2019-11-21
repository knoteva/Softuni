using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    class ImportPrisonersMailsDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FullName { get; set; }

        //[Required]
        //[RegularExpression("^The [A-Z][a-z]+$")]
        [RegularExpression(@"^The [A-Z]{1}[a-z]+$"), Required]
        public string Nickname { get; set; }

        [Range(18, 65), Required]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal? Bail { get; set; }

        [ForeignKey(nameof(Cell))]
        public int? CellId { get; set; }
        public Cell Cell { get; set; }

        //Mails
        public ICollection<Mail> Mails { get; set; } = new HashSet<Mail>();

    }
}

//{
////  "FullName": "Melanie Simonich",
////  "Nickname": "The Wallaby",
////  "Age": 32,
////  "IncarcerationDate": "29/03/1957",
////  "ReleaseDate": "27/03/2006",
////  "Bail": null,
//  "CellId": 5,
//  "Mails": [
//    {
//      "Description": "please add me to your LinkedIn network",
//      "Sender": "Zonda Vasiljevic",
//      "Address": "51677 Rieder Center str."
//    },
//    {
//      "Description": "Melanie i hope you found the best place for you!",
//      "Sender": "Shell Lofthouse",
//      "Address": "5877 Shoshone Way str."
//    },
//    {
//      "Description": "Turns out they wanted to implement things like fully responsive dynamic content, useful apps, etc – all things I told them they needed in the first place but which they opted not to include.",
//      "Sender": "My Ansell",
//      "Address": "71908 Waubesa Plaza str."
//    }
//  ]
//},

