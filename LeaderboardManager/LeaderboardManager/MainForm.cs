using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeaderboardManager.Models;

namespace LeaderboardManager
{
    public partial class MainForm : Form
    {
		DBService database = new DBService();
        public MainForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            RefreshList();
		}

        private void addLeaderboardBtn_Click(object sender, EventArgs e)
        {
            using (AddForm addForm = new AddForm())
            {
                addForm.ShowDialog();
                RefreshList();
            }
        }

        private void leaderboardsListBox_Click(object sender, EventArgs e)
        {
            int index = this.leaderboardsListBox.IndexFromPoint((e as MouseEventArgs).Location);

            if (index != -1)
            {
                Leaderboard leaderboard = database.GetLeaderboardById(database.GetAllLeaderboards()[index].Id);

                if (leaderboard != null)
                {
                    using (LeaderboardForm form = new LeaderboardForm(leaderboard))
                    {
                        form.ShowDialog();
                        RefreshList();
                    }

                    return;
                }
                else
                {
                    MessageBox.Show("Selected leaderboard doesn't exist.");
                }
            }
        }

        private void RefreshList()
        {
            //Pull all leaderboards from DB
            List<Leaderboard> result = database.GetAllLeaderboards();
            leaderboardsListBox.DataSource = result;
        }
    }
}
