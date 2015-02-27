using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using GREWordStudy.Model;

namespace GREWordStudy.Collector
{
    public partial class SingleWordCollectorForm : Form
    {
        public SingleWordCollectorForm(string listName, string word)
        {
            InitializeComponent();
            LoadListNames();
            textBoxWord.Text = word;
            textBoxWord.Enabled = false;

            foreach (ListName item in comboBoxList.Items.Cast<ListName>().Where(item => item.Name == listName))
            {
                comboBoxList.SelectedItem = item;
                comboBoxList.Enabled = false;
                break;
            }
        }
        public SingleWordCollectorForm()
        {
            InitializeComponent();
            LoadListNames();
        }

        private void LoadListNames()
        {
            var entities = new gredbEntities();
            comboBoxList.DataSource = (from w in entities.ListNames select w).ToList();
        }

        private void SingleWordCollectorForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonCollect_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();

            long listNameId = -1;
            if (comboBoxList.Text.Trim().Length > 0)
            {
                var list = entities.ListNames.Where(o => o.Name.ToLower().Equals(comboBoxList.Text.Trim().ToLower())).Select(o => o).FirstOrDefault();
                if (list == null)
                {

                    ListName listName = new ListName();
                    listName.Name = comboBoxList.Text.Trim().ToLower();
                    entities.AddToListNames(listName);
                    entities.SaveChanges();

                    listNameId = listName.Id;
                }
                else
                {
                    listNameId = list.Id;
                }
            }
            else
            {
                listNameId = Convert.ToInt64(comboBoxList.SelectedValue);
            }

            String strWord = textBoxWord.Text.Trim().ToLower();
            ListName ln = (from n in entities.ListNames
                           where n.Id == listNameId
                           select n).FirstOrDefault();

            try
            {
                GreWord word;
                word = (from w in entities.GreWords
                        where w.Word.ToLower() == strWord
                        select w).FirstOrDefault();

                if (word == null)
                {
                    word = new GreWord()
                    {
                        Word = strWord,
                    };
                    entities.AddToGreWords(word);
                    entities.SaveChanges();
                }

                ListedWord lw = (from w in entities.ListedWords
                                 where w.ListName.Id == ln.Id && w.GreWord.Word == word.Word
                                 select w).FirstOrDefault();

                if (lw == null)
                {
                    lw = new ListedWord()
                    {
                        GreWord = word,
                        ListName = ln
                    };
                    entities.AddToListedWords(lw);
                    entities.SaveChanges();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            ParserHelper parserHelper = new ParserHelper(entities);
            parserHelper.OnLogMessage += (sender2, person) => this.Invoke((MethodInvoker)(() => textBoxInfo.AppendText(person + "\r\n")));


            parserHelper.WordToFetch = strWord;
            var workerThread = new Thread(parserHelper.FetchAndParseSingleWord) {IsBackground = true};
            workerThread.Start();

        }
    }
}
