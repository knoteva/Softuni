using System;
using System.Collections.Generic;
using System.Text;

namespace _04.OnlineRadioDatabase.Exceptions
{
    class InvalidSongMinutesException : InvalidSongLengthException
    {
        public InvalidSongMinutesException(string message = "Song minutes should be between 0 and 14.") : base(message)
        {
        }
    }
}
