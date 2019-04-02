using System;
class DeCatCoding
{
    static void Main()
    {
        string text = Console.ReadLine();
        string[] words = text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            for (int j = 0; j < word.Length; j++)
            {
                ulong a = Convert.ToUInt64(word[j] - 'a');
                //TODO
            }
        }
    }
}

