using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using CommonUtilities;
using CommonUtilities.Extensions;
using CommonUtilities.FileSystem;
using MovieBrowser.Forms;
using MovieBrowser.Model;
using MovieBrowser.Parser;
using ShellLib;

namespace MovieBrowser.Controller
{
    public class MovieBrowserController
    {
        #region Private Variables

        private readonly MovieDbEntities _entities;
        #endregion


        #region Properties

        private bool DbLoggedIn { get; set; }
        public MovieDbEntities Db { get { return _entities; } }
        #endregion


        public MovieBrowserController()
        {
            try
            {
                _entities = new MovieDbEntities();
                DbLoggedIn = false;
            }
            catch (Exception exception)
            {
                Logger.Exception(exception, 43);
            }
        }

        #region Event
        public event EventHandler OnDebugTextFired;

        private void InvokeOnDebugTextFired(string text)
        {
            var handler = OnDebugTextFired;
            if (handler != null) handler(this, new TextEventArgs(text));
        }

        public event EventHandler OnMovieInformationCollected;
        public void InvokeOnMovieInformationCollected(Movie movie, string message)
        {
            var handler = OnMovieInformationCollected;
            if (handler != null) handler(this, new MovieEventArgs(movie, message));
        }

        public event EventHandler OnNotificationFired;

        private void InvokeOnNotificationFired(string text)
        {
            var handler = OnNotificationFired;
            if (handler != null) handler(this, new TextEventArgs(text));
        }
        #endregion

        #region Constants
        public const string GoogleSearch = "http://www.google.com/search?q=";
        public const string ImdbSearch = "http://www.imdb.com/find?s=all&q=";
        private const string ImdbTitle = "http://www.imdb.com/title/";
        private const string ImdbKeywordUrl = "http://www.imdb.com/title/{0}/keywords";
        #endregion

        public WebBrowser Browser { get; set; }

        public bool RecentSearch { get; set; }

        public bool IntelligentSearch { get; set; }

        public List<Movie> Movies
        {
            get
            {
                return _entities.Movies.ToList();
            }
        }

        public void SearchMovieTree(string address, OLVListItem movie)
        {
            try
            {
                SearchMovie(address, (Movie)movie.RowObject);
            }
            catch (Exception exception)
            { Logger.Exception(exception, 134); }
        }

        public void SearchMovie(string address, Movie movie)
        {
            try
            {
                RecentSearch = true;
                if (address.Equals(ImdbSearch) && movie != null && !string.IsNullOrEmpty(movie.ImdbId))
                {

                    Navigate(ImdbTitle + movie.ImdbId);
                }
                else
                {
                    if (movie != null) Navigate(address + IgnoreWords(movie.Title));
                }
            }
            catch (Exception exception) { Logger.Exception(exception, 116); }
        }

        private static string IgnoreWords(string text)
        {
            text = text.ToLower();
            string[] ignored = Properties.Settings.Default.IgnoreWords.ToLower().Split();
            text = ignored.Aggregate(text, (current, s) => string.IsNullOrEmpty(s) ? current : current.Replace(s, ""));
            text = text.Replace(".", " ");
            return text;
        }

        public static string ChangeFolderName(Movie original)
        {
            var newdir = original.FilePath.Substring(0, original.FilePath.LastIndexOf("\\") + 1);
            newdir += original.FolderName.CleanFileName();

            if (original.FilePath != newdir && Directory.Exists(original.FilePath))
                Directory.Move(original.FilePath, newdir);

            return newdir;
        }

        public void UpdateMovieNode(OLVListItem nodeMovie, Movie movie)
        {
            try
            {
                var rowMovie = ((Movie)nodeMovie.RowObject);
                //var movie = CollectAndAddMovieToDb(rowMovie, Browser.DocumentText, false);
                if (movie == null) return;

                if (!movie.IsVirtual)
                {
                    movie.FilePath = rowMovie.FilePath;
                    movie.FilePath = ChangeFolderName(movie);
                }

                rowMovie.CopyFromMovie(movie);
                InvokeOnNotificationFired("Movie: " + rowMovie.Title + " is updated.");
            }
            catch (Exception exception)
            {
                Logger.Exception(exception, 2);
            }
        }

