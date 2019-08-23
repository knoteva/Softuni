using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            string regex = @"^(?<artist>[A-Z][a-z\s']+):[A-Z\s]+\b";

            while ((line = Console.ReadLine()) != "end")
            {
                Match match = Regex.Match(line, regex);
                if (!match.Success)
                {
                    Console.WriteLine($"Invalid input!");
                }
                else
                {
                    var length = match.Groups["artist"].Value.Length;
                    string result = "";
                    foreach (var ch in match.Value)
                    {
                        if (ch == ' ' || ch == '\'')
                        {
                            result += ch;
                        }                   
                        else if(ch == ':')
                        {
                            result += '@';
                        }
                        else if(char.IsUpper(ch))
                        {
                            if (ch + length <= 90)
                            {
                                result += (char)(ch + length);
                            }
                            else
                            {
                                result += (char)(ch + length - 90 + 64);
                            }
                        }
                        else if (char.IsLower(ch))
                        {
                            if (ch + length <= 122)
                            {
                                result += (char)(ch + length);
                            }
                            else
                            {
                                result += (char)(ch + length - 122 + 96);
                            }
                        }
                    }
                    Console.WriteLine($"Successful encryption: {result}");
                }
            }
        }
    }
}
