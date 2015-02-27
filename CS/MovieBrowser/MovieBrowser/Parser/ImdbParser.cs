using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CommonUtilities;
using MovieBrowser.Model;
using CommonUtilities.Extensions;

namespace MovieBrowser.Parser
{
    public class ImdbParser
    {
        public static string ParseRating(string html)
        {
            return Regex.Match(html, @"<span class=""rating-rating"">([\d.]+)<span>").Groups[1].Value.Clean();
        }

        public static string ParseTitle(string html)
        {
            return Regex.Match(html, @"<title>(.+?) \(.*?([\d.]+)\)").Groups[1].Value.Clean();
        }

        public static string ParseYear(string html)
        {
            return Regex.Match(html, @"<title>(.+?) \(.*?([\d.]+)\)").Groups[2].Value.Clean();
        }

        public static string ParseRuntime(string html)
        {
            string raw = Regex.Match(html, @"Runtime:</h4>\s+(.+?)</div>", RegexOptions.Singleline).Groups[1].Value;
            return Regex.Replace(raw, @"&nbsp;<span class=""ghost"">\|</span>", ", ").Replace("\n", "").Clean();
        }

        public static string ParseMpaa(string html)
        {
            return Regex.Match(html, @"<div class=""infobar"">\s*(<img.+?title=""(.+?)"".+?>)").Groups[2].Value.Clean();
        }
        public static string ParseMpaaReason(string html)
        {
            return Regex.Match(html, @"<h4>Motion Picture Rating \(<a href=""/mpaa"">MPAA</a>\)</h4>\s*(.+?)\s*<span").Groups[1].Value.Clean();
        }
        public static List<Genre> ParseGenres(string html)
        {
            var genres = Regex.Matches(html, @"<a href=""/genre/(.+?)"">(.+?)</a>");
            return (from Match m in genres select new Genre() { Code = m.Groups[1].Value, Name = m.Groups[2].Value.Clean() }).ToList();
        }

        public static List<Country> ParseCountries(string html)
        {
            var countries = Regex.Matches(html, @"<a href=""/country/(.+?)"">(.+?)</a>");
            return (from Match m in countries select new Country() { Code = m.Groups[1].Value, Name = m.Groups[2].Value.Clean() }).ToList();
        }

        public static string ParseId(string html)
        {
            return Regex.Match(html, @"<meta property=""og:url"" content=""http://www\.imdb\.com/title/(tt[0-9]+?)/"" />").Groups[1].Value.Clean();
        }

        public static List<Keyword> ParseKeywords(string html)
        {
            var keywords = Regex.Matches(html, @"<a href=""/keyword/(.+?)/"">(.+?)</a>");
            return (from Match m in keywords select new Keyword() { Code = m.Groups[1].Value, Name = m.Groups[2].Value.Clean() }).ToList();
        }

        public static string ParseMoviePoster(string html)
        {
            var regex = new Regex("<td rowspan=\"2\" id=\"img_primary\">.+?<img src=\"(http://.+?)\"", RegexOptions.Singleline);
            return regex.Match(html).Groups[1].Value;
        }



        public static string MediaFrom(string html)
        {
            return Regex.Match(html, "Media from&nbsp;<a href=\"/title/(tt[0-9]+)/").Groups[1].Value;
        }

        public static Movie GuessMovie(string srcHtml)
        {
            var movie = new Movie();
            var match = Regex.Match(srcHtml, @"Media from&nbsp;<a href=""/title/(tt[0-9]+)/"".+?>(.+?)</a>(\s*\(([0-9]+?)\))?");
            movie.ImdbId = match.Groups[1].Value;
            movie.Title = match.Groups[2].Value;
            var year = 0;
            Int32.TryParse(match.Groups[4].Value, out year);
            movie.Year = year;
            return movie;
        }

        public static string ParseHighlight(string html)
        {
            return Regex.Match(html, @"class=""article highlighted"" >\s*(<a href="".+?"">.+?</a>\s*\|\s*)?(.+?)<span class=""see-more inline"">", RegexOptions.Singleline).Groups[2].Value.Replace("\n", " ").Clean();
        }

        public static List<Language> ParseLanguages(string html)
        {

            var countries = Regex.Matches(html, @"<a href=""/language/(.+?)"">(.+?)</a>");
            return (from Match m in countries select new Language() { Code = m.Groups[1].Value, Name = m.Groups[2].Value.Clean() }).ToList();
        }

        private static List<Person> ParsePersons(string src)
        {
            var mc = Regex.Matches(src, @"<a.*?href=""/name/(nm[0-9]+)/"".*?>(.+?)</a>");
            return (from Match match in mc select new Person() { Name = match.Groups[2].Value.Clean(), ImdbId = match.Groups[1].Value }).ToList();
        }

        public static List<Person> ParseDirectors(string html)
        {
            var str = Regex.Match(html, @"Directors?:\s*</h4>\s*(.+?)</div>", RegexOptions.Singleline).Groups[1].Value;
            return ParsePersons(str);
        }

        public static List<Person> ParseWriters(string html)
        {
            var str = Regex.Match(html, @"Writers?:\s*</h4>\s*(.+?)</div>", RegexOptions.Singleline).Groups[1].Value;
            return ParsePersons(str);
        }

        public static List<Person> ParseStars(string html)
        {
            var str = Regex.Match(html, @"Stars?:\s*</h4>\s*(.+?)</div>", RegexOptions.Singleline).Groups[1].Value;
            return ParsePersons(str);
            
        }
    }
}
