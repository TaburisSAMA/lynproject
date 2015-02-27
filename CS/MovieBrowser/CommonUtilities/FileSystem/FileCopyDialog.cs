using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonUtilities.Extensions;

namespace CommonUtilities.FileSystem
{
    public partial class FileCopyDialog : Form
    {
        private readonly FileCopierEx _copierEx;

        public FileCopyDialog()
        {
            InitializeComponent();
            _copierEx = new FileCopierEx();
            _copierEx.CopyProgress += CopierExCopyProgress;
        }


        public String CopyText
        {
            set
            {
                this.textCurrent.Text = value;
            }
            get
            {
                return this.textCurrent.Text;
            }
        }

        private bool _cancelled = false;

        private void BtnCancelClick(object sender, EventArgs e)
        {
            _cancelled = true;
        }


        public void CopyFile(string from, string to)
        {
            backgroundWorker1.RunWorkerAsync();
        }


        void CopierExCopyProgress(object sender, CopyProgressEventArgs e)
        {

            var percent = (int)(e.TotalBytesTransferred * 100 / (e.TotalFileSize * 1.0));
            progressBar1.SetPropertyThreadSafe(() => progressBar1.Value, percent);

            if (_cancelled)
                e.Cancel = true;
        }

        private void BackgroundWorker1DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (_filesToCopy.Count == 0) return;

            foreach (CopyFileInfo t in _filesToCopy)
            {
                try
                {
                    textCurrent.SetPropertyThreadSafe(() => textCurrent.Text, t.SourcePath);

                    CopyFileInfo copyFileInfo = t;
                    _copierEx.CopyFile(copyFileInfo.SourcePath, copyFileInfo.TargetPath);

                    textFinished.SetPropertyThreadSafe(() => textFinished.Text, textFinished.Text + t.TargetPath + "\r\n");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            MessageBox.Show("Copy Done!");
            this.SetPropertyThreadSafe(() => this.Visible, false);
        }

        private List<CopyFileInfo> _filesToCopy = null;

        public void CopyFiles(List<CopyFileInfo> list)
        {
            _cancelled = false;
            _filesToCopy = list;
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
