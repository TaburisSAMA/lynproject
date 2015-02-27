using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GREWordStudy.Common.Browser
{


    public partial class MaxBrowser : UserControl
    {
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);
        const int URLMON_OPTION_USERAGENT = 0x10000001;


        public MaxBrowser()
        {
            string url = "about:blank";
            InitializeComponent();
            try
            {
                textAddress.Text = url;
                webBrowser1.Url = new Uri(url);
            }
            catch { }
        }
        public MaxBrowser(string url)
        {
            InitializeComponent();
            try
            {
                textAddress.Text = url;
                webBrowser1.Url = new Uri(url);
            }
            catch { }
        }

        public void ChangeUserAgent(string Agent)
        {
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0);
        }

        public void Navigate(String url)
        {

            try
            {
                textAddress.Text = url;
                webBrowser1.Navigate(url);
            }
            catch { }
        }

        private void TextAddressKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(textAddress.Text);
            }
        }



        private void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textAddress.Text = webBrowser1.Url.AbsoluteUri;
        }



        private void toolStripButtonGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(textAddress.Text);
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        private void toolStripButtonIE8_Click(object sender, EventArgs e)
        {
            ChangeUserAgent(Properties.Settings.Default.IE8);
        }

        private void toolStripButtonIPhone_Click(object sender, EventArgs e)
        {
            ChangeUserAgent(Properties.Settings.Default.IPhone);
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (Control control in this.Controls)
                {
                    control.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }
    }
}
