using System;
using System.Collections.Generic;
using System.Text;

namespace _02.BookShop
{
    public class Book
    {
        private string author;
        private string title;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            Author = author;
            Title = title;
            Price = price;
        }

        public string Author
        {
            get => author; 
            set
            {
                if (value.Split(" ").Length == 2)
                {
                    var secondName = value.Split(" ")[1];
                    if (char.IsDigit(secondName[0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }
                
                author = value;
            }
        }
        public string Title
        {
            get => title; 
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                title = value;
            }
        }
        public virtual decimal Price
        {
            get => price; 
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                price = value;
            }
        }

        public override string ToString()
        {
            var resultBuilder = new StringBuilder();
            resultBuilder.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:F2}");

            string result = resultBuilder.ToString().TrimEnd();
            return result;
        }

    }
}
