namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
               .Where(p => ids.Contains(p.Id))

               //               "Id": 3,
               //"Name": "Binni Cornhill",
               //"CellNumber": 503,
               //"Officers": [
               //  {
               //    "OfficerName": "Hailee Kennon",
               //    "Department": "ArtificialIntelligence"
               //  },
               .Select(x => new
               {
                   Id = x.Id,
                   Name = x.FullName,
                   CellNumber = x.Cell.CellNumber,
                   //.Where(p => p.Purchases.Any())
                   Officers = x.PrisonerOfficers
                   .Select(o => new
                   {
                       OfficerName = o.Officer.FullName,
                       Department = o.Officer.Department.Name

                   })
                   .OrderBy(o => o.OfficerName)
                   //.ThenBy(o => o.)
                   .ToArray(),
                   TotalOfficerSalary = x.PrisonerOfficers.Sum(p => p.Officer.Salary)
                   //.ToString("0.00")

               })
               .OrderBy(n => n.Name)
               .ThenBy(p => p.Id)
               .ToArray();

            var jsonResult = JsonConvert.SerializeObject(prisoners, Newtonsoft.Json.Formatting.Indented);

            return jsonResult;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisoners = context.Prisoners
               .Where(p => prisonersNames.Contains(p.FullName))
               .Select(p => new ExportPrisonersInboxDto
               {
                   Id = p.Id,
                   Name = p.FullName,
                   IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd",
                                CultureInfo.InvariantCulture),
                   //.Where(t => t.Type == purchaseType)
                   EncryptedMessages = p.Mails
                      .Select(m => new ExportEncryptedMessagesDto
                      {
                          Description = ReverseString(m.Description)
          
                          //.Select(c => (string)c.Reverse().ToArray())
                          //        Cvc = p.Card.Cvc,
                          //        Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                          //        Game = new ExportGameDto
                          //        {
                          //            Genre = p.Game.Genre.Name,
                          //            Title = p.Game.Name,
                          //            Price = p.Game.Price
                          //        }
                      })
                   //    .OrderBy(d => d.Date)
                       .ToArray(),
                   //    TotalSpent = x.Cards
                   //    .SelectMany(p => p.Purchases)
                   //    .Where(t => t.Type == purchaseType)
                   //    .Sum(p => p.Game.Price)
               })
               .OrderBy(p => p.Name)
               //.ThenBy(u => u.Username)
               .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportPrisonersInboxDto[]), new XmlRootAttribute("Prisoners"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), prisoners, namespaces);

            return sb.ToString().TrimEnd();
        }
        private static string ReverseString(string text)
        {
            return string.Concat(text.Reverse());
        }
    }
}