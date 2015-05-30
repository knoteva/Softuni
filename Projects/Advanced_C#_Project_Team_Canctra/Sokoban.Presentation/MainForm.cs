using System;
using System.Drawing;
using System.Windows.Forms;
using Sokoban.Logic;

namespace Sokoban.Presentation
{
    public partial class MainForm : Form
    {
        #region Variables
        public Soko Model { get; set; }
        private readonly int _cellSize = Properties.Resources.Wall.Width;
        private readonly int _defaultFormWidth;
        private readonly int _defaultFormHeight;
        private readonly int _defaultBackgroundPanelWidth;
        private readonly int _defaultBackgroundPanelHeight;
        private bool PlayerFacesRight = false;

        #endregion Variables

        public MainForm()
        {
            InitializeComponent();

            _defaultFormWidth = Width;
            _defaultFormHeight = Height;

            _defaultBackgroundPanelWidth = backgroundPanel.Width;
            _defaultBackgroundPanelHeight = backgroundPanel.Height;

            this.undoButton.Click += undoButton_Click;
            this.undoButton.Enabled = false;
            this.restartButton.Click += restartButton_Click;
            this.restartButton.Enabled = false;
            this.newGameMenuItem.Click += newGameMenuItem_Click;
            this.exitMenuItem.Click += exitMenuItem_Click;
            this.drawingArea.Paint += drawingArea_Paint;
            this.KeyDown += MainForm_KeyDown;
            this.Load += MainForm_Load;
            this.timer1.Tick += timer1_Tick;
        }

        #region Events

        void MainForm_Load(object sender, EventArgs e)
        {
            this.Model = new Soko();
            this.Model.LevelCompleted += Model_LevelCompleted;
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            this.Model.TimeLeft--;
            this.timerLabel.Text = this.Model.TimeLeft.ToString().PadLeft(2, '0');
            if (this.Model.TimeLeft <= 0)
            {
                timer1.Stop();
                this.statusLabel.Text = "Please press enter to restart..";
            }
        }

        void Model_LevelCompleted(object sender, EventArgs e)
        {
            restartButton.Enabled = false;
            undoButton.Enabled = false;
            pointsLabel.Text = this.Model.TotalScore.ToString();
            timer1.Stop();

            if (this.Model.GameType == GameType.Standart && this.Model.IsLastLevel)
            {
                statusLabel.Text = "Level Completed! No more levels in the collection.";

                //top score check call
                if (this.Model.HasTopScore)
                {
                    drawingArea.Invalidate();
                    ShowNamePromptForm();
                }
            }
            else
            {
                if (this.Model.GameType == GameType.Standart)
                {
                    statusLabel.Text = "Level Completed! Press enter to go to the next level...";
                }
                else if (this.Model.GameType == GameType.Practice)
                {
                    statusLabel.Text = "Level Completed! Press enter to go to menu...";
                }
            }

            drawingArea.Invalidate();
        }

        void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Model.SelectedCollection == null)
            {
                return;
            }

            if (this.Model.TimeLeft == 0 && e.KeyCode == Keys.Enter)
            {
                RestartLevel();
            }

