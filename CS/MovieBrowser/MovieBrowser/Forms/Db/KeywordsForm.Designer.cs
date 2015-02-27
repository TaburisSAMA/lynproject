namespace MovieBrowser.Forms.Db
{
    partial class KeywordsForm
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
            this.horizontalPanel1 = new WindowsFormsAero.HorizontalPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataListView1 = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchTextBox1 = new WindowsFormsAero.SearchTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ratingStar1 = new RatingControl.RatingStar();
            this.highlightTextRenderer1 = new BrightIdeasSoftware.HighlightTextRenderer();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // horizontalPanel1
            // 
            this.horizontalPanel1.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel1.Location = new System.Drawing.Point(0, 374);
            this.horizontalPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.horizontalPanel1.Name = "horizontalPanel1";
            this.horizontalPanel1.Size = new System.Drawing.Size(634, 76);
            this.horizontalPanel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataListView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(634, 251);
            this.panel2.TabIndex = 8;
            // 
            // dataListView1
            // 
            this.dataListView1.AllColumns.Add(this.olvColumn1);
            this.dataListView1.AllColumns.Add(this.olvColumn2);
            this.dataListView1.AllColumns.Add(this.olvColumn3);
            this.dataListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.dataListView1.DataSource = null;
            this.dataListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListView1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataListView1.FullRowSelect = true;
            this.dataListView1.GridLines = true;
            this.dataListView1.HideSelection = false;
            this.dataListView1.Location = new System.Drawing.Point(10, 10);
            this.dataListView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataListView1.Name = "dataListView1";
            this.dataListView1.OwnerDraw = true;
            this.dataListView1.Size = new System.Drawing.Size(614, 231);
            this.dataListView1.TabIndex = 4;
            this.dataListView1.UseCompatibleStateImageBehavior = false;
            this.dataListView1.UseFiltering = true;
            this.dataListView1.UseHotItem = true;
            this.dataListView1.View = System.Windows.Forms.View.Details;
            this.dataListView1.SelectedIndexChanged += new System.EventHandler(this.dataListView1_SelectedIndexChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.IsTileViewColumn = true;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 250;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Code";
            this.olvColumn2.Text = "Code";
            this.olvColumn2.UseInitialLetterForGroup = true;
            this.olvColumn2.Width = 250;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Rated";
            this.olvColumn3.Text = "Rate";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchTextBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ratingStar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(634, 123);
            this.panel1.TabIndex = 7;
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.ActiveFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchTextBox1.Location = new System.Drawing.Point(10, 10);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.Size = new System.Drawing.Size(394, 21);
            this.searchTextBox1.TabIndex = 3;
            this.searchTextBox1.SearchStarted += new System.EventHandler(this.searchTextBox1_SearchStarted);
            this.searchTextBox1.SearchCancelled += new System.EventHandler(this.searchTextBox1_SearchCancelled);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adultness";
            // 
            // ratingStar1
            // 
            this.ratingStar1.ControlLayout = RatingControl.RatingStar.Layouts.Horizontal;
            this.ratingStar1.Level = 5;
            this.ratingStar1.Location = new System.Drawing.Point(88, 41);
            this.ratingStar1.Name = "ratingStar1";
            this.ratingStar1.Rating = 0D;
            this.ratingStar1.Size = new System.Drawing.Size(144, 24);
            this.ratingStar1.TabIndex = 1;
            this.ratingStar1.RatingValueChanged += new RatingControl.RatingStar.RatingValueChangedEventHandler(this.ratingStar1_RatingValueChanged);
            // 
            // KeywordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.horizontalPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "KeywordsForm";
            this.Text = "KeywordsForm";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsAero.HorizontalPanel horizontalPanel1;
        private System.Windows.Forms.Panel panel2;
        private BrightIdeasSoftware.DataListView dataListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.Panel panel1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.Label label1;
        private RatingControl.RatingStar ratingStar1;
        private WindowsFormsAero.SearchTextBox searchTextBox1;
        private BrightIdeasSoftware.HighlightTextRenderer highlightTextRenderer1;


    }
}