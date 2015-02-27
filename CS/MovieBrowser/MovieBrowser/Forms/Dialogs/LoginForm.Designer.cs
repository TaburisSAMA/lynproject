namespace MovieBrowser.Forms.Dialogs
{
    partial class LoginForm
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
            this.themedLabel1 = new WindowsFormsAero.ThemeText.ThemedLabel();
            this.themedLabel2 = new WindowsFormsAero.ThemeText.ThemedLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.textUsername = new WindowsFormsAero.TextBox();
            this.textPassword = new WindowsFormsAero.TextBox();
            this.clLogin = new WindowsFormsAero.CommandLink();
            this.commandLink1 = new WindowsFormsAero.CommandLink();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // themedLabel1
            // 
            this.themedLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.themedLabel1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themedLabel1.Location = new System.Drawing.Point(0, 0);
            this.themedLabel1.Name = "themedLabel1";
            this.themedLabel1.Size = new System.Drawing.Size(488, 48);
            this.themedLabel1.TabIndex = 1;
            this.themedLabel1.Text = "Log In";
            this.themedLabel1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.themedLabel1.TextAlignVertical = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            // 
            // themedLabel2
            // 
            this.themedLabel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.themedLabel2.Font = new System.Drawing.Font("Candara", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themedLabel2.Location = new System.Drawing.Point(0, 205);
            this.themedLabel2.Name = "themedLabel2";
            this.themedLabel2.Padding = new System.Windows.Forms.Padding(5);
            this.themedLabel2.Size = new System.Drawing.Size(488, 48);
            this.themedLabel2.TabIndex = 2;
            this.themedLabel2.Text = "Login or use anonymous access";
            this.themedLabel2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.themedLabel2.TextAlignVertical = System.Windows.Forms.VisualStyles.VerticalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // textUsername
            // 
            this.textUsername.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.Location = new System.Drawing.Point(12, 87);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(232, 39);
            this.textUsername.TabIndex = 4;
            // 
            // textPassword
            // 
            this.textPassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword.Location = new System.Drawing.Point(12, 158);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(232, 39);
            this.textPassword.TabIndex = 5;
            this.textPassword.UseSystemPasswordChar = true;
            // 
            // clLogin
            // 
            this.clLogin.Cursor = System.Windows.Forms.Cursors.Default;
            this.clLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clLogin.Location = new System.Drawing.Point(250, 65);
            this.clLogin.Name = "clLogin";
            this.clLogin.Note = "Please Login";
            this.clLogin.ShowShield = true;
            this.clLogin.Size = new System.Drawing.Size(226, 63);
            this.clLogin.TabIndex = 6;
            this.clLogin.Text = "Log In";
            this.clLogin.UseVisualStyleBackColor = true;
            this.clLogin.Click += new System.EventHandler(this.clLogin_Click);
            // 
            // commandLink1
            // 
            this.commandLink1.Cursor = System.Windows.Forms.Cursors.Default;
            this.commandLink1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.commandLink1.Location = new System.Drawing.Point(250, 134);
            this.commandLink1.Name = "commandLink1";
            this.commandLink1.Note = "Anonymous";
            this.commandLink1.Size = new System.Drawing.Size(226, 63);
            this.commandLink1.TabIndex = 7;
            this.commandLink1.Text = "Guest";
            this.commandLink1.UseVisualStyleBackColor = true;
            this.commandLink1.Click += new System.EventHandler(this.commandLink1_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.clLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 253);
            this.Controls.Add(this.commandLink1);
            this.Controls.Add(this.clLogin);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.themedLabel2);
            this.Controls.Add(this.themedLabel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log In";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private WindowsFormsAero.ThemeText.ThemedLabel themedLabel1;
        private WindowsFormsAero.ThemeText.ThemedLabel themedLabel2;
        private System.Windows.Forms.Label label2;
        private WindowsFormsAero.TextBox textUsername;
        private WindowsFormsAero.TextBox textPassword;
        private WindowsFormsAero.CommandLink clLogin;
        private WindowsFormsAero.CommandLink commandLink1;
    }
}