        public static string UpdateIgnoreWords()
        {
            string[] words = Properties.Settings.Default.IgnoreWords.ToLower().Split();
            //Array.Sort(words);

            var t = (from s in words
                     orderby s descending
                     select s).ToArray();

            string s2 = string.Join(" ", t);

            Properties.Settings.Default.IgnoreWords = s2;
            Properties.Settings.Default.Save();

            return s2;
        }

        public static void SaveFolderListTree(ArrayList movieFolderTree)
        {
            Properties.Settings.Default.Paths = new StringCollection();

            foreach (Movie node in movieFolderTree)
            {
                Properties.Settings.Default.Paths.Add(node.FilePath);
            }
            Properties.Settings.Default.Save();
        }

        public static void Open(string path)
        {
            var execute = new ShellExecute
            {
                Verb = ShellExecute.OpenFile,
                Path = path
            };
            execute.Execute();
        }

        void Navigate(string url)
        {
            Browser.Navigate(url);
        }

        public void Redirect(string srcurl, string src)
        {
            var title = ImdbParser.MediaFrom(src);
            if (!string.IsNullOrEmpty(title))
            {
                var url = "http://www.imdb.com/title/" + title;
                InvokeOnDebugTextFired(string.Format("Redirect to '{0}'...\r\n", url));
                Browser.Navigate(url);

                RecentSearch = false;
            }

            if (srcurl.StartsWith(ImdbSearch))
                RecentSearch = false;
        }

        public static void LoadPenDrives(ToolStripComboBox tsPendrives)
        {
            tsPendrives.Items.Clear();

            var ss = FileHelper.UsbDrives();
            foreach (string t in ss)
            {
                tsPendrives.Items.Add(t);
            }
            if (ss.Count > 0) tsPendrives.SelectedIndex = 0;
        }

        public static void SendTo(IEnumerable<Movie> movies, ToolStripComboBox tsPendrives)
        {
            try
            {
                foreach (var stt in movies.Select(movie => new SendToThread
                                                               {
                                                                   Source = movie.FilePath,
                                                                   Destination = Path.Combine(tsPendrives.SelectedItem.ToString(), movie.FolderName)
                                                               }))
                {
                    stt.SendTo();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("SendTo:\r\n{0}", exception.Message));
            }
        }

