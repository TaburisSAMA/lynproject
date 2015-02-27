namespace GREWordStudy.Collector
{
    partial class GREWordCollectorForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonMnemonicsDictionary = new System.Windows.Forms.Button();
            this.buttonGoogleDictionary = new System.Windows.Forms.Button();
            this.buttonSynonym = new System.Windows.Forms.Button();
            this.buttonWordnetSynonym = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonEtymology = new System.Windows.Forms.Button();
            this.buttonGooglePhrase = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBoxList = new System.Windows.Forms.ComboBox();
            this.buttonAffinity = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSynonymsNet = new System.Windows.Forms.Button();
            this.buttonDefinitionsNet = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.buttonParseWordnetSynonyms = new System.Windows.Forms.Button();
            this.buttonParseWordnetDefinitions = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(178, 272);
            this.textBox1.TabIndex = 1;
            // 
            // buttonMnemonicsDictionary
            // 
            this.buttonMnemonicsDictionary.AutoSize = true;
            this.buttonMnemonicsDictionary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonMnemonicsDictionary.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonMnemonicsDictionary.Location = new System.Drawing.Point(6, 19);
            this.buttonMnemonicsDictionary.Name = "buttonMnemonicsDictionary";
            this.buttonMnemonicsDictionary.Size = new System.Drawing.Size(91, 30);
            this.buttonMnemonicsDictionary.TabIndex = 2;
            this.buttonMnemonicsDictionary.Text = "Mnemonics";
            this.buttonMnemonicsDictionary.UseVisualStyleBackColor = true;
            this.buttonMnemonicsDictionary.Click += new System.EventHandler(this.buttonFetchMnemonicDictionary_Click);
            // 
            // buttonGoogleDictionary
            // 
            this.buttonGoogleDictionary.AutoSize = true;
            this.buttonGoogleDictionary.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGoogleDictionary.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonGoogleDictionary.Location = new System.Drawing.Point(103, 19);
            this.buttonGoogleDictionary.Name = "buttonGoogleDictionary";
            this.buttonGoogleDictionary.Size = new System.Drawing.Size(131, 30);
            this.buttonGoogleDictionary.TabIndex = 4;
            this.buttonGoogleDictionary.Text = "Google Dictionary";
            this.buttonGoogleDictionary.UseVisualStyleBackColor = true;
            this.buttonGoogleDictionary.Click += new System.EventHandler(this.buttonFetchGoogleDictionary_Click);
            // 
            // buttonSynonym
            // 
            this.buttonSynonym.AutoSize = true;
            this.buttonSynonym.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSynonym.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSynonym.Location = new System.Drawing.Point(7, 19);
            this.buttonSynonym.Name = "buttonSynonym";
            this.buttonSynonym.Size = new System.Drawing.Size(127, 30);
            this.buttonSynonym.TabIndex = 5;
            this.buttonSynonym.Text = "Google Synonym";
            this.buttonSynonym.UseVisualStyleBackColor = true;
            this.buttonSynonym.Click += new System.EventHandler(this.buttonGoogleSynonym_Click);
            // 
            // buttonWordnetSynonym
            // 
            this.buttonWordnetSynonym.AutoSize = true;
            this.buttonWordnetSynonym.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonWordnetSynonym.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWordnetSynonym.Location = new System.Drawing.Point(7, 55);
            this.buttonWordnetSynonym.Name = "buttonWordnetSynonym";
            this.buttonWordnetSynonym.Size = new System.Drawing.Size(134, 30);
            this.buttonWordnetSynonym.TabIndex = 6;
            this.buttonWordnetSynonym.Text = "WordNet Synonym";
            this.buttonWordnetSynonym.UseVisualStyleBackColor = true;
            this.buttonWordnetSynonym.Click += new System.EventHandler(this.buttonMnemonicDictionarySynonym_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(196, 290);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(160, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Create gre.txt";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // buttonEtymology
            // 
            this.buttonEtymology.AutoSize = true;
            this.buttonEtymology.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonEtymology.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonEtymology.Location = new System.Drawing.Point(240, 19);
            this.buttonEtymology.Name = "buttonEtymology";
            this.buttonEtymology.Size = new System.Drawing.Size(86, 30);
            this.buttonEtymology.TabIndex = 8;
            this.buttonEtymology.Text = "Etymology";
            this.buttonEtymology.UseVisualStyleBackColor = true;
            this.buttonEtymology.Click += new System.EventHandler(this.buttonEtymologyFetch_Click);
            // 
            // buttonGooglePhrase
            // 
            this.buttonGooglePhrase.AutoSize = true;
            this.buttonGooglePhrase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGooglePhrase.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGooglePhrase.Location = new System.Drawing.Point(140, 19);
            this.buttonGooglePhrase.Name = "buttonGooglePhrase";
            this.buttonGooglePhrase.Size = new System.Drawing.Size(111, 30);
            this.buttonGooglePhrase.TabIndex = 9;
            this.buttonGooglePhrase.Text = "Google Phrase";
            this.buttonGooglePhrase.UseVisualStyleBackColor = true;
            this.buttonGooglePhrase.Click += new System.EventHandler(this.buttonGooglePhrase_Click);
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(147, 55);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 30);
            this.button3.TabIndex = 10;
            this.button3.Text = "ParseMnemonics";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBoxList
            // 
            this.comboBoxList.DisplayMember = "Name";
            this.comboBoxList.FormattingEnabled = true;
            this.comboBoxList.Location = new System.Drawing.Point(196, 12);
            this.comboBoxList.Name = "comboBoxList";
            this.comboBoxList.Size = new System.Drawing.Size(160, 21);
            this.comboBoxList.TabIndex = 12;
            this.comboBoxList.ValueMember = "Id";
            // 
            // buttonAffinity
            // 
            this.buttonAffinity.AutoSize = true;
            this.buttonAffinity.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAffinity.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAffinity.Location = new System.Drawing.Point(279, 55);
            this.buttonAffinity.Name = "buttonAffinity";
            this.buttonAffinity.Size = new System.Drawing.Size(86, 30);
            this.buttonAffinity.TabIndex = 13;
            this.buttonAffinity.Text = "Affinity.net";
            this.buttonAffinity.UseVisualStyleBackColor = true;
            this.buttonAffinity.Click += new System.EventHandler(this.buttonAffinity_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(362, 290);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(160, 23);
            this.button5.TabIndex = 14;
            this.button5.Text = "Create gre.txt H";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(196, 319);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(160, 23);
            this.button8.TabIndex = 15;
            this.button8.Text = "ListHardNess";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSynonymsNet);
            this.groupBox1.Controls.Add(this.buttonDefinitionsNet);
            this.groupBox1.Controls.Add(this.buttonMnemonicsDictionary);
            this.groupBox1.Controls.Add(this.buttonGoogleDictionary);
            this.groupBox1.Controls.Add(this.buttonEtymology);
            this.groupBox1.Location = new System.Drawing.Point(196, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 107);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fetch Html";
            // 
            // buttonSynonymsNet
            // 
            this.buttonSynonymsNet.AutoSize = true;
            this.buttonSynonymsNet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSynonymsNet.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSynonymsNet.Location = new System.Drawing.Point(122, 55);
            this.buttonSynonymsNet.Name = "buttonSynonymsNet";
            this.buttonSynonymsNet.Size = new System.Drawing.Size(108, 30);
            this.buttonSynonymsNet.TabIndex = 10;
            this.buttonSynonymsNet.Text = "Synonyms.net";
            this.buttonSynonymsNet.UseVisualStyleBackColor = true;
            this.buttonSynonymsNet.Click += new System.EventHandler(this.buttonSynonymsNet_Click);
            // 
            // buttonDefinitionsNet
            // 
            this.buttonDefinitionsNet.AutoSize = true;
            this.buttonDefinitionsNet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDefinitionsNet.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDefinitionsNet.Location = new System.Drawing.Point(7, 55);
            this.buttonDefinitionsNet.Name = "buttonDefinitionsNet";
            this.buttonDefinitionsNet.Size = new System.Drawing.Size(109, 30);
            this.buttonDefinitionsNet.TabIndex = 9;
            this.buttonDefinitionsNet.Text = "Definitions.net";
            this.buttonDefinitionsNet.UseVisualStyleBackColor = true;
            this.buttonDefinitionsNet.Click += new System.EventHandler(this.buttonDefinitionsNet_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.buttonParseWordnetSynonyms);
            this.groupBox2.Controls.Add(this.buttonParseWordnetDefinitions);
            this.groupBox2.Controls.Add(this.button10);
            this.groupBox2.Controls.Add(this.buttonSynonym);
            this.groupBox2.Controls.Add(this.buttonWordnetSynonym);
            this.groupBox2.Controls.Add(this.buttonGooglePhrase);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.buttonAffinity);
            this.groupBox2.Location = new System.Drawing.Point(196, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 132);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parse";
            // 
            // button9
            // 
            this.button9.AutoSize = true;
            this.button9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(268, 91);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(125, 30);
            this.button9.TabIndex = 17;
            this.button9.Text = "Parse Etymology";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // buttonParseWordnetSynonyms
            // 
            this.buttonParseWordnetSynonyms.AutoSize = true;
            this.buttonParseWordnetSynonyms.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonParseWordnetSynonyms.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonParseWordnetSynonyms.Location = new System.Drawing.Point(138, 91);
            this.buttonParseWordnetSynonyms.Name = "buttonParseWordnetSynonyms";
            this.buttonParseWordnetSynonyms.Size = new System.Drawing.Size(124, 30);
            this.buttonParseWordnetSynonyms.TabIndex = 16;
            this.buttonParseWordnetSynonyms.Text = "Parse Synonyms";
            this.buttonParseWordnetSynonyms.UseVisualStyleBackColor = true;
            this.buttonParseWordnetSynonyms.Click += new System.EventHandler(this.buttonParseWordnetSynonyms_Click);
            // 
            // buttonParseWordnetDefinitions
            // 
            this.buttonParseWordnetDefinitions.AutoSize = true;
            this.buttonParseWordnetDefinitions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonParseWordnetDefinitions.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonParseWordnetDefinitions.Location = new System.Drawing.Point(7, 91);
            this.buttonParseWordnetDefinitions.Name = "buttonParseWordnetDefinitions";
            this.buttonParseWordnetDefinitions.Size = new System.Drawing.Size(125, 30);
            this.buttonParseWordnetDefinitions.TabIndex = 15;
            this.buttonParseWordnetDefinitions.Text = "Parse Definitions";
            this.buttonParseWordnetDefinitions.UseVisualStyleBackColor = true;
            this.buttonParseWordnetDefinitions.Click += new System.EventHandler(this.buttonParseWordnetDefinitions_Click);
            // 
            // button10
            // 
            this.button10.AutoSize = true;
            this.button10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button10.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(257, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(124, 30);
            this.button10.TabIndex = 14;
            this.button10.Text = "Parse Google Bn";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox2.Location = new System.Drawing.Point(0, 348);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(934, 140);
            this.textBox2.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(615, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(127, 30);
            this.button2.TabIndex = 21;
            this.button2.Text = "RemoveDuplicate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(371, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 30);
            this.button4.TabIndex = 18;
            this.button4.Text = "Google Affinity";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // GREWordCollectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 488);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.comboBoxList);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "GREWordCollectorForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MnemonicsCollector_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonMnemonicsDictionary;
        private System.Windows.Forms.Button buttonGoogleDictionary;
        private System.Windows.Forms.Button buttonSynonym;
        private System.Windows.Forms.Button buttonWordnetSynonym;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonEtymology;
        private System.Windows.Forms.Button buttonGooglePhrase;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBoxList;
        private System.Windows.Forms.Button buttonAffinity;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonDefinitionsNet;
        private System.Windows.Forms.Button buttonSynonymsNet;
        private System.Windows.Forms.Button buttonParseWordnetDefinitions;
        private System.Windows.Forms.Button buttonParseWordnetSynonyms;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
    }
}

