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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();

            algorithmDropdown.DataSource = Enum.GetValues(typeof(CryptoAlgo));
            algorithmDropdown.SelectedItem = CryptoAlgo.RC4;

            formatTooltip.InitialDelay = 20;
            formatTooltip.SetToolTip(label4, "Click on label for help.");
        }

        public AddForm(Leaderboard leaderboard)
        {
            InitializeComponent();

            passwordTxt.Text = leaderboard.Password;
            keyTxt.Text = leaderboard.Key;
            algorithmDropdown.DataSource = Enum.GetValues(typeof(CryptoAlgo));
            algorithmDropdown.SelectedItem = leaderboard.Algorithm;
            formatTxt.Text = leaderboard.Format;

            formatTooltip.InitialDelay = 20;
            formatTooltip.SetToolTip(label4, "Click on label for help.");
        }

        private bool ValidateInputs()
        {
            if(passwordTxt.Text == "")
            {
                DisplayError("Password is empty");
                return false;
            }
            if(!ValidateKey())
            {
                DisplayError("Key is empty");
                return false;
            }
            if (formatTxt.Text == "")
            {
                DisplayError("Format is empty");
                return false;
            }
            if (!Formatter.ValidateFormat(formatTxt.Text))
            {
                DisplayError("Format string is not formated correctly.");
                return false;
            }
            return true;
        }

        private bool ValidateKey()
        {
            CryptionService cryptionService = new CryptionService((CryptoAlgo) algorithmDropdown.SelectedItem);
            return cryptionService.ValidateKey(keyTxt.Text);
        }

        private void DisplayError(string text)
        {
            errorLbl.Text = text;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if(ValidateInputs())
            {
                //TODO add new leaderboard to db
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
