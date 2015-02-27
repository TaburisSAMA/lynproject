using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using CommonUtilities;
using CommonUtilities.FileSystem;

namespace MovieBrowser.Model
{
    public partial class Movie
    {

        //Parsing Information
        public List<Genre> Genres { get; set; }
        public List<Country> Countries { get; set; }
        public List<Keyword> Keywords { get; set; }
        public List<Language> Languages { get; set; }
        public List<Person> PersonWriters { get; set; }
        public List<Person> PersonStars { get; set; }
        public List<Person> PersonDirectors { get; set; }

        private static readonly List<string> MovieFiles = new List<string> { "avi", "mkv", "flv", "mp4" };
        private static readonly List<string> SubtitleFiles = new List<string> { "srt", "sub" };

        // Tree Purpose
        public List<Movie> Children { get; set; }
        public Movie Parent { get; set; }
        //

        public Movie()
        {
            Children = new List<Movie>();
        }

        public string TitleWithRating
        {
            get
            {
                if (Rating > 0)
                {
                    return Title + " [" + Rating + "]";
                }
                else
                {
                    return Title;
                }
            }
        }

        public static Movie FromFolderName(string folderPath)
        {
            var folderName = "";
            var i = folderPath.LastIndexOf("\\");
            if (i > 0)
            {
                folderName = folderPath.Substring(i + 1);
            }

            var match = Regex.Match(folderName, @"(.+) \((\d+)\), \[([\d.]+)\]\s*(\[(tt\d+)\])?");
            if (match.Success)
            {
                return new Movie()
                {
                    Title = match.Groups[1].Value,
                    Year = int.Parse(match.Groups[2].Value),
                    Rating = double.Parse(match.Groups[3].Value),
                    ImdbId = match.Groups[5].Value,
                    FilePath = folderPath,
                    IsValidMovie = true,
                    IsVirtual = false
                };
            }
            return new Movie() { Title = folderName, FilePath = folderPath, IsValidMovie = false, IsVirtual = false };
        }

        public bool IsFilesystemFolder
        {
            get
            {
                return Directory.Exists(FilePath);
            }
        }
        public bool IsFolder { get; set; }
        public bool IsVirtual { get; set; }
        public bool IsValidMovie { get; set; }
        public string FilePath { get; set; }

        public string FolderName { get { return string.Format("{0} ({1}), [{2}] [{3}]", Title, Year, Rating, ImdbId); } }
        public int ImageIndex
        {
            get
            {
                if (IsValidMovie)
                    return 0; // Movie

                else if (IsFilesystemFolder)
                    return 1; // Folder
                else
                {
                    if (FilePath.Extension().ExistsIn(MovieFiles))
                        return 2; // Video
                    else if (FilePath.Extension().ExistsIn(SubtitleFiles))
                        return 3; // Subtitles
                    else
                    {
                        return 4; // File
                    }
                }
            }
        }


        public string TitleCleaned
        {
            get
            {
                return HttpHelper.HtmlDecode(Title);
            }
        }

        public Movie CopyFromMovie(Movie movie)
        {
            this.ImdbId = movie.ImdbId;
            this.Rating = movie.Rating;
            this.Title = movie.Title;
            this.Year = movie.Year;
            this.ImdbId = movie.ImdbId;
            this.FilePath = movie.FilePath;
            this.Runtime = movie.Runtime;
            this.MPAA = movie.MPAA;
            this.MPAAReason = movie.MPAAReason;
            this.Highlight = movie.Highlight;
            //
            this.Genres = movie.Genres;
            this.Countries = movie.Countries;
            this.Languages = movie.Languages;
            this.Keywords = movie.Keywords;
            //
            this.IsValidMovie = movie.IsValidMovie;
            //
            this.Children = movie.Children;
            this.Parent = movie.Parent;
            //
            return this;
        }
    }
}
