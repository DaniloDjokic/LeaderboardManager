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
            leaderboardDataGridView.DataSource = dbService.GetFullEntries(leaderboard.Id).ToList();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            CryptionService cryptionService = new CryptionService(leaderboard.Algorithm, leaderboard.KeyIVPair.Key, leaderboard.KeyIVPair.IV);
            using (AuthForm authForm = new AuthForm(AuthFormFunction.InputCheck, format: leaderboard.Format, cryptionService: cryptionService))
            {
                authForm.ShowDialog();

                if (authForm.PassedCheck)
                {
                    try
                    {
                        dbService.AddNewEntry(leaderboard, new Entry()
                        {
                            Message = authForm.ParsedCode.comment,
                            Name = authForm.ParsedCode.name,
                            Points = authForm.ParsedCode.value
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Couldn't add new entry: {ex.Message}", "New entry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
				RefreshList();
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

        private void RefreshList()
        {
	        leaderboardDataGridView.DataSource = dbService.GetFullEntries(leaderboard.Id).ToList();
		}
    }
}
