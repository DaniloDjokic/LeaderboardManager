namespace LeaderboardManager
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.leaderboardsListBox = new System.Windows.Forms.ListBox();
            this.addLeaderboardBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "LeaderboardManager";
            // 
            // leaderboardsListBox
            // 
            this.leaderboardsListBox.FormattingEnabled = true;
            this.leaderboardsListBox.ItemHeight = 16;
            this.leaderboardsListBox.Location = new System.Drawing.Point(12, 77);
            this.leaderboardsListBox.Name = "leaderboardsListBox";
            this.leaderboardsListBox.Size = new System.Drawing.Size(522, 340);
            this.leaderboardsListBox.TabIndex = 1;
            // 
            // addLeaderboardBtn
            // 
            this.addLeaderboardBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLeaderboardBtn.Location = new System.Drawing.Point(157, 423);
            this.addLeaderboardBtn.Name = "addLeaderboardBtn";
            this.addLeaderboardBtn.Size = new System.Drawing.Size(216, 53);
            this.addLeaderboardBtn.TabIndex = 2;
            this.addLeaderboardBtn.Text = "ADD";
            this.addLeaderboardBtn.UseVisualStyleBackColor = true;
            this.addLeaderboardBtn.Click += new System.EventHandler(this.addLeaderboardBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 488);
            this.Controls.Add(this.addLeaderboardBtn);
            this.Controls.Add(this.leaderboardsListBox);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox leaderboardsListBox;
        private System.Windows.Forms.Button addLeaderboardBtn;
    }
}

