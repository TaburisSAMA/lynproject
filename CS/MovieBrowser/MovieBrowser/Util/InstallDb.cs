using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Configuration;
using System.Windows.Forms;

namespace MovieBrowser.Util
{
    [RunInstaller(true)]
    public partial class InstallDb : Installer
    {
        public InstallDb()
        {
            InitializeComponent();
        }

        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            Configuration c = ConfigurationManager.OpenExeConfiguration(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var section = (ConnectionStringsSection)c.GetSection("connectionStrings");
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string datasource = string.Format(@"metadata=res://*/Model.MoviesDb.csdl|res://*/Model.MoviesDb.ssdl|res://*/Model.MoviesDb.msl;provider=System.Data.SQLite;provider connection string='data source={0}\MaxInc\Db\MovieDb.sqlite'", path);
            section.ConnectionStrings["MovieDbEntities"].ConnectionString = datasource;
            c.Save();
        }


        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }
    }
}
