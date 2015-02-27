using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using BrightIdeasSoftware;
using CommonUtilities;
using CommonUtilities.FileSystem;
using MovieBrowser.Controller;
using MovieBrowser.Forms.Db;
using MovieBrowser.Forms.Dialogs;
using MovieBrowser.Model;
using System.Linq;
using MovieBrowser.Util;
using FolderBrowserDialog = VistaUIApi.Dialog.FolderBrowserDialog;


namespace MovieBrowser.Forms
{

    public partial class MovieBrowserSimple : Form
    {
        #region Fields

        readonly SaveFileDialog _saveFileDialog = new SaveFileDialog();
        readonly OpenFileDialog _openFileDialog = new OpenFileDialog();
        readonly FolderBrowserDialog _dialog = new FolderBrowserDialog();
        private SearchForm _searchForm;
        private User _loggedInUser = null;
        private Movie _movie = null;
        readonly MovieBrowserController _controller = new MovieBrowserController();
        private readonly Color[] _hardnessBackground = new[]
                                                           {
                                                               Color.White, Color.LightGreen, Color.Aquamarine,
                                                               Color.Yellow, Color.Pink, Color.Red
                                                           };

        private readonly Color[] _hardnessForeground = new[]
                                                           {
                                                               Color.Black, Color.Navy, Color.Black, Color.Black,
                                                               Color.Black, Color.White
                                                           };
        #endregion

        public MovieBrowserSimple()
        {
            InitializeComponent();
            //treeView1.TreeViewNodeSorter = new MovieComparer();

            _controller.Browser = webBrowser1;
            _controller.OnDebugTextFired += _controller_OnDebugTextFired;
            _controller.OnNotificationFired += DesktopNotify;
            _controller.IntelligentSearch = intelligentTrackerToolStripMenuItem.Checked;

            InitializeTree();
            InitializeVirtualTree();

            _searchForm = new SearchForm(_controller);

        }

        private bool IsAuthorized
        {
            get
            {
                return _loggedInUser != null;
            }
        }


        #region ThreadSafe Access
        void _controller_OnDebugTextFired(object sender, EventArgs e)
        {
            if (textBox1.InvokeRequired)
            {
                textBox1.Invoke(new EventHandler(_controller_OnDebugTextFired), sender, e);
            }
            else
            {
                textBox1.AppendText(((TextEventArgs)e).Text);
            }
        }

        void DesktopNotify(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = ((TextEventArgs)e).Title;
            notifyIcon1.BalloonTipText = ((TextEventArgs)e).Text;
            notifyIcon1.ShowBalloonTip(200);
        }
        #endregion


