using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeaderboardManagerClientLibrary;

namespace Encrypter
{
    public partial class FormatInput : Form
    {
        public string Format { get; private set; } = null;

        public FormatInput()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = Formatter.ValidateFormat(textBoxInput.Text);

                if (!result)
                {
                    DisplayFeedback("The specified format is invalid. Check format help.");
                    DialogResult = DialogResult.None;
                }
                else
                {
                    Format = textBoxInput.Text;
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                DisplayFeedback($"Error validating the specified format: {ex.Message}");
            }
        }

        private void DisplayFeedback(string text)
        {
            labelDisplay.Text = text;
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Formatter.FormatHelp, "Format Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
