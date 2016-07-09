namespace FetchOBotApi
{
    using System;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// A low-level implementation of the Track-o-bot web API
    /// </summary>
    internal class TrackOBot
    {
        private const string HistoryUrl = "https://trackobot.com/profile/history.json?username={0}&token={1}&page={2}";
        private IWebClient webClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="webClient">Web client</param>
        public TrackOBot(IWebClient webClient)
        {
            this.webClient = webClient;
        }

        /// <summary>
        /// Load a single page of the user's game history
        /// </summary>
        /// <param name="username">Track-o-bot username</param>
        /// <param name="apiToken">API token</param>
        /// <param name="page">Page</param>
        /// <returns>Game history</returns>
        public async Task<HistoryPage> GetHistoryAsync(string username, string apiToken, int page)
        {
            // Get the history JSON from the server
            string url = String.Format(TrackOBot.HistoryUrl, username, apiToken, page);
            string json = await this.webClient.GetAsync(url);

            // Parse the JSON
            try
            {
                var historyPage = await JsonConvert.DeserializeObjectAsync<HistoryPage>(json);
                return historyPage;
            }
            catch (JsonException ex)
            {
                throw new FetchOBotParseException(ex, json);
            }
        }
    }
}