        #region Methods
        private void ReloadTreeRoot()
        {
            var strs = (from object root in treeListFileSystem.Roots select ((Movie)root).FilePath).ToList();
            LoadTree(strs);
        }
        private void Login()
        {
            if (_loggedInUser == null)
            {
                var form = new LoginForm(_controller.Db);
                form.LoggedIn += (sender, args) =>
                {
                    var textEventArgs = (TextEventArgs)args;
                    if (textEventArgs.Data != null)
                        _loggedInUser = (User)textEventArgs.Data;
                };
                form.ShowDialog(this);
            }
        }
        void InitializeTree()
        {
            this.treeListFileSystem.CanExpandGetter = delegate(object x)
            {
                return ((Movie)x).IsFilesystemFolder;
            };

            this.treeListFileSystem.ChildrenGetter = delegate(object x)
            {
                var movie = (Movie)x;
                try
                {
                    var dir = new DirectoryInfo(movie.FilePath);

                    var members = dir.GetFileSystemInfos();

                    return movie.Children = members.Select(fileSystemInfo => Movie.FromFolderName(fileSystemInfo.FullName)).ToList();
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(this, ex.Message, "ObjectListViewDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return new ArrayList();
                }
            };


            // Show the size of files as GB, MB and KBs. Also, group them by
            // some meaningless divisions
            this.treeColumnSize.AspectGetter = delegate(object x)
            {
                var m = (Movie)x;

                if (!m.IsFilesystemFolder)
                {

                    try
                    {
                        var fileInfo = new FileInfo(((Movie)x).FilePath);

                        return fileInfo.Length;
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        // Mono 1.2.6 throws this for hidden files
                        return (long)-2;
                    }
                }
                else
                {
                    return (long)-2;
                }
            };

            // Draw the system icon next to the name
            //var helper = new SysImageListHelper(this.treeListView1);
            this.treeColumnTitle.ImageGetter = delegate(object x)
            {
                return ((Movie)x).ImageIndex;
            };



            this.treeColumnSize.AspectToStringConverter = delegate(object x)
            {
                if ((long)x < 0) // folder
                    return "";
                else
                    return FormatFileSize((long)x);
            };

            this.treeColumnYear.AspectToStringConverter = delegate(object x)
            {
                if (x + "" == "0") // folder
                    return "";
                else
                    return x + "";
            };

            this.treeColumnRating.AspectToStringConverter = delegate(object x)
            {
                if (x + "" == "0") // folder
                    return "";
                else
                    return x + "";
            };

            // Show the system description for this object
            this.treeColumnFileType.AspectGetter = delegate(object x)
            {
                return ShellUtilities.GetFileType(((Movie)x).FilePath);
            };
        }

        private void LoadTree(IEnumerable<string> paths)
        {
            var roots = new ArrayList();
            foreach (var root in paths)
            {
                var movie = Movie.FromFolderName(root);
                roots.Add(movie);
            }
            treeListFileSystem.Roots = roots;
        }

        static string FormatFileSize(long size)
        {
            var limits = new int[] { 1024 * 1024 * 1024, 1024 * 1024, 1024 };
            var units = new string[] { "GB", "MB", "KB" };

            for (var i = 0; i < limits.Length; i++)
            {
                if (size >= limits[i])
                    return String.Format("{0:#,##0.##} " + units[i], ((double)size / limits[i]));
            }

            return String.Format("{0} bytes", size); ;
        }

        private void LoadDbInfo(Movie pmovie)
        {

            lblImdbId.Text = pmovie.ImdbId;
            var movie = _controller.Db.Movies.Where(a => a.ImdbId == pmovie.ImdbId).FirstOrDefault();
            if (movie != null)
            {
                var note = _controller.Db.MoviePersonalNotes.Where(o => o.User.Id == _loggedInUser.Id && o.Movie.ImdbId == movie.ImdbId).FirstOrDefault();
                if (!IsAuthorized || note == null)
                {

                    txtUserRating.Text = "";

                    tbDislikeIt.Image = Properties.Resources.hate_it_dis;
                    tbHaveIt.Image = Properties.Resources.have_it_dis;
                    tbLikeIt.Image = Properties.Resources.like_it_dis;
                    tbSeenIt.Image = Properties.Resources.seen_it_dis;
                    tbWantToWatch.Image = Properties.Resources.check_list_dis;

                    tbDislikeIt.Checked = false;
                    tbHaveIt.Checked = false;
                    tbLikeIt.Checked = false;
                    tbSeenIt.Checked = false;
                    tbWantToWatch.Checked = false;
                }
                else
                {
                    _controller_OnDebugTextFired(this, new TextEventArgs("note=" + note.Movie.Title + "\r\n"));

                    txtUserRating.Text = note.Rating + "";

                    tbDislikeIt.Image = note.Favourite < 0 ? Properties.Resources.hate_it : Properties.Resources.hate_it_dis;
                    tbLikeIt.Image = note.Favourite > 0 ? Properties.Resources.like_it : Properties.Resources.like_it_dis;
                    tbHaveIt.Image = note.Have ? Properties.Resources.have_it : Properties.Resources.have_it_dis;
                    tbSeenIt.Image = note.Seen ? Properties.Resources.seen_it : Properties.Resources.seen_it_dis;
                    tbWantToWatch.Image = note.Wishlist ? Properties.Resources.check_list : Properties.Resources.check_list_dis;

                    tbDislikeIt.Checked = note.Favourite == -1;
                    tbHaveIt.Checked = note.Have;
                    tbLikeIt.Checked = note.Favourite == 1;
                    tbSeenIt.Checked = note.Seen;
                    tbWantToWatch.Checked = note.Wishlist;
                }
            }
            else
            {

            }
        }

        void LoadImdbInfo(Movie rowMovie)
        {
            _movie = rowMovie;
            lblImdbId.Text = rowMovie.ImdbId;
            var movie = _controller.Db.Movies.Where(a => a.ImdbId == rowMovie.ImdbId).FirstOrDefault();
            if (movie == null)
            {

                listCountries.Items.Clear();
                listKeywords.Items.Clear();
                listGenres.Items.Clear();
                listLanguages.Items.Clear();
                //
                listActors.Items.Clear();
                listStars.Items.Clear();
                listDirectors.Items.Clear();
                listWriters.Items.Clear();

                if (rowMovie.IsValidMovie)
                {
                    lblTitle.Text = rowMovie.Title;
                    lblRating.Text = rowMovie.Rating + "";
                    lblYear.Text = rowMovie.Year + "";
                }
                else
                {
                    lblTitle.Text = "";
                    lblRating.Text = "";
                    lblYear.Text = "";
                }

                lblRuntime.Text = "";
                lblMPAA.Text = "";
                textMpaaReason.Text = "";
                textHighlight.Text = "";

                tbUpdated.Checked = false;

            }
            else
            {
                lblTitle.Text = movie.Title;
                lblRating.Text = movie.Rating + "";
                lblYear.Text = movie.Year + "";

                lblRuntime.Text = movie.Runtime;
                lblMPAA.Text = movie.MPAA;
                textMpaaReason.Text = movie.MPAAReason;
                textHighlight.Text = movie.Highlight;

                tbUpdated.Checked = movie.IsUpdated;

                var listC = _controller.Db.MovieCountries.Where(a => a.Movie.Id == movie.Id).Select(o => o.Country).ToList();
                listCountries.Items.Clear();
                foreach (var country in listC)
                {
                    var item = new ListViewItem(country.Name);
                    item.SubItems.Add(country.Code);
                    listCountries.Items.Add(item);
                }

                listKeywords.DataSource = _controller.Db.MovieKeywords.Where(a => a.Movie.Id == movie.Id).Select(o => o.Keyword);

                var listG = _controller.Db.MovieGenres.Where(a => a.Movie.Id == movie.Id).Select(o => o.Genre).ToList();
                listGenres.Items.Clear();
                foreach (var country in listG)
                {
                    var item = new ListViewItem(country.Name);
                    item.SubItems.Add(country.Code);
                    listGenres.Items.Add(item);
                }

                listLanguages.DataSource = _controller.Db.MovieLanguages.Where(a => a.Movie.Id == movie.Id).Select(o => o.Language);

                listDirectors.DataSource = _controller.Db.Directors.Where(a => a.Movie.Id == movie.Id).Select(o => o.Person);
                listWriters.DataSource = _controller.Db.Writers.Where(a => a.Movie.Id == movie.Id).Select(o => o.Person);
                listActors.DataSource = _controller.Db.Actors.Where(a => a.Movie.Id == movie.Id).Select(o => o.Person);
                listStars.DataSource = _controller.Db.Stars.Where(a => a.Movie.Id == movie.Id).Select(o => o.Person);

            }

            if (IsAuthorized)
            {
                var personalNote = _controller.Db.MoviePersonalNotes.Where(o => o.User.Id == _loggedInUser.Id && o.Movie.ImdbId == rowMovie.ImdbId).FirstOrDefault();


                comboUserList.SelectedIndex = -1;


                var mul = _controller.Db.MovieUserLists.Where(o => o.UserList.User.Id == _loggedInUser.Id && o.Movie.ImdbId == rowMovie.ImdbId).FirstOrDefault();
                if (mul != null)
                {
                    for (int i = 0; i < comboUserList.Items.Count; i++)
                    {
                        var item = comboUserList.Items[i];
                        if (item.ToString() == mul.UserList.ListName)
                            comboUserList.SelectedIndex = i;
                    }
                }
                LoadPersonalNote(personalNote);
            }
            else
            {
                LoadPersonalNote(null);
            }
        }

        void LoadPersonalNote(MoviePersonalNote note)
        {


            if (note == null)
            {
                rsUserRating.Rating = 0;

                pbDislike.Image = Properties.Resources.hate_it_dis;
                pbHaveIt.Image = Properties.Resources.have_it_dis;
                pbLike.Image = Properties.Resources.like_it_dis;
                pbSeenIt.Image = Properties.Resources.seen_it_dis;
                pbWanted.Image = Properties.Resources.check_list_dis;
            }
            else
            {
                _controller_OnDebugTextFired(this, new TextEventArgs("note=" + note.Movie.Title + "\r\n"));

                rsUserRating.Rating = note.Rating;

                pbDislike.Image = note.Favourite < 0 ? Properties.Resources.hate_it : Properties.Resources.hate_it_dis;
                pbLike.Image = note.Favourite > 0 ? Properties.Resources.like_it : Properties.Resources.like_it_dis;
                pbHaveIt.Image = note.Have ? Properties.Resources.have_it : Properties.Resources.have_it_dis;
                pbSeenIt.Image = note.Seen ? Properties.Resources.seen_it : Properties.Resources.seen_it_dis;
                pbWanted.Image = note.Wishlist ? Properties.Resources.check_list : Properties.Resources.check_list_dis;
            }

        }

        private void MovieSearch(OLVListItem item)
        {
            if (item == null) return;

            var movie = (Movie)item.RowObject;

            if (movie.IsVirtual || movie.IsFolder || movie.IsFilesystemFolder)
                _controller.SearchMovieTree(MovieBrowserController.ImdbSearch, item);
            else
                MovieBrowserController.Open(movie.FilePath);
        }

        private void LoadUserList()
        {
            if (IsAuthorized)
            {
                comboUserList.Items.Clear();

                foreach (UserList movieUserList in _controller.Db.UserLists.Where(o => o.User.Id == _loggedInUser.Id))
                {
                    comboUserList.Items.Add(movieUserList.ListName);
                }
            }
        }
        private static void CollectAndUpdate(OLVListItem selectedItem, string html = null, Movie movie = null, bool fetchKeywords = true)
        {
            var information = new CollectInformation { MovieController = new MovieBrowserController(), MovieNode = selectedItem, Html = html, ParsedMovie = movie, FetchKeyword = fetchKeywords };
            var thread = new Thread(information.Collect);
            thread.Start();
        }

        private void UpdateTreeNode()
        {
            if (tabMovies.SelectedTab == tpMoviesTree)
            {
                UpdateTreeNode(treeListFileSystem);
            }
            else if (tabMovies.SelectedTab == tpVirtualFolders)
            {
                UpdateTreeNode(treeListVirtualFolders);
            }
        }

        private void UpdateTreeNode(TreeListView treeList)
        {
            if (treeList.SelectedItem != null)
            {
                CollectAndUpdate((OLVListItem)treeList.SelectedItem, webBrowser1.DocumentText, null, false);
                //_controller.UpdateMovie((OLVListItem) treeView1.SelectedItem);
            }
        }


        #endregion

        private void MovieBrowserSimpleFormClosing(object sender, FormClosingEventArgs e)
        {
            MovieBrowserController.SaveFolderListTree((ArrayList)treeListFileSystem.Roots);
        }

        private void MovieBrowserSimpleLoad(object sender, EventArgs e)
        {
            Login();

            MovieBrowserController.LoadPenDrives(comboPendrives);

            dataListMoviesDatabase.UseTranslucentHotItem = true;
            dataListMoviesDatabase.DataSource = _controller.Movies;

            try
            {
                var paths = (from object a in Properties.Settings.Default.Paths select (string)a).ToList();
                LoadTree(paths);
            }
            catch (Exception exception)
            { }
            LoadUserList();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.M))
            {
                CollectAndUpdate((OLVListItem)treeListFileSystem.SelectedItem);
                return true;
            }

