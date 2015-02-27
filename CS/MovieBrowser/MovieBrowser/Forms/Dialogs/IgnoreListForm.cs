using System;
using MovieBrowser.Controller;
using WindowsFormsAero.Dwm;
using WindowsFormsAero.Dwm.Helpers;

namespace MovieBrowser.Forms.Dialogs
{
    public partial class IgnoreListForm : GlassForm
    {

        MovieBrowser.Controller.MovieBrowserController _controller = new MovieBrowserController();
        public IgnoreListForm()
        {
            InitializeComponent();

            GlassMargins = new Margins(0, 0, 0, 32);
        }

        private void IgnoreListForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.IgnoreWords;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.IgnoreWords = MovieBrowserController.UpdateIgnoreWords();
            Properties.Settings.Default.Save();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


    }
}
