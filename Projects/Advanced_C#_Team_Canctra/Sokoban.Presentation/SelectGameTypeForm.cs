using System;
using System.Windows.Forms;
using Sokoban.Logic;


namespace Sokoban.Presentation
{
    public partial class SelectGameTypeForm : Form
    {
        public GameType Game { get; set; }
        public SelectGameTypeForm()
        {
            InitializeComponent();
            this.Game = GameType.None;
            this.btnPractice.Click += btnPractice_Click;
            this.btnStandart.Click += btnStandart_Click;
        }

        void btnStandart_Click(object sender, EventArgs e)
        {
            this.Game = GameType.Standart;
            this.Close();
        }

        void btnPractice_Click(object sender, EventArgs e)
        {
            this.Game = GameType.Practice;
            this.Close();
        }

        public static GameType ShowForm()
        {
            using (SelectGameTypeForm form = new SelectGameTypeForm())
            {
                form.ShowDialog();
                return form.Game;
            }
        }
    }
}
