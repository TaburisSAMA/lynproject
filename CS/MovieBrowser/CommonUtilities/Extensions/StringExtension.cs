using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonUtilities.Extensions
{
    public static class StringExtension
    {
        public static string Clean(this string @this)
        {
            return HttpHelper.HtmlDecode(@this);
        }
    }
}
