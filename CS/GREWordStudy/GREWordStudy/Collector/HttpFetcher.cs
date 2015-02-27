using System;
using System.Net;
using System.IO;

namespace GREWordStudy.Collector
{
    public class HttpFetcher
    {
        string _url;
        string _result;
        public HttpFetcher(string url)
        {
            _url = url;
        }

        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }

        public string Result
        {
            get
            {
                return _result;
            }
        }

        public string GetHttpHtml
        {
            get
            {
                _result = "";
                try
                {
                    Uri URL = new Uri(_url);
                    HttpWebRequest myRequest = (HttpWebRequest) WebRequest.Create(URL);
                    myRequest.Method = "GET";
                    //myRequest.UserAgent = ".NET Framework Scraper Client";
                    //myRequest.Timeout = 50000;
                    //myRequest.Proxy = GlobalProxySelection.GetEmptyWebProxy();

                    WebResponse myResponse = myRequest.GetResponse();
                    StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                    _result = sr.ReadToEnd();
                    sr.Close();
                    myResponse.Close();
                    return _result;
                }
                catch (Exception)
                {
                    _result = null;
                    return _result;
                }
            }
        }
    }
}
