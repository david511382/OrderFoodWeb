using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ManagerAngular.Util.http
{
    public static class Http
    {
        public struct Response
        {
            public string Content;
            public HttpResponseHeaders Header;
            public CookieCollection Cookies;
        }

        static Http()
        {
            SupportOldHttpServer = true;

            try
            {
                // 設定 1 分鐘更新 DNS，預設 120000 (2 分鐘)
                ServicePointManager.DnsRefreshTimeout = (int)TimeSpan.FromMinutes(1).TotalMilliseconds;
            }
            catch
            {
            }
        }

        /// <summary>
        /// 啟用支援舊協定的 HttpServer
        /// </summary>
        public static bool SupportOldHttpServer { get; set; }

        public static async Task<Response> Get(string url, IEnumerable<KeyValuePair<string, string>> headers = null, CookieCollection cookies = null)
        {
            Uri uri = new Uri(url);
            return await Get(uri, headers, cookies);
        }

        public static async Task<Response> Get(Uri uri, IEnumerable<KeyValuePair<string, string>> headers = null, CookieCollection cookies = null)
        {
            return await GetResponse(uri, HttpMethod.Get, null, headers, cookies);
        }

        public static async Task<Response> PostForm(string url, IEnumerable<KeyValuePair<string, string>> keyValues, IEnumerable<KeyValuePair<string, string>> headers = null, CookieCollection cookies = null,bool dontCareOK = false)
        {
            Uri uri = new Uri(url);
            return await PostForm(uri, keyValues, headers, cookies, dontCareOK );
        }

        public static async Task<Response> PostForm(Uri uri, IEnumerable<KeyValuePair<string, string>> keyValues, IEnumerable<KeyValuePair<string, string>> headers = null, CookieCollection cookies = null, bool dontCareOK = false)
        {
            FormUrlEncodedContent formContent = new FormUrlEncodedContent(keyValues);
            return await Post(uri, formContent, headers, cookies, dontCareOK);
        }

        public static async Task<Response> PostJson(string url, string json, IEnumerable<KeyValuePair<string, string>> headers = null, CookieCollection cookies = null)
        {
            Uri uri = new Uri(url);
            return await PostJson(uri, json, headers, cookies);
        }

        public static async Task<Response> PostJson(Uri uri, string json, IEnumerable<KeyValuePair<string, string>> headers = null, CookieCollection cookies = null)
        {
            StringContent jsonContent = new StringContent(json, Encoding.UTF8, "application/json");
            return await Post(uri, jsonContent, headers, cookies);
        }

        private static async Task<Response> Post(Uri uri, ByteArrayContent content, IEnumerable<KeyValuePair<string, string>> headers = null, CookieCollection cookies = null, bool dontCareOK = false)
        {
            return await GetResponse(uri, HttpMethod.Post, content, headers, cookies, dontCareOK);
        }

        public static async Task<Response> Send(string uri, HttpMethod method)
        {
            return await GetResponse(new Uri(uri), method);
        }

        public static async Task<Response> Send(Uri uri, HttpMethod method)
        {
            return await GetResponse(uri, method);
        }

        private static async Task<Response> GetResponse(Uri uri, HttpMethod method, ByteArrayContent content = null, IEnumerable<KeyValuePair<string, string>> headers = null, CookieCollection cookies = null, bool dontCareOK = false)
        {
            HttpResponseMessage response;
            Response result = new Response();
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.AllowAutoRedirect = false;

                if (cookies != null)
                    foreach (Cookie cookie in cookies)
                        handler.CookieContainer.Add(cookie);

                using (HttpClient client = new HttpClient(handler))
                {
                    if (SupportOldHttpServer)
                    {
                        SetServicePoint(uri);

                        HttpRequestMessage requestMessage = CreateRequestMessage(uri, method, content);
                        if (headers != null)
                            foreach (KeyValuePair<string, string> header in headers)
                            {
                                requestMessage.Headers.Add(header.Key, header.Value);
                            }

                        response = await client.SendAsync(requestMessage);
                    }
                    else
                    {
                        if (method == HttpMethod.Get)
                            response = await client.GetAsync(uri.ToString());
                        else
                            response = await client.PostAsync(uri, content);
                    }

                    if (!dontCareOK)
                    // 返回 *非* 200 系列的 Http Status Code 則丟出例外
                    response.EnsureSuccessStatusCode();

                    result.Cookies = handler.CookieContainer.GetCookies(uri);
                    result.Content = await response.Content.ReadAsStringAsync();
                    result.Header = response.Headers;
                }
            }

            return result;
        }

        private static void SetServicePoint(Uri uri)
        {
            ServicePoint serverPoint = ServicePointManager.FindServicePoint(uri);

            // 設定 30 秒沒有活動即關閉連線，預設 -1 (永不關閉)
            serverPoint.ConnectionLeaseTimeout = (int)TimeSpan.FromSeconds(30).TotalMilliseconds;

            // 停用 100-Continue
            // https://docs.microsoft.com/zh-tw/dotnet/api/system.net.servicepointmanager.expect100continue?view=netstandard-2.0
            serverPoint.Expect100Continue = false;
        }

        private static HttpRequestMessage CreateRequestMessage(Uri uri, HttpMethod method, ByteArrayContent content)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                // 使用 HTTP/1.0
                Version = HttpVersion.Version10,
                Method = method,
                RequestUri = uri
            };

            if (content != null)
            {
                requestMessage.Content = content;
            }

            // 完成後關閉連接, 預設為 false (Keep-Alive)
            requestMessage.Headers.ConnectionClose = true;

            CacheControlHeaderValue cacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };

            requestMessage.Headers.CacheControl = cacheControl;
            return requestMessage;
        }
    }
}