using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NightLife
{
    static void Main()
    {
        var input = Console.ReadLine();
        var information = new Dictionary<string, SortedDictionary<string, SortedSet<string>>>();
        while (!input.Equals("END"))
        {
            string[] data = input.Split(';');
            string city = data[0];
            string place = data[1];
            string performer = data[2];
            if (!information.ContainsKey(city))
            {
                information.Add(city, new SortedDictionary<string, SortedSet<string>>());
            }

            if (!information[city].ContainsKey(place))
            {
                information[city].Add(place, new SortedSet<string>());
            }

            information[city][place].Add(performer);
            input = Console.ReadLine();
        }

        //Print;
        foreach (var city in information)
        {
            Console.WriteLine(city.Key);
            foreach (var pair in city.Value)
            {
                Console.WriteLine("->{0}: {1}", pair.Key, string.Join(", ", pair.Value));
            }
        }
    }
}

