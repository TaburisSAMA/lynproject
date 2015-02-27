namespace MovieBrowser.Forms.Db
{
    partial class UsersForm
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.horizontalPanel1 = new WindowsFormsAero.HorizontalPanel();
            this.verticalPanel1 = new WindowsFormsAero.VerticalPanel();
            this.clDelete = new WindowsFormsAero.CommandLink();
            this.clUpdate = new WindowsFormsAero.CommandLink();
            this.clCreate = new WindowsFormsAero.CommandLink();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataListView1 = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.verticalPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MovieBrowser.Model.User);
            // 
            // horizontalPanel1
            // 
            this.horizontalPanel1.BackColor = System.Drawing.Color.Transparent;
            this.horizontalPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horizontalPanel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horizontalPanel1.Location = new System.Drawing.Point(0, 306);
            this.horizontalPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.horizontalPanel1.Name = "horizontalPanel1";
            this.horizontalPanel1.Size = new System.Drawing.Size(764, 88);
            this.horizontalPanel1.TabIndex = 1;
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
            this.verticalPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.verticalPanel1.Name = "verticalPanel1";
            this.verticalPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.verticalPanel1.Size = new System.Drawing.Size(220, 306);
            this.verticalPanel1.TabIndex = 2;
            // 
            // clDelete
            // 
            this.clDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clDelete.Location = new System.Drawing.Point(9, 136);
            this.clDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clDelete.Name = "clDelete";
            this.clDelete.Size = new System.Drawing.Size(200, 48);
            this.clDelete.TabIndex = 2;
            this.clDelete.Text = "Delete";
            this.clDelete.UseVisualStyleBackColor = true;
            this.clDelete.Click += new System.EventHandler(this.clDelete_Click);
            // 
            // clUpdate
            // 
            this.clUpdate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clUpdate.Location = new System.Drawing.Point(10, 72);
            this.clUpdate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clUpdate.Name = "clUpdate";
            this.clUpdate.Size = new System.Drawing.Size(200, 48);
            this.clUpdate.TabIndex = 1;
            this.clUpdate.Text = "Save";
            this.clUpdate.UseVisualStyleBackColor = true;
            this.clUpdate.Click += new System.EventHandler(this.clUpdate_Click);
            // 
            // clCreate
            // 
            this.clCreate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.clCreate.Location = new System.Drawing.Point(10, 10);
            this.clCreate.Margin = new System.Windows.Forms.Padding(5);
            this.clCreate.Name = "clCreate";
            this.clCreate.Size = new System.Drawing.Size(200, 48);
            this.clCreate.TabIndex = 0;
            this.clCreate.Text = "Create/Update";
            this.clCreate.UseVisualStyleBackColor = true;
            this.clCreate.Click += new System.EventHandler(this.clCreate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textPassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textUsername);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(220, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 16, 15, 16);
            this.panel1.Size = new System.Drawing.Size(544, 120);
            this.panel1.TabIndex = 3;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(109, 67);
            this.textPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textPassword.Name = "textPassword";
            this.textPassword.ReadOnly = true;
            this.textPassword.Size = new System.Drawing.Size(289, 29);
            this.textPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(109, 15);
            this.textUsername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textUsername.Name = "textUsername";
            this.textUsername.ReadOnly = true;
            this.textUsername.Size = new System.Drawing.Size(289, 29);
            this.textUsername.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataListView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(220, 120);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(544, 186);
            this.panel2.TabIndex = 4;
            // 
            // dataListView1
            // 
            this.dataListView1.AllColumns.Add(this.olvColumn1);
            this.dataListView1.AllColumns.Add(this.olvColumn2);
            this.dataListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2});
            this.dataListView1.DataSource = null;
            this.dataListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListView1.FullRowSelect = true;
            this.dataListView1.Location = new System.Drawing.Point(10, 10);
            this.dataListView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataListView1.Name = "dataListView1";
            this.dataListView1.Size = new System.Drawing.Size(524, 166);
            this.dataListView1.TabIndex = 4;
            this.dataListView1.UseCompatibleStateImageBehavior = false;
            this.dataListView1.View = System.Windows.Forms.View.Details;
            this.dataListView1.SelectedIndexChanged += new System.EventHandler(this.dataListView1_SelectedIndexChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Username";
            this.olvColumn1.Text = "Username";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 150;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Password";
            this.olvColumn2.Text = "Password";
            this.olvColumn2.Width = 150;
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 394);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.verticalPanel1);
            this.Controls.Add(this.horizontalPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UsersForm";
            this.Text = "Users";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.verticalPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private WindowsFormsAero.HorizontalPanel horizontalPanel1;
        private WindowsFormsAero.VerticalPanel verticalPanel1;
        private WindowsFormsAero.CommandLink clDelete;
        private WindowsFormsAero.CommandLink clUpdate;
        private WindowsFormsAero.CommandLink clCreate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private BrightIdeasSoftware.DataListView dataListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;


    }
}