            if (keyData == Keys.F8)
            {
                UpdateTreeNode();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void WebBrowser1DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                textBox1.AppendText("Document Completed: " + webBrowser1.ReadyState + "\r\n");
                if (_controller.RecentSearch && _controller.IntelligentSearch)
                    _controller.Redirect(e.Url.AbsoluteUri, webBrowser1.DocumentText);
                else
                {
                    _controller.RecentSearch = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void WebBrowser1Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.AppendText("Navigated to " + e.Url.AbsoluteUri + "\r\n");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var information = new CollectInformation { Html = webBrowser1.DocumentText, MovieController = _controller, MovieNode = null };
            var thread = new Thread(information.Collect);
            thread.Start();
        }

        private void updateMovieInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var movies = ((Movie)treeListFileSystem.SelectedObject).Children;
            new UpdateMovieInformation(movies).Show();
        }

        private void DataListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var movie = (Movie)(dataListMoviesDatabase.SelectedObject);
                LoadImdbInfo(movie);

                LoadDbInfo(movie);

            }
            catch { }
        }

        private void DataListView1DoubleClick(object sender, EventArgs e)
        {
            try
            {
                var movie = (Movie)(dataListMoviesDatabase.SelectedObject);
                _controller.SearchMovie(MovieBrowserController.ImdbSearch, movie);
            }
            catch
            {
            }
        }

        private void DataListView1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                DataListView1DoubleClick(sender, e);
        }

        private void searchTextBox1_SearchStarted(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.treeListFileSystem, searchTextBox1.Text);
        }

        private void searchTextBox1_SearchCancelled(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.treeListFileSystem, "");
        }

        private void searchTextBox2_SearchStarted(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.dataListMoviesDatabase, searchTextBox2.Text);
        }

        private void searchTextBox2_SearchCancelled(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.dataListMoviesDatabase, "");
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeListFileSystem.SelectedObject != null)
                LoadImdbInfo((Movie)treeListFileSystem.SelectedObject);
        }

        /****************************************************************/
        private void tbBrowseFolders_Click(object sender, EventArgs e)
        {

            if (_dialog.ShowDialog(this) == DialogResult.OK)
            {
                treeListFileSystem.AddObject(Movie.FromFolderName(_dialog.SelectedPath));
            }
        }

        private void tbSaveFolders_Click(object sender, EventArgs e)
        {
            MovieBrowserController.SaveFolderListTree((ArrayList)treeListFileSystem.Roots);
        }

        private void tbLoadPendrives_Click(object sender, EventArgs e)
        {
            MovieBrowserController.LoadPenDrives(comboPendrives);
        }

        private void tbOpenExplorer_Click(object sender, EventArgs e)
        {
            if (treeListFileSystem.SelectedItem != null)
                MovieBrowserController.Open(((Movie)treeListFileSystem.SelectedObject).FilePath);
        }

        private void tbSearchImdb_Click(object sender, EventArgs e)
        {
            _controller.SearchMovie(Controller.MovieBrowserController.ImdbSearch, (Movie)treeListFileSystem.SelectedObject);
        }

        private void tbIgnoreList_Click(object sender, EventArgs e)
        {
            var form = new IgnoreListForm();
            form.ShowDialog(this);
        }

        private void rsUserRating_RatingValueChanged(object sender, RatingControl.RatingChangedEventArgs e)
        {
            if (IsAuthorized)
                _controller.UpdateUserRating(_loggedInUser, _movie, rsUserRating.Rating);
            else
            {
                rsUserRating.Rating = 0;
            }
        }

        private void pbWanted_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {
                LoadPersonalNote(_controller.ToggleWanted(_loggedInUser, _movie));
            }
        }

        private void tbRemoveFolders_Click(object sender, EventArgs e)
        {
            foreach (Movie item in treeListFileSystem.SelectedObjects)
            {
                treeListFileSystem.RemoveObject(item);
            }

        }

        private void tbRefreshFolders_Click(object sender, EventArgs e)
        {
            ReloadTreeRoot();
        }

        private void tbSearchGoogle_Click(object sender, EventArgs e)
        {
            _controller.SearchMovie(Controller.MovieBrowserController.GoogleSearch, (Movie)treeListFileSystem.SelectedObject);
        }

        private void treeListView1_DoubleClick(object sender, EventArgs e)
        {
            MovieSearch(treeListFileSystem.SelectedItem as OLVListItem);
        }

        private void refreshFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadTreeRoot();
        }

        private void pbLike_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {
                LoadPersonalNote(_controller.SetFavourite(_loggedInUser, _movie, true));
            }
        }

        private void pbSeenIt_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {
                LoadPersonalNote(_controller.ToggleSeenIt(_loggedInUser, _movie));
            }
        }

        private void pbHaveIt_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {
                LoadPersonalNote(_controller.ToggleHaveIt(_loggedInUser, _movie));
            }
        }

        private void pbDislike_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {

                LoadPersonalNote(_controller.SetFavourite(_loggedInUser, _movie, false));
            }
        }

        private void tbAddToDb_Click(object sender, EventArgs e)
        {
            CollectAndUpdate(null, webBrowser1.DocumentText);
        }

        private void pbUpdateTree_Click(object sender, EventArgs e)
        {
            UpdateTreeNode();
        }

        private void pbAddTreeItemToDb_Click(object sender, EventArgs e)
        {
            if (treeListFileSystem.SelectedItem != null)
                CollectAndUpdate((OLVListItem)treeListFileSystem.SelectedItem);
        }

        private void tbSendTo_Click(object sender, EventArgs e)
        {
            if (comboPendrives.SelectedItem != null)
            {
                var movies = treeListFileSystem.CheckedObjects.Cast<Movie>().Where(movie => movie.IsFilesystemFolder).ToList();
                MovieBrowserController.SendTo(movies, comboPendrives);
            }
        }

        private void tbDeleteFromDb_Click(object sender, EventArgs e)
        {
            if (dataListMoviesDatabase.SelectedObject != null)
                _controller.RemoveMovie(((Movie)dataListMoviesDatabase.SelectedObject).ImdbId);
        }

        private void tbRefreshDb_Click(object sender, EventArgs e)
        {
            dataListMoviesDatabase.DataSource = _controller.Movies;
        }

        private void tbWantToWatch_Click(object sender, EventArgs e)
        {
            tbWantToWatch.Checked = !tbWantToWatch.Checked;
            foreach (Movie movie in dataListMoviesDatabase.SelectedObjects)
            {
                if (IsAuthorized)
                {

                    _controller.ToggleWanted(_loggedInUser, movie, tbWantToWatch.Checked);
                }
            }
        }

        private void tbLikeIt_Click(object sender, EventArgs e)
        {
            tbLikeIt.Checked = !tbLikeIt.Checked;
            foreach (Movie movie in dataListMoviesDatabase.SelectedObjects)
            {
                if (IsAuthorized)
                {

                    _controller.SetFavourite(_loggedInUser, movie, tbLikeIt.Checked);
                }
            }
        }

        private void tbDislikeIt_Click(object sender, EventArgs e)
        {
            tbDislikeIt.Checked = !tbDislikeIt.Checked;
            foreach (Movie movie in dataListMoviesDatabase.SelectedObjects)
            {
                if (IsAuthorized)
                {

                    _controller.SetFavourite(_loggedInUser, movie, tbDislikeIt.Checked);
                }
            }
        }

        private void tbSeenIt_Click(object sender, EventArgs e)
        {
            tbSeenIt.Checked = !tbSeenIt.Checked;
            foreach (Movie movie in dataListMoviesDatabase.SelectedObjects)
            {
                if (IsAuthorized)
                {

                    _controller.ToggleSeenIt(_loggedInUser, movie, tbSeenIt.Checked);
                }
            }
        }

        private void tbHaveIt_Click(object sender, EventArgs e)
        {
            tbHaveIt.Checked = !tbHaveIt.Checked;
            foreach (Movie movie in dataListMoviesDatabase.SelectedObjects)
            {
                if (IsAuthorized)
                {

                    _controller.ToggleHaveIt(_loggedInUser, movie, tbHaveIt.Checked);
                }
            }
        }

        private void tbRateIt_Click(object sender, EventArgs e)
        {
            foreach (Movie movie in dataListMoviesDatabase.SelectedObjects)
            {
                if (IsAuthorized)
                {
                    double rating = 0.0;
                    double.TryParse(txtUserRating.Text, out rating);
                    _controller.RateIt(_loggedInUser, movie, rating);
                }
            }
        }

        private void tbUserManagement_Click(object sender, EventArgs e)
        {
            Form form = new UsersForm(_controller.Db);
            form.ShowDialog(this);

        }

        private void buttonModifyList_Click(object sender, EventArgs e)
        {
            if (IsAuthorized)
            {
                new MovieListForm(_loggedInUser, _controller.Db).ShowDialog(this);

                LoadUserList();
            }
        }

        private void tbKeywordManagement_Click(object sender, EventArgs e)
        {
            new KeywordsForm(_controller.Db).ShowDialog(this);
        }

        private void listKeywords_FormatRow(object sender, FormatRowEventArgs e)
        {
            var w = (Keyword)e.Model;
            e.Item.ForeColor = _hardnessForeground[w.Rated];
            e.Item.BackColor = _hardnessBackground[w.Rated];
            e.Item.Font = w.Rated > 0 ? new Font(listKeywords.Font, FontStyle.Bold) : new Font(listKeywords.Font, FontStyle.Regular);
        }

        private void buttonAddToList_Click(object sender, EventArgs e)
        {
            if (comboUserList.SelectedIndex >= 0)
            {
                _controller.AddToUserList(_movie, comboUserList.SelectedItem.ToString());
            }
        }

        private void tbIntelligent_Click(object sender, EventArgs e)
        {
            tbIntelligent.Checked = !tbIntelligent.Checked;
            _controller.IntelligentSearch = tbIntelligent.Checked;
        }

        private void tbUpdateDb_Click(object sender, EventArgs e)
        {
            if (dataListMoviesDatabase.SelectedObject != null)
                CollectAndUpdate(null, null, (Movie)dataListMoviesDatabase.SelectedObject);
        }

        private void tbAddToDbFromBrowser_Click(object sender, EventArgs e)
        {
            CollectAndUpdate(null, webBrowser1.DocumentText);
        }

        private void treeView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MovieSearch(treeListFileSystem.SelectedItem as OLVListItem);
            }
        }

        private void tbUpdateTreeNode_Click(object sender, EventArgs e)
        {
            UpdateTreeNode();
        }
        private class CollectInformation
        {
            public OLVListItem MovieNode { private get; set; }
            public Movie ParsedMovie { get; set; }
            public MovieBrowserController MovieController { private get; set; }
            public string Html { private get; set; }
            public bool FetchKeyword { get; set; }

            public void Collect()
            {
                try
                {

                    if (MovieNode != null)
                    {
                        ParsedMovie = (Movie)MovieNode.RowObject;
                    }

                    var movie = MovieController.CollectAndAddMovieToDb(ParsedMovie, Html, FetchKeyword);
                    if (MovieNode != null && movie != null)
                    {
                        MovieController.UpdateMovieNode(MovieNode, movie);
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show(@"Problem Collecting Information.", exception.Message);
                }
            }

        }

        private void tbUpdated_Click(object sender, EventArgs e)
        {
            tbUpdated.Checked = !tbUpdated.Checked;
            foreach (Movie movie in dataListMoviesDatabase.SelectedObjects)
            {
                var m = _controller.Db.Movies.Where(o => o.ImdbId == movie.ImdbId).FirstOrDefault();
                if (m == null) continue;
                m.IsUpdated = tbUpdated.Checked;
                movie.IsUpdated = tbUpdated.Checked;
                _controller.Db.SaveChanges();
            }
        }

        private void clSearch_Click(object sender, EventArgs e)
        {
            _searchForm.ShowDialog();

            datalistResult.DataSource = _searchForm.SearchResult;
        }

        private void datalistResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var movie = (Movie)(datalistResult.SelectedObject);
                LoadImdbInfo(movie);
                LoadDbInfo(movie);

            }
            catch { }
        }

        private void datalistResult_DoubleClick(object sender, EventArgs e)
        {
            if (datalistResult.SelectedObject != null)
                _controller.SearchMovie(MovieBrowserController.ImdbSearch, (Movie)datalistResult.SelectedObject);
        }

        private void datalistResult_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (datalistResult.SelectedObject != null)
                _controller.SearchMovie(MovieBrowserController.ImdbSearch, (Movie)datalistResult.SelectedObject);
        }

        private void tbGenerateXML_Click(object sender, EventArgs e)
        {

            if (_saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var serializer = new VirtualMovieFolderSerializer();
                serializer.SerializeTreeView(Properties.Settings.Default.Paths, _saveFileDialog.FileName);
            }
        }

        private void tbLoadVirtualFolders_Click(object sender, EventArgs e)
        {
            LoadVirtualTree();
        }


        void InitializeVirtualTree()
        {
            this.treeListVirtualFolders.CanExpandGetter = delegate(object x)
            {
                return ((Movie)x).IsFolder;
            };

            this.treeListVirtualFolders.ChildrenGetter = delegate(object x)
            {
                var movie = (Movie)x;
                try
                {
                    return movie.Children;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(this, ex.Message, "ObjectListViewDemo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return new ArrayList();
                }
            };

        }

        private void LoadVirtualTree()
        {

            if (_openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var roots = new ArrayList();
                var serializer = new VirtualMovieFolderSerializer();
                var movie = serializer.DeserializeTreeView(_openFileDialog.FileName);
                foreach (var m in movie.Children)
                    roots.Add(m);
                treeListVirtualFolders.Roots = roots;
            }


        }

        private void searchVirtualFolders_SearchStarted(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.treeListVirtualFolders, searchVirtualFolders.Text);
        }

        private void searchVirtualFolders_SearchCancelled(object sender, EventArgs e)
        {
            ComponentUtility.TimedFilter(this.treeListVirtualFolders, "");
        }

        private void treeListVirtualFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (treeListVirtualFolders.SelectedObject != null)
                LoadImdbInfo((Movie)treeListVirtualFolders.SelectedObject);
        }

        private void treeListVirtualFolders_DoubleClick(object sender, EventArgs e)
        {
            MovieSearch(treeListVirtualFolders.SelectedItem as OLVListItem);
        }

        private void treeListVirtualFolders_KeyDown(object sender, KeyEventArgs e)
        {
            MovieSearch(treeListVirtualFolders.SelectedItem as OLVListItem);
        }

        private void updateItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var movies = ((Movie)treeListVirtualFolders.SelectedObject).Children;
            new UpdateMovieInformation(movies).Show();
        }

        private void tbSaveVirtualTree_Click(object sender, EventArgs e)
        {
            if (_saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                var roots = (ArrayList)treeListVirtualFolders.Roots;
                var movies = new List<Movie>();

                foreach (Movie movie in roots)
                {
                    movies.Add(movie);
                }

                var serializer = new VirtualMovieFolderSerializer();
                serializer.SerializeTreeView(movies, _saveFileDialog.FileName);
            }
        }
    }

    public class SendToThread
    {

        public string Source { get; set; }
        public string Destination { get; set; }


        public void SendTo()
        {
            try
            {
                FileHelper.CopyAllRecursive(new DirectoryInfo(Source), new DirectoryInfo(Destination));
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Problem Sending file.\r\n{0}", exception.Message);
            }
        }

    }

}