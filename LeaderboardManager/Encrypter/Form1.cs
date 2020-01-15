using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeaderboardManager;

namespace Encrypter
{
    public partial class Encrypter : Form
    {
        private CryptionService cryptionService = null;

        public Encrypter()
        {
            InitializeComponent();
        }

        private void buttonLoadSettings_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cryptionService = new CryptionService(openFileDialog1.FileName);

                    MessageBox.Show("Load successful.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error loading");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxInput.Text) && cryptionService != null)
            {
                textBoxResult.Text = Convert.ToBase64String(cryptionService.EncryptData(Encoding.UTF8.GetBytes(textBoxInput.Text)));
            }
        }
    }
}
