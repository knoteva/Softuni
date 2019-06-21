using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            Article article = new Article(input);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandLine = Console.ReadLine().Split(": ");
                string command = commandLine[0];
                string content = commandLine[1];
                if (command == "Edit")
                {
                    article.Edit(content);
                }
                if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(content);
                }
                if (command == "Rename")
                {
                    article.Rename(content);
                }
            }
            Console.WriteLine(article.ToString());
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

            public void Edit(string newContent)
            {
                Content = newContent;
            }

            public void ChangeAuthor(string newAuthor)
            {
                Author = newAuthor;
            }

            public void Rename(string newTitle)
            {
                Title = newTitle;
            }
            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}