        public Movie CollectAndAddMovieToDb(Movie movie2, string moviePage = null, bool collectKeyword = true)
        {
            if (string.IsNullOrEmpty(moviePage))
            {
                InvokeOnNotificationFired("Started collecting movie: " + movie2.Title);
                moviePage = HttpHelper.FetchWebPage(ImdbTitle + movie2.ImdbId);
            }

            var parseMovieInfo = ParseMovieInfo(moviePage);

            if (parseMovieInfo == null) return null;



            var movie = _entities.Movies.Where(o => o.ImdbId == parseMovieInfo.ImdbId).FirstOrDefault();
            if (movie == null)
            {
                movie = parseMovieInfo;
                movie.IsUpdated = false;
                _entities.AddToMovies(movie);
                _entities.SaveChanges();
            }
            else
            {
                movie.CopyFromMovie(parseMovieInfo);
                _entities.SaveChanges();
            }

            foreach (var g in parseMovieInfo.Genres)
            {
                var genre = GetGenre(g);
                var movieGenre = _entities.MovieGenres.Where(o => o.Movie.Id == movie.Id && o.Genre.Id == genre.Id).FirstOrDefault();

                if (movieGenre != null) continue;
                movieGenre = new MovieGenre { Movie = movie, Genre = genre };
                _entities.AddToMovieGenres(movieGenre);
                _entities.SaveChanges();
            }

            foreach (var g in parseMovieInfo.Languages)
            {
                var language = GetLanguage(g);
                var movieLanguage = _entities.MovieLanguages.Where(o => o.Movie.Id == movie.Id && o.Language.Id == language.Id).FirstOrDefault();

                if (movieLanguage != null) continue;
                movieLanguage = new MovieLanguage { Movie = movie, Language = language };
                _entities.AddToMovieLanguages(movieLanguage);
                _entities.SaveChanges();
            }

            foreach (var g in parseMovieInfo.Countries)
            {
                var country = GetCountry(g);
                var movieCountry = _entities.MovieCountries.Where(o => o.Movie.Id == movie.Id && o.Country.Id == country.Id).FirstOrDefault();

                if (movieCountry != null) continue;
                movieCountry = new MovieCountry { Movie = movie, Country = country };
                _entities.AddToMovieCountries(movieCountry);
                _entities.SaveChanges();
            }

            foreach (var g in parseMovieInfo.PersonDirectors)
            {
                var person = GetPerson(g);
                var director = _entities.Directors.Where(o => o.Movie.Id == movie.Id && o.Person.Id == person.Id).FirstOrDefault();

                if (director != null) continue;
                director = new Director { Movie = movie, Person = person };
                _entities.AddToDirectors(director);
                _entities.SaveChanges();
            }

            foreach (var g in parseMovieInfo.PersonStars)
            {
                var person = GetPerson(g);
                var star = _entities.Stars.Where(o => o.Movie.Id == movie.Id && o.Person.Id == person.Id).FirstOrDefault();

                if (star != null) continue;
                star = new Star { Movie = movie, Person = person };
                _entities.AddToStars(star);
                _entities.SaveChanges();
            }

            foreach (var g in parseMovieInfo.PersonWriters)
            {
                var person = GetPerson(g);
                var writer = _entities.Writers.Where(o => o.Movie.Id == movie.Id && o.Person.Id == person.Id).FirstOrDefault();

                if (writer != null) continue;
                writer = new Writer { Movie = movie, Person = person };
                _entities.AddToWriters(writer);
                _entities.SaveChanges();
            }


            if (collectKeyword)
            {
                var keywordPage = HttpHelper.FetchWebPage(string.Format(ImdbKeywordUrl, parseMovieInfo.ImdbId));
                parseMovieInfo.Keywords = ImdbParser.ParseKeywords(keywordPage);

                foreach (var g in parseMovieInfo.Keywords)
                {
                    var keyword = GetKeyword(g);
                    var movieKeyword =
                        _entities.MovieKeywords.Where(o => o.Movie.Id == movie.Id && o.Keyword.Id == keyword.Id).
                            FirstOrDefault();

                    if (movieKeyword != null) continue;
                    movieKeyword = new MovieKeyword { Movie = movie, Keyword = keyword };
                    _entities.AddToMovieKeywords(movieKeyword);
                    _entities.SaveChanges();
                }
            }
            InvokeOnNotificationFired("Fiished collecting movie: " + movie.Title);

            movie.IsUpdated = true;
            _entities.SaveChanges();

            return movie;
        }

        private Person GetPerson(Person g)
        {
            var person = _entities.People.Where(o => o.ImdbId == g.ImdbId).FirstOrDefault();
            if (person == null)
            {
                person = new Person { Name = g.Name, ImdbId = g.ImdbId };
                _entities.AddToPeople(person);
                _entities.SaveChanges();
            }
            return person;
        }

        private Keyword GetKeyword(Keyword g)
        {
            var keyword = _entities.Keywords.Where(o => o.Code == g.Code).FirstOrDefault();
            if (keyword == null)
            {
                keyword = new Keyword { Name = g.Name, Code = g.Code };
                _entities.AddToKeywords(keyword);
                _entities.SaveChanges();
            }
            return keyword;
        }

