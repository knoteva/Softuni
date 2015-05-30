using System;
using System.Drawing;
using System.Windows.Forms;
using Sokoban.Logic;


namespace Sokoban.Presentation
{
    public partial class LevelSelectionForm : Form
    {
        private Soko soko;
        public int SelectedLevel { get; set; }
        int _cellSize;
        int _paddingX;
        int _paddingY;

        public LevelSelectionForm()
        {
            InitializeComponent();

            soko = new Soko();
        }

        private void levelSelectionGrid_SelectionChanged(object sender, EventArgs e)
        {
            SelectedLevel = levelSelectionGrid.CurrentRow.Index + 1;

            soko.SetCurrentLevel(SelectedLevel);
            soko.LoadLevel();

            _cellSize = levelPreview.Width / Math.Max(soko.Width, soko.Height);
            _paddingX = (levelPreview.Width - (soko.Width * _cellSize)) / 2;
            _paddingY = (levelPreview.Height - (soko.Height * _cellSize)) / 2;

            levelPreview.Invalidate();
        }

        private void LevelSelectionForm_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= this.soko.SelectedCollection.NumberOfLevels; i++)
            {
                levelSelectionGrid.Rows.Add("Level " + i);
            }
        }

        //draw level preview
        private void levelPreview_Paint(object sender, PaintEventArgs e)
        {
            foreach (Element element in soko)
            {
                Bitmap img = null;

                switch (element.Type)
                {
                    case ElementType.Wall:
                        img = Properties.Resources.Wall;
                        break;
                    case ElementType.Box:
                    case ElementType.BoxOnGoal:
                        img = Properties.Resources.Box;
                        break;
                    case ElementType.Goal:
                        img = Properties.Resources.Goal;
                        break;
                    case ElementType.Player:
                    case ElementType.PlayerOnGoal:
                        img = Properties.Resources.Player;
                        break;
                    case ElementType.BonusTime:
                        img = Properties.Resources.Time;
                        break;
                    case ElementType.BonusPoints:
                        img = Properties.Resources.Points;
                        break;

                }

                if (img != null)
                {
                    e.Graphics.DrawImage(img, _paddingX + element.Column * _cellSize,
                                         _paddingY + element.Row * _cellSize,
                                         _cellSize, _cellSize);
                }
            }
        }

        public static DialogResult ShowForm(Soko model)
        {
            using (LevelSelectionForm form = new LevelSelectionForm())
            {
                form.soko = model;
                return form.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            soko.SetCurrentLevel(0);
            soko.IsPlaying = false;
            this.Close();
        }

    }
}
