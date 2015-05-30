using System;
using System.Linq;
using System.Xml.Linq;

namespace Sokoban.Logic
{
    public class LevelCollection
    {
        public int NumberOfLevels { get; private set; }
        public string CollectionName { get; private set; }

        private XDocument _levelsFile;

        public LevelCollection(string fileName)
        {
            LoadLevels(fileName);
        }

        public LevelCollection() { }

        public void LoadLevels(string fileName)
        {
            try
            {
                _levelsFile = XDocument.Load(fileName);
            }
            catch
            {
                throw new Exception("File does not exist");
            }

            this.CollectionName = _levelsFile.Root.Element("LevelCollection").Attribute("Name").Value;
            NumberOfLevels = _levelsFile.Descendants("Level").Count();
        }

        public Level this[int levelNumber]
        {
            get { return GetLevel(levelNumber); }
        }

        private Level GetLevel(int levelNumber)
        {
            var level = _levelsFile.Descendants("Level").FirstOrDefault(t => t.Attribute("Id").Value == levelNumber.ToString()).Elements();
            if (level == null) throw new ArgumentNullException("Няма повече нива!");

            int levelWidth = (from row in level select row.Value.Length).Max();
            int levelHeight = level.Count();
            string[] levelData = new string[levelHeight];
            int rowNumber = 0;
            bool hasTimeBonus = false;
            bool hasPointsBonus = false;

            foreach (var row in level)
            {
                if (!hasTimeBonus && row.Value.Contains('~'))//bonus time
                {
                    if (RandomGenerator(20))
                    {
                        hasTimeBonus = true;
                    }
                }

                if (!hasPointsBonus && row.Value.Contains('%'))//bonus points
                {
                    if (RandomGenerator(30))
                    {
                        hasPointsBonus = true;
                    }
                }

                levelData[rowNumber] += row.Value;
                rowNumber++;
            }


            return new Level() { Data = levelData, Width = levelWidth, Height = levelHeight, HasPointsBonus = hasPointsBonus, HasTimeBonus = hasTimeBonus };
        }

        private bool RandomGenerator(int percentage)
        {
            Random gen = new Random();
            int prob = gen.Next(100);
            if (prob < percentage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
