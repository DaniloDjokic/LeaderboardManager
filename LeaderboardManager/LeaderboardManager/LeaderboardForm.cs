using LeaderboardManager.Models;
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
    public partial class LeaderboardForm : Form
    {
        private Leaderboard leaderboard;

        public LeaderboardForm(Leaderboard leaderboard)
        {
            InitializeComponent();

            this.leaderboard = leaderboard;

            leaderboardDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            leaderboardDataGridView.AllowUserToAddRows = false;
            leaderboardDataGridView.DataSource = leaderboard.Entries;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AuthForm form = new AuthForm(false);
            form.ShowDialog();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm(leaderboard);
            form.ShowDialog();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            AuthForm form = new AuthForm(true);
            form.ShowDialog();
        }
    }
}
