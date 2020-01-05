namespace LeaderboardManager
{
    partial class AuthForm
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
            this.confirmBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.codeLbl = new System.Windows.Forms.Label();
            this.codeTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // confirmBtn
            // 
            this.confirmBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmBtn.Location = new System.Drawing.Point(12, 113);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(131, 51);
            this.confirmBtn.TabIndex = 0;
            this.confirmBtn.Text = "CONFIRM";
            this.confirmBtn.UseVisualStyleBackColor = true;
            // 
            // backBtn
            // 
            this.backBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.Location = new System.Drawing.Point(194, 113);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(132, 51);
            this.backBtn.TabIndex = 1;
            this.backBtn.Text = "BACK";
            this.backBtn.UseVisualStyleBackColor = true;
            // 
            // codeLbl
            // 
            this.codeLbl.AutoSize = true;
            this.codeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeLbl.Location = new System.Drawing.Point(51, 37);
            this.codeLbl.Name = "codeLbl";
            this.codeLbl.Size = new System.Drawing.Size(92, 29);
            this.codeLbl.TabIndex = 2;
            this.codeLbl.Text = "CODE:";
            // 
            // codeTxt
            // 
            this.codeTxt.Location = new System.Drawing.Point(194, 44);
            this.codeTxt.Name = "codeTxt";
            this.codeTxt.Size = new System.Drawing.Size(122, 22);
            this.codeTxt.TabIndex = 3;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 176);
            this.Controls.Add(this.codeTxt);
            this.Controls.Add(this.codeLbl);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.confirmBtn);
            this.Name = "AuthForm";
            this.Text = "AuthForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label codeLbl;
        private System.Windows.Forms.TextBox codeTxt;
    }
}