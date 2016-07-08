namespace FetchOBotApi
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Mock implementation of IWebClient
    /// </summary>
    public class MockWebClient : IWebClient
    {
        /// <summary>
        /// Response string to return
        /// </summary>
        public string ResponseString { get; set; }

        /// <summary>
        /// Last URL seen
        /// </summary>
        public string LastUrl { get; set; }

        /// <summary>
        /// Send a GET request and return the response body
        /// </summary>
        /// <param name="url">Target URL</param>
        /// <returns>Response body</returns>
        public Task<string> Get(string url)
        {
            this.LastUrl = url;
            return Task.FromResult(this.ResponseString);
        }
    }
}
