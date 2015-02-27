using System;
using System.Linq;
using System.Windows.Forms;
using MovieBrowser.Controller;
using MovieBrowser.Model;
using WindowsFormsAero.Dwm;
using WindowsFormsAero.Dwm.Helpers;

namespace MovieBrowser.Forms.Dialogs
{
    public partial class LoginForm : GlassForm
    {
        private TextEventArgs _args;
        public event EventHandler LoggedIn;

        MovieDbEntities db;


        public void InvokeLoggedIn(EventArgs e)
        {
            var handler = LoggedIn;
            if (handler != null) handler(this, e);
        }

        public LoginForm(MovieDbEntities context = null)
        {
            db = context ?? new MovieDbEntities();
            InitializeComponent();

            GlassMargins = new Margins(0, 0, 48, 48);
        }

        private void clLogin_Click(object sender, EventArgs e)
        {
            if (textUsername.Text.Trim().Length == 0) return;
            if (textPassword.Text.Trim().Length == 0) return;



            var user = db.Users.Where(o => o.Username == textUsername.Text).FirstOrDefault();
            if (user == null)
            {
                user = new User { Username = textUsername.Text, Password = textPassword.Text };

                db.AddToUsers(user);
                db.SaveChanges();


                _args = new TextEventArgs("Success") { Data = user };
                this.Hide();
            }
            else if (user.Password != textPassword.Text)
            {
                _args = new TextEventArgs("Fail") { Data = null };
                MessageBox.Show(this, @"Username/Password does not match!");

            }
            else
            {
                _args = new TextEventArgs("Success") { Data = user };
                this.Hide();
            }
        }

        private void commandLink1_Click(object sender, EventArgs e)
        {
            _args = new TextEventArgs("Fail") { Title = "", Data = null };
            this.Hide();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_args == null)
                _args = new TextEventArgs("Fail") { Data = null };
            InvokeLoggedIn(_args);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textUsername.Focus();
        }
    }
}
