using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sokoban.Logic
{
    public class TopPlayer
    {
        public TopPlayer() { }
        public TopPlayer(string playerName, int score)
        {
            this.Name = playerName;
            this.Score = score;
        }

        public string Name { get; set; }
        public int Score { get; set; }
    }
}
