using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace SRTSync
{
    public partial class OnTheFlySRTWriter : Form
    {
        public int i;
        public bool start = false;
        public OnTheFlySRTWriter()
        {
            InitializeComponent();
            i = 1;


        }



        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _openFileDialog.Filter = @"All|*.*";
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                wmp.URL = _openFileDialog.FileName;
                //wmp.Ctlcontrols.stop();
                start = false;
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (start)
            //{
            //    int time = (int)(wmp.Ctlcontrols.currentPosition * 1000);
            //    this.textSRT.SelectedText = i++ + "\r\n" + Subtitle.MillisecondsToString(time) + "  -->  ";
            //    start = false;
            //}
            //else
            //{
            //    int time = (int)(wmp.Ctlcontrols.currentPosition * 1000);
            //    this.textSRT.SelectedText = Subtitle.MillisecondsToString(time) + "\r\n\r\n";
            //    start = true;
            //}

            Sync();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }

        OpenFileDialog _openFileDialog = new OpenFileDialog();
        private void Open()
        {
            Regex unit = new Regex(@"(?<sequence>\d+)\r\n(?<start>\d{2}\:\d{2}\:\d{2},\d{3}) --\> " + @"(?<end>\d{2}\:\d{2}\:\d{2},\d{3})\r\n(?<text>[\s\S]*?\r\n\r\n)", RegexOptions.Compiled | RegexOptions.ECMAScript);

            _openFileDialog.Filter = @"SRT File|*.srt";
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //textSrtFile.Text = sfd.FileName;
                var sw = new StreamReader(_openFileDialog.FileName);

                string subtitles = sw.ReadToEnd();

                MatchCollection matchCollection = unit.Matches(subtitles);
                int serial = 0;

                listSubtitles.Items.Clear();
                foreach (Match match in matchCollection)
                {
                    Int32.TryParse(match.Groups[1].Value, out serial);
                    var subtitle = new Subtitle
                                       {
                                           Serial = serial,
                                           Start = match.Groups[2].Value,
                                           End = match.Groups[3].Value,
                                           Text = match.Groups[4].Value.Trim()
                                       };
                    listSubtitles.Items.Add(subtitle.ToListViewItem());
                }


                sw.Close();
            }
        }

        SaveFileDialog _saveFileDialog = new SaveFileDialog();

        private void Save()
        {
            _saveFileDialog.Filter = @"SRT File|*.srt";
            _saveFileDialog.FileName = RemoveExtension(_openFileDialog.FileName + "");
            if (_saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //textSrtFile.Text = sfd.FileName;
                var sw = new StreamWriter(_saveFileDialog.FileName);

                int index = 1;
                foreach (var item in listSubtitles.Items)
                {
                    var subtitle = Subtitle.FromListViewItem((ListViewItem)item);
                    sw.Write(index++ + "\r\n" + subtitle.Start + " --> " + subtitle.End + "\r\n" + subtitle.Text + "\r\n\r\n");
                }

                sw.Close();
            }

            start = false;
        }

        private string RemoveExtension(string s)
        {
            int last = s.LastIndexOf(".");
            if (last == -1)
                return s;
            else
            {
                return s.Substring(0, last);
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wmp.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                wmp.Ctlcontrols.pause();
            }
            else
            {
                wmp.Ctlcontrols.play();
            }
        }

        private void endToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int time = (int)(wmp.Ctlcontrols.currentPosition * 1000);
            this.textSRT.SelectedText = Subtitle.MillisecondsToString(time);
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.currentPosition = wmp.Ctlcontrols.currentPosition - 2;
        }



        private void OnTheFlySRTWriter_Load(object sender, EventArgs e)
        {

        }

        private void listSubtitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSubtitles.SelectedItems.Count > 0)
            {
                Subtitle subtitle = Subtitle.FromListViewItem(listSubtitles.SelectedItems[0]);
                textSRT.Text = subtitle.Text;
                textStart.Text = subtitle.Start;
                textEnd.Text = subtitle.End;
            }
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Sync();
        }

        void Sync()
        {
            try
            {
                int index = listSubtitles.SelectedIndices[0];

                double d = 0;
                double.TryParse(responseTime.Text, out d);
                d = d / 1000.0;

                if (start)
                {
                    listSubtitles.Items[index].SubItems[2].Text =
                        Subtitle.MillisecondsToString(wmp.Ctlcontrols.currentPosition + d);

                    listSubtitles.Items[index].Selected = false;
                    listSubtitles.Items[index + 1].Selected = true;
                }
                else
                {
                    listSubtitles.Items[index].SubItems[1].Text =
                        Subtitle.MillisecondsToString(wmp.Ctlcontrols.currentPosition + d);
                }

                start = !start;

                listSubtitles.EnsureVisible(index + 2);
            }
            catch
            {
            }
        }




        private void updateSubtitle()
        {
            if (listSubtitles.SelectedItems.Count > 0)
            {

                listSubtitles.SelectedItems[0].Text = textSRT.Text;
            }
        }

        private void textSRT_TextChanged(object sender, EventArgs e)
        {
            updateSubtitle();
        }

        private void tbLoad_Click(object sender, EventArgs e)
        {

        }

        private void tbUp_Click(object sender, EventArgs e)
        {
            if (listSubtitles.SelectedIndices.Count > 0)
            {
                int index = listSubtitles.SelectedIndices[0];
                if (index == 0) return;

                ListViewItem item = listSubtitles.Items[index];
                listSubtitles.Items.RemoveAt(index);
                listSubtitles.Items.Insert(index - 1, item);
            }
        }

        private void tbDown_Click(object sender, EventArgs e)
        {
            if (listSubtitles.SelectedIndices.Count > 0)
            {
                int index = listSubtitles.SelectedIndices[0];
                if (index == listSubtitles.Items.Count - 1) return;

                ListViewItem item = listSubtitles.Items[index];
                listSubtitles.Items.RemoveAt(index);
                listSubtitles.Items.Insert(index + 1, item);
            }
        }

        private void tbDelete_Click(object sender, EventArgs e)
        {
            if (listSubtitles.SelectedIndices.Count > 0)
            {
                int index = listSubtitles.SelectedIndices[0];
                listSubtitles.Items.RemoveAt(index);
            }
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            var subtitle = new Subtitle() { Text = textSRT.Text, Serial = listSubtitles.Items.Count };
            listSubtitles.Items.Add(subtitle.ToListViewItem());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            start = false;
        }

        private void listSubtitles_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                double position =
                    Subtitle.StringToMilliseconds(Subtitle.FromListViewItem(listSubtitles.SelectedItems[0]).Start);
                wmp.Ctlcontrols.currentPosition = position;
            }
            catch
            {
            }
        }

        private void listSubtitles_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Sync();
        }

        private void tbOpen_Click(object sender, EventArgs e)
        {
            Open();
        }

        private void tbSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void tbReload_Click(object sender, EventArgs e)
        {
            var strings = textSRT.Text.Split('\n');
            listSubtitles.Items.Clear();
            foreach (var s in strings)
            {
                if (s.Trim().Length != 0)
                {
                    var subtitle = new Subtitle() { Text = s.Trim(), Serial = listSubtitles.Items.Count + 1 };
                    listSubtitles.Items.Add(subtitle.ToListViewItem());
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Regex r = new Regex("<br.*?>");
            textSRT.Text = r.Replace(textSRT.Text, "\r\n");

        }

        private void tbReset_Click(object sender, EventArgs e)
        {
            start = false;
        }

        private void btnGetStart_Click(object sender, EventArgs e)
        {
            textStart.Text = Subtitle.MillisecondsToString(wmp.Ctlcontrols.currentPosition);
        }

        private void btnGetEnd_Click(object sender, EventArgs e)
        {
            textEnd.Text = Subtitle.MillisecondsToString(wmp.Ctlcontrols.currentPosition);
        }

        private void textStart_TextChanged(object sender, EventArgs e)
        {
            if (listSubtitles.SelectedItems.Count > 0)
            {
                listSubtitles.SelectedItems[0].SubItems[1].Text = textStart.Text;
            }
        }

        private void textEnd_TextChanged(object sender, EventArgs e)
        {
            if (listSubtitles.SelectedItems.Count > 0)
            {
                listSubtitles.SelectedItems[0].SubItems[2].Text = textEnd.Text;
            }
        }

       
    }



    #region "business object"

    public class Subtitle
    {
        public int Serial { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Text { get; set; }

        public static string MillisecondsToString(double time)
        {
            var msTime = (int)(time * 1000);
            var hh = (msTime / (60 * 60 * 1000));
            var mm = (msTime / (60 * 1000)) % 60;
            var ss = (msTime / 1000) % 60;
            var ms = msTime % 1000;
            return String.Format("{0:00}", hh) + ":" + String.Format("{0:00}", mm) + ":" + String.Format("{0:00}", ss) + "," + String.Format("{0:000}", ms);
        }

        public static double StringToMilliseconds(string time)
        {
            var regex = new Regex(@"(\d+):(\d+):(\d+),(\d+)");
            var m = regex.Match(time);

            var hh = (Int32.Parse(m.Groups[1].Value) * 60 * 60 * 1000);
            var mm = (Int32.Parse(m.Groups[2].Value) * 60 * 1000);
            var ss = (Int32.Parse(m.Groups[3].Value) * 1000);
            var ms = (Int32.Parse(m.Groups[4].Value));

            return (double)(hh + mm + ss + ms) / 1000.0;
        }

        public ListViewItem ToListViewItem()
        {
            var lvi = new ListViewItem(this.Text);
            lvi.SubItems.Add(this.Start);
            lvi.SubItems.Add(this.End);
            lvi.SubItems.Add(this.Serial + "");
            return lvi;
        }

        public static Subtitle FromListViewItem(ListViewItem lvi)
        {
            int i = 0;
            Int32.TryParse(lvi.SubItems[3].Text, out i);

            var subtitle = new Subtitle()
                                    {
                                        Text = lvi.SubItems[0].Text,
                                        Start = lvi.SubItems[1].Text,
                                        End = lvi.SubItems[2].Text,
                                        Serial = i
                                    };
            return subtitle;
        }
    }
    #endregion
}