        private Country GetCountry(Country c)
        {
            var country = _entities.Countries.Where(o => o.Code == c.Code).FirstOrDefault();
            if (country == null)
            {
                country = new Country { Name = c.Name, Code = c.Code };
                _entities.AddToCountries(country);
                _entities.SaveChanges();
            }
            return country;
        }

        private Language GetLanguage(Language l)
        {
            var language = _entities.Languages.Where(o => o.Code == l.Code).FirstOrDefault();
            if (language == null)
            {
                language = new Language { Name = l.Name, Code = l.Code };
                _entities.AddToLanguages(language);
                _entities.SaveChanges();
            }
            return language;
        }

        private Genre GetGenre(Genre g)
        {
            var genre = _entities.Genres.Where(o => o.Code == g.Code).FirstOrDefault();
            if (genre == null)
            {
                genre = new Genre { Name = g.Name, Code = g.Code, Rated = 0 };
                _entities.AddToGenres(genre);
                _entities.SaveChanges();
            }
            return genre;
        }

        public static Movie GuessMovie(string srcHtml)
        {
            return ImdbParser.GuessMovie(srcHtml);
        }

        #region Imdb Parser
        public Movie ParseMovieInfo(string html)
        {
            try
            {
                var movie = new Movie();

                //var src = Browser.DocumentText;
                var rating = ImdbParser.ParseRating(html);
                var title = ImdbParser.ParseTitle(html);
                var year = ImdbParser.ParseYear(html);
                var imdbId = ImdbParser.ParseId(html);

                InvokeOnDebugTextFired("Title: " + title + "\r\n");
                InvokeOnDebugTextFired("Year: " + year + "\r\n");
                InvokeOnDebugTextFired("Rating: " + rating + "\r\n");

                movie.Rating = Convert.ToDouble(rating);
                movie.Title = HttpHelper.HtmlDecode(HttpHelper.UrlDecode(ImdbParser.ParseTitle(html)));
                movie.Year = Convert.ToInt32(year);
                movie.ImdbId = imdbId;
                movie.FilePath = "";
                movie.Runtime = ImdbParser.ParseRuntime(html);
                movie.MPAA = ImdbParser.ParseMpaa(html);
                movie.MPAAReason = ImdbParser.ParseMpaaReason(html);
                movie.Highlight = ImdbParser.ParseHighlight(html);
                movie.Genres = ImdbParser.ParseGenres(html);
                movie.Countries = ImdbParser.ParseCountries(html);
                movie.Languages = ImdbParser.ParseLanguages(html);

                movie.PersonStars = ImdbParser.ParseStars(html);
                movie.PersonWriters = ImdbParser.ParseWriters(html);
                movie.PersonDirectors = ImdbParser.ParseDirectors(html);

                movie.IsValidMovie = true;

                return movie;
            }
            catch (Exception exception)
            {
                Logger.Exception(exception, 418);
                return null;
            }
        }

        #endregion

        #region Db Access
        //public void AddMovieToDb(Movie movie)
        //{
        //    var entities = new MovieDbEntities();

        //    if (entities.Movies.Where(o => o.ImdbId.Equals(movie.ImdbId)).ToList().Count() == 0)
        //    {
        //        entities.AddToMovies(movie);
        //        entities.SaveChanges();
        //    }
        //    else
        //    {
        //        //Already exists
        //        Console.WriteLine(@"Exists: {0}", movie.ImdbId);
        //    }
        //}
        #endregion

        public void RemoveMovie(string imdbId)
        {

            _entities.DeleteObjects(_entities.MovieGenres.Where(o => o.Movie.ImdbId == imdbId));
            _entities.DeleteObjects(_entities.MovieCountries.Where(o => o.Movie.ImdbId == imdbId));
            _entities.DeleteObjects(_entities.MovieKeywords.Where(o => o.Movie.ImdbId == imdbId));
            _entities.DeleteObjects(_entities.MovieLanguages.Where(o => o.Movie.ImdbId == imdbId));
            _entities.DeleteObjects(_entities.MoviePersonalNotes.Where(o => o.Movie.ImdbId == imdbId));
            _entities.DeleteObjects(_entities.MovieUserLists.Where(o => o.Movie.ImdbId == imdbId));


            _entities.DeleteObjects(_entities.Movies.Where(o => o.ImdbId == imdbId));


            _entities.SaveChanges();
        }

