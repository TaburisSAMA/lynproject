using System.Windows.Forms;
using MovieBrowser.Model;
using MovieBrowser.Util;
using System.Linq;

namespace MovieBrowser.Forms.Db
{
    public partial class KeywordsForm : Form
    {
        private MovieDbEntities _db;
        public KeywordsForm(MovieDbEntities context)
        {
            _db = context;
            InitializeComponent();

            dataListView1.DataSource = _db.Keywords;
        }

       

        private void dataListView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (dataListView1.SelectedObject != null)
            {
                ratingStar1.Rating = ((Keyword)dataListView1.SelectedObject).Rated;
            }
        }

        private void searchTextBox1_SearchStarted(object sender, System.EventArgs e)
        {
            ComponentUtility.TimedFilter(this.dataListView1, searchTextBox1.Text);
        }

        private void searchTextBox1_SearchCancelled(object sender, System.EventArgs e)
        {
            ComponentUtility.TimedFilter(this.dataListView1, "");
        }

        private void ratingStar1_RatingValueChanged(object sender, RatingControl.RatingChangedEventArgs e)
        {
            foreach (Keyword keyword in dataListView1.SelectedObjects)
            {
                keyword.Rated = (int)ratingStar1.Rating;
                //Keyword keyword1 = keyword;
                //var k = _db.Keywords.Where(o => o.Id == keyword1.Id).FirstOrDefault().Rated = (int)ratingStar1.Rating;
            }
            _db.SaveChanges();
        }
    }
}
