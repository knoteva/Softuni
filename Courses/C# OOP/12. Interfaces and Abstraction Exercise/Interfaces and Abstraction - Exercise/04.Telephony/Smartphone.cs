using _04.Telephony.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.Telephony
{
    class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            ValidateURL(url);
            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            ValidatePhoneNumber(phoneNumber);
            return $"Calling... {phoneNumber}";
        }

        private void ValidatePhoneNumber(string phoneNumber)
        {
            foreach (var c in phoneNumber)
            {
                if (!char.IsDigit(c))
                {
                    throw new ArgumentException("Invalid number!");
                }
            }
        }

        private void ValidateURL(string url)
        {
            foreach (var c in url)
            {
                if (char.IsDigit(c))
                {
                    throw new ArgumentException("Invalid URL!");
                }
            }
        }
    }
}
