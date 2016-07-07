namespace FetchOBotApi
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// A simple wrapper around HttpClient
    /// </summary>
    internal class WebClient
    {
        /// <summary>
        /// Send a GET request and return the response body
        /// </summary>
        /// <param name="url">Target URL</param>
        /// <returns>Response body</returns>
        public async Task<string> Get(string url)
        {
            var client = new HttpClient();
            string responseBody = await client.GetStringAsync(url);
            return responseBody;
        }
    }
}
