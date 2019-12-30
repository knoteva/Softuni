﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongException : FormatException
    {
        public InvalidSongException(string message = "Invalid song.")
            : base(message)
        {
        }
    }
}
