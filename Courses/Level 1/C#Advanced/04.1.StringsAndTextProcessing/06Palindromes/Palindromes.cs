using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Palindromes
{
    static void Main()
    {
        char[] symbols = { ',', '?', '!', '.', ' '};
        List<string> words = Console.ReadLine().Split(symbols, StringSplitOptions.RemoveEmptyEntries).Select(p => p).ToList();
        var result = new SortedSet<string>();
        foreach (string word in words)
        {
            if (IsPalyndrome(word))
                result.Add(word);
        }
        Console.WriteLine(string.Join(", ", result));
    } 
    
    private static bool IsPalyndrome(string words)
    {
        if (words.Length == 1)
        {
            return true;
        }
        for (int i = 0; i < words.Length / 2; i++)
        {
            if (words[i] != words[words.Length - i - 1])
                return false;
        }
        return true;
    }
}

