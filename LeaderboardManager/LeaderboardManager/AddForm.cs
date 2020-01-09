using LeaderboardManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeaderboardManager
{
    public partial class AddForm : Form
    {
        public Leaderboard selectedLeaderboard = null;
        public AddForm()
        {
            InitializeComponent();

            algorithmDropdown.DataSource = Enum.GetValues(typeof(CryptoAlgo));
            algorithmDropdown.SelectedItem = CryptoAlgo.RC2;

            formatTooltip.InitialDelay = 20;
            formatTooltip.SetToolTip(label4, "Click on label for help.");
        }

        public AddForm(Leaderboard leaderboard)
        {
            InitializeComponent();

            selectedLeaderboard = leaderboard;

            //Treba da se ubaci i za Key i za IV
            //keyTxt.Text = leaderboard.Key;
            algorithmDropdown.DataSource = Enum.GetValues(typeof(CryptoAlgo));
            algorithmDropdown.SelectedItem = leaderboard.Algorithm;
            formatTxt.Text = leaderboard.Format;

            formatTooltip.InitialDelay = 20;
            formatTooltip.SetToolTip(label4, "Click on label for help.");
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(nameTxt.Text))
            {
                DisplayError("Name is empty");
                return false;
            }
            if(string.IsNullOrWhiteSpace(passwordTxt.Text))
            {
                DisplayError("Password is empty");
                return false;
            }
            if (!Formatter.ValidateFormat(formatTxt.Text))
            {
                DisplayError("Format string is not formated correctly.");
                return false;
            }
            return true;
        }

        private void DisplayError(string text)
        {
            errorLbl.Text = text;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if(ValidateInputs())
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                CryptionService cryptionService = new CryptionService((CryptoAlgo)algorithmDropdown.SelectedIndex);
                DBService dBService = new DBService();

                if (selectedLeaderboard == null)
                {
                    Leaderboard leaderboard = new Leaderboard();
                    leaderboard.Algorithm = cryptionService.ChosenAlgo;
                    leaderboard.KeyIVPair = cryptionService.KeyIVPair;
                    //TODO Should display the KeyIVPair to the user
                    leaderboard.Format = formatTxt.Text;
                    leaderboard.Name = nameTxt.Text;
                    leaderboard.Password = sha1.ComputeHash(Encoding.UTF8.GetBytes(passwordTxt.Text));

                    dBService.AddNewLeaderboard(leaderboard);
                }
                else
                {
                    CryptoAlgo newAlgo = (CryptoAlgo)algorithmDropdown.SelectedIndex;

                    //If the user has chosen a new algorithm recalculate keys
                    if (newAlgo != selectedLeaderboard.Algorithm)
                    {
                        selectedLeaderboard.Algorithm = newAlgo;
                        selectedLeaderboard.KeyIVPair = cryptionService.KeyIVPair;
                        //TODO Should display the new KeyIVPair to the user
                    }

                    selectedLeaderboard.Format = formatTxt.Text;
                    selectedLeaderboard.Name = nameTxt.Text;
                    selectedLeaderboard.Password = sha1.ComputeHash(Encoding.UTF8.GetBytes(passwordTxt.Text));

                    dBService.UpdateLeaderboard(selectedLeaderboard);
                }

                this.Close();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Formatter.FormatHelp, "Format help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
