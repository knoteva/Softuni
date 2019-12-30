using _04.OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.OnlineRadioDatabase.Core
{
    public class Engine
    {
        private List<Song> songs;

        public Engine()
        {
            this.songs = new List<Song>(); ;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var input = Console.ReadLine().Split(";");
                    if (input.Length < 3)
                    {
                        throw new InvalidSongException();
                    }
                    string artistName = input[0];
                    string songName = input[1];
                    var length = input[2].Split(":");
                    int minutes = 0;
                    int seconds = 0;
                    bool isMinutes = int.TryParse(length[0], out minutes);
                    bool isSeconds = int.TryParse(length[1], out seconds);
                    if (!isMinutes || !isSeconds)
                    {
                        throw new InvalidSongLengthException();
                    }
                    var song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine($"Song added.");
                }
                catch (FormatException ex)
                {

                    Console.WriteLine(ex.Message);
                }               
            }
            Print();

        }

        private void Print()
        {
            Console.WriteLine($"Songs added: {songs.Count}");
            int totalSeconds = songs.Sum(x => x.Seconds + x.Minutes * 60);
            TimeSpan timeSpam = TimeSpan.FromSeconds(totalSeconds);
            Console.WriteLine($"Playlist length: {timeSpam.Hours}h {timeSpam.Minutes}m {timeSpam.Seconds}s");
        }
    }
}
