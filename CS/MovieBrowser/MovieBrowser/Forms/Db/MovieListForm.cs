using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MovieBrowser.Model;

namespace MovieBrowser.Forms.Db
{
    public partial class MovieListForm : Form
    {
        private readonly User _user;
        private readonly MovieDbEntities _entities;
        public MovieListForm(User user, MovieDbEntities context = null)
        {
            _user = user;
            _entities = context ?? new MovieDbEntities();
            InitializeComponent();

            dataListView1.DataSource = _entities.UserLists.Where(o => o.User.Id == _user.Id);
        }

        private void dataListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var userList = (UserList)dataListView1.SelectedObject;
            if (userList != null)
            {
                textUsername.Text = userList.ListName;
            }
        }

        private void clCreate_Click(object sender, EventArgs e)
        {
            if (_entities.UserLists.Where(o => o.ListName == textUsername.Text && o.User.Id == _user.Id).FirstOrDefault() == null)
            {
                var userList = new UserList { User = _user, ListName = textUsername.Text };
                _entities.AddToUserLists(userList);
                _entities.SaveChanges();

                dataListView1.DataSource = _entities.UserLists.Where(o => o.User.Id == _user.Id);
            }
        }

        private void clUpdate_Click(object sender, EventArgs e)
        {
            if (dataListView1.SelectedObject == null) return;


            UserList u = (from o in _entities.UserLists
                          where o.Id == ((UserList)dataListView1.SelectedObject).Id
                          select o).FirstOrDefault();
            if (u != null)
            {
                u.ListName = textUsername.Text;
            }
            _entities.SaveChanges();

        }

        private void clDelete_Click(object sender, EventArgs e)
        {
            if (dataListView1.SelectedObject == null) return;

            var u = (from o in _entities.UserLists
                     where o.Id == ((UserList)dataListView1.SelectedObject).Id
                     select o).FirstOrDefault();
            if (u != null)
            {
                _entities.DeleteObject(u);
            }
            _entities.SaveChanges();
        }

        private void MovieListForm_Load(object sender, EventArgs e)
        {

        }
    }
}
