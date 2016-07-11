namespace FetchOBotApi
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for a simple wrapper around HttpClient
    /// </summary>
    internal interface IWebClient
    {
        /// <summary>
        /// Send a GET request and return the response body
        /// </summary>
        /// <param name="url">Target URL</param>
        /// <returns>Response body</returns>
        Task<string> GetAsync(string url);
    }
}
