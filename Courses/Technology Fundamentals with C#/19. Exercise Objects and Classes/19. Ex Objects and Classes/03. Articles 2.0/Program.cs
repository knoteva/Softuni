using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2_0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(", ");
                articles.Add(new Article(data));

            }
            string command = Console.ReadLine();
            if (command == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
             else if (command == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (command == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            articles.ForEach(x => Console.WriteLine(x.ToString()));           
        }
        class Article
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public Article(string[] data)
            {
                Title = data[0];
                Content = data[1];
                Author = data[2];
            }
            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}
