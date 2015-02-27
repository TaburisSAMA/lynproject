using System;
using MovieBrowser.Model;

namespace MovieBrowser.Controller
{
    public class MovieEventArgs : EventArgs
    {
        public string Message { get; set; }
        public Movie Movie { get; set; }

        public override string ToString()
        {
            return Message;
        }


        public MovieEventArgs(Movie movie, string message)
        {
            this.Movie = movie;
            this.Message = message;
        }
    }
}