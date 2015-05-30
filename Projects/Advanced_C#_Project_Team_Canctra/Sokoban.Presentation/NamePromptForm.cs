using System;
using System.Windows.Forms;

namespace Sokoban.Presentation
{
    public partial class NamePromptForm : Form
    {
        private string _playerName;

        public NamePromptForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            _playerName = nameBox.Text;
        }

        public static string ShowForm()
        {
            using (NamePromptForm form = new NamePromptForm())
            {
                form.ShowDialog();
                return form._playerName;
            }
        }

    }
}
