namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore.Internal;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //// 0. Create Database
                //DbInitializer.ResetDatabase(db);

                //// 1. Age Restriction
                //var command = Console.ReadLine();
                //Console.WriteLine(GetBooksByAgeRestriction(db, command));

                //// 2. Golden Books
                //Console.WriteLine(GetGoldenBooks(db));

                //// 3. Books by Price
                //Console.WriteLine(GetBooksByPrice(db));

                //// 4. Not Released In
                //int year = int.Parse(Console.ReadLine());
                //Console.WriteLine(GetBooksNotReleasedIn(db, year));

                //// 5. Book Titles by Category
                var input = Console.ReadLine();
                Console.WriteLine(GetBooksByCategory(db, input));

                //// 6. Released Before Date
                //var date = Console.ReadLine();
                //Console.WriteLine(GetBooksReleasedBefore(db, date));

                //// 7. Author Search
                //var input = Console.ReadLine();
                //Console.WriteLine(GetAuthorNamesEndingIn(db, input));

                //// 8. Book Search
                //var input = Console.ReadLine();
                //Console.WriteLine(GetBookTitlesContaining(db, input));

                //// 9. Book Search by Author
                //var input = Console.ReadLine();
                //Console.WriteLine(GetBooksByAuthor(db, input));

                //// 10. Count Books
                //int lengthCheck = int.Parse(Console.ReadLine());
                //Console.WriteLine(CountBooks(db, lengthCheck));

                //// 11. Total Book Copies
                //Console.WriteLine(CountCopiesByAuthor(db));

                //// 12. Profit by Category
                //Console.WriteLine(GetTotalProfitByCategory(db));

                //// 13. Most Recent Books
                //Console.WriteLine(GetMostRecentBooks(db));

                //// 14. Increase Prices
                //IncreasePrices(db);

                //// 15. Remove Books
                //Console.WriteLine(RemoveBooks(db));
            }


        }
        // 1. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.AgeRestriction
                })
                .Where(x => x.AgeRestriction == ageRestriction)
                .OrderBy(x => x.Title);
            //.ToList();
            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }
            return sb.ToString().TrimEnd();
        }

        // 2. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Copies
                })
                .Where(x => x.EditionType == Enum.Parse<EditionType>("Gold", true) && x.Copies < 5000);
            //.OrderBy(x => x.Title);
            //.ToList();
            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }
            return sb.ToString().TrimEnd();
        }

        // 3. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new
                {
                    b.Price,
                    b.Title
                })
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .ToList();
            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price}");
            }
            return sb.ToString().TrimEnd();
        }

        // 4. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
               .Select(b => new
               {
                   Title = b.Title,
                   b.ReleaseDate
               })

               .Where(x => x.ReleaseDate.Value.Year != year)
               .ToList();
            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }
            return sb.ToString().TrimEnd();
        }

        // 5. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.Split()
                .Select(c => c.ToLower())
                .ToArray();

            var books = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains((c.Category.Name).ToLower())))
                .Select(b => new
                {
                    Title = b.Title
                })
                .OrderBy(b => b.Title);
            //.ToList();
            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }
            return sb.ToString().TrimEnd();
        }

        // 6. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture);
            var books = context.Books
                   .Select(b => new
                   {
                       Title = b.Title,
                       b.EditionType,
                       b.Price,
                       b.ReleaseDate
                   })

                   .Where(x => x.ReleaseDate < dateTime)
                   .OrderByDescending(x => x.ReleaseDate)
                   .ToList();
            var sb = new StringBuilder();

            foreach (var book in books)
            {
                //sb.AppendLine($"{book.ReleaseDate}");
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        // 7. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                   .Select(a => new
                   {
                       FirstName = a.FirstName,
                       FullName = a.FirstName + " " + a.LastName
                   })
                   .Where(x => x.FirstName.EndsWith(input))
                   .OrderBy(x => x.FullName)
                   .ToList();
            var sb = new StringBuilder();

            foreach (var author in authors)
            {
                //sb.AppendLine($"{book.ReleaseDate}");
                sb.AppendLine($"{author.FullName}");
            }
            return sb.ToString().TrimEnd();
        }

        // 8. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                       .Select(b => new
                       {
                           b.Title
                       })
                       .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                       .OrderBy(x => x.Title)
                       .ToList();
            var sb = new StringBuilder();

            foreach (var title in titles)
            {
                //sb.AppendLine($"{book.ReleaseDate}");
                sb.AppendLine($"{title.Title}");
            }
            return sb.ToString().TrimEnd();
        }

        // 9. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var authorsBooks = context.Authors
                       .Select(a => new
                       {
                           LastName = a.LastName,
                           FullName = a.FirstName + " " + a.LastName,
                           BooksTitles = a.Books
                           .Select(b => new
                           {
                               Title = b.Title,
                               Id = b.BookId
                           })
                           .OrderBy(x => x.Id)
                       })
                       .Where(x => x.LastName.ToLower().StartsWith(input.ToLower()))
                       .ToList();
            var sb = new StringBuilder();

            foreach (var author in authorsBooks)
            {
                foreach (var title in author.BooksTitles)
                {
                    sb.AppendLine($"{title.Title} ({author.FullName})");
                }


            }
            return sb.ToString().TrimEnd();
        }

        // 10. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books
                   .Select(b => new
                   {
                       Title = b.Title
                   })

                   .Where(x => x.Title.Length > lengthCheck)
                   .ToList();

            var count = books.Count();
            return count;
        }

        // 11. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsCount = context.Authors
                       .Select(a => new
                       {
                           FullName = a.FirstName + " " + a.LastName,
                           Count = a.Books.Sum(b => b.Copies)
                       })
                       .OrderByDescending(x => x.Count)
                       .ToList();

            var sb = new StringBuilder();
            foreach (var author in authorsCount)
            {
                sb.AppendLine($"{author.FullName} - {author.Count}");
            }
            return sb.ToString().TrimEnd();
        }

        // 12. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                       .Select(c => new
                       {
                           c.Name,
                           Profit = c.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)         
                       })
                       .OrderByDescending(x => x.Profit)
                       .ToList();

            var sb = new StringBuilder();
            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        // 13. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var books = context.Categories
                          .Select(c => new
                          {
                              c.Name,
                              Books = c.CategoryBooks
                              .Select(b => new { 
                              Title = b.Book.Title,
                              Date = b.Book.ReleaseDate
                              })
                              .OrderByDescending(b => b.Date)
                              .Take(3)
                          })
                          .OrderBy(x => x.Name)
                          .ToList();

            var sb = new StringBuilder();
            foreach (var category in books)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var item in category.Books)
                {
                    sb.AppendLine($"{item.Title} ({item.Date.Value.Year})");
                }
                
            }
            return sb.ToString().TrimEnd();
        }

        // 14. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var prices = context.Books
                    .Where(b => b.ReleaseDate.Value.Year < 2010);

            foreach (var price in prices)
            {
                price.Price += 5;

            }
            context.SaveChanges();
        }

        // 15. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
            .Where(b => b.Copies < 4200);
            int count = 0;

            foreach (var book in books)
            {
                context.Books.Remove(book);
                count++;
            }
            context.SaveChanges();

            return count;
        }
    }
}
