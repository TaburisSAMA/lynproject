﻿namespace GREWordStudy.Study
{
    partial class StickyBrowser
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
            this.maxBrowser1 = new GREWordStudy.Common.Browser.MaxBrowser();
            this.SuspendLayout();
            // 
            // maxBrowser1
            // 
            this.maxBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.maxBrowser1.Location = new System.Drawing.Point(0, 0);
            this.maxBrowser1.Name = "maxBrowser1";
            this.maxBrowser1.Size = new System.Drawing.Size(284, 262);
            this.maxBrowser1.TabIndex = 1;
            // 
            // StickyBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.maxBrowser1);
            this.Name = "StickyBrowser";
            this.Text = "StickyBrowser";
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Browser.MaxBrowser maxBrowser1;
    }
}