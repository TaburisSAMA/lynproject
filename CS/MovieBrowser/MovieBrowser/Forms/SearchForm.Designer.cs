namespace MovieBrowser.Forms
{
    partial class SearchForm
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
            this.listKeywords = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.textRatingFrom = new System.Windows.Forms.TextBox();
            this.textRatingTo = new System.Windows.Forms.TextBox();
            this.clSearch = new WindowsFormsAero.CommandLink();
            this.listGenres = new BrightIdeasSoftware.DataListView();
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.horizontalPanel1 = new WindowsFormsAero.HorizontalPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.searchGenres = new WindowsFormsAero.SearchTextBox();
            this.chkGenres = new System.Windows.Forms.CheckBox();
            this.horizontalPanel2 = new WindowsFormsAero.HorizontalPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkClear = new System.Windows.Forms.CheckBox();
            this.searchKeywords = new WindowsFormsAero.SearchTextBox();
            this.chkKeywords = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.horizontalPanel5 = new WindowsFormsAero.HorizontalPanel();
            this.listDirectors = new BrightIdeasSoftware.DataListView();
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.searchDirectors = new WindowsFormsAero.SearchTextBox();
            this.chkDirectors = new System.Windows.Forms.CheckBox();
            this.horizontalPanel3 = new WindowsFormsAero.HorizontalPanel();
            this.listStars = new BrightIdeasSoftware.DataListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.searchStars = new WindowsFormsAero.SearchTextBox();
            this.chkStars = new System.Windows.Forms.CheckBox();
            this.horizontalPanel6 = new WindowsFormsAero.HorizontalPanel();
            this.ratingTo = new RatingControl.RatingStar();
            this.ratingFrom = new RatingControl.RatingStar();
            this.chkRating = new System.Windows.Forms.CheckBox();
            this.horizontalPanel7 = new WindowsFormsAero.HorizontalPanel();
            this.clReset = new WindowsFormsAero.CommandLink();
            this.clCancel = new WindowsFormsAero.CommandLink();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.listKeywords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listGenres)).BeginInit();
            this.horizontalPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.horizontalPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.horizontalPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDirectors)).BeginInit();
            this.panel4.SuspendLayout();
            this.horizontalPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listStars)).BeginInit();
            this.panel3.SuspendLayout();
            this.horizontalPanel6.SuspendLayout();
            this.horizontalPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // listKeywords
            // 
            this.listKeywords.AllColumns.Add(this.olvColumn1);
            this.listKeywords.AllColumns.Add(this.olvColumn3);
            this.listKeywords.CheckBoxes = true;
            this.listKeywords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn3});
            this.listKeywords.Cursor = System.Windows.Forms.Cursors.Default;
            this.listKeywords.DataSource = null;
            this.listKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listKeywords.Enabled = false;
            this.listKeywords.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listKeywords.FullRowSelect = true;
            this.listKeywords.GridLines = true;
            this.listKeywords.HideSelection = false;
            this.listKeywords.Location = new System.Drawing.Point(5, 30);
            this.listKeywords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listKeywords.Name = "listKeywords";
            this.listKeywords.OwnerDraw = true;
            this.listKeywords.Size = new System.Drawing.Size(333, 163);
            this.listKeywords.TabIndex = 5;
            this.listKeywords.UseCompatibleStateImageBehavior = false;
            this.listKeywords.UseFiltering = true;
            this.listKeywords.UseHotItem = true;
            this.listKeywords.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.IsTileViewColumn = true;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 200;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Rated";
            this.olvColumn3.Text = "Rate";
            // 
            // textRatingFrom
            // 
            this.textRatingFrom.Location = new System.Drawing.Point(5, 32);
            this.textRatingFrom.Name = "textRatingFrom";
            this.textRatingFrom.Size = new System.Drawing.Size(53, 23);
            this.textRatingFrom.TabIndex = 9;
            this.textRatingFrom.Text = "6";
            this.textRatingFrom.TextChanged += new System.EventHandler(this.textRatingFrom_TextChanged);
            // 
            // textRatingTo
            // 
            this.textRatingTo.Location = new System.Drawing.Point(8, 91);
            this.textRatingTo.Name = "textRatingTo";
            this.textRatingTo.Size = new System.Drawing.Size(53, 23);
            this.textRatingTo.TabIndex = 11;
            this.textRatingTo.Text = "10";
            this.textRatingTo.TextChanged += new System.EventHandler(this.textRatingTo_TextChanged);
            // 
            // clSearch
            // 
            this.clSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clSearch.Location = new System.Drawing.Point(791, 3);
            this.clSearch.Name = "clSearch";
            this.clSearch.Size = new System.Drawing.Size(175, 48);
            this.clSearch.TabIndex = 12;
            this.clSearch.Text = "Search";
            this.clSearch.UseVisualStyleBackColor = true;
            this.clSearch.Click += new System.EventHandler(this.clSearch_Click);
            // 
            // listGenres
            // 
            this.listGenres.AllColumns.Add(this.olvColumn5);
            this.listGenres.CheckBoxes = true;
            this.listGenres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn5});
            this.listGenres.Cursor = System.Windows.Forms.Cursors.Default;
            this.listGenres.DataSource = null;
            this.listGenres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGenres.Enabled = false;
            this.listGenres.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listGenres.FullRowSelect = true;
            this.listGenres.GridLines = true;
            this.listGenres.HideSelection = false;
            this.listGenres.Location = new System.Drawing.Point(5, 30);
            this.listGenres.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listGenres.Name = "listGenres";
            this.listGenres.OwnerDraw = true;
            this.listGenres.Size = new System.Drawing.Size(333, 163);
            this.listGenres.TabIndex = 16;
            this.listGenres.UseCompatibleStateImageBehavior = false;
            this.listGenres.UseFiltering = true;
            this.listGenres.UseHotItem = true;
            this.listGenres.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Name";
            this.olvColumn5.IsTileViewColumn = true;
            this.olvColumn5.Text = "Name";
            this.olvColumn5.UseInitialLetterForGroup = true;
            this.olvColumn5.Width = 200;
            // 
            // horizontalPanel1
            // 
            this.horizontalPanel1.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel1.Controls.Add(this.listGenres);
            this.horizontalPanel1.Controls.Add(this.panel1);
            this.horizontalPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel1.Location = new System.Drawing.Point(3, 207);
            this.horizontalPanel1.Name = "horizontalPanel1";
            this.horizontalPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.horizontalPanel1.Size = new System.Drawing.Size(343, 198);
            this.horizontalPanel1.TabIndex = 26;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.searchGenres);
            this.panel1.Controls.Add(this.chkGenres);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(333, 25);
            this.panel1.TabIndex = 20;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox1.Location = new System.Drawing.Point(64, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(31, 21);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.Text = "*";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // searchGenres
            // 
            this.searchGenres.ActiveFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchGenres.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchGenres.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchGenres.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchGenres.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchGenres.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchGenres.Location = new System.Drawing.Point(131, 2);
            this.searchGenres.Name = "searchGenres";
            this.searchGenres.Size = new System.Drawing.Size(200, 21);
            this.searchGenres.TabIndex = 19;
            this.searchGenres.SearchStarted += new System.EventHandler(this.searchGenres_SearchStarted);
            this.searchGenres.SearchCancelled += new System.EventHandler(this.searchGenres_SearchCancelled);
            // 
            // chkGenres
            // 
            this.chkGenres.AutoSize = true;
            this.chkGenres.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkGenres.Location = new System.Drawing.Point(2, 2);
            this.chkGenres.Name = "chkGenres";
            this.chkGenres.Size = new System.Drawing.Size(62, 21);
            this.chkGenres.TabIndex = 18;
            this.chkGenres.Text = "Genres";
            this.chkGenres.UseVisualStyleBackColor = true;
            this.chkGenres.CheckedChanged += new System.EventHandler(this.chkGenres_CheckedChanged);
            // 
            // horizontalPanel2
            // 
            this.horizontalPanel2.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel2.Controls.Add(this.listKeywords);
            this.horizontalPanel2.Controls.Add(this.panel2);
            this.horizontalPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalPanel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel2.Location = new System.Drawing.Point(3, 3);
            this.horizontalPanel2.Name = "horizontalPanel2";
            this.horizontalPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.horizontalPanel2.Size = new System.Drawing.Size(343, 198);
            this.horizontalPanel2.TabIndex = 27;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkClear);
            this.panel2.Controls.Add(this.searchKeywords);
            this.panel2.Controls.Add(this.chkKeywords);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(333, 25);
            this.panel2.TabIndex = 21;
            // 
            // chkClear
            // 
            this.chkClear.AutoSize = true;
            this.chkClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkClear.Location = new System.Drawing.Point(79, 2);
            this.chkClear.Name = "chkClear";
            this.chkClear.Size = new System.Drawing.Size(31, 21);
            this.chkClear.TabIndex = 20;
            this.chkClear.Text = "*";
            this.chkClear.UseVisualStyleBackColor = true;
            this.chkClear.CheckedChanged += new System.EventHandler(this.chkClear_CheckedChanged);
            // 
            // searchKeywords
            // 
            this.searchKeywords.ActiveFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchKeywords.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchKeywords.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchKeywords.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchKeywords.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchKeywords.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchKeywords.Location = new System.Drawing.Point(131, 2);
            this.searchKeywords.Name = "searchKeywords";
            this.searchKeywords.Size = new System.Drawing.Size(200, 21);
            this.searchKeywords.TabIndex = 19;
            this.searchKeywords.SearchStarted += new System.EventHandler(this.searchKeywords_SearchStarted);
            this.searchKeywords.SearchCancelled += new System.EventHandler(this.searchKeywords_SearchCancelled);
            // 
            // chkKeywords
            // 
            this.chkKeywords.AutoSize = true;
            this.chkKeywords.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkKeywords.Location = new System.Drawing.Point(2, 2);
            this.chkKeywords.Name = "chkKeywords";
            this.chkKeywords.Size = new System.Drawing.Size(77, 21);
            this.chkKeywords.TabIndex = 18;
            this.chkKeywords.Text = "Keywords";
            this.chkKeywords.UseVisualStyleBackColor = true;
            this.chkKeywords.CheckedChanged += new System.EventHandler(this.chkKeywords_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(993, 504);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(985, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
            this.tableLayoutPanel1.Controls.Add(this.horizontalPanel5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.horizontalPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.horizontalPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.horizontalPanel6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.horizontalPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.horizontalPanel7, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(979, 468);
            this.tableLayoutPanel1.TabIndex = 29;
            // 
            // horizontalPanel5
            // 
            this.horizontalPanel5.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel5.Controls.Add(this.listDirectors);
            this.horizontalPanel5.Controls.Add(this.panel4);
            this.horizontalPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalPanel5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel5.Location = new System.Drawing.Point(352, 207);
            this.horizontalPanel5.Name = "horizontalPanel5";
            this.horizontalPanel5.Padding = new System.Windows.Forms.Padding(5);
            this.horizontalPanel5.Size = new System.Drawing.Size(343, 198);
            this.horizontalPanel5.TabIndex = 29;
            // 
            // listDirectors
            // 
            this.listDirectors.AllColumns.Add(this.olvColumn7);
            this.listDirectors.CheckBoxes = true;
            this.listDirectors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn7});
            this.listDirectors.Cursor = System.Windows.Forms.Cursors.Default;
            this.listDirectors.DataSource = null;
            this.listDirectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDirectors.Enabled = false;
            this.listDirectors.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDirectors.FullRowSelect = true;
            this.listDirectors.GridLines = true;
            this.listDirectors.HideSelection = false;
            this.listDirectors.Location = new System.Drawing.Point(5, 30);
            this.listDirectors.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listDirectors.Name = "listDirectors";
            this.listDirectors.OwnerDraw = true;
            this.listDirectors.Size = new System.Drawing.Size(333, 163);
            this.listDirectors.TabIndex = 5;
            this.listDirectors.UseCompatibleStateImageBehavior = false;
            this.listDirectors.UseFiltering = true;
            this.listDirectors.UseHotItem = true;
            this.listDirectors.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "Name";
            this.olvColumn7.IsTileViewColumn = true;
            this.olvColumn7.Text = "Name";
            this.olvColumn7.UseInitialLetterForGroup = true;
            this.olvColumn7.Width = 200;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkBox4);
            this.panel4.Controls.Add(this.searchDirectors);
            this.panel4.Controls.Add(this.chkDirectors);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(5, 5);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(333, 25);
            this.panel4.TabIndex = 21;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox4.Location = new System.Drawing.Point(75, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(31, 21);
            this.checkBox4.TabIndex = 21;
            this.checkBox4.Text = "*";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // searchDirectors
            // 
            this.searchDirectors.ActiveFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchDirectors.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchDirectors.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchDirectors.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchDirectors.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchDirectors.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchDirectors.Location = new System.Drawing.Point(131, 2);
            this.searchDirectors.Name = "searchDirectors";
            this.searchDirectors.Size = new System.Drawing.Size(200, 21);
            this.searchDirectors.TabIndex = 19;
            this.searchDirectors.SearchStarted += new System.EventHandler(this.searchDirectors_SearchStarted);
            this.searchDirectors.SearchCancelled += new System.EventHandler(this.searchDirectors_SearchCancelled);
            // 
            // chkDirectors
            // 
            this.chkDirectors.AutoSize = true;
            this.chkDirectors.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkDirectors.Location = new System.Drawing.Point(2, 2);
            this.chkDirectors.Name = "chkDirectors";
            this.chkDirectors.Size = new System.Drawing.Size(73, 21);
            this.chkDirectors.TabIndex = 18;
            this.chkDirectors.Text = "Directors";
            this.chkDirectors.UseVisualStyleBackColor = true;
            this.chkDirectors.CheckedChanged += new System.EventHandler(this.chkDirectors_CheckedChanged);
            // 
            // horizontalPanel3
            // 
            this.horizontalPanel3.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel3.Controls.Add(this.listStars);
            this.horizontalPanel3.Controls.Add(this.panel3);
            this.horizontalPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalPanel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel3.Location = new System.Drawing.Point(352, 3);
            this.horizontalPanel3.Name = "horizontalPanel3";
            this.horizontalPanel3.Padding = new System.Windows.Forms.Padding(5);
            this.horizontalPanel3.Size = new System.Drawing.Size(343, 198);
            this.horizontalPanel3.TabIndex = 28;
            // 
            // listStars
            // 
            this.listStars.AllColumns.Add(this.olvColumn2);
            this.listStars.CheckBoxes = true;
            this.listStars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2});
            this.listStars.Cursor = System.Windows.Forms.Cursors.Default;
            this.listStars.DataSource = null;
            this.listStars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listStars.Enabled = false;
            this.listStars.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listStars.FullRowSelect = true;
            this.listStars.GridLines = true;
            this.listStars.HideSelection = false;
            this.listStars.Location = new System.Drawing.Point(5, 30);
            this.listStars.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listStars.Name = "listStars";
            this.listStars.OwnerDraw = true;
            this.listStars.Size = new System.Drawing.Size(333, 163);
            this.listStars.TabIndex = 5;
            this.listStars.UseCompatibleStateImageBehavior = false;
            this.listStars.UseFiltering = true;
            this.listStars.UseHotItem = true;
            this.listStars.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Name";
            this.olvColumn2.IsTileViewColumn = true;
            this.olvColumn2.Text = "Name";
            this.olvColumn2.UseInitialLetterForGroup = true;
            this.olvColumn2.Width = 200;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox2);
            this.panel3.Controls.Add(this.searchStars);
            this.panel3.Controls.Add(this.chkStars);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 5);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(2);
            this.panel3.Size = new System.Drawing.Size(333, 25);
            this.panel3.TabIndex = 21;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox2.Location = new System.Drawing.Point(53, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(31, 21);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.Text = "*";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // searchStars
            // 
            this.searchStars.ActiveFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchStars.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchStars.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchStars.Dock = System.Windows.Forms.DockStyle.Right;
            this.searchStars.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchStars.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchStars.Location = new System.Drawing.Point(131, 2);
            this.searchStars.Name = "searchStars";
            this.searchStars.Size = new System.Drawing.Size(200, 21);
            this.searchStars.TabIndex = 19;
            this.searchStars.SearchStarted += new System.EventHandler(this.searchStars_SearchStarted);
            this.searchStars.SearchCancelled += new System.EventHandler(this.searchStars_SearchCancelled);
            // 
            // chkStars
            // 
            this.chkStars.AutoSize = true;
            this.chkStars.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkStars.Location = new System.Drawing.Point(2, 2);
            this.chkStars.Name = "chkStars";
            this.chkStars.Size = new System.Drawing.Size(51, 21);
            this.chkStars.TabIndex = 18;
            this.chkStars.Text = "Stars";
            this.chkStars.UseVisualStyleBackColor = true;
            this.chkStars.CheckedChanged += new System.EventHandler(this.chkStars_CheckedChanged);
            // 
            // horizontalPanel6
            // 
            this.horizontalPanel6.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel6.Controls.Add(this.ratingTo);
            this.horizontalPanel6.Controls.Add(this.ratingFrom);
            this.horizontalPanel6.Controls.Add(this.chkRating);
            this.horizontalPanel6.Controls.Add(this.textRatingTo);
            this.horizontalPanel6.Controls.Add(this.textRatingFrom);
            this.horizontalPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalPanel6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel6.Location = new System.Drawing.Point(701, 3);
            this.horizontalPanel6.Name = "horizontalPanel6";
            this.horizontalPanel6.Padding = new System.Windows.Forms.Padding(5);
            this.horizontalPanel6.Size = new System.Drawing.Size(275, 198);
            this.horizontalPanel6.TabIndex = 27;
            // 
            // ratingTo
            // 
            this.ratingTo.ControlLayout = RatingControl.RatingStar.Layouts.Horizontal;
            this.ratingTo.Enabled = false;
            this.ratingTo.Level = 10;
            this.ratingTo.Location = new System.Drawing.Point(5, 120);
            this.ratingTo.Name = "ratingTo";
            this.ratingTo.Rating = 10D;
            this.ratingTo.Size = new System.Drawing.Size(264, 24);
            this.ratingTo.TabIndex = 21;
            this.ratingTo.RatingValueChanged += new RatingControl.RatingStar.RatingValueChangedEventHandler(this.ratingTo_RatingValueChanged);
            // 
            // ratingFrom
            // 
            this.ratingFrom.ControlLayout = RatingControl.RatingStar.Layouts.Horizontal;
            this.ratingFrom.Enabled = false;
            this.ratingFrom.Level = 10;
            this.ratingFrom.Location = new System.Drawing.Point(5, 61);
            this.ratingFrom.Name = "ratingFrom";
            this.ratingFrom.Rating = 6D;
            this.ratingFrom.Size = new System.Drawing.Size(264, 24);
            this.ratingFrom.TabIndex = 20;
            this.ratingFrom.RatingValueChanged += new RatingControl.RatingStar.RatingValueChangedEventHandler(this.ratingFrom_RatingValueChanged);
            // 
            // chkRating
            // 
            this.chkRating.AutoSize = true;
            this.chkRating.Location = new System.Drawing.Point(5, 8);
            this.chkRating.Name = "chkRating";
            this.chkRating.Size = new System.Drawing.Size(60, 19);
            this.chkRating.TabIndex = 18;
            this.chkRating.Text = "Rating";
            this.chkRating.UseVisualStyleBackColor = true;
            this.chkRating.CheckedChanged += new System.EventHandler(this.chkRating_CheckedChanged);
            // 
            // horizontalPanel7
            // 
            this.horizontalPanel7.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.horizontalPanel7, 3);
            this.horizontalPanel7.Controls.Add(this.clReset);
            this.horizontalPanel7.Controls.Add(this.clSearch);
            this.horizontalPanel7.Controls.Add(this.clCancel);
            this.horizontalPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalPanel7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel7.Location = new System.Drawing.Point(3, 411);
            this.horizontalPanel7.Name = "horizontalPanel7";
            this.horizontalPanel7.Size = new System.Drawing.Size(973, 54);
            this.horizontalPanel7.TabIndex = 31;
            // 
            // clReset
            // 
            this.clReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clReset.Location = new System.Drawing.Point(399, 3);
            this.clReset.Name = "clReset";
            this.clReset.ShowShield = true;
            this.clReset.Size = new System.Drawing.Size(175, 48);
            this.clReset.TabIndex = 31;
            this.clReset.Text = "Reset";
            this.clReset.UseVisualStyleBackColor = true;
            this.clReset.Click += new System.EventHandler(this.clReset_Click);
            // 
            // clCancel
            // 
            this.clCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.clCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clCancel.Location = new System.Drawing.Point(595, 3);
            this.clCancel.Name = "clCancel";
            this.clCancel.Size = new System.Drawing.Size(175, 48);
            this.clCancel.TabIndex = 30;
            this.clCancel.Text = "Cancel";
            this.clCancel.UseVisualStyleBackColor = true;
            this.clCancel.Click += new System.EventHandler(this.clCancel_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(985, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User Based Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            this.AcceptButton = this.clSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.clCancel;
            this.ClientSize = new System.Drawing.Size(1013, 524);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SearchForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "SearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.listKeywords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listGenres)).EndInit();
            this.horizontalPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.horizontalPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.horizontalPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listDirectors)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.horizontalPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listStars)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.horizontalPanel6.ResumeLayout(false);
            this.horizontalPanel6.PerformLayout();
            this.horizontalPanel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.DataListView listKeywords;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private System.Windows.Forms.TextBox textRatingFrom;
        private System.Windows.Forms.TextBox textRatingTo;
        private WindowsFormsAero.CommandLink clSearch;
        private BrightIdeasSoftware.DataListView listGenres;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private WindowsFormsAero.HorizontalPanel horizontalPanel1;
        private WindowsFormsAero.HorizontalPanel horizontalPanel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private WindowsFormsAero.HorizontalPanel horizontalPanel6;
        private RatingControl.RatingStar ratingTo;
        private RatingControl.RatingStar ratingFrom;
        private System.Windows.Forms.CheckBox chkRating;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private WindowsFormsAero.SearchTextBox searchGenres;
        private System.Windows.Forms.CheckBox chkGenres;
        private System.Windows.Forms.Panel panel2;
        private WindowsFormsAero.SearchTextBox searchKeywords;
        private System.Windows.Forms.CheckBox chkKeywords;
        private WindowsFormsAero.HorizontalPanel horizontalPanel5;
        private BrightIdeasSoftware.DataListView listDirectors;
        private BrightIdeasSoftware.OLVColumn olvColumn7;
        private System.Windows.Forms.Panel panel4;
        private WindowsFormsAero.SearchTextBox searchDirectors;
        private System.Windows.Forms.CheckBox chkDirectors;
        private WindowsFormsAero.HorizontalPanel horizontalPanel3;
        private BrightIdeasSoftware.DataListView listStars;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private System.Windows.Forms.Panel panel3;
        private WindowsFormsAero.SearchTextBox searchStars;
        private System.Windows.Forms.CheckBox chkStars;
        private System.Windows.Forms.CheckBox chkClear;
        private WindowsFormsAero.HorizontalPanel horizontalPanel7;
        private WindowsFormsAero.CommandLink clReset;
        private WindowsFormsAero.CommandLink clCancel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}