using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using NLog;
using TravianBot.Utilities;

namespace TravianBot.Network
{
    /// <summary>
    ///     Network request handler class.
    /// </summary>
    internal class NetworkClient
    {
        /// <summary>
        ///     Logger for loggin.
        /// </summary>
        private static readonly Logger Logger
            = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Initializes a new instance of the NetworkClient class.
        /// </summary>
        public NetworkClient()
        {
            Cookies = new CookieContainer();
            Headers = new Dictionary<string, string>();
            Requests = new Dictionary<HttpWebRequest, NewContentHandler>();
            LoadConfig();
        }

        /// <summary>
        ///     Gets or sets the cookie container.
        /// </summary>
        public CookieContainer Cookies { get; set; }

        /// <summary>
        ///     Gets or sets the proxy.
        /// </summary>
        public IWebProxy Proxy { get; set; }

        /// <summary>
        ///     Gets or sets the header data for requests.
        /// </summary>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        ///     save load and.
        /// </summary>
        public Dictionary<HttpWebRequest, NewContentHandler> Requests { get; set; }

        /// <summary>
        ///     Makes requests to server.
        /// </summary>
        /// <param name="url">Url to be requested.</param>
        /// <param name="callback">Return function to run when response comes.</param>
        /// <param name="data">Data to post.</param>
        public void RequestContent(string url, NewContentHandler callback, byte[] data = null)
        {
            var request = CreateRequest(url, callback, data);
            SendRequest(request);
        }

        /// <summary>
        ///     Creates a new request using client's own configurations.
        /// </summary>
        /// <param name="url">Request's url address.</param>
        /// <returns>Returns a new HttpWebRequest</returns>
        private HttpWebRequest CreateRequest(string url, NewContentHandler callback, byte[] data = null)
        {
            HttpWebRequest request = null;

            request = (HttpWebRequest) WebRequest.Create(url);
            request.CookieContainer = Cookies;

            if (Headers.ContainsKey("Accept"))
            {
                request.Accept = Headers["Accept"];
            }

            if (Headers.ContainsKey("Connection"))
            {
                request.KeepAlive = Headers["Connection"].Equals("keep-alive");
            }

            if (Headers.ContainsKey("UserAgent"))
            {
                request.UserAgent = Headers["UserAgent"];
            }

            if (Headers.ContainsKey("Referer"))
            {
                request.Referer = Headers["Referer"];
            }

            if (Headers.ContainsKey("Accept-Encoding"))
            {
                // request.Headers.Add(HttpRequestHeader.AcceptEncoding, Headers["Accept-Encoding"]);
            }

            foreach (var key in Headers.Keys)
            {
                if (!key.IsIn(
                    "Accept",
                    "Content-Type",
                    "Referer",
                    "Connection",
                    "Host"))
                {
                    request.Headers.Add(key, Headers[key]);
                }
            }

            if (data != null)
            {
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.GetRequestStream().Write(data, 0, data.Length);
            }
            request.Timeout = 15000;
            Requests.Add(request, callback);

            return request;
        }

        /// <summary>
        ///     Sends parallel and asynced requests using thread pool.
        /// </summary>
        /// <param name="request">Request to send.</param>
        private void SendRequest(HttpWebRequest request)
        {
            Parallel.Invoke(() => { request.BeginGetResponse(EndResponse, request); });
        }

        /// <summary>
        ///     Ends getting the response and calls the
        ///     callback function assosiated with request.
        /// </summary>
        /// <param name="result">Async result.</param>
        private void EndResponse(IAsyncResult result)
        {
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse) (result.AsyncState as HttpWebRequest).EndGetResponse(result);
                Cookies.Add(response.Cookies);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }

            if (response != null)
            {
                var content = ReadResponse(response);
                response.Close();
                var request = result.AsyncState as HttpWebRequest;
                if (Requests.ContainsKey(request))
                {
                    var callback = Requests[request];
                    if (callback != null)
                    {
                        callback.Invoke(content, request.Address.OriginalString);
                    }
                }

                Requests.Remove(request);
            }
        }

        /// <summary>
        ///     Reads response content.
        /// </summary>
        /// <param name="response">Response to read.</param>
        /// <returns>Returns response text.</returns>
        private string ReadResponse(HttpWebResponse response)
        {
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return reader.ReadToEnd();
            }
        }

        /// <summary>
        ///     Loads client configuration from file.
        /// </summary>
        private void LoadConfig()
        {
            var conf = new XmlDocument();
            conf.Load("Network/net.config");
            var headersNode = conf.DocumentElement.SelectSingleNode("//Headers");

            Headers.Clear();
            foreach (XmlNode parentNode in headersNode.ChildNodes)
            {
                foreach (XmlNode node in parentNode.ChildNodes)
                {
                    Headers.Add(node.Attributes["key"].Value, node.InnerText);
                }
            }
        }
    }
}