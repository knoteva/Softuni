namespace Cinema.DataProcessor
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Cinema.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
              .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count() >= 1))
              .OrderByDescending(m => m.Rating)
              .ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
              .Select(m => new
              {
                  MovieName = m.Title,
                  Rating = m.Rating.ToString("F2"),
                  TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                  Customers = m.Projections
                  .SelectMany(p => p.Tickets)
                  .Select(t => new
                  {
                      FirstName = t.Customer.FirstName,
                      LastName = t.Customer.LastName,
                      Balance = t.Customer.Balance.ToString("F2")
                  })
                  .OrderByDescending(c => c.Balance)
                  .ThenBy(c => c.FirstName)
                  .ThenBy(c => c.LastName)
                  .ToList()
              })
              .Take(10)
              .ToList();

            var json = JsonConvert.SerializeObject(movies, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
               .Where(c => c.Age >= age)
               //.OrderByDescending(c => c.Tickets.Sum(t => t.Price))
               .Select(x => new ExportTopCustomers
               {
                   FirstName = x.FirstName,
                   LastName = x.LastName,
                   SpentMoney = x.Tickets.Sum(t => t.Price).ToString("F2"),
                   SpentTime = TimeSpan.FromMilliseconds(x.Tickets.Sum(d => d.Projection.Movie.Duration.TotalMilliseconds))
                   .ToString(@"hh\:mm\:ss")
                   //.SelectMany(p => p.Purchases)
                   //.Where(t => t.Type == purchaseType)
                   //.Select(p => new ExportPurchasesDto
                   //{
                   //    Card = p.Card.Number,
                   //    Cvc = p.Card.Cvc,
                   //    Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                   //    Game = new ExportGameDto
                   //    {
                   //        Genre = p.Game.Genre.Name,
                   //        Title = p.Game.Name,
                   //        Price = p.Game.Price
                   //    }
                   //})
                   //.OrderBy(d => d.Date)
                   //.ToArray(),
               })
               .OrderByDescending(c => double.Parse(c.SpentMoney))
               .Take(10)
               //.ThenBy(u => u.Username)
               .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportTopCustomers[]), new XmlRootAttribute("Customers"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}