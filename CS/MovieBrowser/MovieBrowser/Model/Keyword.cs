using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieBrowser.Model
{
    partial class Keyword
    {
        public Int64 KeywordRating
        {
            get
            {
                return Rated;
            }
        }
    }
}
