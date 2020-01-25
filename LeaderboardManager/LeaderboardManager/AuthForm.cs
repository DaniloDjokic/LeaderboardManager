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
using LeaderboardManagerClientLibrary;

namespace LeaderboardManager
{
    public enum AuthFormFunction
    {
        PasswordCheck,
        InputCheck
    }

    public partial class AuthForm : Form
    {
        byte[] HashedPassword;
        AuthFormFunction function;
        SHA1 sha1;
        CryptionService cryptionService;
        string format;

        public bool PassedCheck { get; private set; }
        public UserInfo ParsedCode { get; private set; }


        public AuthForm(AuthFormFunction authFormFunction, byte[] hashedPassword = null, string format = null, CryptionService cryptionService = null)
        {
            InitializeComponent();

            PassedCheck = false;

            this.function = authFormFunction;
            this.format = format;
            this.HashedPassword = hashedPassword;
            this.cryptionService = cryptionService;

            switch (function)
            {
                case AuthFormFunction.PasswordCheck:
                    codeLbl.Text = "Password";
                    if (hashedPassword == null || hashedPassword.Length != 20)
                    {
                        throw new ArgumentException();
                    }
                    sha1 = new SHA1CryptoServiceProvider();
                    break;
                case AuthFormFunction.InputCheck:
                    codeLbl.Text = "Code";
                    if (format == null || cryptionService == null)
                    {
                        throw new ArgumentException();
                    }
                    break;
                default:
                    break;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            switch (function)
            {
                case AuthFormFunction.PasswordCheck:
                    return ValidatePassword();
                case AuthFormFunction.InputCheck:
                    return ValidateCode();
                default:
                    break;
            }

            return true;
        }

        private bool ValidateCode()
        {
            try
            {
                byte[] decryptedInput = cryptionService.DecryptData(Convert.FromBase64String(codeTxt.Text));
                string code = Encoding.UTF8.GetString(decryptedInput);

                UserInfo userInfo = Formatter.Parse(code, format);

                ParsedCode = userInfo;

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error while parsing code", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ValidatePassword()
        {
            byte[] hashInput = sha1.ComputeHash(Encoding.UTF8.GetBytes(codeTxt.Text));

            return HashedPassword.SequenceEqual(hashInput);
        }

        private void DisplayError(string text)
        {
            errorLbl.Text = text;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                PassedCheck = true;

                this.Close();
            }
            else
            {
                DisplayError($"Invalid {codeLbl.Text}");
            }
        }
    }
}
