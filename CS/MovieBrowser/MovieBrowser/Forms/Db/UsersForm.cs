using System.Linq;
using System.Windows.Forms;
using MovieBrowser.Model;

namespace MovieBrowser.Forms.Db
{
    public partial class UsersForm : Form
    {
        private readonly MovieDbEntities _entities;
        public UsersForm(MovieDbEntities context)
        {
            _entities = context;
            InitializeComponent();
            var data = _entities.Users;
            dataListView1.DataSource = data;
        }

        private void dataListView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            User user = (User)dataListView1.SelectedObject;
            if (user != null)
            {
                textUsername.Text = user.Username;
                textPassword.Text = user.Password;
            }
        }

        private void clUpdate_Click(object sender, System.EventArgs e)
        {
            User u = (from user in _entities.Users
                      where user.Username == textUsername.Text
                      select user).FirstOrDefault();
            if (u == null)
            {
                u = new User { Username = textUsername.Text, Password = textPassword.Text };
                _entities.AddToUsers(u);

                dataListView1.DataSource = _entities.Users;
            }
            else
            {

                u.Username = textUsername.Text;
                u.Password = textPassword.Text;
            }
            _entities.SaveChanges();


            dataListView1.Enabled = true;
            textUsername.ReadOnly = true;
            textPassword.ReadOnly = true;
        }

        private void clCreate_Click(object sender, System.EventArgs e)
        {
            textUsername.Text = "";
            textUsername.ReadOnly = false;

            textPassword.Text = "";
            textPassword.ReadOnly = false;

            dataListView1.Enabled = false;
        }

        private void clDelete_Click(object sender, System.EventArgs e)
        {

        }

        private void UsersForm_Load(object sender, System.EventArgs e)
        {

        }


    }
}
