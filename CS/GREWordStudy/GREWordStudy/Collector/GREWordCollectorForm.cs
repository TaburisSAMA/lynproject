using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using GREWordStudy.Model;
using System.IO;

namespace GREWordStudy.Collector
{
    public partial class GREWordCollectorForm : Form
    {

        public GREWordCollectorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long listNameId = -1;
            var entities = new gredbEntities();


            var list = entities.ListNames.Where(o => o.Name.ToLower().Equals(comboBoxList.Text.Trim().ToLower())).Select(o => o).FirstOrDefault();
            if (list == null)
            {

                ListName listName = new ListName { Name = comboBoxList.Text.Trim() };
                entities.AddToListNames(listName);
                entities.SaveChanges();

                listNameId = listName.Id;
            }
            else
            {
                listNameId = list.Id;
            }

            String str = Regex.Replace(textBox1.Text, "([0-9\\.]+|<.+?>)", "");
            Regex regex = new Regex("([^\\s]+)");

            ListName ln = (from n in entities.ListNames
                           where n.Id == listNameId
                           select n).FirstOrDefault();

            try
            {
                MatchCollection mc = regex.Matches(str);

                foreach (Match m in mc)
                {
                    try
                    {
                        GreWord word = (from w in entities.GreWords
                                        where w.Word.ToLower() == m.Value.ToLower()
                                        select w).FirstOrDefault();

                        if (word == null)
                        {
                            word = new GreWord()
                            {
                                Word = m.Value.ToLower(),
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
                }
                entities.Connection.Close();
            }
            catch (Exception exp)
            {
            }
        }


        private void buttonFetchMnemonicDictionary_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;


            workerThread = new Thread(parser.FetchMnemonicDictionary) { IsBackground = true };
            workerThread.Start();
        }



        Thread workerThread;
        private void buttonFetchGoogleDictionary_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.FetchGoogleDictionary) { IsBackground = true };
            workerThread.Start();

        }

        #region Clear
        private void buttonGoogleSynonym_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.ParseGoogleSynonym));
            workerThread.IsBackground = true;
            workerThread.Start();
        }
        private void buttonMnemonicDictionarySynonym_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += delegate(object sender2, string person)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    textBox2.AppendText(person + "\r\n");
                });
            };

            workerThread = new Thread(new ThreadStart(parser.ParseMnemonicDictionarySynonym));
            workerThread.IsBackground = true;
            workerThread.Start();
        }
        #endregion

        #region MakeJ2ME Data
        private void button6_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            GreWord[] greWords = (from w in entities.GreWords
                                  //where w.list_name == comboBox1.Text
                                  orderby w.Word
                                  select w).ToArray();

            String strGre = "";
            foreach (GreWord w in greWords)
            {
                strGre += w.Word + "\r\n";
                strGre += getGoogleSynonym(w) + "\r\n";
                strGre += getMnemonics(w) + "\r\n";
                strGre += "\r\n";
                strGre += "\r\n";
            }

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(strGre);
                sw.Close();
            }

        }
        String getGoogleSynonym(GreWord gw)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            String synnonym = "";

            List<GoogleSynonym> gSyn = (from w in entities.GoogleSynonyms
                                        where w.GreWord.Word == gw.Word
                                        select w).ToList();
            foreach (GoogleSynonym gs in gSyn)
                synnonym += gs.Synonym + ", ";

            return synnonym;
        }
        String getMnemonics(GreWord gw)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            String mnemonics = "";

            List<FeaturedMnemonic> mSelected = (from w in entities.FeaturedMnemonics
                                                where w.GreWord.Word == gw.Word
                                                select w).ToList();
            foreach (FeaturedMnemonic ms in mSelected)
                mnemonics += "##:" + ms.Mnemonic + ", ";

            List<BasicMnemonic> mAll = (from w in entities.BasicMnemonics
                                        where w.GreWord.Word == gw.Word
                                        select w).ToList();
            foreach (BasicMnemonic ms in mAll)
                mnemonics += "#" + ms.Helpful + "," + ms.NotHelpful + ":" + ms.Mnemonic + ", ";

            mnemonics = Clean(mnemonics, @"\(Tag.+?\)");
            mnemonics = Clean(mnemonics);


            return mnemonics;
        }
        String Clean(String str, String pattern)
        {
            Regex rClean = new Regex(pattern);

            MatchCollection mc = rClean.Matches(str);
            foreach (Match m in mc)
            {
                str = str.Replace(m.Value, " ");
            }
            return str;
        }
        String Clean(String str)
        {
            string resultString = null;
            try
            {
                resultString = Regex.Replace(str, @"[\s\n\t]+", new MatchEvaluator(ComputeReplacement));
            }
            catch (ArgumentException)
            {
                // Syntax error in the regular expression
            }

            return resultString;

        }
        public String ComputeReplacement(Match m)
        {
            return " ";
        }
        #endregion

        private void buttonEtymologyFetch_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.FetchEtymology) { IsBackground = true };
            workerThread.Start();
        }

        private void buttonGooglePhrase_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.ParseGooglePhrase) { IsBackground = true };
            workerThread.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.ParseMnemonicDictionary) { IsBackground = true };
            workerThread.Start();
        }

        private void MnemonicsCollector_Load(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            comboBoxList.DataSource = (from w in entities.ListNames select w).ToList();
        }

        private void buttonAffinity_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);


            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.ParseAffinitySynonyms) { IsBackground = true };
            workerThread.Start();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();

            GreWord[] greWords = (from w in entities.GreWords
                                  where w.Hardness > 4
                                  orderby w.Hardness descending
                                  select w).ToArray();

            String strGre = "";
            foreach (GreWord w in greWords)
            {
                strGre += w.Word + "\r\n";
                strGre += getGoogleSynonym(w) + "\r\n";
                strGre += getMnemonics(w) + "\r\n";
                strGre += "\r\n";
                strGre += "\r\n";
            }

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(strGre);
                sw.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();

            GreWord[] greWords = (from w in entities.GreWords
                                  where w.Hardness > 3
                                  orderby w.Hardness descending
                                  select w).ToArray();

            String strGre = greWords.Aggregate("", (current, w) => current + (w.Word + "\t[ " + w.Hardness + " ]\r\n"));

            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(strGre);
                sw.Close();
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.ParseGoogleBengali) { IsBackground = true };
            workerThread.Start();
        }



        private void buttonDefinitionsNet_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.FetchDefinitionsNet) { IsBackground = true };
            workerThread.Start();
        }

        private void buttonSynonymsNet_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.FetchSynonymsNet) { IsBackground = true };
            workerThread.Start();
        }

        private void buttonParseWordnetDefinitions_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.ParseWordnetDefinitions) { IsBackground = true };
            workerThread.Start();
        }

        private void buttonParseWordnetSynonyms_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.ParseWordnetSynonyms) { IsBackground = true };
            workerThread.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.ParseEtymology) { IsBackground = true };
            workerThread.Start();
        }

        private void OnParserOnLogMessage(object sender, string text)
        {
            Invoke((MethodInvoker)(() => textBox2.AppendText(text + "\r\n")));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            entities.RemoveDuplicateBengaliWord();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var entities = new gredbEntities();
            var parser = new ParserHelper(entities);

            parser.OnLogMessage += OnParserOnLogMessage;

            workerThread = new Thread(parser.ParseAffinityByGoogle) { IsBackground = true };
            workerThread.Start();
        }
    }
}
