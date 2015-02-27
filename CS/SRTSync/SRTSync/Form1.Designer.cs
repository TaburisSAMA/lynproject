namespace SRTSync
{
    partial class Form1
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
            this.textSrtRef = new System.Windows.Forms.TextBox();
            this.textMovieRef = new System.Windows.Forms.TextBox();
            this.textOffset = new System.Windows.Forms.TextBox();
            this.buttonShift = new System.Windows.Forms.Button();
            this.textSrtFile = new System.Windows.Forms.TextBox();
            this.buttonOpenSrt = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonReSync = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textSrtRef
            // 
            this.textSrtRef.Location = new System.Drawing.Point(24, 35);
            this.textSrtRef.Name = "textSrtRef";
            this.textSrtRef.Size = new System.Drawing.Size(100, 20);
            this.textSrtRef.TabIndex = 0;
            // 
            // textMovieRef
            // 
            this.textMovieRef.Location = new System.Drawing.Point(130, 35);
            this.textMovieRef.Name = "textMovieRef";
            this.textMovieRef.Size = new System.Drawing.Size(100, 20);
            this.textMovieRef.TabIndex = 1;
            // 
            // textOffset
            // 
            this.textOffset.Location = new System.Drawing.Point(236, 35);
            this.textOffset.Name = "textOffset";
            this.textOffset.Size = new System.Drawing.Size(100, 20);
            this.textOffset.TabIndex = 2;
            // 
            // buttonShift
            // 
            this.buttonShift.Location = new System.Drawing.Point(342, 33);
            this.buttonShift.Name = "buttonShift";
            this.buttonShift.Size = new System.Drawing.Size(75, 23);
            this.buttonShift.TabIndex = 3;
            this.buttonShift.Text = "Diff";
            this.buttonShift.UseVisualStyleBackColor = true;
            this.buttonShift.Click += new System.EventHandler(this.buttonShift_Click);
            // 
            // textSrtFile
            // 
            this.textSrtFile.Location = new System.Drawing.Point(24, 61);
            this.textSrtFile.Name = "textSrtFile";
            this.textSrtFile.Size = new System.Drawing.Size(312, 20);
            this.textSrtFile.TabIndex = 4;
            // 
            // buttonOpenSrt
            // 
            this.buttonOpenSrt.Location = new System.Drawing.Point(342, 59);
            this.buttonOpenSrt.Name = "buttonOpenSrt";
            this.buttonOpenSrt.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenSrt.TabIndex = 5;
            this.buttonOpenSrt.Text = "Open SRT";
            this.buttonOpenSrt.UseVisualStyleBackColor = true;
            this.buttonOpenSrt.Click += new System.EventHandler(this.buttonOpenSrt_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 87);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 260);
            this.textBox1.TabIndex = 6;
            // 
            // buttonReSync
            // 
            this.buttonReSync.Location = new System.Drawing.Point(423, 33);
            this.buttonReSync.Name = "buttonReSync";
            this.buttonReSync.Size = new System.Drawing.Size(75, 23);
            this.buttonReSync.TabIndex = 7;
            this.buttonReSync.Text = "ReSync";
            this.buttonReSync.UseVisualStyleBackColor = true;
            this.buttonReSync.Click += new System.EventHandler(this.buttonReSync_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(423, 59);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save SRT";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Srt Reference";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Movie Reference";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Difference";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 359);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonReSync);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonOpenSrt);
            this.Controls.Add(this.textSrtFile);
            this.Controls.Add(this.buttonShift);
            this.Controls.Add(this.textOffset);
            this.Controls.Add(this.textMovieRef);
            this.Controls.Add(this.textSrtRef);
            this.Name = "Form1";
            this.Text = "SrtSynchronizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textSrtRef;
        private System.Windows.Forms.TextBox textMovieRef;
        private System.Windows.Forms.TextBox textOffset;
        private System.Windows.Forms.Button buttonShift;
        private System.Windows.Forms.TextBox textSrtFile;
        private System.Windows.Forms.Button buttonOpenSrt;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonReSync;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