            if (this.Model.IsLevelCompleted)
            {
                if (!this.Model.IsLastLevel && e.KeyCode == Keys.Enter)
                {
                    if (this.Model.GameType == GameType.Standart)
                    {
                        this.Model.NextLevel();
                        StartLevel();
                        StartTimer();
                    }
                    else if (this.Model.GameType == GameType.Practice)
                    {
                        StartPractice();
                    }
                }
            }
            else
            {
                bool hasMoved = false;
                if ((this.Model.GameType == GameType.Standart && this.Model.TimeLeft > 0) || this.Model.GameType == GameType.Practice)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Up:
                            hasMoved = this.Model.MovePlayer(Soko.MoveDirection.Up);
                            break;
                        case Keys.Down:
                            hasMoved = this.Model.MovePlayer(Soko.MoveDirection.Down);
                            break;
                        case Keys.Right:
                            PlayerFacesRight = true;
                            hasMoved = this.Model.MovePlayer(Soko.MoveDirection.Right);
                            break;
                        case Keys.Left:
                            PlayerFacesRight = false;
                            hasMoved = this.Model.MovePlayer(Soko.MoveDirection.Left);
                            break;
                        case Keys.Space:
                            // for testing...
                            break;
                        case Keys.Back:
                            UndoMovement();
                            break;
                    }
                }
                if (hasMoved)
                {
                    if (this.Model.GameType == GameType.Standart)
                    {
                        this.pointsLabel.Text = this.Model.StartScore.ToString();
                    }

                    if (!this.Model.IsLevelCompleted)
                    {
                        undoButton.Enabled = true;
                    }
                }

                drawingArea.Invalidate();
            }
        }

        void drawingArea_Paint(object sender, PaintEventArgs e)
        {
            if (this.Model.Collections != null)
            {
                foreach (Element element in this.Model)
                {
                    Bitmap imageToDraw = null;

                    switch (element.Type)
                    {
                        case ElementType.Wall:
                            imageToDraw = Properties.Resources.Wall;
                            break;
                        case ElementType.Box:
                        case ElementType.BoxOnGoal:
                            imageToDraw = Properties.Resources.Box;
                            break;
                        case ElementType.Goal:
                            imageToDraw = Properties.Resources.Goal;
                            break;
                        case ElementType.Player:
                        case ElementType.PlayerOnGoal:
                            if (PlayerFacesRight) { imageToDraw = Properties.Resources.PlayerRight; }
                            else { imageToDraw = Properties.Resources.Player; }
                            break;
                        case ElementType.BonusTime:
                            imageToDraw = Properties.Resources.Time;
                            break;
                        case ElementType.BonusPoints:
                            imageToDraw = Properties.Resources.Points;
                            break;
                    }

                    if (imageToDraw != null)
                    {
                        e.Graphics.DrawImage(imageToDraw, element.Column * _cellSize, element.Row * _cellSize, _cellSize,
                                             _cellSize);
                    }
                }
            }
        }

        void topRankingMenuItem_Click(object sender, EventArgs e)
        {
            TopPlayersForm.ShowForm(this.Model.GetTopPlayers());
        }

        void exitMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Model.IsPlaying)
            {
                if (DialogResult.Yes ==
                    MessageBox.Show("Do you want to close the current game?", "Attention",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        void newGameMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Model.IsPlaying)
            {
                if (DialogResult.Yes ==
                    MessageBox.Show("Do you want to start a new game?", "Attention",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    StartGame();
                }
            }
            else
            {
                StartGame();
            }

        }

        void restartButton_Click(object sender, EventArgs e)
        {
            RestartLevel();
        }

        void undoButton_Click(object sender, EventArgs e)
        {
            UndoMovement();
        }

        #endregion Events

        #region Methods

        private void StartGame()
        {
            this.Model.GameType = SelectGameTypeForm.ShowForm();
            if (GameType.Standart == this.Model.GameType)
            {
                this.Model.StartStandartGame();
                StartLevel();
                StartTimer();
                pointsLabel.Text = this.Model.TotalScore.ToString();
                timerLabel.Text = this.Model.TimeLeft.ToString();
            }
            else if (GameType.Practice == this.Model.GameType)
            {
                StartPractice();
                timer1.Stop();
            }
        }

        private void StartPractice()
        {
        	timer1.Stop();
            this.Model.SetCurrentLevel(1);

            if (DialogResult.OK == LevelSelectionForm.ShowForm(this.Model))
            {
                this.Model.StartPractice();
                pointsLabel.Text = this.Model.TotalScore.ToString();
                StartLevel();
            }
        }

        private void StartTimer()
        {
            timer1.Stop();
            timer1.Interval = 1000;
            timer1.Start();
        }

        private void StartLevel()
        {
            drawingArea.Width = this.Model.GetSelectedCollectionWidth() * _cellSize;
            drawingArea.Height = this.Model.GetSelectedCollectionHeight() * _cellSize;

            int formNewWidth = drawingArea.Width > _defaultBackgroundPanelWidth
                                   ? _defaultFormWidth + drawingArea.Width - _defaultBackgroundPanelWidth + 10
                                   : _defaultFormWidth;
            int formNewHeight = drawingArea.Height > _defaultBackgroundPanelHeight
                                    ? _defaultFormHeight + drawingArea.Height - _defaultBackgroundPanelHeight + 10
                                    : _defaultFormHeight;

            Size = new Size(formNewWidth, formNewHeight);

            int x = backgroundPanel.Size.Width / 2 - drawingArea.Size.Width / 2;
            int y = backgroundPanel.Size.Height / 2 - drawingArea.Size.Height / 2;
            drawingArea.Location = new Point(x, y);

            this.Model.IsLevelCompleted = false;

            statusLabel.Text = "Playing";
            levelLabel.Text = string.Format("{0} of {1}", this.Model.CurrentLevel, this.Model.SelectedCollection.NumberOfLevels);


            restartButton.Enabled = true;
            undoButton.Enabled = false;

            drawingArea.Invalidate();
            drawingArea.Visible = true;
        }

        private void RestartLevel()
        {
            if (Model.CurrentLevel == 0)
            {
                return;
            }
            this.Model.RestartLevel();
            StartLevel();
            if (this.Model.GameType == GameType.Standart)
            {
                StartTimer();
                this.pointsLabel.Text = this.Model.StartScore.ToString();
            }
        }

        void ShowNamePromptForm()
        {
            string playerName = NamePromptForm.ShowForm();
            if (string.IsNullOrWhiteSpace(playerName))
            {
                playerName = "Unknown";
            }

            this.Model.SavePlayer(playerName);
        }

        private void UndoMovement()
        {
            this.Model.UndoMovement();
            if (Model.GameType == GameType.Standart)
            {
                this.pointsLabel.Text = this.Model.StartScore.ToString();
                this.timerLabel.Text = this.Model.TimeLeft.ToString();
            }
            undoButton.Enabled = this.Model.MovesHistoryCount > 0;

            drawingArea.Invalidate();
        }

        #endregion Methods
    }
}
