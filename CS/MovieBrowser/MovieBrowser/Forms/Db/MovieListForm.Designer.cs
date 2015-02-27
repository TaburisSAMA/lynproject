namespace MovieBrowser.Forms.Db
{
    partial class MovieListForm
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
            this.verticalPanel1 = new WindowsFormsAero.VerticalPanel();
            this.clDelete = new WindowsFormsAero.CommandLink();
            this.clUpdate = new WindowsFormsAero.CommandLink();
            this.clCreate = new WindowsFormsAero.CommandLink();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataListView1 = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.verticalPanel1.SuspendLayout();
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
            this.horizontalPanel1.Location = new System.Drawing.Point(0, 267);
            this.horizontalPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.horizontalPanel1.Name = "horizontalPanel1";
            this.horizontalPanel1.Size = new System.Drawing.Size(614, 76);
            this.horizontalPanel1.TabIndex = 0;
            // 
            // verticalPanel1
            // 
            this.verticalPanel1.BackColor = System.Drawing.Color.Transparent;
            this.verticalPanel1.Controls.Add(this.clDelete);
            this.verticalPanel1.Controls.Add(this.clUpdate);
            this.verticalPanel1.Controls.Add(this.clCreate);
            this.verticalPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.verticalPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verticalPanel1.Location = new System.Drawing.Point(0, 0);
            this.verticalPanel1.Name = "verticalPanel1";
            this.verticalPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.verticalPanel1.Size = new System.Drawing.Size(220, 267);
            this.verticalPanel1.TabIndex = 1;
            // 
            // clDelete
            // 
            this.clDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clDelete.Location = new System.Drawing.Point(9, 140);
            this.clDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clDelete.Name = "clDelete";
            this.clDelete.Size = new System.Drawing.Size(200, 48);
            this.clDelete.TabIndex = 5;
            this.clDelete.Text = "Delete";
            this.clDelete.UseVisualStyleBackColor = true;
            this.clDelete.Click += new System.EventHandler(this.clDelete_Click);
            // 
            // clUpdate
            // 
            this.clUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clUpdate.Location = new System.Drawing.Point(10, 76);
            this.clUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clUpdate.Name = "clUpdate";
            this.clUpdate.Size = new System.Drawing.Size(200, 48);
            this.clUpdate.TabIndex = 4;
            this.clUpdate.Text = "Update";
            this.clUpdate.UseVisualStyleBackColor = true;
            this.clUpdate.Click += new System.EventHandler(this.clUpdate_Click);
            // 
            // clCreate
            // 
            this.clCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clCreate.Location = new System.Drawing.Point(10, 14);
            this.clCreate.Margin = new System.Windows.Forms.Padding(5);
            this.clCreate.Name = "clCreate";
            this.clCreate.Size = new System.Drawing.Size(200, 48);
            this.clCreate.TabIndex = 3;
            this.clCreate.Text = "Create";
            this.clCreate.UseVisualStyleBackColor = true;
            this.clCreate.Click += new System.EventHandler(this.clCreate_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataListView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(220, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(394, 205);
            this.panel2.TabIndex = 6;
            // 
            // dataListView1
            // 
            this.dataListView1.AllColumns.Add(this.olvColumn1);
            this.dataListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.dataListView1.DataSource = null;
            this.dataListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListView1.FullRowSelect = true;
            this.dataListView1.HideSelection = false;
            this.dataListView1.Location = new System.Drawing.Point(10, 10);
            this.dataListView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataListView1.Name = "dataListView1";
            this.dataListView1.Size = new System.Drawing.Size(374, 185);
            this.dataListView1.TabIndex = 4;
            this.dataListView1.UseCompatibleStateImageBehavior = false;
            this.dataListView1.View = System.Windows.Forms.View.Details;
            this.dataListView1.SelectedIndexChanged += new System.EventHandler(this.dataListView1_SelectedIndexChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "ListName";
            this.olvColumn1.Text = "List Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 250;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textUsername);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(220, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(394, 62);
            this.panel1.TabIndex = 5;
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(109, 15);
            this.textUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(270, 25);
            this.textUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "List Name";
            // 
            // MovieListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 343);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.verticalPanel1);
            this.Controls.Add(this.horizontalPanel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MovieListForm";
            this.Text = "MovieListForm";
            this.Load += new System.EventHandler(this.MovieListForm_Load);
            this.verticalPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private WindowsFormsAero.HorizontalPanel horizontalPanel1;
        private WindowsFormsAero.VerticalPanel verticalPanel1;
        private WindowsFormsAero.CommandLink clDelete;
        private WindowsFormsAero.CommandLink clUpdate;
        private WindowsFormsAero.CommandLink clCreate;
        private System.Windows.Forms.Panel panel2;
        private BrightIdeasSoftware.DataListView dataListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label label1;
    }
}