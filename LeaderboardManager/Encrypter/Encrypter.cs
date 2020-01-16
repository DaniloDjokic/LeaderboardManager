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
    public partial class Encrypter : Form
    {
        private CryptionService cryptionService = null;
        private FormatInput formatInput = null;

        public Encrypter()
        {
            InitializeComponent();
            formatInput = new FormatInput();
        }

        private void buttonLoadSettings_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cryptionService = new CryptionService(openFileDialog1.FileName);

                    DisplayFeedback("Settings load successful.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading");
                    cryptionService = null;
                }
            }
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (cryptionService == null)
                {
                    DisplayFeedback("No loaded cryption settings!");
                    return;
                }

                if (formatInput.Format == null)
                {
                    DisplayFeedback("No loaded format!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    DisplayFeedback("You haven't defined a name!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxScore.Text) || !double.TryParse(textBoxScore.Text, out double _))
                {
                    DisplayFeedback("You haven't defined a valid score!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxComment.Text))
                {
                    DisplayFeedback("You haven't defined a comment!");
                    return;
                }

                UserInfo userInfo = new UserInfo();
                userInfo.Name = textBoxName.Text;
                userInfo.Score = double.Parse(textBoxScore.Text);
                userInfo.Comment = textBoxComment.Text;

                string formattedString = Formatter.GenerateFormattedString(formatInput.Format, userInfo);
                if (!string.IsNullOrWhiteSpace(formattedString))
                {
                    textBoxResult.Text = Convert.ToBase64String(cryptionService.EncryptData(Encoding.UTF8.GetBytes(formattedString)));
                    DisplayFeedback("Encryption successful.");
                }
                else
                {
                    DisplayFeedback("Couldn't format the values.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error formatting and encrypting");
            }
        }

        private void buttonFormatInput_Click(object sender, EventArgs e)
        {
            if (formatInput.ShowDialog() == DialogResult.OK)
            {
                DisplayFeedback("Format load successful.");
            }
            else
            {
                DisplayFeedback("No format loaded.");
            }
        }

        private void DisplayFeedback(string text)
        {
            labelDisplay.Text = text;
        }
    }
}
