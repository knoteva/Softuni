namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<ImportWritersDtoJson[]>(jsonString);
            var sb = new StringBuilder();
            var writers = new List<Writer>();


            foreach (var writerDto in writersDto)
            {
                
                var writer = Mapper.Map<Writer>(writerDto);
                bool isValidWriter = IsValid(writer);

                if (isValidWriter == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                writers.Add(writer);
                sb.AppendLine($"Imported {writerDto.Name}");
            }
            context.Writers.AddRange(writers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<ImportProducersAlbumsDtoJson[]>(jsonString);

            List<Producer> producers = new List<Producer>();

            StringBuilder sb = new StringBuilder();

            foreach (var producerDto in producersDto)
            {
                var producer = Mapper.Map<Producer>(producerDto);
                bool isValidProducer = IsValid(producer);
                bool isInvalidAlbums = producerDto.ProducerAlbums.Any(a => IsValid(a) == false);

                if (isValidProducer == false || isInvalidAlbums == true)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var albumDto in producerDto.ProducerAlbums)
                {
                    var album = Mapper.Map<Album>(albumDto);
                    producer.Albums.Add(album);
                }

                producers.Add(producer);

                if (producer.PhoneNumber == null)
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithNoPhone,
                        producer.Name,
                        producer.Albums.Count()));
                }
                else
                {
                    sb.AppendLine(string.Format(SuccessfullyImportedProducerWithPhone,
                        producer.Name,
                        producer.PhoneNumber,
                        producer.Albums.Count()));
                }
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongsDtoXml[]), new XmlRootAttribute("Songs"));
            var songsDto = (ImportSongsDtoXml[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var songs = new List<Song>();

            foreach (var songDto in songsDto)
            {
                var isValidEnum = Enum.TryParse<Genre>(songDto.Genre, out Genre genreType);
                bool isValidAlbum = context.Albums.Any(a => a.Id == songDto.AlbumId);
                bool isValidWriter = context.Writers.Any(w => w.Id == songDto.WriterId);

                if (!IsValid(songDto) || !isValidEnum || !isValidAlbum || !isValidWriter)
                {
                    sb.AppendLine($"{ErrorMessage}");
                    continue;
                }

                var song = new Song
                {
                    Name = songDto.Name,
                    Duration = TimeSpan.ParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(songDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre =  genreType,
                    AlbumId = songDto.AlbumId,
                    WriterId = songDto.WriterId,
                    Price = songDto.Price
                };

                songs.Add(song);
                sb.AppendLine($"Imported {songDto.Name} ({genreType} genre) with duration {TimeSpan.ParseExact(songDto.Duration, "c", CultureInfo.InvariantCulture)}");
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSongPerformersDtoXml[]), new XmlRootAttribute("Performers"));
            var songsDto = (ImportSongPerformersDtoXml[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var songs = new List<Performer>();

            foreach (var songDto in songsDto)
            {
              
                var songsIds = context.Songs.Select(s => s.Id).ToList();
                var isSongsExists = songDto.PerformersSongs.Select(s => s.Id).All(v => songsIds.Contains(v));
              
                if (!IsValid(songDto) || !isSongsExists)
                {
                    sb.AppendLine($"Invalid data");
                    continue;
                }


                //var isValidEnumPosition = Enum.TryParse<Position>(officerDto.Position, out Position positionType);
                //var isValidEnumnWeapon = Enum.TryParse<Weapon>(officerDto.Weapon, out Weapon weaponType);

                //if (!isValidEnumPosition || !isValidEnumnWeapon)
                //{
                //    sb.AppendLine($"Invalid Data");
                //    continue;
                //}


                var song = new Performer
                {
                    FirstName = songDto.FirstName,
                    LastName = songDto.LastName,
                    Age = songDto.Age,
                    NetWorth = songDto.NetWorth
                };

                foreach (var currentSong in songDto.PerformersSongs)
                {
                    song.PerformerSongs.Add(new SongPerformer
                    {
                        SongId = currentSong.Id
                    });
                }
                songs.Add(song);
                sb.AppendLine($"Imported {songDto.FirstName} ({songDto.PerformersSongs.Count()} songs)");
            }

            context.Performers.AddRange(songs);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object entity)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);
            return isValid;
        }
    }
}