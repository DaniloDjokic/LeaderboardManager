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
        private DBService dbService;
        private Leaderboard leaderboard;

        public LeaderboardForm(Leaderboard leaderboard)
        {
            InitializeComponent();

            this.leaderboard = leaderboard;
            this.dbService = new DBService();

            leaderboardDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            leaderboardDataGridView.AllowUserToAddRows = false;
            leaderboardDataGridView.DataSource = leaderboard.Entries;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            using (AuthForm authForm = new AuthForm(AuthFormFunction.PasswordCheck))
            {
                authForm.ShowDialog();

                if (authForm.PassedCheck)
                {
                    //Add entry to leaderboard
                }
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            using (AuthForm authForm = new AuthForm(AuthFormFunction.PasswordCheck, leaderboard.Password))
            {
                authForm.ShowDialog();

                if (authForm.PassedCheck)
                {
                    using (AddForm form = new AddForm(leaderboard))
                    {
                        form.ShowDialog();
                    }
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            using (AuthForm authForm = new AuthForm(AuthFormFunction.PasswordCheck, leaderboard.Password))
            {
                authForm.ShowDialog();

                if (authForm.PassedCheck)
                {
                    try
                    {
                        dbService.DeleteLeaderboardById(leaderboard.Id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Couldn't delete the leaderboard: {ex.Message}", "Delete error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.Close();
                }
            }
        }
    }
}
