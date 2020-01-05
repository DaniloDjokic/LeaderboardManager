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

            algorithmDropdown.DataSource = Enum.GetValues(typeof(CrypotAlgo));
            algorithmDropdown.SelectedItem = CrypotAlgo.RC4;

            formatTooltip.InitialDelay = 20;
            formatTooltip.SetToolTip(formatTxt, "Text for tooltip");
        }

        private bool ValidateInputs()
        {
            if(passwordTxt.Text == "")
            {
                DisplayError("Password is empty");
                return false;
            }
            if(keyTxt.Text == "")
            {
                DisplayError("Key is empty");
                return false;
            }
            if (formatTxt.Text == "")
            {
                DisplayError("Format is empty");
                return false;
            }
            if (!ValidateFormat())
            {
                DisplayError("Format is not in the correct format");
                return false;
            }
            return true;
        }

        private bool ValidateFormat()
        {
            //TODO add format validation
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
                //TODO add new leaderboard to db
                this.Close();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
