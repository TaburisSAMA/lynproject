namespace GREWordStudy.Collector
{
    partial class SingleWordCollectorForm
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
            this.comboBoxList = new System.Windows.Forms.ComboBox();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.textBoxWord = new System.Windows.Forms.TextBox();
            this.buttonCollect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxList
            // 
            this.comboBoxList.DisplayMember = "Name";
            this.comboBoxList.FormattingEnabled = true;
            this.comboBoxList.Location = new System.Drawing.Point(12, 12);
            this.comboBoxList.Name = "comboBoxList";
            this.comboBoxList.Size = new System.Drawing.Size(260, 21);
            this.comboBoxList.TabIndex = 13;
            this.comboBoxList.ValueMember = "Id";
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxInfo.Location = new System.Drawing.Point(0, 122);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxInfo.Size = new System.Drawing.Size(284, 140);
            this.textBoxInfo.TabIndex = 21;
            // 
            // textBoxWord
            // 
            this.textBoxWord.Location = new System.Drawing.Point(12, 39);
            this.textBoxWord.Name = "textBoxWord";
            this.textBoxWord.Size = new System.Drawing.Size(179, 20);
            this.textBoxWord.TabIndex = 22;
            // 
            // buttonCollect
            // 
            this.buttonCollect.Location = new System.Drawing.Point(197, 36);
            this.buttonCollect.Name = "buttonCollect";
            this.buttonCollect.Size = new System.Drawing.Size(75, 23);
            this.buttonCollect.TabIndex = 23;
            this.buttonCollect.Text = "Collect";
            this.buttonCollect.UseVisualStyleBackColor = true;
            this.buttonCollect.Click += new System.EventHandler(this.buttonCollect_Click);
            // 
            // SingleWordCollectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonCollect);
            this.Controls.Add(this.textBoxWord);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.comboBoxList);
            this.Name = "SingleWordCollectorForm";
            this.Text = "SingleWordCollectorForm";
            this.Load += new System.EventHandler(this.SingleWordCollectorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxList;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.TextBox textBoxWord;
        private System.Windows.Forms.Button buttonCollect;
    }
}