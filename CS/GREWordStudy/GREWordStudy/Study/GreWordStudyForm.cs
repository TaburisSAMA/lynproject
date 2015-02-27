using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BrightIdeasSoftware;
using CommonUtility;
using CommonUtility.Screenshot;
using Crownwood.DotNetMagic.Controls;
using GREWordStudy.Collector;
using GREWordStudy.Common.Browser;
using GREWordStudy.Model;
using GREWordStudy.Properties;
using ShellLib;
using ThirstyCrow.WinForms.Controls;
using TabPage = Crownwood.DotNetMagic.Controls.TabPage;

namespace GREWordStudy.Study
{
    public partial class GreWordStudyForm : Form
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SetCapture(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseCapture(IntPtr hWnd);

        [DllImport("User32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, UInt32 msg, UInt32 wParam, UInt32 lParam);

        private readonly Color[] _colorBackground = new[] { Color.MistyRose, Color.LightBlue, Color.Yellow, Color.Thistle };

        private gredbEntities _entities = new gredbEntities();
        private readonly OpenFileDialog _excelOfd = new OpenFileDialog();

        private readonly FolderBrowserDialog _fbd = new FolderBrowserDialog();

        private readonly Color[] _hardnessBackground = new[]
                                                           {
                                                               Color.White, Color.LightGreen, Color.Aquamarine,
                                                               Color.Yellow, Color.Pink, Color.Red
                                                           };

        private readonly Color[] _hardnessForeground = new[]
                                                           {
                                                               Color.Black, Color.Navy, Color.Black, Color.Black,
                                                               Color.Black, Color.White
                                                           };

        private readonly EventLogger _logger = new EventLogger(logName: "GREWordStudy", source: "GreWordStudyForm");
        private readonly OpenFileDialog _pdfOfd = new OpenFileDialog();

        private readonly Dictionary<string, WebUrl> _webUrls = new Dictionary<string, WebUrl>();
        private bool _captured;
        private int _cindex;

        private String _currentWord = "";
        private bool _isCommentDirty;
        private Point _pEnd;
        private Point _pStart;
        IList<PlainWord> _plainWordList = null;
        private ScreenOverlay _screenOverlay;

        public GreWordStudyForm()
        {
            InitializeComponent();

            LoadDatabase();
        }




        private void buttonBrowseWord_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentWord)) return;

            var ts = (ToolStripButton)sender;
            string address = _webUrls[ts.Text].Url + _currentWord;

            NavigateTo(_currentWord, address, _webUrls[ts.Text].ImageIndex);
        }


