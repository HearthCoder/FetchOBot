namespace FetchOBotApi
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// A simple wrapper around HttpClient
    /// </summary>
    internal class WebClient : IWebClient
    {
        /// <summary>
        /// Send a GET request and return the response body
        /// </summary>
        /// <param name="url">Target URL</param>
        /// <returns>Response body</returns>
        public async Task<string> Get(string url)
        {
            // Send the request and get the response
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            // Throw a well-known exception for unauthorized
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new FetchOBotUnauthorizedException();
            }

            // Make sure the response succeeded
            response.EnsureSuccessStatusCode();

            // Return the response body
            var responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
    }
}
