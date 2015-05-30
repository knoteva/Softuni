namespace Sokoban.Logic
{
    public class Level
    {
        public string[] Data { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool HasTimeBonus { get; set; }
        public bool HasPointsBonus { get; set; }
    }
}

