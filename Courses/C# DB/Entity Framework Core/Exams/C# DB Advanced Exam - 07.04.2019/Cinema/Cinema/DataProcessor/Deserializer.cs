namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDto = JsonConvert.DeserializeObject<ImportMoviesDto[]>(jsonString);
            var sb = new StringBuilder();
            var movies = new List<Movie>();

            foreach (var movieDto in moviesDto)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine($"{ErrorMessage}");
                    continue;
                }
                var genre = Enum.Parse<Genre>(movieDto.Genre);
                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre = genre,
                    Duration = movieDto.Duration,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director
                };

                var isValid = true;
                foreach (var m in movies)
                {
                    if (m.Title == movie.Title)
                    {
                        sb.AppendLine($"{ErrorMessage}");
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                {
                    movies.Add(movie);
                    sb.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre} and rating {movie.Rating:F2}!");
                }

            }
            context.Movies.AddRange(movies);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallsDto = JsonConvert.DeserializeObject<ImportHallSeatsDto[]>(jsonString);
            var sb = new StringBuilder();
            var halls = new List<Hall>();

            foreach (var hallDto in hallsDto)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine($"{ErrorMessage}");
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D

                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                halls.Add(hall);
                var genre = string.Empty;
                if (hall.Is3D && hall.Is4Dx)
                {
                    genre = "4Dx/3D";
                }
                else if (hall.Is3D)
                {
                    genre = "3D";
                }
                else if (hall.Is4Dx)
                {
                    genre = "4Dx";
                }
                else
                {
                    genre = "Normal";
                }
                sb.AppendLine($"Successfully imported {hall.Name}({genre}) with {hall.Seats.Count} seats!");


            }
            context.Halls.AddRange(halls);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProjectionsDto[]), new XmlRootAttribute("Projections"));
            var projectionsDto = (ImportProjectionsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var projections = new List<Projection>();

            foreach (var projectionDto in projectionsDto)
            {


                if (!IsValid(projectionDto))
                {
                    sb.AppendLine($"{ErrorMessage}");
                    continue;
                }

                var isValidMovie = context.Movies.FirstOrDefault(m => m.Id == projectionDto.MovieId);
                var isValidHall = context.Halls.FirstOrDefault(h => h.Id == projectionDto.HallId);

                if (isValidMovie == null || isValidHall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var projection = new Projection
                {
                    MovieId = projectionDto.MovieId,
                    HallId = projectionDto.HallId,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)


                };


                projections.Add(projection);
                var title = context.Movies.FirstOrDefault(m => m.Id == projectionDto.MovieId).Title;
                var d = projection.DateTime.ToString(@"MM/dd/yyyy", CultureInfo.InvariantCulture);
                sb.AppendLine($"Successfully imported projection {title} on {d}!");
            }

            //sb.AppendLine($"{customers.Sum(x => x.Tickets.Count)}");
            context.Projections.AddRange(projections);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomerTicketsDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomerTicketsDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {


                if (!IsValid(customerDto))
                {
                    sb.AppendLine($"{ErrorMessage}");
                    continue;
                }

                var tickets = new List<Ticket>();

                var projectionsIds = context.Projections.Select(p => p.Id).ToList();

                foreach (var t in customerDto.Tickets)
                {

                    if (!IsValid(t))
                    {
                        sb.AppendLine($"{ErrorMessage}");
                        continue;
                    }


                    tickets.Add(new Ticket()
                    {

                        ProjectionId = t.ProjectionId,
                        Price = t.Price,

                    });
                }


                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance,
                    Tickets = tickets,

                    // OrderItems = orderItems
                };


                customers.Add(customer);
                sb.AppendLine($"Successfully imported customer {customerDto.FirstName} {customerDto.LastName} with bought tickets: {customerDto.Tickets.Count()}!");
            }

            //sb.AppendLine($"{customers.Sum(x => x.Tickets.Count)}");
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }



        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);
            return isValid;
        }
    }
}