        public void RemoveAllInfo()
        {

            _entities.DeleteObjects(_entities.Keywords);
            _entities.SaveChanges();
        }


        private static MoviePersonalNote GetNote(MovieDbEntities db, User loggedInUser, Movie rowMovie)
        {
            try
            {
                var user = db.Users.Where(o => o.Username == loggedInUser.Username).FirstOrDefault();
                var movie = db.Movies.Where(o => o.ImdbId == rowMovie.ImdbId).FirstOrDefault();

                if (movie == null)
                {
                    rowMovie.IsUpdated = false;
                    db.AddToMovies(rowMovie);
                    movie = rowMovie;
                }

                var personalNote =
                    db.MoviePersonalNotes.Where(o => o.User.Id == loggedInUser.Id && o.Movie.Id == movie.Id).
                        FirstOrDefault();

                if (personalNote == null)
                {
                    personalNote = new MoviePersonalNote { Comment = "", Movie = movie, User = user };
                    db.AddToMoviePersonalNotes(personalNote);
                }
                return personalNote;
            }
            catch (Exception exp)
            {
                Logger.Exception(exp, 550);
                return null;
            }
        }

        public MoviePersonalNote UpdateUserRating(User loggedInUser, Movie rowMovie, double rating)
        {
            var note = GetNote(_entities, loggedInUser, rowMovie);
            note.Rating = rating;
            _entities.SaveChanges();
            return note;
        }

        public MoviePersonalNote ToggleWanted(User loggedInUser, Movie rowMovie, bool? value = null)
        {
            var note = GetNote(_entities, loggedInUser, rowMovie);
            if (value != null)
                note.Wishlist = value.Value;
            else
                note.Wishlist = !note.Wishlist;
            _entities.SaveChanges();
            return note;
        }
        public MoviePersonalNote SetFavourite(User loggedInUser, Movie rowMovie, bool val)
        {
            var note = GetNote(_entities, loggedInUser, rowMovie);

            if (val)
            {
                if (note.Favourite > 0)
                    note.Favourite = 0;
                else
                    note.Favourite = 1;
            }
            else
            {
                if (note.Favourite < 0)
                    note.Favourite = 0;
                else
                    note.Favourite = -1;
            }
            _entities.SaveChanges();
            return note;
        }
        public MoviePersonalNote ToggleSeenIt(User loggedInUser, Movie rowMovie, bool? val = null)
        {
            var note = GetNote(_entities, loggedInUser, rowMovie);
            note.Seen = val ?? !note.Seen;
            _entities.SaveChanges();
            return note;
        }
        public MoviePersonalNote ToggleHaveIt(User loggedInUser, Movie rowMovie, bool? val = null)
        {
            var note = GetNote(_entities, loggedInUser, rowMovie);
            note.Have = val ?? !note.Have;
            _entities.SaveChanges();
            return note;
        }

        public void AddToUserList(Movie movie, string selectedText)
        {
            var list = _entities.UserLists.Where(o => o.ListName == selectedText).FirstOrDefault();
            if (list == null) return;
            var a = new MovieUserList { UserList = list, Movie = movie };
            _entities.AddToMovieUserLists(a);
            _entities.SaveChanges();
        }

        public MoviePersonalNote RateIt(User loggedInUser, Movie rowMovie, double rating)
        {
            var note = GetNote(_entities, loggedInUser, rowMovie);
            note.Rating = rating;
            _entities.SaveChanges();
            return note;
        }
    }
}