        private void comboList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWordList();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TimedFilter(wordsDataListView, textWordFilter.Text);
        }

        private static void TimedFilter(DataListView olv, string txt,
                                        TextMatchFilter.MatchKind matchKind = TextMatchFilter.MatchKind.Text)
        {
            TextMatchFilter filter = null;
            if (!String.IsNullOrEmpty(txt))
                filter = new TextMatchFilter(olv, txt, matchKind);

            // Setup a default renderer to draw the filter matches
            olv.DefaultRenderer = filter == null ? null : new HighlightTextRenderer(filter);

            // Some lists have renderers already installed
            var highlightingRenderer = olv.GetColumn(0).Renderer as HighlightTextRenderer;
            if (highlightingRenderer != null)
                highlightingRenderer.Filter = filter;

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            olv.ModelFilter = filter;
            stopWatch.Stop();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (_fbd.ShowDialog() == DialogResult.OK)
            {
                textBanglaDictionary.Text = _fbd.SelectedPath;
                Settings.Default.BengaliDictionaryPath = textBanglaDictionary.Text;
                Settings.Default.Save();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveComment(_currentWord);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadDatabase();
        }

        private void listSynonyms_DoubleClick(object sender, EventArgs e)
        {
            LoadAffineWord((ListView)sender);
        }



        private void listSynonyms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadAffineWord((ListView)sender);
            }
        }

        private void rtfComment_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    SetHardness(1);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.F2:
                    SetHardness(2);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.F3:
                    SetHardness(3);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.F4:
                    SetHardness(4);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.F5:
                    SetHardness(5);
                    e.SuppressKeyPress = true;
                    break;

                case Keys.F11:
                    e.SuppressKeyPress = true;
                    wordsDataListView.Focus();
                    SendKeys.SendWait("{DOWN}");
                    break;

                case Keys.F10:
                    e.SuppressKeyPress = true;
                    wordsDataListView.Focus();
                    SendKeys.SendWait("{UP}");
                    break;

                case Keys.F9:
                    e.SuppressKeyPress = true;
                    Remembered();
                    break;
                case Keys.F7:
                    e.SuppressKeyPress = true;
                    Forgotten();
                    break;

                case Keys.F6:
                    wordsDataListView.Focus();
                    e.SuppressKeyPress = true;
                    return;
            }
            rtfComment.Focus();

            if (!e.Control) return;
            switch (e.KeyCode)
            {
                case Keys.B:
                    MakeBold();
                    break;
                case Keys.U:
                    MakeUnderline();
                    break;
                case Keys.T:
                    MakeStrikethrough();
                    break;
                case Keys.OemOpenBrackets:
                    SetFontSizeAsIncrement((float)-2.0);
                    break;
                case Keys.OemCloseBrackets:
                    SetFontSizeAsIncrement((float)2.0);
                    break;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveComment(_currentWord);
        }

        private void GREWordStudyForm_Load(object sender, EventArgs e)
        {
            textBanglaDictionary.Text = Settings.Default.BengaliDictionaryPath;

            toolStripWebSites.ImageList = imageList1;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                long listNameId = Convert.ToInt64(comboList.SelectedValue);
                List<GreWord> words = (from w in _entities.ListedWords
                                       where w.ListName.Id == listNameId
                                       orderby w.GreWord.Word
                                       select w.GreWord).ToList();

                var saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var streamWriter = new StreamWriter(saveFileDialog.FileName);

                    foreach (GreWord greWord in words)
                    {
                        streamWriter.WriteLine(greWord.Word);
                    }

                    streamWriter.Close();
                }
            }
            finally
            {
            }
        }

        private void rtfComment_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_currentWord))
                _isCommentDirty = true;
        }


        private void ResetWebBrowsers()
        {
            WebUrl[] wurls = (from url in _entities.WebUrls
                              orderby url.Priority
                              select url).ToArray();

            toolStripWebSites.Items.Clear();
            _webUrls.Clear();

            foreach (WebUrl url in wurls)
            {
                if (!_webUrls.ContainsKey(url.WebTitle))
                {
                    _webUrls.Add(url.WebTitle, url);

                    var button = new ToolStripButton
                                     {
                                         Text = url.WebTitle,
                                         DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                                         ImageIndex = url.ImageIndex
                                     };


                    toolStripWebSites.Items.Add(button);
                    button.Click += buttonBrowseWord_Click;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var greWordCollector = new GREWordCollectorForm();
            greWordCollector.Show(this);
        }

        private void singWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SingleWordCollectorForm();
            form.Show(this);
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyImage();
        }

        private void buttonCopyImage_Click(object sender, EventArgs e)
        {
            CopyImage();
        }

        private void CopyImage()
        {
            try
            {
                Clipboard.SetImage(pictureBoxBanglaDictionary.Image);
            }
            catch
            {
            }
        }

        private void NavigateTo(string title, string address, int iconindex = 0)
        {
            if (openInDefaultBrowserToolStripMenuItem.Checked)
            {
                new ShellExecute { Path = address, Verb = ShellExecute.OpenFile }.Execute();
            }
            else
            {
                var mb = new MaxBrowser(address);
                var newPage = new TabPage(title, mb,
                                          iconindex) { Selected = true };

                if (tabbedGroupsWebSites.ActiveLeaf != null)
                {
                    tabbedGroupsWebSites.ActiveLeaf.TabPages.Add(newPage);
                    mb.Navigate(address);
                }
            }
        }


        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NavigateTo(toolStripTextBox1.Text, Settings.Default.GoogleSearch + toolStripTextBox1.Text);
            }
        }


        private void tsBold_Click(object sender, EventArgs e)
        {
            MakeBold();
        }

        private void tsItalic_Click(object sender, EventArgs e)
        {
            MakeItalic();
        }

        private void tsUnderline_Click(object sender, EventArgs e)
        {
            MakeUnderline();
        }

        private void tsStrikethrough_Click(object sender, EventArgs e)
        {
            MakeStrikethrough();
        }

        private void tsFontSegoe_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontSegoe.Font.FontFamily.Name);
        }

        private void tsFontPalatino_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontPalatino.Font.FontFamily.Name);
        }

        private void tsFontCandara_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontCandara.Font.FontFamily.Name);
        }

        private void tsFontCorbel_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontCorbel.Font.FontFamily.Name);
        }

        private void tsFontVrinda_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontVrinda.Font.FontFamily.Name);
        }

        private void tsFontBangla_Click(object sender, EventArgs e)
        {
            SetCommentFont(tsFontBangla.Font.FontFamily.Name);
        }

        private void tsFontIncrease_Click(object sender, EventArgs e)
        {
            SetFontSizeAsIncrement((float)4.0);
        }

        private void tsFontDecrease_Click(object sender, EventArgs e)
        {
            SetFontSizeAsIncrement((float)-4.0);
        }


        private void tsColorRed_Click(object sender, EventArgs e)
        {
            SetCommentColor(((ToolStripMenuItem)sender).ForeColor);
        }

        private void tsGreen_Click(object sender, EventArgs e)
        {
            SetCommentColor(((ToolStripMenuItem)sender).ForeColor);
        }

        private void tsBlue_Click(object sender, EventArgs e)
        {
            SetCommentColor(((ToolStripMenuItem)sender).ForeColor);
        }

        private void tsNormalColor_Click(object sender, EventArgs e)
        {
            SetCommentColor(((ToolStripMenuItem)sender).ForeColor);
            SetCommentBackgroundColor(((ToolStripMenuItem)sender).BackColor);
        }

        private void tsYellowBackground_Click(object sender, EventArgs e)
        {
            SetCommentBackgroundColor(((ToolStripMenuItem)sender).BackColor);
        }

        private void tsLightGreenBackground_Click(object sender, EventArgs e)
        {
            SetCommentBackgroundColor(((ToolStripMenuItem)sender).BackColor);
        }

        private void tsDictionaryImage_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetImage(pictureBoxBanglaDictionary.Image);
                rtfComment.Paste();
                _isCommentDirty = true;
            }
            catch
            {
            }
        }

        private void tsSaveComment_Click(object sender, EventArgs e)
        {
            SaveComment(_currentWord);
        }

        private void tsRemembered_Click(object sender, EventArgs e)
        {
            Remembered();
        }

        private void tsForgot_Click(object sender, EventArgs e)
        {
            Forgotten();
        }

        private void wordRating_RatingChanged(object sender, RatingChangedEventArgs e)
        {
            SetHardness(e.NewRating);
        }


        private void tsFontSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetFontSize((float)Convert.ToDouble(tsFontSize.Text));
            }
            catch
            {
            }
        }

        private void tabbedGroupsWebSites_PageCloseRequest(TabbedGroups tg, TGCloseRequestEventArgs e)
        {
            try
            {
                e.TabPage.Dispose();
            }
            catch
            {
            }
        }

        private void stickyNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var snf = new StickyNoteForm { TopMost = true };
            snf.Show(this);
        }


        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TabPageCollection pages = tabbedGroupsWebSites.ActiveLeaf.TabPages;
                foreach (TabPage tabPage in pages)
                {
                    tabPage.Dispose();
                }
                tabbedGroupsWebSites.ActiveLeaf.TabPages.Clear();
            }
            catch
            {
            }
        }


        private void excelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _excelOfd.Filter = Resources.ExcelFileFilter;
            _excelOfd.FileName = Settings.Default.ExcelPath;
            if (_excelOfd.ShowDialog(this) == DialogResult.OK)
            {
                Settings.Default.ExcelPath = _excelOfd.FileName;
                Settings.Default.Save();

                var execute = new ShellExecute { Verb = ShellExecute.OpenFile, Path = _excelOfd.FileName };
                execute.Execute();
            }
        }


        private void pdfFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _pdfOfd.Filter = Resources.PdfFileFilter;
            _pdfOfd.FileName = Settings.Default.PdfPath;
            if (_pdfOfd.ShowDialog(this) == DialogResult.OK)
            {
                Settings.Default.PdfPath = _pdfOfd.FileName;
                Settings.Default.Save();

                var execute = new ShellExecute { Verb = ShellExecute.OpenFile, Path = _pdfOfd.FileName };
                execute.Execute();
            }
        }

        private void stickyBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new StickyBrowser { TopMost = true }).Show(this);
        }

        private void tsPaste_Click(object sender, EventArgs e)
        {
            rtfComment.Paste();
            _isCommentDirty = true;
        }

        private void wordsDataListView_FormatRow(object sender, FormatRowEventArgs e)
        {
            var w = (PlainWord)e.Model;
            e.Item.ForeColor = _hardnessForeground[w.Hardness];
            e.Item.BackColor = _hardnessBackground[w.Hardness];
            e.Item.Font = w.Hardness > 0
                              ? new Font(wordsDataListView.Font, FontStyle.Bold)
                              : new Font(wordsDataListView.Font, FontStyle.Regular);
        }

        private void wordsDataListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wordsDataListView.SelectedItem != null)
            {
                var index = wordsDataListView.SelectedItem.Index;

                LoadWord(wordsDataListView.SelectedItem.Text, _plainWordList[index].Hardness + "", wordsDataListView.SelectedIndex);
                //LoadWord(wordsDataListView.SelectedItem.Text,  wordsDataListView.SelectedItem.SubItems[1].Text, wordsDataListView.SelectedIndex);

                TryVisibleNext5Words(3);
            }
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (wordsDataListView.SelectedItem != null)
            {
                if (
                    MessageBox.Show(this, "Are you sure to delete these words?", "Delete Confirmation",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (ListViewItem selectedItem in wordsDataListView.SelectedItems)
                    {
                        DeleteWord(selectedItem.Text);
                        wordsDataListView.Items.Remove(selectedItem);
                    }
                }
            }
        }

        private void deleteSelectedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedList();
        }

        private void fetchSelectedWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordsDataListView.SelectedItem != null)
            {
                var form = new SingleWordCollectorForm(comboList.Text,
                                                       wordsDataListView.SelectedItem.Text);
                form.Show(this);
            }
        }


        private void tsPasteImage_Click(object sender, EventArgs e)
        {
            try
            {
                picBmp.Image = Clipboard.GetImage();
            }
            catch
            {
            }
        }

        private void tsScale_Click(object sender, EventArgs e)
        {
            picBmp.Image = ImageUtility.Scale(picBmp.Image, (float)(float.Parse(txtScale.Text) / 100.0));
        }

        private void tsCopyImage_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(picBmp.Image);
        }

        private void tsPictureClear_Click(object sender, EventArgs e)
        {
            picBmp.Image = null;
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openGoogleSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var execute = new ShellExecute { Path = "http://google.com/search?q=" + _currentWord, Verb = ShellExecute.OpenFile };
            execute.Execute();
        }

        private void openInDefaultBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openInDefaultBrowserToolStripMenuItem.Checked = !openInDefaultBrowserToolStripMenuItem.Checked;
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new WebUrlsForm(_entities);
            form.ShowDialog(this);

            ResetWebBrowsers();
        }

        private void tsFont_Click(object sender, EventArgs e)
        {
            try
            {
                fontDialog.Font = rtfComment.Font;
                if (fontDialog.ShowDialog(this) == DialogResult.OK)
                {
                    SetCommentFont(fontDialog.Font);
                }
            }
            catch (Exception exception)
            {
                _logger.Error("Font Exception", 1339, exception);
            }
        }

        private void tsFontColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                SetCommentColor(colorDialog.Color);
            }
        }

        #region Mouse

        private void picBmp_MouseMove(object sender, MouseEventArgs e)
        {
            if (_captured)
            {
                tsTextX2.Text = e.X + "";
                tsTextY2.Text = e.Y + "";
                _pEnd = e.Location;

                picBmp.Refresh();
            }
        }

        private void picBmp_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_captured)
            {
                tsTextX1.Text = e.X + "";
                tsTextY1.Text = e.Y + "";
                _pStart = e.Location;


                _captured = true;
                //SetCapture(this.Handle);
            }
        }

        private void picBmp_MouseUp(object sender, MouseEventArgs e)
        {
            _captured = false;
            //ReleaseCapture(this.Handle);
        }

        private void picBmp_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.BlueViolet), GetCroppedRectangle());
        }

        private void tsCropAndScale_Click(object sender, EventArgs e)
        {
            _pStart.X = int.Parse(tsTextX1.Text);
            _pStart.Y = int.Parse(tsTextY1.Text);

            _pEnd.X = int.Parse(tsTextX2.Text);
            _pEnd.Y = int.Parse(tsTextY2.Text);

            picBmp.Refresh();
            picBmp.Image = ImageUtility.Crop(picBmp.Image, GetCroppedRectangle());
        }

        #region Image Operation

        private Rectangle GetCroppedRectangle()
        {
            var r = new Rectangle();

            if (_pStart.X > _pEnd.X)
            {
                r.X = _pEnd.X;
                r.Width = _pStart.X - _pEnd.X + 1;
            }
            else
            {
                r.X = _pStart.X;
                r.Width = _pEnd.X - _pStart.X + 1;
            }

            if (_pStart.Y > _pEnd.Y)
            {
                r.Y = _pEnd.Y;
                r.Height = _pStart.Y - _pEnd.Y + 1;
            }
            else
            {
                r.Y = _pStart.Y;
                r.Height = _pEnd.Y - _pStart.Y + 1;
            }
            return r;
        }

        #endregion

        #endregion

        #region DB Access

        private void SaveComment(string word)
        {
            try
            {
                GreWord greword = (from w in _entities.GreWords
                                   where w.Word == word
                                   select w).FirstOrDefault();
                String rtf = rtfComment.Rtf;
                greword.Comment = rtf;
                _entities.SaveChanges();
            }
            catch (Exception exception)
            {
            }
        }

        private void LoadDatabase()
        {
            colWord.ImageGetter = delegate(object row)
                                         {
                                             try
                                             {
                                                 var greWord = (PlainWord)row;
                                                 return "rating_" + greWord.Hardness;
                                             }
                                             catch
                                             {
                                                 return "rating_0";
                                             }
                                         };

            colHardness.MakeGroupies(
                new[] { 1, 2, 3, 4, 5 },
                new[] { "Unprocessed", "Very Easy", "Easy", "Moderate", "Hard", "Very Hard" });

            colPercentage.MakeGroupies(
                new[] { 0, 25, 50, 75 },
                new[] { "Untouched", "Hard", "Moderate", "Easy", "Very Easy" });


            ResetWebBrowsers();

            //photohelper = new DataGridViewPhotoHelper(gridWordDefinition);

            List<ListName> list2 = (from w in _entities.ListNames
                                    select w).ToList();
            var list = new List<ListName>
                           {
                               new ListName {Id = -1, Name = "None"},
                               new ListName {Id = 0, Name = "All Words"}
                           };

            list.AddRange(list2);
            comboList.DisplayMember = "Name";
            comboList.ValueMember = "Id";
            comboList.DataSource = list;
        }



        private void LoadWordList()
        {
            long listNameId = Convert.ToInt64(comboList.SelectedValue);
            _entities.Dispose();
            _entities = new gredbEntities();


            if (listNameId > 0)
            {
                _plainWordList = (from w in _entities.ListedWords
                                  where w.ListName.Id == listNameId
                                  orderby w.GreWord.Word
                                  select new PlainWord()
                                  {
                                      Word = w.GreWord.Word,
                                      Forgotten = w.GreWord.Forgotten,
                                      Remembered = w.GreWord.Remembered,
                                      Hardness = w.GreWord.Hardness,
                                  }).ToList();
            }
            else if (listNameId == 0)
            {
                _plainWordList = (from w in _entities.GreWords
                                  orderby w.Word
                                  select new PlainWord()
                                  {
                                      Word = w.Word,
                                      Forgotten = w.Forgotten,
                                      Remembered = w.Remembered,
                                      Hardness = w.Hardness,
                                  }).ToList();
            }
            else
            {
                _plainWordList = new List<PlainWord>();
            }

            //listBox1.Items.Clear();
            wordsDataListView.Items.Clear();
            wordsDataListView.DataSource = _plainWordList;
        }

        private void LoadWordInformation(string word, bool chkAffinity)
        {
            labelWord.Text = word.ToUpper();

            if (_isCommentDirty)
            {
                SaveComment(_currentWord);
            }
            _currentWord = word;

            if (chkAffinity)
            {
                try
                {
                    listSynonyms.Items.Clear();
                    listAntonyms.Items.Clear();

                    var affinity = (from w in _entities.GreWordAffinities
                                    where w.GreWord.Word == word && w.Affinity > 0
                                    orderby w.Affinity
                                    select new
                                               {
                                                   synonym = w.RelevantWord.Word,
                                                   relation = w.Affinity,
                                                   hardness = w.RelevantWord.Hardness
                                               }).ToList();

                    foreach (var aword in affinity)
                    {
                        var lvi = new ListViewItem { Text = aword.synonym };
                        lvi.SubItems.Add(aword.relation + "");
                        lvi.ToolTipText = " [" + aword.hardness + "]";

                        lvi.BackColor = aword.relation == 1 ? Color.LightGreen : aword.relation == 3 ? Color.LightBlue : Color.Cornsilk;

                        listSynonyms.Items.Add(lvi);
                    }

                    var antonyms = (from w in _entities.GreWordAffinities
                                    where w.GreWord.Word == word && w.Affinity < 0
                                    orderby w.Affinity descending
                                    select new
                                    {
                                        antonym = w.RelevantWord.Word,
                                        relation = w.Affinity,
                                        hardness = w.RelevantWord.Hardness
                                    }).ToList();

                    foreach (var aword in antonyms)
                    {
                        var lvi = new ListViewItem { Text = aword.antonym };
                        lvi.SubItems.Add(aword.relation + "");
                        lvi.ToolTipText = " [" + aword.hardness + "]";
                        lvi.BackColor = aword.relation == -1 ? Color.LightGreen : Color.Cornsilk;
                        listAntonyms.Items.Add(lvi);
                    }
                }
                catch (Exception exp)
                {
                    _logger.Error("Load Word Information", 895, exp);
                }
            }

            //
            List<string> listNames = (from o in _entities.ListedWords where o.GreWord.Word == word select o.ListName.Name).ToList();

            statusListNames.Text = "";
            foreach (string listName in listNames)
            {
                statusListNames.Text += "**" + listName + ",  ";
            }

            GreWord greWord = (from o in _entities.GreWords where o.Word == word select o).FirstOrDefault();
            statusRemembered.Text = greWord.Remembered + "";
            statusFailed.Text = greWord.Forgotten + "";
            statusTried.Text = (greWord.Remembered + greWord.Forgotten) + "";

            try
            {
                String filename = textBanglaDictionary.Text + "\\" + word + ".jpg";
                pictureBoxBanglaDictionary.Image = Image.FromFile(filename);
            }
            catch
            {
                pictureBoxBanglaDictionary.Image = null;
            }

            rtfMnemonics.Text = "";

            #region Featured Mnemonics
            var selectedMnemonics = (from w in _entities.FeaturedMnemonics
                                     where w.GreWord.Word == word
                                     select w).ToList();
            foreach (FeaturedMnemonic mnemonic in selectedMnemonics)
            {
                rtfMnemonics.SelectionBackColor = _colorBackground[_cindex++ % 4];
                rtfMnemonics.AppendText(mnemonic.Mnemonic + "\r\n");
            }
            #endregion


            //Basic Mnemonics

            #region Basic Mnemonics
            var allMnemonics = (from w in _entities.BasicMnemonics
                                where w.GreWord.Word == word
                                select w).ToList();
            foreach (BasicMnemonic mnemonic in allMnemonics)
            {
                rtfMnemonics.SelectionBackColor = _colorBackground[_cindex++ % 4];
                rtfMnemonics.AppendText("[" + mnemonic.Helpful + "][" + mnemonic.NotHelpful + "]  " +
                                        mnemonic.Mnemonic + "\r\n");
            }
            #endregion


            //Bengali Definition
            {
                var fSonarBangla = new Font(tsFontVrinda.Font.FontFamily, 12.0f, FontStyle.Bold);
                var f10R = new Font(tsFontVrinda.Font.FontFamily, 10.0f, FontStyle.Regular);
                var f12R = new Font(rtfGoogleDictionary.Font.FontFamily, 12.0f, FontStyle.Regular);
                var f10B = new Font(rtfGoogleDictionary.Font.FontFamily, 10.0f, FontStyle.Bold);

                var wordDefinition = (from w in _entities.BengaliDefinitions
                                      where w.GreWord.Word == word
                                      select w).Distinct().ToList();
                rtfGoogleDictionary.Text = "";
                rtfGoogleDictionary.SelectionFont = fSonarBangla;
                rtfGoogleDictionary.SelectionColor = Color.Black;
                foreach (BengaliDefinition mnemonic in wordDefinition)
                {
                    rtfGoogleDictionary.AppendText(mnemonic.Bengali + @", ");
                }


                //Google Synonym
                var googleSynonyms = (from w in _entities.GoogleSynonyms
                                      where w.GreWord.Word == word
                                      select w).Distinct().ToList();

                rtfGoogleDictionary.AppendText(Environment.NewLine);
                rtfGoogleDictionary.SelectionFont = f12R;
                rtfGoogleDictionary.SelectionColor = Color.DarkBlue;
                foreach (GoogleSynonym googleSynonym in googleSynonyms)
                {
                    rtfGoogleDictionary.AppendText(googleSynonym.Synonym + @", ");
                }


                //Google Phrase

                var googlePhrases = (from w in _entities.GooglePhrases
                                     where w.GreWord.Word == word
                                     select w).ToList();
                rtfGoogleDictionary.AppendText(Environment.NewLine);

                foreach (GooglePhrase googlePhrase in googlePhrases)
                {
                    rtfGoogleDictionary.SelectionColor = Color.DarkRed;
                    rtfGoogleDictionary.SelectionFont = f10B;
                    rtfGoogleDictionary.AppendText(googlePhrase.EnglishPhrase + ": ");
                    rtfGoogleDictionary.SelectionColor = Color.DarkGreen;
                    rtfGoogleDictionary.SelectionFont = f10R;
                    rtfGoogleDictionary.AppendText(googlePhrase.BengaliPhrase + ", ");
                }
            }

            //Comment
            {
                var wordDefinition = (from w in _entities.GreWords
                                      where w.Word == word
                                      select w).FirstOrDefault();
                rtfComment.Text = "";

                if (wordDefinition != null)
                {
                    rtfComment.Rtf = wordDefinition.Comment;
                    wordHardness.Rating = wordDefinition.Hardness;
                }
                _isCommentDirty = false;
            }

            //Etymology
            {
                var wordDefinition = (from w in _entities.WordEtymologies
                                      where w.GreWord.Word == word
                                      select w).FirstOrDefault();
                rtfEtymology.Text = "";

                if (wordDefinition != null)
                    rtfEtymology.Text = wordDefinition.Etymology;
            }

            //WordNet Definitions
            {
                var greWordDefinitions = (from w in _entities.GreWordDefinitions
                                          where w.GreWord.Word == word
                                          orderby w.Serial
                                          select w).ToList();
                rtfWordnetDefinitions.Text = "";
                var f12N = new Font(rtfWordnetDefinitions.SelectionFont.FontFamily, 12.0f);
                var f12B = new Font(rtfWordnetDefinitions.SelectionFont.FontFamily, 12.0f, FontStyle.Bold);
                var f12I = new Font(rtfWordnetDefinitions.SelectionFont.FontFamily, 12.0f, FontStyle.Italic);
                var f10B = new Font(rtfWordnetDefinitions.SelectionFont.FontFamily, 10.0f, FontStyle.Bold);

                foreach (GreWordDefinition definition in greWordDefinitions)
                {

                    rtfWordnetDefinitions.SelectionFont = f12N;
                    rtfWordnetDefinitions.AppendText(definition.Serial + ".");

                    rtfWordnetDefinitions.SelectionFont = f10B;
                    rtfWordnetDefinitions.AppendText(" (" + definition.PartsOfSpeech + ") ");

                    rtfWordnetDefinitions.SelectionFont = f12B;
                    rtfWordnetDefinitions.SelectionColor = Color.DarkBlue;
                    rtfWordnetDefinitions.AppendText(definition.SimilarWords + "\n");
                    rtfWordnetDefinitions.SelectionColor = Color.Black;

                    if (!string.IsNullOrEmpty(definition.Definitions))
                    {
                        rtfWordnetDefinitions.SelectionFont = f12N;
                        rtfWordnetDefinitions.AppendText(definition.Definitions + "\n");
                    }
                    if (!string.IsNullOrEmpty(definition.Sentences))
                    {
                        rtfWordnetDefinitions.SelectionFont = f12I;
                        rtfWordnetDefinitions.SelectionColor = Color.FromArgb(0, 100, 100, 100);
                        rtfWordnetDefinitions.AppendText(definition.Sentences + "\n");
                        rtfWordnetDefinitions.SelectionColor = Color.Black;
                    }
                    rtfWordnetDefinitions.AppendText("\n");
                }

                rtfWordnetDefinitions.SelectionStart = 0;
            }

            //Synonyms.net
            {
                var greWordSynonyms = (from w in _entities.GreWordSynonyms
                                       where w.GreWord.Word == word
                                       orderby w.Serial
                                       select w).ToList();
                rtfWordnetSynonyms.Text = "";
                var f12N = new Font(rtfWordnetSynonyms.SelectionFont.FontFamily, 12.0f);
                var f12B = new Font(rtfWordnetSynonyms.SelectionFont.FontFamily, 12.0f, FontStyle.Bold);
                var f10B = new Font(rtfWordnetSynonyms.SelectionFont.FontFamily, 10.0f, FontStyle.Bold);

                foreach (GreWordSynonym definition in greWordSynonyms)
                {

                    rtfWordnetSynonyms.SelectionFont = f12N;
                    rtfWordnetSynonyms.AppendText(definition.Serial + ".");

                    rtfWordnetSynonyms.SelectionFont = f10B;
                    rtfWordnetSynonyms.AppendText(" (" + definition.PartsOfSpeech + ") ");

                    rtfWordnetSynonyms.SelectionFont = f12B;
                    rtfWordnetSynonyms.SelectionColor = Color.DarkBlue;
                    rtfWordnetSynonyms.AppendText(definition.SimilarWords + "\n");
                    rtfWordnetSynonyms.SelectionColor = Color.Black;

                    if (!string.IsNullOrEmpty(definition.Synonyms))
                    {
                        rtfWordnetSynonyms.SelectionFont = f10B;
                        rtfWordnetSynonyms.AppendText("Synonym: ");

                        rtfWordnetSynonyms.SelectionFont = f12N;
                        rtfWordnetSynonyms.AppendText(definition.Synonyms.Trim() + "\n");
                    }

                    if (!string.IsNullOrEmpty(definition.Antonyms))
                    {
                        rtfWordnetSynonyms.SelectionFont = f10B;
                        rtfWordnetSynonyms.AppendText("Antonym: ");

                        rtfWordnetSynonyms.SelectionFont = f12N;
                        rtfWordnetSynonyms.AppendText(definition.Antonyms.Trim() + "\n");
                    }

                    rtfWordnetSynonyms.AppendText("\n");
                }
                rtfWordnetSynonyms.SelectionStart = 0;
            }
        }

        private void LoadWord(string word, string hardness, int index)
        {
            try
            {
                Text = string.Format("Currently Studying #{1}: {0}", word, index);

                LoadWordInformation(word, true);


            }
            catch (Exception exception)
            {
                _logger.Error("LoadWord", 1111, exception);
            }
        }

        private void DeleteWord(string word)
        {
            try
            {
                long listNameId = Convert.ToInt64(comboList.SelectedValue);

                if (listNameId != 0)
                {
                    var words = (from w in _entities.ListedWords
                                 where w.ListName.Id == listNameId && w.GreWord.Word == word
                                 select w).ToList();


                    if (words.Count > 0)
                    {
                        _entities.DeleteObject(words.First());
                        _entities.SaveChanges();
                    }
                }
                else
                {
                    var affineWords = (from w in _entities.GreWordAffinities
                                       where w.RelevantWord.Word == word
                                       select w).ToList();

                    foreach (GreWordAffinity w in affineWords)
                    {
                        _entities.DeleteObject(w);
                    }
                    _entities.SaveChanges();

                    var words = (from w in _entities.GreWords
                                 where w.Word.Equals(word)
                                 select w).ToList();

                    if (words.Count > 0)
                    {
                        foreach (var greWord in words)
                        {
                            _entities.DeleteObject(greWord);    
                        }
                        _entities.SaveChanges();
                    }
                }
            }
            catch (Exception exp)
            {
                _logger.Error("DeleteWord", 1156, exp);
            }
        }

        private void DeleteSelectedList()
        {
            long listNameId = Convert.ToInt64(comboList.SelectedValue);
            try
            {
                if (listNameId != 0)
                {
                    List<ListName> words = (from w in _entities.ListNames
                                            where w.Id == listNameId
                                            select w).ToList();

                    if (words.Count > 0)
                    {
                        _entities.DeleteObject(words.First());
                        _entities.SaveChanges();
                    }

                    comboList.Items.Remove(comboList.SelectedItem);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("List Delete Problem:\n" + exception.Message, "Deletion Problem");
                _logger.Error("Delete From List", 1183, exception);
            }

            LoadWordList();
        }

        private void SetHardness(int level)
        {
            try
            {
                string word = _currentWord;
                GreWord greword = (from w in _entities.GreWords
                                   where w.Word == word
                                   select w).FirstOrDefault();

                greword.Hardness = level;
                _entities.SaveChanges();

                _plainWordList.Where(a => a.Word == word).Select(a => a).FirstOrDefault().Hardness = level;

                foreach (ListViewItem item in wordsDataListView.SelectedItems)
                {
                    if (item.Text.Equals(_currentWord))
                    {
                        item.SubItems[1].Text = greword.Hardness + "";
                        item.SubItems[3].Text = greword.Tried + "";
                        wordsDataListView.EnsureVisible(item.Index);

                        item.Font = greword.Hardness > 0 ? new Font(wordsDataListView.Font, FontStyle.Bold) : new Font(wordsDataListView.Font, FontStyle.Regular);
                        item.ForeColor = _hardnessForeground[greword.Hardness];
                        item.BackColor = _hardnessBackground[greword.Hardness];

                        item.ImageKey = "rating_" + level;
                    }
                }
            }
            catch
            {
            }
        }


        private void Remembered()
        {
            UpdateRememberCount(1, 0);
        }

        private void Forgotten()
        {
            UpdateRememberCount(0, 1);
        }

        private void UpdateRememberCount(int countRemember, int countForgot)
        {
            try
            {

                string word = _currentWord;
                GreWord greword = (from w in _entities.GreWords
                                   where w.Word == word
                                   select w).FirstOrDefault();

                greword.Forgotten += countForgot;
                greword.Remembered += countRemember;
                _entities.SaveChanges();

                var p = _plainWordList.Where(a => a.Word == word).Select(a => a).FirstOrDefault();
                p.Forgotten += countForgot;
                p.Remembered += countRemember;

                foreach (ListViewItem item in wordsDataListView.SelectedItems)
                {
                    if (item.Text.Equals(_currentWord))
                    {
                        item.SubItems[2].Text = greword.RememberPercentile + "";
                        item.SubItems[3].Text = greword.Tried + "";
                    }
                }
                wordsDataListView.Focus();
            }
            catch
            {
            }
        }

        #endregion

        #region Text Effects

        private FontStyle MakeFontStyle(bool bold, bool italic, bool underline, bool strike)
        {
            FontStyle fs = FontStyle.Regular;
            if (bold)
                fs = fs | FontStyle.Bold;
            if (italic)
                fs = fs | FontStyle.Italic;
            if (underline)
                fs = fs | FontStyle.Underline;
            if (strike)
                fs = fs | FontStyle.Strikeout;
            return fs;
        }

        private void MakeBold()
        {
            FontStyle fs = MakeFontStyle(!rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic,
                                         rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout);
            var newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void MakeItalic()
        {
            FontStyle fs = MakeFontStyle(rtfComment.SelectionFont.Bold, !rtfComment.SelectionFont.Italic,
                                         rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout);
            var newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void MakeUnderline()
        {
            FontStyle fs = MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic,
                                         !rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout);
            var newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void MakeStrikethrough()
        {
            FontStyle fs = MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic,
                                         rtfComment.SelectionFont.Underline, !rtfComment.SelectionFont.Strikeout);
            var newFont = new Font(rtfComment.SelectionFont, fs);
            rtfComment.SelectionFont = newFont;
        }

        private void SetFontSizeAsIncrement(float increment)
        {
            try
            {
                SetFontSize(rtfComment.SelectionFont.Size + increment);
            }
            catch
            {
            }
        }

        private void SetFontSize(float fontsize)
        {
            try
            {
                Font selectionFont = rtfComment.SelectionFont;
                rtfComment.SelectionFont = new Font(selectionFont.FontFamily, fontsize, selectionFont.Style);
            }
            catch
            {
            }
        }

        private void SetCommentFont(string fontFamily)
        {
            var font = new Font(fontFamily, rtfComment.SelectionFont.Size, MakeFontStyle(rtfComment.SelectionFont.Bold, rtfComment.SelectionFont.Italic, rtfComment.SelectionFont.Underline, rtfComment.SelectionFont.Strikeout));
            if (rtfComment.SelectedText.Length == 0)
            {
                rtfComment.Font = font;
            }
            else
            {
                rtfComment.SelectionFont = font;
            }
        }

        private void SetCommentFont(Font font)
        {
            if (rtfComment.SelectedText.Length == 0)
            {
                rtfComment.Font = font;
            }
            else
            {
                rtfComment.SelectionFont = font;
            }
        }

        private void SetCommentColor(Color color)
        {
            if (rtfComment.SelectedText.Length == 0)
            {
                rtfComment.ForeColor = color;
            }
            else
            {
                rtfComment.SelectionColor = color;
            }
        }

        private void SetCommentBackgroundColor(Color color)
        {
            rtfComment.SelectionBackColor = color;
        }

        private void LoadAffineWord(ListView listView)
        {
            if (listView.SelectedItems.Count == 1)
            {
                LoadWordInformation(listView.SelectedItems[0].Text, false);
            }
        }
        #endregion

        private void captureScreenAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_screenOverlay == null)
                _screenOverlay = new ScreenOverlay() { ParentForm = this };
            //System.Threading.Thread.Sleep(1000);
            _screenOverlay.Show();
        }


        private void wordsDataListView_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D0:
                case Keys.NumPad0:
                    SetHardness(0);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.D1:
                case Keys.NumPad1:
                    SetHardness(1);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.D2:
                case Keys.NumPad2:
                    SetHardness(2);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.D3:
                case Keys.NumPad3:
                    SetHardness(3);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.D4:
                case Keys.NumPad4:
                    SetHardness(4);
                    e.SuppressKeyPress = true;
                    break;
                case Keys.D5:
                case Keys.NumPad5:
                    SetHardness(5);
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Space:
                case Keys.Add:
                    Remembered();
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Cancel:
                case Keys.Subtract:
                    Forgotten();
                    e.SuppressKeyPress = true;
                    break;

                case Keys.F6:
                    rtfComment.Focus();
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        void TryVisibleNext5Words(int num)
        {
            try
            {
                if (autoWordVisiblityToolStripMenuItem.Checked)
                {
                    Message msg = new Message { Msg = WM_VSCROLL };
                    WndProc(ref msg);
                }
            }
            catch { }
        }

        private const int WM_HSCROLL = 0x114;
        private const int WM_VSCROLL = 0x115;
        protected override void WndProc(ref Message msg)
        {

            // Look for the WM_VSCROLL or the WM_HSCROLL messages.
            if (msg.Msg == WM_VSCROLL)
            {
                int myInt = 1;
                int intLow = myInt & 0xffff;
                long intHigh = ((long)myInt & 0xffff0000) >> 16;
                SendMessage(this.wordsDataListView.Handle, (int)WM_VSCROLL, (uint)intLow, (uint)intHigh);
            }
            // Pass message to default handler.
            base.WndProc(ref msg);
        }

        private void wordListFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                fontDialog.Font = wordsDataListView.Font;
                if (fontDialog.ShowDialog(this) == DialogResult.OK)
                {
                    wordsDataListView.Font = fontDialog.Font;
                }
            }
            catch (Exception exception)
            {
                _logger.Error("Font Exception", 1583, exception);
            }
        }

        private void wordListGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordListGroupToolStripMenuItem.Checked = !wordListGroupToolStripMenuItem.Checked;
            wordsDataListView.ShowGroups = wordListGroupToolStripMenuItem.Checked;
        }

        private void viewAsDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordsDataListView.View = View.Details;
        }

        private void viewAsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordsDataListView.View = View.List;
        }

        private void viewAsIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordsDataListView.View = View.LargeIcon;
        }

        private void autoWordVisiblityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoWordVisiblityToolStripMenuItem.Checked = !autoWordVisiblityToolStripMenuItem.Checked;
        }

        private void textWord_Enter(object sender, EventArgs e)
        {
            textWordFilter.SelectAll();
        }

        private void textSearchSynonym_Enter(object sender, EventArgs e)
        {
            textSearchSynonym.SelectAll();
        }

        void SearchBySynonym(string text, bool isBySynonym = true)
        {
            long listNameId = 0;
            comboList.SelectedIndex = 0;
            _entities.Dispose();
            _entities = new gredbEntities();

            if (isBySynonym)
            {
                _plainWordList = (from w in _entities.GoogleSynonyms
                                  where w.Synonym.Contains(text)
                                  orderby w.Word
                                  select new PlainWord()
                                  {
                                      Word = w.Word,
                                      Forgotten = w.GreWord.Forgotten,
                                      Remembered = w.GreWord.Remembered,
                                      Hardness = w.GreWord.Hardness,
                                  }).Distinct().ToList();
            }
            else
            {
                _plainWordList = (from w in _entities.GreWordSynonyms
                                  where w.Antonyms.Contains(textSearchSynonym.Text)
                                  orderby w.Word
                                  select new PlainWord()
                                  {
                                      Word = w.Word,
                                      Forgotten = w.GreWord.Forgotten,
                                      Remembered = w.GreWord.Remembered,
                                      Hardness = w.GreWord.Hardness,
                                  }).Distinct().ToList();
            }

            //listBox1.Items.Clear();
            wordsDataListView.Items.Clear();
            wordsDataListView.DataSource = _plainWordList;
        }

        private void buttonSearchBySynonym_Click(object sender, EventArgs e)
        {
            SearchBySynonym(textSearchSynonym.Text);
        }

        private void buttonSearchByAntonym_Click(object sender, EventArgs e)
        {
            SearchBySynonym(textSearchSynonym.Text, false);
        }

        private void textSearchSynonym_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SearchBySynonym(textSearchSynonym.Text);
            }

            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                textSearchSynonym.Text = "";
            }
        }

        private void textWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                textWordFilter.Text = "";
            }
        }
    }
}