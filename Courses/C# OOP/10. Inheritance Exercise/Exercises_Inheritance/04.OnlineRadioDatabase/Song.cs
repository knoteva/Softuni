using _04.OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.OnlineRadioDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;
        private int minutes;
        private int seconds;

        public Song(string artistName, string songName, int minutes, int seconds)
        {
            ArtistName = artistName;
            SongName = songName;
            Minutes = minutes;
            Seconds = seconds;
        }

        public string ArtistName
        {
            get => artistName;
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }
                artistName = value;
            }
        }
        public string SongName
        {
            get => songName;
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }
                songName = value;
            }
        }
        public int Minutes
        {
            get => minutes;
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }
                minutes = value;
            }
        }
        public int Seconds
        {
            get => seconds;
            set
            {

                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                seconds = value;
            }
        }
    }
}
