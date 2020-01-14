namespace LeaderboardManager
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.formatTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.algorithmDropdown = new System.Windows.Forms.ComboBox();
            this.confirmBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.errorLbl = new System.Windows.Forms.Label();
            this.formatTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.keyLbl = new System.Windows.Forms.Label();
            this.ivLbl = new System.Windows.Forms.Label();
            this.keyTxt = new System.Windows.Forms.TextBox();
            this.ivTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password";
            // 
            // passwordTxt
            // 
            this.passwordTxt.Location = new System.Drawing.Point(219, 66);
            this.passwordTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordTxt.Name = "passwordTxt";
            this.passwordTxt.PasswordChar = '*';
            this.passwordTxt.Size = new System.Drawing.Size(175, 22);
            this.passwordTxt.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Algorithm";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // formatTxt
            // 
            this.formatTxt.Location = new System.Drawing.Point(218, 168);
            this.formatTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.formatTxt.Name = "formatTxt";
            this.formatTxt.Size = new System.Drawing.Size(175, 22);
            this.formatTxt.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Format";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // algorithmDropdown
            // 
            this.algorithmDropdown.FormattingEnabled = true;
            this.algorithmDropdown.Location = new System.Drawing.Point(218, 114);
            this.algorithmDropdown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.algorithmDropdown.Name = "algorithmDropdown";
            this.algorithmDropdown.Size = new System.Drawing.Size(175, 24);
            this.algorithmDropdown.TabIndex = 8;
            this.algorithmDropdown.SelectedIndexChanged += new System.EventHandler(this.algorithmDropdown_SelectedIndexChanged);
            // 
            // confirmBtn
            // 
            this.confirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmBtn.Location = new System.Drawing.Point(53, 319);
            this.confirmBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(141, 42);
            this.confirmBtn.TabIndex = 9;
            this.confirmBtn.Text = "CONFIRM";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(252, 319);
            this.backBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(141, 42);
            this.backBtn.TabIndex = 10;
            this.backBtn.Text = "BACK";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // errorLbl
            // 
            this.errorLbl.AutoSize = true;
            this.errorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.errorLbl.Location = new System.Drawing.Point(49, 254);
            this.errorLbl.Name = "errorLbl";
            this.errorLbl.Size = new System.Drawing.Size(0, 29);
            this.errorLbl.TabIndex = 11;
            // 
            // formatTooltip
            // 
            this.formatTooltip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(219, 17);
            this.nameTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(175, 22);
            this.nameTxt.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 29);
            this.label5.TabIndex = 12;
            this.label5.Text = "Name";
            // 
            // keyLbl
            // 
            this.keyLbl.AutoSize = true;
            this.keyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyLbl.Location = new System.Drawing.Point(48, 215);
            this.keyLbl.Name = "keyLbl";
            this.keyLbl.Size = new System.Drawing.Size(57, 29);
            this.keyLbl.TabIndex = 14;
            this.keyLbl.Text = "Key";
            // 
            // ivLbl
            // 
            this.ivLbl.AutoSize = true;
            this.ivLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ivLbl.Location = new System.Drawing.Point(48, 267);
            this.ivLbl.Name = "ivLbl";
            this.ivLbl.Size = new System.Drawing.Size(36, 29);
            this.ivLbl.TabIndex = 15;
            this.ivLbl.Text = "IV";
            // 
            // keyTxt
            // 
            this.keyTxt.Location = new System.Drawing.Point(218, 222);
            this.keyTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.keyTxt.Name = "keyTxt";
            this.keyTxt.ReadOnly = true;
            this.keyTxt.Size = new System.Drawing.Size(175, 22);
            this.keyTxt.TabIndex = 16;
            // 
            // ivTxt
            // 
            this.ivTxt.Location = new System.Drawing.Point(218, 274);
            this.ivTxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ivTxt.Name = "ivTxt";
            this.ivTxt.ReadOnly = true;
            this.ivTxt.Size = new System.Drawing.Size(175, 22);
            this.ivTxt.TabIndex = 17;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 382);
            this.Controls.Add(this.ivTxt);
            this.Controls.Add(this.keyTxt);
            this.Controls.Add(this.ivLbl);
            this.Controls.Add(this.keyLbl);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.errorLbl);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.algorithmDropdown);
            this.Controls.Add(this.formatTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.passwordTxt);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox formatTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox algorithmDropdown;
        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label errorLbl;
        private System.Windows.Forms.ToolTip formatTooltip;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label keyLbl;
        private System.Windows.Forms.Label ivLbl;
        private System.Windows.Forms.TextBox keyTxt;
        private System.Windows.Forms.TextBox ivTxt;
    }
}