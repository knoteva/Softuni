using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            var likesD = new Dictionary<string, int>();
            var commentsD = new Dictionary<string, int>();

            var line = string.Empty;

            while ((line = Console.ReadLine()) != "Log out")
            {
                string command = line.Split(": ")[0];
                string username = line.Split(": ")[1];

                if (command == "New follower")
                {
                    if (!likesD.ContainsKey(username))
                    {
                        likesD.Add(username, 0);
                        commentsD.Add(username, 0);
                    }
                }
                else if (command == "Like")
                {
                    int likeCount = int.Parse(line.Split(": ")[2]);
                    if (!likesD.ContainsKey(username))
                    {
                        likesD.Add(username, 0);
                        commentsD.Add(username, 0);
                    }
                    likesD[username] += likeCount;
                }
                else if (command == "Comment")
                {
                    if (!commentsD.ContainsKey(username))
                    {
                        commentsD.Add(username, 0);
                        likesD.Add(username, 0);
                    }
                    commentsD[username]++;
                }
                else if (command == "Blocked")
                {
                    if (likesD.ContainsKey(username))
                    {
                        likesD.Remove(username);
                        commentsD.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
            }

            //var result = likesD
            //                .Union(commentsD)
            //                .GroupBy(e => e.Key, e => e.Value)
            //                .ToDictionary(g => g.Key, v => v.ToArray());

            //Console.WriteLine($"{result.Count} followers");
            //foreach (var item in result.OrderByDescending(x => x.Value[0]).ThenBy(x => x.Key))
            //{
            //    Console.WriteLine($"{item.Key}: {item.Value[0] + item.Value[1]}");

            //}

            Console.WriteLine($"{likesD.Count} followers");

            foreach (var item in likesD.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value + commentsD[item.Key]}");
            }
        }
    }
}
