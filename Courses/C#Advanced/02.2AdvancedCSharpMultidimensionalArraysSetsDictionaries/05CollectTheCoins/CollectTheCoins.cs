using System;

class CollectTheCoins
{
    static void Main()
    {
        string[] layout  = new string[4];
        for (int i = 0; i < layout.Length; i++)
        {
            layout[i] = Console.ReadLine();
        }
        string commands = Console.ReadLine();
        int coins = 0;
        int hits = 0;
        int row = 0;
        int col = 0;

        for (int i = 0; i < commands.Length; i++)
        {
            switch (commands[i])
            {
                case '>':
                    if (col + 1 < layout[row].Length)
                    {
                        col++;
                        if (layout[row][col] == '$')
                        {
                            coins++;
                        }                        
                    }
                    else
                    {
                        hits++;
                    }
                    break;
                case '<':
                    if (col - 1 >= 0)
                    {
                        col--;
                        if (layout[row][col] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;
                case '^':
                    if (row - 1 >= 0 && (col <= layout[row - 1].Length))
                    {
                        row--;
                        if (layout[row][col] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;
                case 'V':
                    if (row + 1 < 4 && (col <= layout[row + 1].Length))
                    {
                        row++;
                        if (layout[row][col] == '$')
                        {
                            coins++;
                        }
                    }
                    else
                    {
                        hits++;
                    }
                    break;
            }
        }
        Console.WriteLine("Coins collected: {0} \nWalls hit: {1}", coins, hits);
    }
}

