namespace SRTSync
{
    partial class OnTheFlySRTWriter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnTheFlySRTWriter));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wmp = new AxWMPLib.AxWindowsMediaPlayer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.responseTime = new System.Windows.Forms.TextBox();
            this.listSubtitles = new System.Windows.Forms.ListView();
            this.colSubtitles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textSRT = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGetEnd = new System.Windows.Forms.Button();
            this.textEnd = new System.Windows.Forms.TextBox();
            this.btnGetStart = new System.Windows.Forms.Button();
            this.textStart = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbOpen = new System.Windows.Forms.ToolStripButton();
            this.tbSave = new System.Windows.Forms.ToolStripButton();
            this.tbReload = new System.Windows.Forms.ToolStripButton();
            this.tbAdd = new System.Windows.Forms.ToolStripButton();
            this.tbUp = new System.Windows.Forms.ToolStripButton();
            this.tbDown = new System.Windows.Forms.ToolStripButton();
            this.tbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tbReset = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(729, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewToolStripMenuItem,
            this.toolStripMenuItem1,
            this.playToolStripMenuItem,
            this.endToolStripMenuItem,
            this.backToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.addNewToolStripMenuItem.Text = "&Add New";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.playToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.playToolStripMenuItem.Text = "&PlayPause";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // endToolStripMenuItem
            // 
            this.endToolStripMenuItem.Name = "endToolStripMenuItem";
            this.endToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.endToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.endToolStripMenuItem.Text = "&Current";
            this.endToolStripMenuItem.Click += new System.EventHandler(this.endToolStripMenuItem_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.backToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // wmp
            // 
            this.wmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wmp.Enabled = true;
            this.wmp.Location = new System.Drawing.Point(0, 0);
            this.wmp.Name = "wmp";
            this.wmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmp.OcxState")));
            this.wmp.Size = new System.Drawing.Size(300, 264);
            this.wmp.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listSubtitles);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(729, 375);
            this.splitContainer2.SplitterDistance = 300;
            this.splitContainer2.TabIndex = 4;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.responseTime);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.wmp);
            this.splitContainer3.Size = new System.Drawing.Size(300, 375);
            this.splitContainer3.SplitterDistance = 107;
            this.splitContainer3.TabIndex = 0;
            // 
            // responseTime
            // 
            this.responseTime.Font = new System.Drawing.Font("Monaco", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.responseTime.Location = new System.Drawing.Point(3, 3);
            this.responseTime.Name = "responseTime";
            this.responseTime.Size = new System.Drawing.Size(65, 29);
            this.responseTime.TabIndex = 4;
            this.responseTime.Text = "-500";
            // 
            // listSubtitles
            // 
            this.listSubtitles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSubtitles,
            this.colStart,
            this.colEnd,
            this.colSerial});
            this.listSubtitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listSubtitles.Font = new System.Drawing.Font("Constantia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listSubtitles.FullRowSelect = true;
            this.listSubtitles.GridLines = true;
            this.listSubtitles.HideSelection = false;
            this.listSubtitles.Location = new System.Drawing.Point(0, 25);
            this.listSubtitles.Name = "listSubtitles";
            this.listSubtitles.Size = new System.Drawing.Size(425, 150);
            this.listSubtitles.TabIndex = 9;
            this.listSubtitles.UseCompatibleStateImageBehavior = false;
            this.listSubtitles.View = System.Windows.Forms.View.Details;
            this.listSubtitles.SelectedIndexChanged += new System.EventHandler(this.listSubtitles_SelectedIndexChanged);
            this.listSubtitles.DoubleClick += new System.EventHandler(this.listSubtitles_DoubleClick);
            this.listSubtitles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listSubtitles_KeyDown);
            // 
            // colSubtitles
            // 
            this.colSubtitles.DisplayIndex = 3;
            this.colSubtitles.Text = "Subtitle";
            this.colSubtitles.Width = 600;
            // 
            // colStart
            // 
            this.colStart.Text = "Start";
            this.colStart.Width = 150;
            // 
            // colEnd
            // 
            this.colEnd.Text = "End";
            this.colEnd.Width = 150;
            // 
            // colSerial
            // 
            this.colSerial.DisplayIndex = 0;
            this.colSerial.Text = "#";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textSRT);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 200);
            this.panel1.TabIndex = 8;
            // 
            // textSRT
            // 
            this.textSRT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSRT.Font = new System.Drawing.Font("Monaco", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSRT.Location = new System.Drawing.Point(0, 36);
            this.textSRT.Multiline = true;
            this.textSRT.Name = "textSRT";
            this.textSRT.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textSRT.Size = new System.Drawing.Size(425, 164);
            this.textSRT.TabIndex = 0;
            this.textSRT.TextChanged += new System.EventHandler(this.textSRT_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnGetEnd);
            this.panel2.Controls.Add(this.textEnd);
            this.panel2.Controls.Add(this.btnGetStart);
            this.panel2.Controls.Add(this.textStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 36);
            this.panel2.TabIndex = 1;
            // 
            // btnGetEnd
            // 
            this.btnGetEnd.AutoSize = true;
            this.btnGetEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetEnd.Image = global::SRTSync.Properties.Resources._1305262333_full_time;
            this.btnGetEnd.Location = new System.Drawing.Point(364, 6);
            this.btnGetEnd.Name = "btnGetEnd";
            this.btnGetEnd.Size = new System.Drawing.Size(24, 24);
            this.btnGetEnd.TabIndex = 3;
            this.btnGetEnd.UseVisualStyleBackColor = true;
            this.btnGetEnd.Click += new System.EventHandler(this.btnGetEnd_Click);
            // 
            // textEnd
            // 
            this.textEnd.Font = new System.Drawing.Font("Monaco", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEnd.Location = new System.Drawing.Point(208, 3);
            this.textEnd.Name = "textEnd";
            this.textEnd.Size = new System.Drawing.Size(150, 29);
            this.textEnd.TabIndex = 2;
            this.textEnd.TextChanged += new System.EventHandler(this.textEnd_TextChanged);
            // 
            // btnGetStart
            // 
            this.btnGetStart.AutoSize = true;
            this.btnGetStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetStart.Image = global::SRTSync.Properties.Resources._1305262333_full_time;
            this.btnGetStart.Location = new System.Drawing.Point(159, 6);
            this.btnGetStart.Name = "btnGetStart";
            this.btnGetStart.Size = new System.Drawing.Size(24, 24);
            this.btnGetStart.TabIndex = 1;
            this.btnGetStart.UseVisualStyleBackColor = true;
            this.btnGetStart.Click += new System.EventHandler(this.btnGetStart_Click);
            // 
            // textStart
            // 
            this.textStart.Font = new System.Drawing.Font("Monaco", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textStart.Location = new System.Drawing.Point(3, 3);
            this.textStart.Name = "textStart";
            this.textStart.Size = new System.Drawing.Size(150, 29);
            this.textStart.TabIndex = 0;
            this.textStart.TextChanged += new System.EventHandler(this.textStart_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbOpen,
            this.tbSave,
            this.tbReload,
            this.tbAdd,
            this.tbUp,
            this.tbDown,
            this.tbDelete,
            this.toolStripButton1,
            this.tbReset});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(425, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbOpen
            // 
            this.tbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tbOpen.Image")));
            this.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpen.Name = "tbOpen";
            this.tbOpen.Size = new System.Drawing.Size(56, 22);
            this.tbOpen.Text = "Open";
            this.tbOpen.Click += new System.EventHandler(this.tbOpen_Click);
            // 
            // tbSave
            // 
            this.tbSave.Image = ((System.Drawing.Image)(resources.GetObject("tbSave.Image")));
            this.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(51, 22);
            this.tbSave.Text = "Save";
            this.tbSave.Click += new System.EventHandler(this.tbSave_Click);
            // 
            // tbReload
            // 
            this.tbReload.Image = ((System.Drawing.Image)(resources.GetObject("tbReload.Image")));
            this.tbReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbReload.Name = "tbReload";
            this.tbReload.Size = new System.Drawing.Size(63, 22);
            this.tbReload.Text = "Reload";
            this.tbReload.Click += new System.EventHandler(this.tbReload_Click);
            // 
            // tbAdd
            // 
            this.tbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tbAdd.Image")));
            this.tbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(23, 22);
            this.tbAdd.Text = "Add";
            this.tbAdd.Click += new System.EventHandler(this.tbAdd_Click);
            // 
            // tbUp
            // 
            this.tbUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUp.Image = ((System.Drawing.Image)(resources.GetObject("tbUp.Image")));
            this.tbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUp.Name = "tbUp";
            this.tbUp.Size = new System.Drawing.Size(23, 22);
            this.tbUp.Text = "Up";
            this.tbUp.Click += new System.EventHandler(this.tbUp_Click);
            // 
            // tbDown
            // 
            this.tbDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDown.Image = ((System.Drawing.Image)(resources.GetObject("tbDown.Image")));
            this.tbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDown.Name = "tbDown";
            this.tbDown.Size = new System.Drawing.Size(23, 22);
            this.tbDown.Text = "Down";
            this.tbDown.Click += new System.EventHandler(this.tbDown_Click);
            // 
            // tbDelete
            // 
            this.tbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbDelete.Image")));
            this.tbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDelete.Name = "tbDelete";
            this.tbDelete.Size = new System.Drawing.Size(23, 22);
            this.tbDelete.Text = "Delete";
            this.tbDelete.Click += new System.EventHandler(this.tbDelete_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Clean";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tbReset
            // 
            this.tbReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbReset.Image = ((System.Drawing.Image)(resources.GetObject("tbReset.Image")));
            this.tbReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbReset.Name = "tbReset";
            this.tbReset.Size = new System.Drawing.Size(23, 22);
            this.tbReset.Text = "Reset";
            this.tbReset.Click += new System.EventHandler(this.tbReset_Click);
            // 
            // OnTheFlySRTWriter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 399);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "OnTheFlySRTWriter";
            this.Text = "OnTheFlySRTWriter";
            this.Load += new System.EventHandler(this.OnTheFlySRTWriter_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wmp)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private AxWMPLib.AxWindowsMediaPlayer wmp;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbOpen;
        private System.Windows.Forms.ToolStripButton tbReload;
        private System.Windows.Forms.ListView listSubtitles;
        private System.Windows.Forms.ColumnHeader colSubtitles;
        private System.Windows.Forms.ColumnHeader colStart;
        private System.Windows.Forms.ColumnHeader colEnd;
        private System.Windows.Forms.ColumnHeader colSerial;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textSRT;
        private System.Windows.Forms.ToolStripButton tbAdd;
        private System.Windows.Forms.ToolStripButton tbUp;
        private System.Windows.Forms.ToolStripButton tbDown;
        private System.Windows.Forms.ToolStripButton tbDelete;
        private System.Windows.Forms.ToolStripButton tbSave;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tbReset;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGetStart;
        private System.Windows.Forms.TextBox textStart;
        private System.Windows.Forms.Button btnGetEnd;
        private System.Windows.Forms.TextBox textEnd;
        private System.Windows.Forms.TextBox responseTime;
    }
}