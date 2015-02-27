using System;

namespace MovieBrowser.Controller
{
    public class TextEventArgs : EventArgs
    {
        public string Text { get; set; }
        public string Title { get; set; }
        public object Data { get; set; }

        public TextEventArgs(string text)
        {
            Text = text;
        }

        public TextEventArgs()
        {

        }

        public override string ToString()
        {
            return Text;
        }
    }
}