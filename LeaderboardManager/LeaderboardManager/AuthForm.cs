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
    public partial class AuthForm : Form
    {
        bool isDeleteForm;

        public AuthForm(bool isDeleteForm)
        {
            InitializeComponent();

            this.isDeleteForm = isDeleteForm;

            if (isDeleteForm)
                codeLbl.Text = "Password";
            else
                codeLbl.Text = "Code";
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            //TODO Check input in database
            return true;
        }

        private void DisplayError(string text)
        {
            errorLbl.Text = text;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                if(isDeleteForm)
                {
                    //Delete leaderboard
                }
                else
                {
                    //Add entry to leaderboard 
                }
                this.Close();
            }
            else
            {
                DisplayError($"Invalid {codeLbl.Text}");
            }
        }
    }
}
