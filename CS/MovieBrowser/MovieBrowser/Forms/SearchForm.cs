using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using MovieBrowser.Controller;
using MovieBrowser.Model;
using CommonUtilities.Extensions;
using MovieBrowser.Util;

namespace MovieBrowser.Forms
{
    public partial class SearchForm : Form
    {
        private readonly MovieBrowserController _controller;

        public SearchForm(MovieBrowserController controller)
        {
            _controller = controller;
            InitializeComponent();

            listKeywords.DataSource = _controller.Db.Keywords;
            listGenres.DataSource = _controller.Db.Genres;
            listStars.DataSource = _controller.Db.Stars.Select(o => o.Person).Distinct();
            listDirectors.DataSource = _controller.Db.Directors.Select(o => o.Person).Distinct();
        }

        private void textRatingFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double d = double.Parse(textRatingFrom.Text);
                ratingFrom.Rating = d;
            }
            catch (Exception)
            { }
        }
        private void textRatingTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double d = double.Parse(textRatingTo.Text);
                ratingTo.Rating = d;
            }
            catch (Exception)
            {
            }
        }
        private void clSearch_Click(object sender, EventArgs e)
        {
            var movies = _controller.Db.Movies.Select(o => o);

            if (chkKeywords.Checked)
            {
                var list = (from Keyword keyword in listKeywords.CheckedObjects select keyword.Id).ToList();

                var t = _controller.Db.MovieKeywords.WhereIn(o => o.Keyword.Id, list).Select(o => o.Movie);
                movies = movies.Intersect(t);
            }

            if (chkGenres.Checked)
            {
                var list = (from Genre genre in listGenres.CheckedObjects select genre.Id).ToList();
                var t = _controller.Db.MovieGenres.WhereIn(o => o.Genre.Id, list).Select(o => o.Movie);
                movies = movies.Intersect(t);
            }
            if (chkDirectors.Checked)
            {
                var list = (from Person genre in listDirectors.CheckedObjects select genre.Id).ToList();
                var t = _controller.Db.Directors.WhereIn(o => o.Person.Id, list).Select(o => o.Movie);
                movies = movies.Intersect(t);
            }
            if (chkStars.Checked)
            {
                var list = (from Person genre in listStars.CheckedObjects select genre.Id).ToList();
                var t = _controller.Db.Stars.WhereIn(o => o.Person.Id, list).Select(o => o.Movie);
                movies = movies.Intersect(t);
            }
            if (chkRating.Checked)
            {
                movies = movies.Where(o => o.Rating >= ratingFrom.Rating && o.Rating <= ratingTo.Rating);
            }

            SearchResult = movies.ToList();

            this.Hide();
        }

        public List<Movie> SearchResult { get; set; }

        private void searchKeywords_SearchStarted(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.listKeywords, searchKeywords.Text);
        }

        private void searchKeywords_SearchCancelled(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.listKeywords, "");
        }

        private void searchGenres_SearchStarted(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.listGenres, searchGenres.Text);
        }

        private void searchGenres_SearchCancelled(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.listGenres, "");
        }

        private void searchStars_SearchStarted(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.listStars, searchStars.Text);
        }

        private void searchStars_SearchCancelled(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.listStars, "");
        }

        private void searchDirectors_SearchStarted(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.listDirectors, searchDirectors.Text);
        }

        private void searchDirectors_SearchCancelled(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.listDirectors, "");
        }

        private void ratingFrom_RatingValueChanged(object sender, RatingControl.RatingChangedEventArgs e)
        {
            textRatingFrom.Text = ratingFrom.Rating + "";
        }

        private void ratingTo_RatingValueChanged(object sender, RatingControl.RatingChangedEventArgs e)
        {
            textRatingTo.Text = ratingTo.Rating + "";
        }

        private void chkClear_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckClearClick(listKeywords, chkClear);
        }

        private void OnCheckClearClick(DataListView dataListView, CheckBox chk)
        {
            if (dataListView.SelectedItems.Count == 0)
            {
                foreach (OLVListItem selectedObject in dataListView.Items)
                {
                    selectedObject.Checked = chk.Checked;
                }
            }
            else
            {
                foreach (OLVListItem selectedObject in dataListView.SelectedItems)
                {
                    selectedObject.Checked = chk.Checked;
                }
            }
        }

        private void chkKeywords_CheckedChanged(object sender, EventArgs e)
        {
            listKeywords.Enabled = chkKeywords.Checked;
        }

        private void chkGenres_CheckedChanged(object sender, EventArgs e)
        {
            listGenres.Enabled = chkGenres.Checked;
        }

        private void chkStars_CheckedChanged(object sender, EventArgs e)
        {
            listStars.Enabled = chkStars.Checked;
        }

        private void chkDirectors_CheckedChanged(object sender, EventArgs e)
        {
            listDirectors.Enabled = chkDirectors.Checked;
        }

        private void chkRating_CheckedChanged(object sender, EventArgs e)
        {
            ratingTo.Enabled = chkRating.Checked;
            ratingFrom.Enabled = chkRating.Checked;
        }

        private void clCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void clReset_Click(object sender, EventArgs e)
        {


            listKeywords.DataSource = _controller.Db.Keywords;
            listGenres.DataSource = _controller.Db.Genres;
            listStars.DataSource = _controller.Db.Stars.Select(o => o.Person).Distinct();
            listDirectors.DataSource = _controller.Db.Directors.Select(o => o.Person).Distinct();

            textRatingTo.Text = "10";
            textRatingFrom.Text = "6";

            chkKeywords.Checked = false;
            chkGenres.Checked = false;
            chkStars.Checked = false;
            chkDirectors.Checked = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckClearClick(listGenres, checkBox1);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckClearClick(listStars, checkBox2);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            OnCheckClearClick(listDirectors, checkBox4);
        }





    }
}
