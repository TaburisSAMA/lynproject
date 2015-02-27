using System;
using System.IO;
using System.Net;

namespace CommonUtilities
{
    public class HttpHelper
    {
        /// <summary>
        /// Returns the content of a given web adress as string.
        /// </summary>
        /// <param name="url">URL of the webpage</param>
        /// <returns>Website content</returns>
        public static string FetchWebPage(string url)
        {
            try
            {
                // Open a connection
                var webRequestObject = (HttpWebRequest)HttpWebRequest.Create(url);

                // You can also specify additional header values like 
                // the user agent or the referer:
                webRequestObject.UserAgent = ".NET Framework/2.0";
                webRequestObject.Referer = "http://www.example.com/";

                // Request response:
                var response = webRequestObject.GetResponse();

                // Open data stream:
                var webStream = response.GetResponseStream();

                // Create reader object:
                var reader = new StreamReader(webStream);

                // Read the entire stream content:
                string pageContent = reader.ReadToEnd();

                // Cleanup
                reader.Close();
                webStream.Close();
                response.Close();

                return pageContent;
            }
            catch (Exception exception)
            {
                Logger.Exception(exception, 1, "FetchWebPage");
                return "";
            }
        }


        public static string HtmlDecode(string data)
        {
            return System.Web.HttpUtility.HtmlDecode(data);
        }
        public static string HtmlEncode(string data)
        {
            return System.Web.HttpUtility.HtmlEncode(data);
        }

        public static string UrlDecode(string data)
        {
            return System.Web.HttpUtility.UrlDecode(data);
        }
        public static string UrlEncode(string data)
        {
            return System.Web.HttpUtility.UrlEncode(data);
        }
    }
}