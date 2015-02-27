using System;
using BrightIdeasSoftware;

namespace MovieBrowser.Forms
{
    partial class MovieBrowserSimple
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieBrowserSimple));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabMovies = new System.Windows.Forms.TabControl();
            this.tpMoviesTree = new System.Windows.Forms.TabPage();
            this.treeListFileSystem = new BrightIdeasSoftware.TreeListView();
            this.treeColumnTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.treeColumnRating = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.treeColumnYear = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.treeColumnSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.treeColumnFileType = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendToPendriveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.updateMovieInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchTextBox1 = new WindowsFormsAero.SearchTextBox();
            this.toolStripMoviesFilesystem = new System.Windows.Forms.ToolStrip();
            this.tbBrowseFolders = new System.Windows.Forms.ToolStripButton();
            this.tbRemoveFolders = new System.Windows.Forms.ToolStripButton();
            this.tbRefreshFolders = new System.Windows.Forms.ToolStripButton();
            this.tbSaveFolders = new System.Windows.Forms.ToolStripButton();
            this.tbGenerateXML = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.pbUpdateTree = new System.Windows.Forms.ToolStripButton();
            this.pbAddTreeItemToDb = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tbSearchImdb = new System.Windows.Forms.ToolStripButton();
            this.tbSearchGoogle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tbOpenExplorer = new System.Windows.Forms.ToolStripButton();
            this.tbIgnoreList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.comboPendrives = new System.Windows.Forms.ToolStripComboBox();
            this.tbLoadPendrives = new System.Windows.Forms.ToolStripButton();
            this.tbSendTo = new System.Windows.Forms.ToolStripButton();
            this.tpMovies2 = new System.Windows.Forms.TabPage();
            this.dataListMoviesDatabase = new BrightIdeasSoftware.DataListView();
            this.olvTitle = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvImdbId = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvRating = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvYear = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.searchTextBox2 = new WindowsFormsAero.SearchTextBox();
            this.toolStripMovies = new System.Windows.Forms.ToolStrip();
            this.tbUpdateDb = new System.Windows.Forms.ToolStripButton();
            this.tbAddToDb = new System.Windows.Forms.ToolStripButton();
            this.tbRefreshDb = new System.Windows.Forms.ToolStripButton();
            this.tbDeleteFromDb = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbWantToWatch = new System.Windows.Forms.ToolStripButton();
            this.tbLikeIt = new System.Windows.Forms.ToolStripButton();
            this.tbDislikeIt = new System.Windows.Forms.ToolStripButton();
            this.tbSeenIt = new System.Windows.Forms.ToolStripButton();
            this.tbHaveIt = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtUserRating = new System.Windows.Forms.ToolStripTextBox();
            this.tbRateIt = new System.Windows.Forms.ToolStripButton();
            this.tbUpdated = new System.Windows.Forms.ToolStripButton();
            this.tpVirtualFolders = new System.Windows.Forms.TabPage();
            this.treeListVirtualFolders = new BrightIdeasSoftware.TreeListView();
            this.olvColumn11 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn12 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn13 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.searchVirtualFolders = new WindowsFormsAero.SearchTextBox();
            this.toolStripVirtualFolders = new System.Windows.Forms.ToolStrip();
            this.tbLoadVirtualFolders = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.tbSaveVirtualTree = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.tpSearch = new System.Windows.Forms.TabPage();
            this.horizontalPanel3 = new WindowsFormsAero.HorizontalPanel();
            this.datalistResult = new BrightIdeasSoftware.DataListView();
            this.olvColumn7 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn8 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn9 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn10 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.searchTextForSearchResult = new WindowsFormsAero.SearchTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.clSearch = new WindowsFormsAero.CommandLink();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.tabInformation = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.toolStripBrowser = new System.Windows.Forms.ToolStrip();
            this.tbIntelligent = new System.Windows.Forms.ToolStripButton();
            this.tbAddToDbFromBrowser = new System.Windows.Forms.ToolStripButton();
            this.tbUpdateTreeNode = new System.Windows.Forms.ToolStripButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tpInformation = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listLanguages = new BrightIdeasSoftware.DataListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label1 = new System.Windows.Forms.Label();
            this.listKeywords = new BrightIdeasSoftware.DataListView();
            this.olvColKeyword = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColKeywordRated = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.listGenres = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.listCountries = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.listDirectors = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.listStars = new BrightIdeasSoftware.DataListView();
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.listWriters = new BrightIdeasSoftware.DataListView();
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label6 = new System.Windows.Forms.Label();
            this.listActors = new BrightIdeasSoftware.DataListView();
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.horizontalPanel1 = new WindowsFormsAero.HorizontalPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMPAA = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.textMpaaReason = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblRuntime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textHighlight = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.horizontalPanel2 = new WindowsFormsAero.HorizontalPanel();
            this.buttonModifyList = new System.Windows.Forms.Button();
            this.buttonAddToList = new System.Windows.Forms.Button();
            this.comboUserList = new WindowsFormsAero.ComboBox();
            this.pbHaveIt = new System.Windows.Forms.PictureBox();
            this.pbSeenIt = new System.Windows.Forms.PictureBox();
            this.pbDislike = new System.Windows.Forms.PictureBox();
            this.lblImdbId = new System.Windows.Forms.Label();
            this.pbLike = new System.Windows.Forms.PictureBox();
            this.pbWanted = new System.Windows.Forms.PictureBox();
            this.rsUserRating = new RatingControl.RatingStar();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.tbUserManagement = new System.Windows.Forms.ToolStripButton();
            this.tbKeywordManagement = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.googleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intelligentTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMovies.SuspendLayout();
            this.tpMoviesTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListFileSystem)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStripMoviesFilesystem.SuspendLayout();
            this.tpMovies2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListMoviesDatabase)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStripMovies.SuspendLayout();
            this.tpVirtualFolders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeListVirtualFolders)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStripVirtualFolders.SuspendLayout();
            this.tpSearch.SuspendLayout();
            this.horizontalPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datalistResult)).BeginInit();
            this.panel3.SuspendLayout();
            this.toolStripContainer2.ContentPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.tabInformation.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStripBrowser.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpInformation.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listLanguages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listKeywords)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDirectors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listStars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listWriters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listActors)).BeginInit();
            this.horizontalPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.horizontalPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHaveIt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeenIt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDislike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWanted)).BeginInit();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.horizontalPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1008, 422);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1008, 447);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripMain);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabMovies);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStripContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 322);
            this.splitContainer1.SplitterDistance = 411;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabMovies
            // 
            this.tabMovies.Controls.Add(this.tpMoviesTree);
            this.tabMovies.Controls.Add(this.tpMovies2);
            this.tabMovies.Controls.Add(this.tpVirtualFolders);
            this.tabMovies.Controls.Add(this.tpSearch);
            this.tabMovies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMovies.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMovies.Location = new System.Drawing.Point(0, 0);
            this.tabMovies.Name = "tabMovies";
            this.tabMovies.SelectedIndex = 0;
            this.tabMovies.Size = new System.Drawing.Size(411, 322);
            this.tabMovies.TabIndex = 0;
            // 
            // tpMoviesTree
            // 
            this.tpMoviesTree.Controls.Add(this.treeListFileSystem);
            this.tpMoviesTree.Controls.Add(this.panel2);
            this.tpMoviesTree.Location = new System.Drawing.Point(4, 26);
            this.tpMoviesTree.Name = "tpMoviesTree";
            this.tpMoviesTree.Padding = new System.Windows.Forms.Padding(3);
            this.tpMoviesTree.Size = new System.Drawing.Size(403, 292);
            this.tpMoviesTree.TabIndex = 3;
            this.tpMoviesTree.Text = "Movies Folders";
            this.tpMoviesTree.UseVisualStyleBackColor = true;
            // 
            // treeListFileSystem
            // 
            this.treeListFileSystem.AllColumns.Add(this.treeColumnTitle);
            this.treeListFileSystem.AllColumns.Add(this.treeColumnRating);
            this.treeListFileSystem.AllColumns.Add(this.treeColumnYear);
            this.treeListFileSystem.AllColumns.Add(this.treeColumnSize);
            this.treeListFileSystem.AllColumns.Add(this.treeColumnFileType);
            this.treeListFileSystem.AllowColumnReorder = true;
            this.treeListFileSystem.CheckBoxes = true;
            this.treeListFileSystem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.treeColumnTitle,
            this.treeColumnRating,
            this.treeColumnYear,
            this.treeColumnSize,
            this.treeColumnFileType});
            this.treeListFileSystem.ContextMenuStrip = this.contextMenuStrip1;
            this.treeListFileSystem.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListFileSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListFileSystem.EmptyListMsg = "Please add folder!";
            this.treeListFileSystem.FullRowSelect = true;
            this.treeListFileSystem.GridLines = true;
            this.treeListFileSystem.HideSelection = false;
            this.treeListFileSystem.Location = new System.Drawing.Point(3, 55);
            this.treeListFileSystem.Name = "treeListFileSystem";
            this.treeListFileSystem.OwnerDraw = true;
            this.treeListFileSystem.ShowGroups = false;
            this.treeListFileSystem.ShowImagesOnSubItems = true;
            this.treeListFileSystem.ShowItemToolTips = true;
            this.treeListFileSystem.Size = new System.Drawing.Size(397, 234);
            this.treeListFileSystem.SmallImageList = this.imageList1;
            this.treeListFileSystem.TabIndex = 1;
            this.treeListFileSystem.UseCompatibleStateImageBehavior = false;
            this.treeListFileSystem.UseFiltering = true;
            this.treeListFileSystem.View = System.Windows.Forms.View.Details;
            this.treeListFileSystem.VirtualMode = true;
            this.treeListFileSystem.SelectedIndexChanged += new System.EventHandler(this.treeListView1_SelectedIndexChanged);
            this.treeListFileSystem.DoubleClick += new System.EventHandler(this.treeListView1_DoubleClick);
            this.treeListFileSystem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // treeColumnTitle
            // 
            this.treeColumnTitle.AspectName = "Title";
            this.treeColumnTitle.Text = "Title";
            this.treeColumnTitle.Width = 300;
            // 
            // treeColumnRating
            // 
            this.treeColumnRating.AspectName = "Rating";
            this.treeColumnRating.Text = "Rating";
            // 
            // treeColumnYear
            // 
            this.treeColumnYear.AspectName = "Year";
            this.treeColumnYear.Text = "Year";
            // 
            // treeColumnSize
            // 
            this.treeColumnSize.Text = "Size";
            // 
            // treeColumnFileType
            // 
            this.treeColumnFileType.Text = "File Type";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendToPendriveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.updateMovieInformationToolStripMenuItem,
            this.refreshFolderToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(215, 76);
            // 
            // sendToPendriveToolStripMenuItem
            // 
            this.sendToPendriveToolStripMenuItem.Name = "sendToPendriveToolStripMenuItem";
            this.sendToPendriveToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.sendToPendriveToolStripMenuItem.Text = "Send To Pendrive";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(211, 6);
            // 
            // updateMovieInformationToolStripMenuItem
            // 
            this.updateMovieInformationToolStripMenuItem.Name = "updateMovieInformationToolStripMenuItem";
            this.updateMovieInformationToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.updateMovieInformationToolStripMenuItem.Text = "Update Movie Information";
            this.updateMovieInformationToolStripMenuItem.Click += new System.EventHandler(this.updateMovieInformationToolStripMenuItem_Click);
            // 
            // refreshFolderToolStripMenuItem
            // 
            this.refreshFolderToolStripMenuItem.Name = "refreshFolderToolStripMenuItem";
            this.refreshFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.refreshFolderToolStripMenuItem.Text = "Refresh Folder";
            this.refreshFolderToolStripMenuItem.Click += new System.EventHandler(this.refreshFolderToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "movie.png");
            this.imageList1.Images.SetKeyName(1, "folder.png");
            this.imageList1.Images.SetKeyName(2, "movie_file.png");
            this.imageList1.Images.SetKeyName(3, "subtitle.png");
            this.imageList1.Images.SetKeyName(4, "file.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.searchTextBox1);
            this.panel2.Controls.Add(this.toolStripMoviesFilesystem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(397, 52);
            this.panel2.TabIndex = 0;
            // 
            // searchTextBox1
            // 
            this.searchTextBox1.ActiveFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchTextBox1.Location = new System.Drawing.Point(0, 25);
            this.searchTextBox1.Name = "searchTextBox1";
            this.searchTextBox1.Size = new System.Drawing.Size(397, 24);
            this.searchTextBox1.TabIndex = 7;
            this.searchTextBox1.SearchStarted += new System.EventHandler(this.searchTextBox1_SearchStarted);
            this.searchTextBox1.SearchCancelled += new System.EventHandler(this.searchTextBox1_SearchCancelled);
            // 
            // toolStripMoviesFilesystem
            // 
            this.toolStripMoviesFilesystem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbBrowseFolders,
            this.tbRemoveFolders,
            this.tbRefreshFolders,
            this.tbSaveFolders,
            this.tbGenerateXML,
            this.toolStripSeparator6,
            this.pbUpdateTree,
            this.pbAddTreeItemToDb,
            this.toolStripSeparator5,
            this.tbSearchImdb,
            this.tbSearchGoogle,
            this.toolStripSeparator4,
            this.tbOpenExplorer,
            this.tbIgnoreList,
            this.toolStripSeparator7,
            this.comboPendrives,
            this.tbLoadPendrives,
            this.tbSendTo});
            this.toolStripMoviesFilesystem.Location = new System.Drawing.Point(0, 0);
            this.toolStripMoviesFilesystem.Name = "toolStripMoviesFilesystem";
            this.toolStripMoviesFilesystem.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripMoviesFilesystem.Size = new System.Drawing.Size(397, 25);
            this.toolStripMoviesFilesystem.TabIndex = 6;
            this.toolStripMoviesFilesystem.Text = "toolStrip2";
            // 
            // tbBrowseFolders
            // 
            this.tbBrowseFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbBrowseFolders.Image = global::MovieBrowser.Properties.Resources.folder_add;
            this.tbBrowseFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbBrowseFolders.Name = "tbBrowseFolders";
            this.tbBrowseFolders.Size = new System.Drawing.Size(23, 22);
            this.tbBrowseFolders.Text = "Browse";
            this.tbBrowseFolders.Click += new System.EventHandler(this.tbBrowseFolders_Click);
            // 
            // tbRemoveFolders
            // 
            this.tbRemoveFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRemoveFolders.Image = global::MovieBrowser.Properties.Resources.delete;
            this.tbRemoveFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRemoveFolders.Name = "tbRemoveFolders";
            this.tbRemoveFolders.Size = new System.Drawing.Size(23, 22);
            this.tbRemoveFolders.Text = "Remove Selected Folder";
            this.tbRemoveFolders.Click += new System.EventHandler(this.tbRemoveFolders_Click);
            // 
            // tbRefreshFolders
            // 
            this.tbRefreshFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRefreshFolders.Image = global::MovieBrowser.Properties.Resources.refresh;
            this.tbRefreshFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefreshFolders.Name = "tbRefreshFolders";
            this.tbRefreshFolders.Size = new System.Drawing.Size(23, 22);
            this.tbRefreshFolders.Text = "Refresh Folders";
            this.tbRefreshFolders.Click += new System.EventHandler(this.tbRefreshFolders_Click);
            // 
            // tbSaveFolders
            // 
            this.tbSaveFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSaveFolders.Image = global::MovieBrowser.Properties.Resources.save;
            this.tbSaveFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSaveFolders.Name = "tbSaveFolders";
            this.tbSaveFolders.Size = new System.Drawing.Size(23, 22);
            this.tbSaveFolders.Text = "Save";
            this.tbSaveFolders.Click += new System.EventHandler(this.tbSaveFolders_Click);
            // 
            // tbGenerateXML
            // 
            this.tbGenerateXML.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbGenerateXML.Image = ((System.Drawing.Image)(resources.GetObject("tbGenerateXML.Image")));
            this.tbGenerateXML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbGenerateXML.Name = "tbGenerateXML";
            this.tbGenerateXML.Size = new System.Drawing.Size(23, 22);
            this.tbGenerateXML.Text = "Export XML";
            this.tbGenerateXML.Click += new System.EventHandler(this.tbGenerateXML_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // pbUpdateTree
            // 
            this.pbUpdateTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pbUpdateTree.Image = global::MovieBrowser.Properties.Resources.pb_update;
            this.pbUpdateTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pbUpdateTree.Name = "pbUpdateTree";
            this.pbUpdateTree.Size = new System.Drawing.Size(23, 22);
            this.pbUpdateTree.Text = "Update";
            this.pbUpdateTree.Click += new System.EventHandler(this.pbUpdateTree_Click);
            // 
            // pbAddTreeItemToDb
            // 
            this.pbAddTreeItemToDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pbAddTreeItemToDb.Image = global::MovieBrowser.Properties.Resources.pb_movie;
            this.pbAddTreeItemToDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pbAddTreeItemToDb.Name = "pbAddTreeItemToDb";
            this.pbAddTreeItemToDb.Size = new System.Drawing.Size(23, 22);
            this.pbAddTreeItemToDb.Text = "Collect && Add to Database";
            this.pbAddTreeItemToDb.Click += new System.EventHandler(this.pbAddTreeItemToDb_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tbSearchImdb
            // 
            this.tbSearchImdb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSearchImdb.Image = global::MovieBrowser.Properties.Resources.imdb;
            this.tbSearchImdb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSearchImdb.Name = "tbSearchImdb";
            this.tbSearchImdb.Size = new System.Drawing.Size(23, 22);
            this.tbSearchImdb.Text = "Imdb Search";
            this.tbSearchImdb.Click += new System.EventHandler(this.tbSearchImdb_Click);
            // 
            // tbSearchGoogle
            // 
            this.tbSearchGoogle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSearchGoogle.Image = global::MovieBrowser.Properties.Resources.google;
            this.tbSearchGoogle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSearchGoogle.Name = "tbSearchGoogle";
            this.tbSearchGoogle.Size = new System.Drawing.Size(23, 22);
            this.tbSearchGoogle.Text = "Search Google";
            this.tbSearchGoogle.Click += new System.EventHandler(this.tbSearchGoogle_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tbOpenExplorer
            // 
            this.tbOpenExplorer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbOpenExplorer.Image = global::MovieBrowser.Properties.Resources.explorer;
            this.tbOpenExplorer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbOpenExplorer.Name = "tbOpenExplorer";
            this.tbOpenExplorer.Size = new System.Drawing.Size(23, 22);
            this.tbOpenExplorer.Text = "Open in Explorer";
            this.tbOpenExplorer.Click += new System.EventHandler(this.tbOpenExplorer_Click);
            // 
            // tbIgnoreList
            // 
            this.tbIgnoreList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbIgnoreList.Image = global::MovieBrowser.Properties.Resources.ignore_list;
            this.tbIgnoreList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbIgnoreList.Name = "tbIgnoreList";
            this.tbIgnoreList.Size = new System.Drawing.Size(23, 22);
            this.tbIgnoreList.Text = "Ignore List";
            this.tbIgnoreList.Click += new System.EventHandler(this.tbIgnoreList_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // comboPendrives
            // 
            this.comboPendrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPendrives.Name = "comboPendrives";
            this.comboPendrives.Size = new System.Drawing.Size(75, 25);
            // 
            // tbLoadPendrives
            // 
            this.tbLoadPendrives.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbLoadPendrives.Image = global::MovieBrowser.Properties.Resources.pen_drives;
            this.tbLoadPendrives.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLoadPendrives.Name = "tbLoadPendrives";
            this.tbLoadPendrives.Size = new System.Drawing.Size(23, 20);
            this.tbLoadPendrives.Text = "Load Pen Drives";
            this.tbLoadPendrives.Click += new System.EventHandler(this.tbLoadPendrives_Click);
            // 
            // tbSendTo
            // 
            this.tbSendTo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSendTo.Image = global::MovieBrowser.Properties.Resources.send_to;
            this.tbSendTo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSendTo.Name = "tbSendTo";
            this.tbSendTo.Size = new System.Drawing.Size(23, 20);
            this.tbSendTo.Text = "Send To Pendrive";
            this.tbSendTo.Click += new System.EventHandler(this.tbSendTo_Click);
            // 
            // tpMovies2
            // 
            this.tpMovies2.Controls.Add(this.dataListMoviesDatabase);
            this.tpMovies2.Controls.Add(this.panel1);
            this.tpMovies2.Location = new System.Drawing.Point(4, 26);
            this.tpMovies2.Name = "tpMovies2";
            this.tpMovies2.Padding = new System.Windows.Forms.Padding(3);
            this.tpMovies2.Size = new System.Drawing.Size(403, 292);
            this.tpMovies2.TabIndex = 2;
            this.tpMovies2.Text = "Movies";
            this.tpMovies2.UseVisualStyleBackColor = true;
            // 
            // dataListMoviesDatabase
            // 
            this.dataListMoviesDatabase.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.dataListMoviesDatabase.AllColumns.Add(this.olvTitle);
            this.dataListMoviesDatabase.AllColumns.Add(this.olvImdbId);
            this.dataListMoviesDatabase.AllColumns.Add(this.olvRating);
            this.dataListMoviesDatabase.AllColumns.Add(this.olvYear);
            this.dataListMoviesDatabase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvTitle,
            this.olvImdbId,
            this.olvRating,
            this.olvYear});
            this.dataListMoviesDatabase.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataListMoviesDatabase.DataSource = null;
            this.dataListMoviesDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListMoviesDatabase.FullRowSelect = true;
            this.dataListMoviesDatabase.GridLines = true;
            this.dataListMoviesDatabase.HideSelection = false;
            this.dataListMoviesDatabase.Location = new System.Drawing.Point(3, 56);
            this.dataListMoviesDatabase.Name = "dataListMoviesDatabase";
            this.dataListMoviesDatabase.OverlayText.Text = "";
            this.dataListMoviesDatabase.OwnerDraw = true;
            this.dataListMoviesDatabase.Size = new System.Drawing.Size(397, 233);
            this.dataListMoviesDatabase.TabIndex = 2;
            this.dataListMoviesDatabase.UseAlternatingBackColors = true;
            this.dataListMoviesDatabase.UseCompatibleStateImageBehavior = false;
            this.dataListMoviesDatabase.UseExplorerTheme = true;
            this.dataListMoviesDatabase.UseFiltering = true;
            this.dataListMoviesDatabase.UseHotItem = true;
            this.dataListMoviesDatabase.UseOverlays = false;
            this.dataListMoviesDatabase.UseTranslucentHotItem = true;
            this.dataListMoviesDatabase.View = System.Windows.Forms.View.Details;
            this.dataListMoviesDatabase.SelectedIndexChanged += new System.EventHandler(this.DataListView1SelectedIndexChanged);
            this.dataListMoviesDatabase.DoubleClick += new System.EventHandler(this.DataListView1DoubleClick);
            this.dataListMoviesDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataListView1KeyDown);
            // 
            // olvTitle
            // 
            this.olvTitle.AspectName = "TitleCleaned";
            this.olvTitle.Text = "Title";
            this.olvTitle.UseInitialLetterForGroup = true;
            this.olvTitle.Width = 200;
            // 
            // olvImdbId
            // 
            this.olvImdbId.AspectName = "ImdbId";
            this.olvImdbId.Text = "ImdbId";
            this.olvImdbId.Width = 100;
            // 
            // olvRating
            // 
            this.olvRating.AspectName = "Rating";
            this.olvRating.Text = "Rating";
            // 
            // olvYear
            // 
            this.olvYear.AspectName = "Year";
            this.olvYear.Text = "Year";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.searchTextBox2);
            this.panel1.Controls.Add(this.toolStripMovies);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 53);
            this.panel1.TabIndex = 1;
            // 
            // searchTextBox2
            // 
            this.searchTextBox2.ActiveFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchTextBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTextBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextBox2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchTextBox2.Location = new System.Drawing.Point(0, 25);
            this.searchTextBox2.Name = "searchTextBox2";
            this.searchTextBox2.Size = new System.Drawing.Size(397, 24);
            this.searchTextBox2.TabIndex = 6;
            this.searchTextBox2.SearchStarted += new System.EventHandler(this.searchTextBox2_SearchStarted);
            this.searchTextBox2.SearchCancelled += new System.EventHandler(this.searchTextBox2_SearchCancelled);
            // 
            // toolStripMovies
            // 
            this.toolStripMovies.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbUpdateDb,
            this.tbAddToDb,
            this.tbRefreshDb,
            this.tbDeleteFromDb,
            this.toolStripSeparator1,
            this.tbWantToWatch,
            this.tbLikeIt,
            this.tbDislikeIt,
            this.tbSeenIt,
            this.tbHaveIt,
            this.toolStripSeparator2,
            this.txtUserRating,
            this.tbRateIt,
            this.tbUpdated});
            this.toolStripMovies.Location = new System.Drawing.Point(0, 0);
            this.toolStripMovies.Name = "toolStripMovies";
            this.toolStripMovies.Size = new System.Drawing.Size(397, 25);
            this.toolStripMovies.TabIndex = 5;
            // 
            // tbUpdateDb
            // 
            this.tbUpdateDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbUpdateDb.Image = global::MovieBrowser.Properties.Resources.refresh;
            this.tbUpdateDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUpdateDb.Name = "tbUpdateDb";
            this.tbUpdateDb.Size = new System.Drawing.Size(23, 22);
            this.tbUpdateDb.Text = "Update";
            this.tbUpdateDb.Click += new System.EventHandler(this.tbUpdateDb_Click);
            // 
            // tbAddToDb
            // 
            this.tbAddToDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbAddToDb.Image = global::MovieBrowser.Properties.Resources.update;
            this.tbAddToDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAddToDb.Name = "tbAddToDb";
            this.tbAddToDb.Size = new System.Drawing.Size(23, 22);
            this.tbAddToDb.Text = "Collect From Browser";
            this.tbAddToDb.Click += new System.EventHandler(this.tbAddToDb_Click);
            // 
            // tbRefreshDb
            // 
            this.tbRefreshDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRefreshDb.Image = global::MovieBrowser.Properties.Resources.refresh16;
            this.tbRefreshDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefreshDb.Name = "tbRefreshDb";
            this.tbRefreshDb.Size = new System.Drawing.Size(23, 22);
            this.tbRefreshDb.Text = "Refresh";
            this.tbRefreshDb.Click += new System.EventHandler(this.tbRefreshDb_Click);
            // 
            // tbDeleteFromDb
            // 
            this.tbDeleteFromDb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDeleteFromDb.Image = global::MovieBrowser.Properties.Resources.delete;
            this.tbDeleteFromDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDeleteFromDb.Name = "tbDeleteFromDb";
            this.tbDeleteFromDb.Size = new System.Drawing.Size(23, 22);
            this.tbDeleteFromDb.Text = "Delete";
            this.tbDeleteFromDb.Click += new System.EventHandler(this.tbDeleteFromDb_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tbWantToWatch
            // 
            this.tbWantToWatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbWantToWatch.Image = global::MovieBrowser.Properties.Resources.check_list;
            this.tbWantToWatch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbWantToWatch.Name = "tbWantToWatch";
            this.tbWantToWatch.Size = new System.Drawing.Size(23, 22);
            this.tbWantToWatch.Text = "Watch";
            this.tbWantToWatch.Click += new System.EventHandler(this.tbWantToWatch_Click);
            // 
            // tbLikeIt
            // 
            this.tbLikeIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbLikeIt.Image = global::MovieBrowser.Properties.Resources.like_it;
            this.tbLikeIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLikeIt.Name = "tbLikeIt";
            this.tbLikeIt.Size = new System.Drawing.Size(23, 22);
            this.tbLikeIt.Text = "Like It";
            this.tbLikeIt.Click += new System.EventHandler(this.tbLikeIt_Click);
            // 
            // tbDislikeIt
            // 
            this.tbDislikeIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbDislikeIt.Image = global::MovieBrowser.Properties.Resources.hate_it;
            this.tbDislikeIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbDislikeIt.Name = "tbDislikeIt";
            this.tbDislikeIt.Size = new System.Drawing.Size(23, 22);
            this.tbDislikeIt.Text = "Dislike It";
            this.tbDislikeIt.ToolTipText = "Dislike It";
            this.tbDislikeIt.Click += new System.EventHandler(this.tbDislikeIt_Click);
            // 
            // tbSeenIt
            // 
            this.tbSeenIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSeenIt.Image = global::MovieBrowser.Properties.Resources.seen_it;
            this.tbSeenIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSeenIt.Name = "tbSeenIt";
            this.tbSeenIt.Size = new System.Drawing.Size(23, 22);
            this.tbSeenIt.Text = "Seen It";
            this.tbSeenIt.Click += new System.EventHandler(this.tbSeenIt_Click);
            // 
            // tbHaveIt
            // 
            this.tbHaveIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbHaveIt.Image = global::MovieBrowser.Properties.Resources.have_it;
            this.tbHaveIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbHaveIt.Name = "tbHaveIt";
            this.tbHaveIt.Size = new System.Drawing.Size(23, 22);
            this.tbHaveIt.Text = "Have It";
            this.tbHaveIt.Click += new System.EventHandler(this.tbHaveIt_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // txtUserRating
            // 
            this.txtUserRating.Name = "txtUserRating";
            this.txtUserRating.Size = new System.Drawing.Size(48, 25);
            // 
            // tbRateIt
            // 
            this.tbRateIt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRateIt.Image = global::MovieBrowser.Properties.Resources.movie_db;
            this.tbRateIt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRateIt.Name = "tbRateIt";
            this.tbRateIt.Size = new System.Drawing.Size(23, 22);
            this.tbRateIt.Text = "Rate It";
            this.tbRateIt.Click += new System.EventHandler(this.tbRateIt_Click);
            // 
            // tbUpdated
            // 
            this.tbUpdated.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbUpdated.Image = ((System.Drawing.Image)(resources.GetObject("tbUpdated.Image")));
            this.tbUpdated.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUpdated.Name = "tbUpdated";
            this.tbUpdated.Size = new System.Drawing.Size(56, 22);
            this.tbUpdated.Text = "Updated";
            this.tbUpdated.Click += new System.EventHandler(this.tbUpdated_Click);
            // 
            // tpVirtualFolders
            // 
            this.tpVirtualFolders.Controls.Add(this.treeListVirtualFolders);
            this.tpVirtualFolders.Controls.Add(this.panel4);
            this.tpVirtualFolders.Location = new System.Drawing.Point(4, 26);
            this.tpVirtualFolders.Name = "tpVirtualFolders";
            this.tpVirtualFolders.Padding = new System.Windows.Forms.Padding(3);
            this.tpVirtualFolders.Size = new System.Drawing.Size(403, 292);
            this.tpVirtualFolders.TabIndex = 5;
            this.tpVirtualFolders.Text = "Virtual Folders";
            this.tpVirtualFolders.UseVisualStyleBackColor = true;
            // 
            // treeListVirtualFolders
            // 
            this.treeListVirtualFolders.AllColumns.Add(this.olvColumn11);
            this.treeListVirtualFolders.AllColumns.Add(this.olvColumn12);
            this.treeListVirtualFolders.AllColumns.Add(this.olvColumn13);
            this.treeListVirtualFolders.AllowColumnReorder = true;
            this.treeListVirtualFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn11,
            this.olvColumn12,
            this.olvColumn13});
            this.treeListVirtualFolders.ContextMenuStrip = this.contextMenuStrip2;
            this.treeListVirtualFolders.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeListVirtualFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListVirtualFolders.EmptyListMsg = "Please add folder!";
            this.treeListVirtualFolders.FullRowSelect = true;
            this.treeListVirtualFolders.GridLines = true;
            this.treeListVirtualFolders.HideSelection = false;
            this.treeListVirtualFolders.Location = new System.Drawing.Point(3, 55);
            this.treeListVirtualFolders.Name = "treeListVirtualFolders";
            this.treeListVirtualFolders.OwnerDraw = true;
            this.treeListVirtualFolders.ShowGroups = false;
            this.treeListVirtualFolders.ShowImagesOnSubItems = true;
            this.treeListVirtualFolders.ShowItemToolTips = true;
            this.treeListVirtualFolders.Size = new System.Drawing.Size(397, 234);
            this.treeListVirtualFolders.TabIndex = 3;
            this.treeListVirtualFolders.UseCompatibleStateImageBehavior = false;
            this.treeListVirtualFolders.UseFiltering = true;
            this.treeListVirtualFolders.View = System.Windows.Forms.View.Details;
            this.treeListVirtualFolders.SelectedIndexChanged += new System.EventHandler(this.treeListVirtualFolders_SelectedIndexChanged);
            this.treeListVirtualFolders.DoubleClick += new System.EventHandler(this.treeListVirtualFolders_DoubleClick);
            this.treeListVirtualFolders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeListVirtualFolders_KeyDown);
            // 
            // olvColumn11
            // 
            this.olvColumn11.AspectName = "Title";
            this.olvColumn11.Text = "Title";
            this.olvColumn11.Width = 300;
            // 
            // olvColumn12
            // 
            this.olvColumn12.AspectName = "Rating";
            this.olvColumn12.Text = "Rating";
            // 
            // olvColumn13
            // 
            this.olvColumn13.AspectName = "Year";
            this.olvColumn13.Text = "Year";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateItemsToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(145, 26);
            // 
            // updateItemsToolStripMenuItem
            // 
            this.updateItemsToolStripMenuItem.Name = "updateItemsToolStripMenuItem";
            this.updateItemsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.updateItemsToolStripMenuItem.Text = "Update Items";
            this.updateItemsToolStripMenuItem.Click += new System.EventHandler(this.updateItemsToolStripMenuItem_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.searchVirtualFolders);
            this.panel4.Controls.Add(this.toolStripVirtualFolders);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(397, 52);
            this.panel4.TabIndex = 2;
            // 
            // searchVirtualFolders
            // 
            this.searchVirtualFolders.ActiveFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchVirtualFolders.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchVirtualFolders.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchVirtualFolders.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchVirtualFolders.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchVirtualFolders.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchVirtualFolders.Location = new System.Drawing.Point(0, 25);
            this.searchVirtualFolders.Name = "searchVirtualFolders";
            this.searchVirtualFolders.Size = new System.Drawing.Size(397, 24);
            this.searchVirtualFolders.TabIndex = 7;
            this.searchVirtualFolders.SearchStarted += new System.EventHandler(this.searchVirtualFolders_SearchStarted);
            this.searchVirtualFolders.SearchCancelled += new System.EventHandler(this.searchVirtualFolders_SearchCancelled);
            // 
            // toolStripVirtualFolders
            // 
            this.toolStripVirtualFolders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbLoadVirtualFolders,
            this.toolStripButton3,
            this.toolStripButton4,
            this.tbSaveVirtualTree,
            this.toolStripSeparator3,
            this.toolStripButton7,
            this.toolStripSeparator8,
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripSeparator9});
            this.toolStripVirtualFolders.Location = new System.Drawing.Point(0, 0);
            this.toolStripVirtualFolders.Name = "toolStripVirtualFolders";
            this.toolStripVirtualFolders.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripVirtualFolders.Size = new System.Drawing.Size(397, 25);
            this.toolStripVirtualFolders.TabIndex = 6;
            this.toolStripVirtualFolders.Text = "Tool Virtual";
            // 
            // tbLoadVirtualFolders
            // 
            this.tbLoadVirtualFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbLoadVirtualFolders.Image = global::MovieBrowser.Properties.Resources.folder_add;
            this.tbLoadVirtualFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbLoadVirtualFolders.Name = "tbLoadVirtualFolders";
            this.tbLoadVirtualFolders.Size = new System.Drawing.Size(23, 22);
            this.tbLoadVirtualFolders.Text = "Browse";
            this.tbLoadVirtualFolders.Click += new System.EventHandler(this.tbLoadVirtualFolders_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::MovieBrowser.Properties.Resources.delete;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "Remove Selected Folder";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::MovieBrowser.Properties.Resources.refresh;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "Refresh Folders";
            // 
            // tbSaveVirtualTree
            // 
            this.tbSaveVirtualTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbSaveVirtualTree.Image = global::MovieBrowser.Properties.Resources.save;
            this.tbSaveVirtualTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbSaveVirtualTree.Name = "tbSaveVirtualTree";
            this.tbSaveVirtualTree.Size = new System.Drawing.Size(23, 22);
            this.tbSaveVirtualTree.Text = "Save";
            this.tbSaveVirtualTree.Click += new System.EventHandler(this.tbSaveVirtualTree_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = global::MovieBrowser.Properties.Resources.pb_movie;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Collect && Add to Database";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = global::MovieBrowser.Properties.Resources.imdb;
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton8.Text = "Imdb Search";
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton9.Image = global::MovieBrowser.Properties.Resources.google;
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton9.Text = "Search Google";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // tpSearch
            // 
            this.tpSearch.Controls.Add(this.horizontalPanel3);
            this.tpSearch.Controls.Add(this.panel3);
            this.tpSearch.Location = new System.Drawing.Point(4, 26);
            this.tpSearch.Name = "tpSearch";
            this.tpSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tpSearch.Size = new System.Drawing.Size(403, 292);
            this.tpSearch.TabIndex = 4;
            this.tpSearch.Text = "Search";
            this.tpSearch.UseVisualStyleBackColor = true;
            // 
            // horizontalPanel3
            // 
            this.horizontalPanel3.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel3.Controls.Add(this.datalistResult);
            this.horizontalPanel3.Controls.Add(this.searchTextForSearchResult);
            this.horizontalPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.horizontalPanel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel3.Location = new System.Drawing.Point(3, 73);
            this.horizontalPanel3.Name = "horizontalPanel3";
            this.horizontalPanel3.Padding = new System.Windows.Forms.Padding(10);
            this.horizontalPanel3.Size = new System.Drawing.Size(397, 216);
            this.horizontalPanel3.TabIndex = 1;
            // 
            // datalistResult
            // 
            this.datalistResult.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.datalistResult.AllColumns.Add(this.olvColumn7);
            this.datalistResult.AllColumns.Add(this.olvColumn8);
            this.datalistResult.AllColumns.Add(this.olvColumn9);
            this.datalistResult.AllColumns.Add(this.olvColumn10);
            this.datalistResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn7,
            this.olvColumn8,
            this.olvColumn9,
            this.olvColumn10});
            this.datalistResult.Cursor = System.Windows.Forms.Cursors.Default;
            this.datalistResult.DataSource = null;
            this.datalistResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datalistResult.FullRowSelect = true;
            this.datalistResult.GridLines = true;
            this.datalistResult.HideSelection = false;
            this.datalistResult.Location = new System.Drawing.Point(10, 34);
            this.datalistResult.Name = "datalistResult";
            this.datalistResult.OverlayText.Text = "";
            this.datalistResult.OwnerDraw = true;
            this.datalistResult.Size = new System.Drawing.Size(377, 172);
            this.datalistResult.TabIndex = 8;
            this.datalistResult.UseAlternatingBackColors = true;
            this.datalistResult.UseCompatibleStateImageBehavior = false;
            this.datalistResult.UseExplorerTheme = true;
            this.datalistResult.UseFiltering = true;
            this.datalistResult.UseHotItem = true;
            this.datalistResult.UseOverlays = false;
            this.datalistResult.UseTranslucentHotItem = true;
            this.datalistResult.View = System.Windows.Forms.View.Details;
            this.datalistResult.SelectedIndexChanged += new System.EventHandler(this.datalistResult_SelectedIndexChanged);
            this.datalistResult.DoubleClick += new System.EventHandler(this.datalistResult_DoubleClick);
            this.datalistResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datalistResult_KeyDown);
            // 
            // olvColumn7
            // 
            this.olvColumn7.AspectName = "TitleCleaned";
            this.olvColumn7.Text = "Title";
            this.olvColumn7.UseInitialLetterForGroup = true;
            this.olvColumn7.Width = 200;
            // 
            // olvColumn8
            // 
            this.olvColumn8.AspectName = "ImdbId";
            this.olvColumn8.Text = "ImdbId";
            this.olvColumn8.Width = 100;
            // 
            // olvColumn9
            // 
            this.olvColumn9.AspectName = "Rating";
            this.olvColumn9.Text = "Rating";
            // 
            // olvColumn10
            // 
            this.olvColumn10.AspectName = "Year";
            this.olvColumn10.Text = "Year";
            // 
            // searchTextForSearchResult
            // 
            this.searchTextForSearchResult.ActiveFont = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextForSearchResult.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.searchTextForSearchResult.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchTextForSearchResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchTextForSearchResult.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchTextForSearchResult.ForeColor = System.Drawing.SystemColors.GrayText;
            this.searchTextForSearchResult.Location = new System.Drawing.Point(10, 10);
            this.searchTextForSearchResult.Name = "searchTextForSearchResult";
            this.searchTextForSearchResult.Size = new System.Drawing.Size(377, 24);
            this.searchTextForSearchResult.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.clSearch);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 70);
            this.panel3.TabIndex = 0;
            // 
            // clSearch
            // 
            this.clSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clSearch.Location = new System.Drawing.Point(10, 10);
            this.clSearch.Name = "clSearch";
            this.clSearch.ShowShield = true;
            this.clSearch.Size = new System.Drawing.Size(200, 50);
            this.clSearch.TabIndex = 0;
            this.clSearch.Text = "Search Criteria";
            this.clSearch.UseVisualStyleBackColor = true;
            this.clSearch.Click += new System.EventHandler(this.clSearch_Click);
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Controls.Add(this.tabInformation);
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(593, 297);
            this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(593, 322);
            this.toolStripContainer2.TabIndex = 1;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // tabInformation
            // 
            this.tabInformation.Controls.Add(this.tabPage2);
            this.tabInformation.Controls.Add(this.tabPage1);
            this.tabInformation.Controls.Add(this.tpInformation);
            this.tabInformation.Controls.Add(this.tabPage4);
            this.tabInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInformation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInformation.Location = new System.Drawing.Point(0, 0);
            this.tabInformation.Name = "tabInformation";
            this.tabInformation.SelectedIndex = 0;
            this.tabInformation.Size = new System.Drawing.Size(593, 297);
            this.tabInformation.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.webBrowser1);
            this.tabPage2.Controls.Add(this.toolStripBrowser);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(585, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Browser";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 28);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(579, 236);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser1DocumentCompleted);
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.WebBrowser1Navigated);
            // 
            // toolStripBrowser
            // 
            this.toolStripBrowser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbIntelligent,
            this.tbAddToDbFromBrowser,
            this.tbUpdateTreeNode});
            this.toolStripBrowser.Location = new System.Drawing.Point(3, 3);
            this.toolStripBrowser.Name = "toolStripBrowser";
            this.toolStripBrowser.Size = new System.Drawing.Size(579, 25);
            this.toolStripBrowser.TabIndex = 1;
            this.toolStripBrowser.Text = "toolStrip4";
            // 
            // tbIntelligent
            // 
            this.tbIntelligent.Checked = true;
            this.tbIntelligent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tbIntelligent.Image = global::MovieBrowser.Properties.Resources.intel;
            this.tbIntelligent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbIntelligent.Name = "tbIntelligent";
            this.tbIntelligent.Size = new System.Drawing.Size(80, 22);
            this.tbIntelligent.Text = "Intelligent";
            this.tbIntelligent.Click += new System.EventHandler(this.tbIntelligent_Click);
            // 
            // tbAddToDbFromBrowser
            // 
            this.tbAddToDbFromBrowser.Image = global::MovieBrowser.Properties.Resources.update;
            this.tbAddToDbFromBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbAddToDbFromBrowser.Name = "tbAddToDbFromBrowser";
            this.tbAddToDbFromBrowser.Size = new System.Drawing.Size(81, 22);
            this.tbAddToDbFromBrowser.Text = "Add to Db";
            this.tbAddToDbFromBrowser.Click += new System.EventHandler(this.tbAddToDbFromBrowser_Click);
            // 
            // tbUpdateTreeNode
            // 
            this.tbUpdateTreeNode.Image = global::MovieBrowser.Properties.Resources.pb_update;
            this.tbUpdateTreeNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUpdateTreeNode.Name = "tbUpdateTreeNode";
            this.tbUpdateTreeNode.Size = new System.Drawing.Size(123, 22);
            this.tbUpdateTreeNode.Text = "Update Tree Node";
            this.tbUpdateTreeNode.Click += new System.EventHandler(this.tbUpdateTreeNode_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(585, 267);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Debug";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(579, 261);
            this.textBox1.TabIndex = 0;
            // 
            // tpInformation
            // 
            this.tpInformation.Controls.Add(this.tableLayoutPanel1);
            this.tpInformation.Location = new System.Drawing.Point(4, 26);
            this.tpInformation.Name = "tpInformation";
            this.tpInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tpInformation.Size = new System.Drawing.Size(585, 267);
            this.tpInformation.TabIndex = 4;
            this.tpInformation.Text = "Movie Info";
            this.tpInformation.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.listLanguages, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listKeywords, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listGenres, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.listCountries, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(579, 261);
            this.tableLayoutPanel1.TabIndex = 20;
            // 
            // listLanguages
            // 
            this.listLanguages.AllColumns.Add(this.olvColumn2);
            this.listLanguages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2});
            this.listLanguages.DataSource = null;
            this.listLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLanguages.FullRowSelect = true;
            this.listLanguages.GridLines = true;
            this.listLanguages.HasCollapsibleGroups = false;
            this.listLanguages.Location = new System.Drawing.Point(196, 153);
            this.listLanguages.Name = "listLanguages";
            this.listLanguages.ShowGroups = false;
            this.listLanguages.Size = new System.Drawing.Size(187, 105);
            this.listLanguages.TabIndex = 21;
            this.listLanguages.UseCompatibleStateImageBehavior = false;
            this.listLanguages.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Name";
            this.olvColumn2.Text = "Language";
            this.olvColumn2.UseInitialLetterForGroup = true;
            this.olvColumn2.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Keywords";
            // 
            // listKeywords
            // 
            this.listKeywords.AllColumns.Add(this.olvColKeyword);
            this.listKeywords.AllColumns.Add(this.olvColKeywordRated);
            this.listKeywords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColKeyword,
            this.olvColKeywordRated});
            this.listKeywords.DataSource = null;
            this.listKeywords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listKeywords.FullRowSelect = true;
            this.listKeywords.GridLines = true;
            this.listKeywords.Location = new System.Drawing.Point(3, 23);
            this.listKeywords.Name = "listKeywords";
            this.tableLayoutPanel1.SetRowSpan(this.listKeywords, 3);
            this.listKeywords.Size = new System.Drawing.Size(187, 235);
            this.listKeywords.TabIndex = 19;
            this.listKeywords.UseCompatibleStateImageBehavior = false;
            this.listKeywords.View = System.Windows.Forms.View.Details;
            this.listKeywords.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.listKeywords_FormatRow);
            // 
            // olvColKeyword
            // 
            this.olvColKeyword.AspectName = "Name";
            this.olvColKeyword.IsTileViewColumn = true;
            this.olvColKeyword.Text = "Keyword";
            this.olvColKeyword.UseInitialLetterForGroup = true;
            this.olvColKeyword.Width = 200;
            // 
            // olvColKeywordRated
            // 
            this.olvColKeywordRated.AspectName = "KeywordRating";
            this.olvColKeywordRated.Text = "Rated";
            // 
            // listGenres
            // 
            this.listGenres.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listGenres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listGenres.FullRowSelect = true;
            this.listGenres.Location = new System.Drawing.Point(389, 23);
            this.listGenres.Name = "listGenres";
            this.listGenres.Size = new System.Drawing.Size(187, 104);
            this.listGenres.TabIndex = 2;
            this.listGenres.UseCompatibleStateImageBehavior = false;
            this.listGenres.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 200;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(389, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Genres";
            // 
            // listCountries
            // 
            this.listCountries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.listCountries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listCountries.FullRowSelect = true;
            this.listCountries.Location = new System.Drawing.Point(196, 23);
            this.listCountries.Name = "listCountries";
            this.listCountries.Size = new System.Drawing.Size(187, 104);
            this.listCountries.TabIndex = 1;
            this.listCountries.UseCompatibleStateImageBehavior = false;
            this.listCountries.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Countries";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Languages";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tableLayoutPanel3);
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(585, 267);
            this.tabPage4.TabIndex = 5;
            this.tabPage4.Text = "Personnels";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.listDirectors, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.listStars, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.listWriters, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.listActors, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label12, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(579, 261);
            this.tableLayoutPanel3.TabIndex = 21;
            // 
            // listDirectors
            // 
            this.listDirectors.AllColumns.Add(this.olvColumn1);
            this.listDirectors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.listDirectors.DataSource = null;
            this.listDirectors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDirectors.FullRowSelect = true;
            this.listDirectors.GridLines = true;
            this.listDirectors.HasCollapsibleGroups = false;
            this.listDirectors.Location = new System.Drawing.Point(389, 23);
            this.listDirectors.Name = "listDirectors";
            this.listDirectors.ShowGroups = false;
            this.listDirectors.Size = new System.Drawing.Size(187, 94);
            this.listDirectors.TabIndex = 24;
            this.listDirectors.UseCompatibleStateImageBehavior = false;
            this.listDirectors.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 200;
            // 
            // listStars
            // 
            this.listStars.AllColumns.Add(this.olvColumn6);
            this.listStars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn6});
            this.listStars.DataSource = null;
            this.listStars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listStars.FullRowSelect = true;
            this.listStars.GridLines = true;
            this.listStars.HasCollapsibleGroups = false;
            this.listStars.Location = new System.Drawing.Point(196, 23);
            this.listStars.Name = "listStars";
            this.listStars.ShowGroups = false;
            this.listStars.Size = new System.Drawing.Size(187, 94);
            this.listStars.TabIndex = 23;
            this.listStars.UseCompatibleStateImageBehavior = false;
            this.listStars.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "Name";
            this.olvColumn6.Text = "Name";
            this.olvColumn6.UseInitialLetterForGroup = true;
            this.olvColumn6.Width = 200;
            // 
            // listWriters
            // 
            this.listWriters.AllColumns.Add(this.olvColumn5);
            this.listWriters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn5});
            this.listWriters.DataSource = null;
            this.listWriters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listWriters.FullRowSelect = true;
            this.listWriters.GridLines = true;
            this.listWriters.HasCollapsibleGroups = false;
            this.listWriters.Location = new System.Drawing.Point(196, 143);
            this.listWriters.Name = "listWriters";
            this.listWriters.ShowGroups = false;
            this.listWriters.Size = new System.Drawing.Size(187, 94);
            this.listWriters.TabIndex = 22;
            this.listWriters.UseCompatibleStateImageBehavior = false;
            this.listWriters.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Name";
            this.olvColumn5.Text = "Name";
            this.olvColumn5.UseInitialLetterForGroup = true;
            this.olvColumn5.Width = 200;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Actors";
            // 
            // listActors
            // 
            this.listActors.AllColumns.Add(this.olvColumn3);
            this.listActors.AllColumns.Add(this.olvColumn4);
            this.listActors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn3,
            this.olvColumn4});
            this.listActors.DataSource = null;
            this.listActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listActors.FullRowSelect = true;
            this.listActors.GridLines = true;
            this.listActors.Location = new System.Drawing.Point(3, 23);
            this.listActors.Name = "listActors";
            this.tableLayoutPanel3.SetRowSpan(this.listActors, 3);
            this.listActors.Size = new System.Drawing.Size(187, 214);
            this.listActors.TabIndex = 19;
            this.listActors.UseCompatibleStateImageBehavior = false;
            this.listActors.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Name";
            this.olvColumn3.IsTileViewColumn = true;
            this.olvColumn3.Text = "Keyword";
            this.olvColumn3.UseInitialLetterForGroup = true;
            this.olvColumn3.Width = 200;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "KeywordRating";
            this.olvColumn4.Text = "Rated";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(389, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Directors";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(196, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "Stars";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(196, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 17);
            this.label12.TabIndex = 20;
            this.label12.Text = "Writers";
            // 
            // horizontalPanel1
            // 
            this.horizontalPanel1.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel1.Controls.Add(this.tableLayoutPanel2);
            this.horizontalPanel1.Controls.Add(this.lblYear);
            this.horizontalPanel1.Controls.Add(this.lblRating);
            this.horizontalPanel1.Controls.Add(this.horizontalPanel2);
            this.horizontalPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel1.Location = new System.Drawing.Point(0, 322);
            this.horizontalPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 100);
            this.horizontalPanel1.Name = "horizontalPanel1";
            this.horizontalPanel1.Size = new System.Drawing.Size(1008, 100);
            this.horizontalPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblMPAA, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textMpaaReason, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblRuntime, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.textHighlight, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(90, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(571, 100);
            this.tableLayoutPanel2.TabIndex = 40;
            // 
            // lblMPAA
            // 
            this.lblMPAA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMPAA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMPAA.Location = new System.Drawing.Point(3, 29);
            this.lblMPAA.Name = "lblMPAA";
            this.lblMPAA.ReadOnly = true;
            this.lblMPAA.Size = new System.Drawing.Size(69, 23);
            this.lblMPAA.TabIndex = 24;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblTitle, 3);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(332, 26);
            this.lblTitle.TabIndex = 34;
            this.lblTitle.Text = ".";
            // 
            // textMpaaReason
            // 
            this.textMpaaReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textMpaaReason.Location = new System.Drawing.Point(108, 29);
            this.textMpaaReason.Name = "textMpaaReason";
            this.textMpaaReason.ReadOnly = true;
            this.textMpaaReason.Size = new System.Drawing.Size(227, 23);
            this.textMpaaReason.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Right;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(80, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 26);
            this.label10.TabIndex = 26;
            this.label10.Text = "for";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(13, 52);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(2);
            this.label8.Size = new System.Drawing.Size(59, 26);
            this.label8.TabIndex = 30;
            this.label8.Text = "Runtime:";
            // 
            // lblRuntime
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.lblRuntime, 2);
            this.lblRuntime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRuntime.Location = new System.Drawing.Point(78, 55);
            this.lblRuntime.Name = "lblRuntime";
            this.lblRuntime.ReadOnly = true;
            this.lblRuntime.Size = new System.Drawing.Size(257, 23);
            this.lblRuntime.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(341, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 15);
            this.label4.TabIndex = 39;
            this.label4.Text = "Highlight:";
            // 
            // textHighlight
            // 
            this.textHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textHighlight.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textHighlight.Location = new System.Drawing.Point(341, 29);
            this.textHighlight.Multiline = true;
            this.textHighlight.Name = "textHighlight";
            this.textHighlight.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.textHighlight, 3);
            this.textHighlight.Size = new System.Drawing.Size(227, 68);
            this.textHighlight.TabIndex = 38;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(101, 42);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(0, 25);
            this.lblYear.TabIndex = 36;
            // 
            // lblRating
            // 
            this.lblRating.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRating.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblRating.Location = new System.Drawing.Point(0, 0);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(90, 100);
            this.lblRating.TabIndex = 33;
            this.lblRating.Text = ".";
            this.lblRating.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // horizontalPanel2
            // 
            this.horizontalPanel2.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel2.Controls.Add(this.buttonModifyList);
            this.horizontalPanel2.Controls.Add(this.buttonAddToList);
            this.horizontalPanel2.Controls.Add(this.comboUserList);
            this.horizontalPanel2.Controls.Add(this.pbHaveIt);
            this.horizontalPanel2.Controls.Add(this.pbSeenIt);
            this.horizontalPanel2.Controls.Add(this.pbDislike);
            this.horizontalPanel2.Controls.Add(this.lblImdbId);
            this.horizontalPanel2.Controls.Add(this.pbLike);
            this.horizontalPanel2.Controls.Add(this.pbWanted);
            this.horizontalPanel2.Controls.Add(this.rsUserRating);
            this.horizontalPanel2.Controls.Add(this.label9);
            this.horizontalPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.horizontalPanel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel2.Location = new System.Drawing.Point(661, 0);
            this.horizontalPanel2.Name = "horizontalPanel2";
            this.horizontalPanel2.Size = new System.Drawing.Size(347, 100);
            this.horizontalPanel2.TabIndex = 28;
            // 
            // buttonModifyList
            // 
            this.buttonModifyList.Image = global::MovieBrowser.Properties.Resources.modify;
            this.buttonModifyList.Location = new System.Drawing.Point(299, 68);
            this.buttonModifyList.Name = "buttonModifyList";
            this.buttonModifyList.Size = new System.Drawing.Size(24, 24);
            this.buttonModifyList.TabIndex = 35;
            this.buttonModifyList.UseVisualStyleBackColor = true;
            this.buttonModifyList.Click += new System.EventHandler(this.buttonModifyList_Click);
            // 
            // buttonAddToList
            // 
            this.buttonAddToList.Image = global::MovieBrowser.Properties.Resources.add;
            this.buttonAddToList.Location = new System.Drawing.Point(269, 68);
            this.buttonAddToList.Name = "buttonAddToList";
            this.buttonAddToList.Size = new System.Drawing.Size(24, 24);
            this.buttonAddToList.TabIndex = 34;
            this.buttonAddToList.UseVisualStyleBackColor = true;
            this.buttonAddToList.Click += new System.EventHandler(this.buttonAddToList_Click);
            // 
            // comboUserList
            // 
            this.comboUserList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboUserList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboUserList.FormattingEnabled = true;
            this.comboUserList.Location = new System.Drawing.Point(79, 68);
            this.comboUserList.Name = "comboUserList";
            this.comboUserList.Size = new System.Drawing.Size(184, 23);
            this.comboUserList.TabIndex = 33;
            // 
            // pbHaveIt
            // 
            this.pbHaveIt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbHaveIt.Image = global::MovieBrowser.Properties.Resources.have_it_dis;
            this.pbHaveIt.Location = new System.Drawing.Point(231, 30);
            this.pbHaveIt.Name = "pbHaveIt";
            this.pbHaveIt.Size = new System.Drawing.Size(32, 32);
            this.pbHaveIt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbHaveIt.TabIndex = 32;
            this.pbHaveIt.TabStop = false;
            this.pbHaveIt.Click += new System.EventHandler(this.pbHaveIt_Click);
            // 
            // pbSeenIt
            // 
            this.pbSeenIt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSeenIt.Image = global::MovieBrowser.Properties.Resources.seen_it_dis;
            this.pbSeenIt.Location = new System.Drawing.Point(193, 30);
            this.pbSeenIt.Name = "pbSeenIt";
            this.pbSeenIt.Size = new System.Drawing.Size(32, 32);
            this.pbSeenIt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSeenIt.TabIndex = 31;
            this.pbSeenIt.TabStop = false;
            this.pbSeenIt.Click += new System.EventHandler(this.pbSeenIt_Click);
            // 
            // pbDislike
            // 
            this.pbDislike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDislike.Image = global::MovieBrowser.Properties.Resources.hate_it_dis;
            this.pbDislike.Location = new System.Drawing.Point(155, 30);
            this.pbDislike.Name = "pbDislike";
            this.pbDislike.Size = new System.Drawing.Size(32, 32);
            this.pbDislike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbDislike.TabIndex = 30;
            this.pbDislike.TabStop = false;
            this.pbDislike.Click += new System.EventHandler(this.pbDislike_Click);
            // 
            // lblImdbId
            // 
            this.lblImdbId.AutoSize = true;
            this.lblImdbId.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImdbId.Location = new System.Drawing.Point(5, 76);
            this.lblImdbId.Name = "lblImdbId";
            this.lblImdbId.Size = new System.Drawing.Size(21, 19);
            this.lblImdbId.TabIndex = 13;
            this.lblImdbId.Text = "tt";
            this.lblImdbId.Visible = false;
            // 
            // pbLike
            // 
            this.pbLike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLike.Image = global::MovieBrowser.Properties.Resources.like_it_dis;
            this.pbLike.Location = new System.Drawing.Point(117, 30);
            this.pbLike.Name = "pbLike";
            this.pbLike.Size = new System.Drawing.Size(32, 32);
            this.pbLike.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLike.TabIndex = 29;
            this.pbLike.TabStop = false;
            this.pbLike.Click += new System.EventHandler(this.pbLike_Click);
            // 
            // pbWanted
            // 
            this.pbWanted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbWanted.Image = global::MovieBrowser.Properties.Resources.check_list_dis;
            this.pbWanted.Location = new System.Drawing.Point(79, 30);
            this.pbWanted.Name = "pbWanted";
            this.pbWanted.Size = new System.Drawing.Size(32, 32);
            this.pbWanted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbWanted.TabIndex = 28;
            this.pbWanted.TabStop = false;
            this.pbWanted.Click += new System.EventHandler(this.pbWanted_Click);
            // 
            // rsUserRating
            // 
            this.rsUserRating.ControlLayout = RatingControl.RatingStar.Layouts.Horizontal;
            this.rsUserRating.Level = 10;
            this.rsUserRating.Location = new System.Drawing.Point(79, 3);
            this.rsUserRating.Margin = new System.Windows.Forms.Padding(0);
            this.rsUserRating.Name = "rsUserRating";
            this.rsUserRating.Rating = 0D;
            this.rsUserRating.Size = new System.Drawing.Size(264, 24);
            this.rsUserRating.TabIndex = 19;
            this.rsUserRating.RatingValueChanged += new RatingControl.RatingStar.RatingValueChangedEventHandler(this.rsUserRating_RatingValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(6, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "User Rating:";
            // 
            // toolStripMain
            // 
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbUserManagement,
            this.tbKeywordManagement});
            this.toolStripMain.Location = new System.Drawing.Point(3, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(113, 25);
            this.toolStripMain.TabIndex = 0;
            // 
            // tbUserManagement
            // 
            this.tbUserManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbUserManagement.Image = ((System.Drawing.Image)(resources.GetObject("tbUserManagement.Image")));
            this.tbUserManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbUserManagement.Name = "tbUserManagement";
            this.tbUserManagement.Size = new System.Drawing.Size(39, 22);
            this.tbUserManagement.Text = "Users";
            this.tbUserManagement.Click += new System.EventHandler(this.tbUserManagement_Click);
            // 
            // tbKeywordManagement
            // 
            this.tbKeywordManagement.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbKeywordManagement.Image = ((System.Drawing.Image)(resources.GetObject("tbKeywordManagement.Image")));
            this.tbKeywordManagement.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbKeywordManagement.Name = "tbKeywordManagement";
            this.tbKeywordManagement.Size = new System.Drawing.Size(62, 22);
            this.tbKeywordManagement.Text = "Keywords";
            this.tbKeywordManagement.Click += new System.EventHandler(this.tbKeywordManagement_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(166, 22);
            this.toolStripButton2.Text = "Collect Movie Information";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.googleToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // googleToolStripMenuItem
            // 
            this.googleToolStripMenuItem.Name = "googleToolStripMenuItem";
            this.googleToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // parseToolStripMenuItem
            // 
            this.parseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intelligentTrackerToolStripMenuItem});
            this.parseToolStripMenuItem.Name = "parseToolStripMenuItem";
            this.parseToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.parseToolStripMenuItem.Text = "&Parse";
            // 
            // intelligentTrackerToolStripMenuItem
            // 
            this.intelligentTrackerToolStripMenuItem.Checked = true;
            this.intelligentTrackerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.intelligentTrackerToolStripMenuItem.Name = "intelligentTrackerToolStripMenuItem";
            this.intelligentTrackerToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.intelligentTrackerToolStripMenuItem.Text = "&Intelligent Tracker";
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortToolStripMenuItem});
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.sortToolStripMenuItem.Text = "&Sort";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // MovieBrowserSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 447);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MovieBrowserSimple";
            this.Text = "Movie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MovieBrowserSimpleFormClosing);
            this.Load += new System.EventHandler(this.MovieBrowserSimpleLoad);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabMovies.ResumeLayout(false);
            this.tpMoviesTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListFileSystem)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStripMoviesFilesystem.ResumeLayout(false);
            this.toolStripMoviesFilesystem.PerformLayout();
            this.tpMovies2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListMoviesDatabase)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripMovies.ResumeLayout(false);
            this.toolStripMovies.PerformLayout();
            this.tpVirtualFolders.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeListVirtualFolders)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStripVirtualFolders.ResumeLayout(false);
            this.toolStripVirtualFolders.PerformLayout();
            this.tpSearch.ResumeLayout(false);
            this.horizontalPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datalistResult)).EndInit();
            this.panel3.ResumeLayout(false);
            this.toolStripContainer2.ContentPanel.ResumeLayout(false);
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.tabInformation.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStripBrowser.ResumeLayout(false);
            this.toolStripBrowser.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tpInformation.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listLanguages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listKeywords)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listDirectors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listStars)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listWriters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listActors)).EndInit();
            this.horizontalPanel1.ResumeLayout(false);
            this.horizontalPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.horizontalPanel2.ResumeLayout(false);
            this.horizontalPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHaveIt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSeenIt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDislike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbWanted)).EndInit();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem googleToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabInformation;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.ToolStripMenuItem parseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intelligentTrackerToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendToPendriveToolStripMenuItem;
        private System.Windows.Forms.TabControl tabMovies;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TabPage tpInformation;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateMovieInformationToolStripMenuItem;
        private System.Windows.Forms.ListView listGenres;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView listCountries;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblImdbId;
        private System.Windows.Forms.TabPage tpMovies2;
        private System.Windows.Forms.Panel panel1;
        private BrightIdeasSoftware.DataListView dataListMoviesDatabase;
        private BrightIdeasSoftware.OLVColumn olvTitle;
        private BrightIdeasSoftware.OLVColumn olvImdbId;
        private BrightIdeasSoftware.OLVColumn olvRating;
        private BrightIdeasSoftware.OLVColumn olvYear;
        private System.Windows.Forms.TabPage tpMoviesTree;
        private System.Windows.Forms.Panel panel2;
        private BrightIdeasSoftware.TreeListView treeListFileSystem;
        private BrightIdeasSoftware.OLVColumn treeColumnTitle;
        private BrightIdeasSoftware.OLVColumn treeColumnRating;
        private BrightIdeasSoftware.OLVColumn treeColumnYear;
        private BrightIdeasSoftware.OLVColumn treeColumnSize;
        private BrightIdeasSoftware.OLVColumn treeColumnFileType;
        private RatingControl.RatingStar rsUserRating;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private WindowsFormsAero.HorizontalPanel horizontalPanel1;
        private System.Windows.Forms.TextBox textMpaaReason;
        private System.Windows.Forms.TextBox lblMPAA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private WindowsFormsAero.HorizontalPanel horizontalPanel2;
        private System.Windows.Forms.PictureBox pbWanted;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox lblRuntime;
        private System.Windows.Forms.TextBox textHighlight;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbHaveIt;
        private System.Windows.Forms.PictureBox pbSeenIt;
        private System.Windows.Forms.PictureBox pbDislike;
        private System.Windows.Forms.PictureBox pbLike;
        private System.Windows.Forms.ToolStripMenuItem refreshFolderToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private WindowsFormsAero.ComboBox comboUserList;
        private System.Windows.Forms.TabPage tpSearch;
        private System.Windows.Forms.Button buttonModifyList;
        private System.Windows.Forms.Button buttonAddToList;
        private WindowsFormsAero.SearchTextBox searchTextBox1;
        private System.Windows.Forms.ToolStrip toolStripMoviesFilesystem;
        private System.Windows.Forms.ToolStripButton pbUpdateTree;
        private System.Windows.Forms.ToolStripButton pbAddTreeItemToDb;
        private System.Windows.Forms.ToolStripButton tbBrowseFolders;
        private System.Windows.Forms.ToolStripButton tbRemoveFolders;
        private System.Windows.Forms.ToolStripButton tbSaveFolders;
        private System.Windows.Forms.ToolStripButton tbRefreshFolders;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tbSearchImdb;
        private System.Windows.Forms.ToolStripButton tbSearchGoogle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tbOpenExplorer;
        private System.Windows.Forms.ToolStripButton tbIgnoreList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripComboBox comboPendrives;
        private System.Windows.Forms.ToolStripButton tbLoadPendrives;
        private System.Windows.Forms.ToolStripButton tbSendTo;
        private WindowsFormsAero.SearchTextBox searchTextBox2;
        private System.Windows.Forms.ToolStrip toolStripMovies;
        private System.Windows.Forms.ToolStripButton tbAddToDb;
        private System.Windows.Forms.ToolStripButton tbRefreshDb;
        private System.Windows.Forms.ToolStripButton tbDeleteFromDb;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tbWantToWatch;
        private System.Windows.Forms.ToolStripButton tbLikeIt;
        private System.Windows.Forms.ToolStripButton tbDislikeIt;
        private System.Windows.Forms.ToolStripButton tbSeenIt;
        private System.Windows.Forms.ToolStripButton tbHaveIt;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox txtUserRating;
        private System.Windows.Forms.ToolStripButton tbRateIt;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton tbUserManagement;
        private System.Windows.Forms.ToolStripButton tbKeywordManagement;
        private DataListView listKeywords;
        private OLVColumn olvColKeyword;
        private OLVColumn olvColKeywordRated;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ToolStrip toolStripBrowser;
        private System.Windows.Forms.ToolStripButton tbIntelligent;
        private System.Windows.Forms.ToolStripButton tbUpdateDb;
        private System.Windows.Forms.ToolStripButton tbAddToDbFromBrowser;
        private System.Windows.Forms.ToolStripButton tbUpdateTreeNode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DataListView listLanguages;
        private OLVColumn olvColumn2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DataListView listDirectors;
        private OLVColumn olvColumn1;
        private DataListView listStars;
        private OLVColumn olvColumn6;
        private DataListView listWriters;
        private OLVColumn olvColumn5;
        private System.Windows.Forms.Label label6;
        private DataListView listActors;
        private OLVColumn olvColumn3;
        private OLVColumn olvColumn4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripButton tbUpdated;
        private WindowsFormsAero.HorizontalPanel horizontalPanel3;
        private System.Windows.Forms.Panel panel3;
        private DataListView datalistResult;
        private OLVColumn olvColumn7;
        private OLVColumn olvColumn8;
        private OLVColumn olvColumn9;
        private OLVColumn olvColumn10;
        private WindowsFormsAero.SearchTextBox searchTextForSearchResult;
        private WindowsFormsAero.CommandLink clSearch;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabPage tpVirtualFolders;
        private TreeListView treeListVirtualFolders;
        private OLVColumn olvColumn11;
        private OLVColumn olvColumn12;
        private OLVColumn olvColumn13;
        private System.Windows.Forms.Panel panel4;
        private WindowsFormsAero.SearchTextBox searchVirtualFolders;
        private System.Windows.Forms.ToolStrip toolStripVirtualFolders;
        private System.Windows.Forms.ToolStripButton tbLoadVirtualFolders;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton tbSaveVirtualTree;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton tbGenerateXML;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem updateItemsToolStripMenuItem;
    }
}

