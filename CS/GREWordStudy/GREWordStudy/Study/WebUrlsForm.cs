using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GREWordStudy.Model;

namespace GREWordStudy.Study
{
    public partial class WebUrlsForm : Form
    {
        private readonly gredbEntities _entities;

        public WebUrlsForm(gredbEntities entities)
        {
            _entities = entities;
            InitializeComponent();
        }

        private void WebUrlsForm_Load(object sender, EventArgs e)
        {
            webUrlBindingSource.DataSource = _entities.WebUrls;
        }

        private void webUrlBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            _entities.SaveChanges();
        }

    }
}
