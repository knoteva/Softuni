using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Sokoban.Logic;

namespace Sokoban.Presentation
{
    public partial class TopPlayersForm : Form
    {
        private List<TopPlayer> _players = new List<TopPlayer>();
        
        public TopPlayersForm()
        {
            InitializeComponent();
            
            this.Load += TopPlayersForm_Load;
        }

        void TopPlayersForm_Load(object sender, EventArgs e)
        {
            playersGrid.DataSource = new BindingList<TopPlayer>(_players);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playersGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex < 10)
            {
                playersGrid.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
            }
        }

        public static void ShowForm(List<TopPlayer> players)
        {
            using (TopPlayersForm form = new TopPlayersForm())
            {
                form._players = players;
                form.ShowDialog();
            }
        }

    }

}
