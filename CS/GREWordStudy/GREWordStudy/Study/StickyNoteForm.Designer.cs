namespace GREWordStudy.Study
{
    partial class StickyNoteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StickyNoteForm));
            this.rtfComment = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBold = new System.Windows.Forms.ToolStripButton();
            this.tsItalic = new System.Windows.Forms.ToolStripButton();
            this.tsUnderline = new System.Windows.Forms.ToolStripButton();
            this.tsStrikethrough = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsColorRed = new System.Windows.Forms.ToolStripMenuItem();
            this.tsGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsNormalColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsYellowBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLightGreenBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFont = new System.Windows.Forms.ToolStripSplitButton();
            this.tsFontSegoe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFontPalatino = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFontCandara = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFontCorbel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFontVrinda = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFontBangla = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFontIncrease = new System.Windows.Forms.ToolStripButton();
            this.tsFontDecrease = new System.Windows.Forms.ToolStripButton();
            this.tsFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtfComment
            // 
            this.rtfComment.BackColor = System.Drawing.Color.AliceBlue;
            this.rtfComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfComment.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfComment.HideSelection = false;
            this.rtfComment.Location = new System.Drawing.Point(0, 25);
            this.rtfComment.Name = "rtfComment";
            this.rtfComment.Size = new System.Drawing.Size(431, 237);
            this.rtfComment.TabIndex = 6;
            this.rtfComment.Text = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBold,
            this.tsItalic,
            this.tsUnderline,
            this.tsStrikethrough,
            this.toolStripDropDownButton1,
            this.tsFont,
            this.tsFontIncrease,
            this.tsFontDecrease,
            this.tsFontSize});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(431, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBold
            // 
            this.tsBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBold.Image = ((System.Drawing.Image)(resources.GetObject("tsBold.Image")));
            this.tsBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBold.Name = "tsBold";
            this.tsBold.Size = new System.Drawing.Size(23, 22);
            this.tsBold.Text = "Bold";
            this.tsBold.Click += new System.EventHandler(this.tsBold_Click);
            // 
            // tsItalic
            // 
            this.tsItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsItalic.Image = ((System.Drawing.Image)(resources.GetObject("tsItalic.Image")));
            this.tsItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsItalic.Name = "tsItalic";
            this.tsItalic.Size = new System.Drawing.Size(23, 22);
            this.tsItalic.Text = "Italic";
            this.tsItalic.Click += new System.EventHandler(this.tsItalic_Click);
            // 
            // tsUnderline
            // 
            this.tsUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsUnderline.Image = ((System.Drawing.Image)(resources.GetObject("tsUnderline.Image")));
            this.tsUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUnderline.Name = "tsUnderline";
            this.tsUnderline.Size = new System.Drawing.Size(23, 22);
            this.tsUnderline.Text = "Underline";
            this.tsUnderline.Click += new System.EventHandler(this.tsUnderline_Click);
            // 
            // tsStrikethrough
            // 
            this.tsStrikethrough.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsStrikethrough.Image = ((System.Drawing.Image)(resources.GetObject("tsStrikethrough.Image")));
            this.tsStrikethrough.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsStrikethrough.Name = "tsStrikethrough";
            this.tsStrikethrough.Size = new System.Drawing.Size(23, 22);
            this.tsStrikethrough.Text = "Strikethrough";
            this.tsStrikethrough.Click += new System.EventHandler(this.tsStrikethrough_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsColorRed,
            this.tsGreen,
            this.tsBlue,
            this.toolStripSeparator2,
            this.tsNormalColor,
            this.toolStripSeparator1,
            this.tsYellowBackground,
            this.tsLightGreenBackground});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "Color";
            // 
            // tsColorRed
            // 
            this.tsColorRed.ForeColor = System.Drawing.Color.Red;
            this.tsColorRed.Name = "tsColorRed";
            this.tsColorRed.Size = new System.Drawing.Size(152, 22);
            this.tsColorRed.Text = "Red";
            this.tsColorRed.Click += new System.EventHandler(this.tsColorRed_Click);
            // 
            // tsGreen
            // 
            this.tsGreen.ForeColor = System.Drawing.Color.Green;
            this.tsGreen.Name = "tsGreen";
            this.tsGreen.Size = new System.Drawing.Size(152, 22);
            this.tsGreen.Text = "Green";
            this.tsGreen.Click += new System.EventHandler(this.tsGreen_Click);
            // 
            // tsBlue
            // 
            this.tsBlue.ForeColor = System.Drawing.Color.Blue;
            this.tsBlue.Name = "tsBlue";
            this.tsBlue.Size = new System.Drawing.Size(152, 22);
            this.tsBlue.Text = "Blue";
            this.tsBlue.Click += new System.EventHandler(this.tsBlue_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsNormalColor
            // 
            this.tsNormalColor.Name = "tsNormalColor";
            this.tsNormalColor.Size = new System.Drawing.Size(152, 22);
            this.tsNormalColor.Text = "Normal";
            this.tsNormalColor.Click += new System.EventHandler(this.tsNormalColor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsYellowBackground
            // 
            this.tsYellowBackground.BackColor = System.Drawing.Color.Yellow;
            this.tsYellowBackground.Name = "tsYellowBackground";
            this.tsYellowBackground.Size = new System.Drawing.Size(152, 22);
            this.tsYellowBackground.Text = "Yellow";
            this.tsYellowBackground.Click += new System.EventHandler(this.tsYellowBackground_Click);
            // 
            // tsLightGreenBackground
            // 
            this.tsLightGreenBackground.BackColor = System.Drawing.Color.LightGreen;
            this.tsLightGreenBackground.Name = "tsLightGreenBackground";
            this.tsLightGreenBackground.Size = new System.Drawing.Size(152, 22);
            this.tsLightGreenBackground.Text = "Light Green";
            this.tsLightGreenBackground.Click += new System.EventHandler(this.tsLightGreenBackground_Click);
            // 
            // tsFont
            // 
            this.tsFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFont.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFontSegoe,
            this.tsFontPalatino,
            this.tsFontCandara,
            this.tsFontCorbel,
            this.tsFontVrinda,
            this.tsFontBangla});
            this.tsFont.Image = ((System.Drawing.Image)(resources.GetObject("tsFont.Image")));
            this.tsFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFont.Name = "tsFont";
            this.tsFont.Size = new System.Drawing.Size(32, 22);
            this.tsFont.Text = "Font";
            // 
            // tsFontSegoe
            // 
            this.tsFontSegoe.Font = new System.Drawing.Font("Segoe Print", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFontSegoe.Name = "tsFontSegoe";
            this.tsFontSegoe.Size = new System.Drawing.Size(145, 38);
            this.tsFontSegoe.Text = "Segoe";
            this.tsFontSegoe.Click += new System.EventHandler(this.tsFontSegoe_Click);
            // 
            // tsFontPalatino
            // 
            this.tsFontPalatino.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFontPalatino.Name = "tsFontPalatino";
            this.tsFontPalatino.Size = new System.Drawing.Size(145, 38);
            this.tsFontPalatino.Text = "Palatino";
            this.tsFontPalatino.Click += new System.EventHandler(this.tsFontPalatino_Click);
            // 
            // tsFontCandara
            // 
            this.tsFontCandara.Font = new System.Drawing.Font("Candara", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFontCandara.Name = "tsFontCandara";
            this.tsFontCandara.Size = new System.Drawing.Size(145, 38);
            this.tsFontCandara.Text = "Candara";
            this.tsFontCandara.Click += new System.EventHandler(this.tsFontCandara_Click);
            // 
            // tsFontCorbel
            // 
            this.tsFontCorbel.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFontCorbel.Name = "tsFontCorbel";
            this.tsFontCorbel.Size = new System.Drawing.Size(145, 38);
            this.tsFontCorbel.Text = "Corbel";
            this.tsFontCorbel.Click += new System.EventHandler(this.tsFontCorbel_Click);
            // 
            // tsFontVrinda
            // 
            this.tsFontVrinda.Font = new System.Drawing.Font("Vrinda", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFontVrinda.Name = "tsFontVrinda";
            this.tsFontVrinda.Size = new System.Drawing.Size(145, 38);
            this.tsFontVrinda.Text = "Vrinda";
            this.tsFontVrinda.Click += new System.EventHandler(this.tsFontVrinda_Click);
            // 
            // tsFontBangla
            // 
            this.tsFontBangla.Font = new System.Drawing.Font("Shonar Bangla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsFontBangla.Name = "tsFontBangla";
            this.tsFontBangla.Size = new System.Drawing.Size(145, 38);
            this.tsFontBangla.Text = "বাংলা";
            this.tsFontBangla.Click += new System.EventHandler(this.tsFontBangla_Click);
            // 
            // tsFontIncrease
            // 
            this.tsFontIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFontIncrease.Image = ((System.Drawing.Image)(resources.GetObject("tsFontIncrease.Image")));
            this.tsFontIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFontIncrease.Name = "tsFontIncrease";
            this.tsFontIncrease.Size = new System.Drawing.Size(23, 22);
            this.tsFontIncrease.Text = "Increase";
            this.tsFontIncrease.Click += new System.EventHandler(this.tsFontIncrease_Click);
            // 
            // tsFontDecrease
            // 
            this.tsFontDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFontDecrease.Image = ((System.Drawing.Image)(resources.GetObject("tsFontDecrease.Image")));
            this.tsFontDecrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFontDecrease.Name = "tsFontDecrease";
            this.tsFontDecrease.Size = new System.Drawing.Size(23, 22);
            this.tsFontDecrease.Text = "toolStripButton7";
            this.tsFontDecrease.Click += new System.EventHandler(this.tsFontDecrease_Click);
            // 
            // tsFontSize
            // 
            this.tsFontSize.Items.AddRange(new object[] {
            "12",
            "14",
            "16",
            "20"});
            this.tsFontSize.Name = "tsFontSize";
            this.tsFontSize.Size = new System.Drawing.Size(75, 25);
            this.tsFontSize.TextChanged += new System.EventHandler(this.tsFontSize_TextChanged);
            // 
            // StickyNoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 262);
            this.Controls.Add(this.rtfComment);
            this.Controls.Add(this.toolStrip1);
            this.Name = "StickyNoteForm";
            this.Text = "StickyNoteForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfComment;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsBold;
        private System.Windows.Forms.ToolStripButton tsItalic;
        private System.Windows.Forms.ToolStripButton tsUnderline;
        private System.Windows.Forms.ToolStripButton tsStrikethrough;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem tsColorRed;
        private System.Windows.Forms.ToolStripMenuItem tsGreen;
        private System.Windows.Forms.ToolStripMenuItem tsBlue;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsNormalColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsYellowBackground;
        private System.Windows.Forms.ToolStripMenuItem tsLightGreenBackground;
        private System.Windows.Forms.ToolStripSplitButton tsFont;
        private System.Windows.Forms.ToolStripMenuItem tsFontSegoe;
        private System.Windows.Forms.ToolStripMenuItem tsFontPalatino;
        private System.Windows.Forms.ToolStripMenuItem tsFontCandara;
        private System.Windows.Forms.ToolStripMenuItem tsFontCorbel;
        private System.Windows.Forms.ToolStripMenuItem tsFontVrinda;
        private System.Windows.Forms.ToolStripMenuItem tsFontBangla;
        private System.Windows.Forms.ToolStripButton tsFontIncrease;
        private System.Windows.Forms.ToolStripButton tsFontDecrease;
        private System.Windows.Forms.ToolStripComboBox tsFontSize;
    }
}