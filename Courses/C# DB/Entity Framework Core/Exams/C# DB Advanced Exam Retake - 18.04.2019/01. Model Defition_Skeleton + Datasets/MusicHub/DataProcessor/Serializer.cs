namespace MusicHub.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context.Albums
             .Where(a => a.ProducerId == producerId)
             //.OrderByDescending(m => m.Rating)
             //.ThenByDescending(m => m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)))
             .Select(a => new
             {
                 AlbumName = a.Name,
                 ReleaseDate = a.ReleaseDate.ToString(@"MM/dd/yyyy", CultureInfo.InvariantCulture),
                 ProducerName = a.Producer.Name,
                 Songs = a.Songs
                 .Select(s => new
                 {
                     SongName = s.Name,
                     Price = s.Price.ToString("F2"),
                     Writer = s.Writer.Name
                 })
                 .OrderByDescending(n => n.SongName)
                 .ThenBy(w => w.Writer)
                 .ToList(),
                 AlbumPrice = a.Songs.Sum(p => p.Price).ToString("F2")
             })
             .OrderByDescending(a => Double.Parse(a.AlbumPrice))
             .ToList();

            var json = JsonConvert.SerializeObject(albums, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs             
              .Where(d => d.Duration.TotalSeconds >= duration)
              //.OrderByDescending(c => c.Tickets.Sum(t => t.Price))
              .Select(x => new ExportSongsAboveDurationDtoXml
              {

                  //<Song>
                  //  <SongName>Away</SongName>
                  //  <Writer>Norina Renihan</Writer>
                  //  <Performer>Lula Zuan</Performer>
                  //  <AlbumProducer>Georgi Milkov</AlbumProducer>
                  //  <Duration>00:05:35</Duration>
                  //</Song>

                  SongName = x.Name,
                  Writer = x.Writer.Name,
                  Performer = x.SongPerformers.Select(f => $"{f.Performer.FirstName} {f.Performer.LastName}").FirstOrDefault(),
                  AlbumProducer = x.Album.Producer.Name,
                  Duration = x.Duration.ToString("c", CultureInfo.InvariantCulture)
                  //FirstName = x.FirstName,
                  //LastName = x.LastName,
                  //SpentMoney = x.Tickets.Sum(t => t.Price).ToString("F2"),
                  //SpentTime = TimeSpan.FromMilliseconds(x.Tickets.Sum(d => d.Projection.Movie.Duration.TotalMilliseconds))
                  //.ToString(@"hh\:mm\:ss")
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
              .OrderBy(n => n.SongName)
              .ThenBy(n => n.Writer)
              .ThenBy(n => n.Performer)
              //.ThenBy(u => u.Username)
              .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportSongsAboveDurationDtoXml[]), new XmlRootAttribute("Songs"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), songs, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}