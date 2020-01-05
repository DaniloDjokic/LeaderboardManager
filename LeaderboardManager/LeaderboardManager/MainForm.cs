using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaderboardManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            //Pull all leaderboards from DB
            leaderboardsListBox.DataSource = MockData.leaderboards;
        }

        private void addLeaderboardBtn_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
        }

        private void leaderboardsListBox_Click(object sender, EventArgs e)
        {
            int index = this.leaderboardsListBox.IndexFromPoint((e as MouseEventArgs).Location);
            LeaderboardForm form = new LeaderboardForm(MockData.leaderboards[index]);
            form.ShowDialog();
        }
    }
}
