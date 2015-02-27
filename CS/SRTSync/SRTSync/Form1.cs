using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace SRTSync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string srtFile;
        string srtResult;
        const string regexTimestampSRT = "([0-9\\-]+):([0-9\\-]+):([0-9\\-]+),([0-9\\-]+) --> ([0-9\\-]+):([0-9\\-]+):([0-9\\-]+),([0-9\\-]+)";
        const string regexTimestamp = "([0-9\\-]+):([0-9\\-]+):([0-9\\-]+),([0-9\\-]+)";

        private void buttonOpenSrt_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SRT File|*.srt";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textSrtFile.Text = ofd.FileName;
                System.IO.StreamReader sr = new StreamReader(ofd.FileName);
                srtFile = sr.ReadToEnd();
                sr.Close();
            }
        }


        private string OffsetTimestampString(string sTimeHH, string sTimeMM, string sTimeSS, string sTimeMS, int offset)
        {
            int msTime = GetTimeMilliseconds(sTimeHH, sTimeMM, sTimeSS, sTimeSS);
            msTime += offset;
            return MillisecondsToString(msTime);
        }

        private string MillisecondsToString(int msTime)
        {
            int hh = (msTime / (60 * 60 * 1000));
            int mm = (msTime / (60 * 1000)) % 60;
            int ss = (msTime / 1000) % 60;
            int ms = msTime % 1000;
            return String.Format("{0:00}", hh) + ":" + String.Format("{0:00}", mm) + ":" + String.Format("{0:00}", ss) + "," + String.Format("{0:000}", ms);
        }

        private int StringToMilliseconds(string sSrtRef)
        {
            try
            {
                Regex reTS = new Regex(regexTimestamp);
                Match mTS = reTS.Match(sSrtRef);
                return GetTimeMilliseconds(mTS.Groups[1].Value, mTS.Groups[2].Value, mTS.Groups[3].Value, mTS.Groups[4].Value);
            }
            catch (Exception exp)
            {
                return 0;
            }
        }

        private int DiffTimestamp(string sSrtRef, string sMovieRef)
        {
            int tsSrtRef = StringToMilliseconds(sSrtRef);
            int tsMovieRef = StringToMilliseconds(sMovieRef);
            return tsMovieRef - tsSrtRef;
        }

        private int GetTimeMilliseconds(string sTimeHH, string sTimeMM, string sTimeSS, string sTimeMS)
        {
            return int.Parse(sTimeHH) * 60 * 60 * 1000 + int.Parse(sTimeMM) * 60 * 1000 + int.Parse(sTimeSS) * 1000 + int.Parse(sTimeMS);
        }

        private void buttonShift_Click(object sender, EventArgs e)
        {
            int ms = DiffTimestamp(textSrtRef.Text, textMovieRef.Text);
            textOffset.Text =  MillisecondsToString(ms);
        }

        private void buttonReSync_Click(object sender, EventArgs e)
        {
            try
            {
                Regex reSrt = new Regex(regexTimestampSRT);
                MatchCollection mTS = reSrt.Matches(srtFile);
                int timeOffset = StringToMilliseconds(textOffset.Text);

                srtResult = srtFile;
                foreach (Match m in mTS)
                {
                    int time1 = GetTimeMilliseconds(m.Groups[1].Value, m.Groups[2].Value, m.Groups[3].Value, m.Groups[4].Value);
                    int time2 = GetTimeMilliseconds(m.Groups[5].Value, m.Groups[6].Value, m.Groups[7].Value, m.Groups[8].Value);
                    time1 += timeOffset;
                    time2 += timeOffset;
                    srtResult = srtResult.Replace(m.Value, MillisecondsToString(time1) + " --> " + MillisecondsToString(time2));
                }
                textBox1.Text = srtResult;
            }
            catch (Exception exp)
            {
               
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "SRT File|*.srt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //textSrtFile.Text = sfd.FileName;
                System.IO.StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(textBox1.Text);
                sw.Close();
            }
        }
    }
}
