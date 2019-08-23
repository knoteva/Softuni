using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split("&");
            string regex = @"[A-Za-z0-9]{16,25}";
            var result = new List<string>();
            

            for (int i = 0; i < input.Length; i++)
            {
                var changedSentence = new StringBuilder();
                Match m = Regex.Match(input[i], regex);

                if (m.Success)
                {
                    string sentence = input[i].ToUpper();
                    if (m.Value.Length != 16 && m.Value.Length != 25)
                    {
                        continue;
                    }                   

                    else if (m.Value.Length == 16)
                    {
                        for (int j = 4; j < 16; j += 5)
                        {
                            sentence = sentence.Insert(j, "-");

                        }                       
                    }
                    else if (m.Value.Length == 25)
                    {
                        for (int j = 5; j < 25; j += 6)
                        {
                            sentence = sentence.Insert(j, "-");
                        }
                       
                    }
                    for (int c = 0; c < sentence.Length; c++)
                    {
                        
                        if ((sentence[c] >= '0') && (sentence[c] <= '9'))
                        {
                            changedSentence.Append(9 - (sentence[c] - '0'));
                        }
                        else
                        {
                            changedSentence.Append(sentence[c]);
                        }
                    }
                    result.Add(changedSentence.ToString());
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
