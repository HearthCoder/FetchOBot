namespace FetchOBotApi
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// A low-level implementation of the Track-o-bot web API
    /// </summary>
    internal class TrackOBot : ITrackOBot
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
            this.RequestCount = 0;
        }

        /// <summary>
        /// Number of requests this TrackOBot has made
        /// </summary>
        public int RequestCount { get; private set; }

        /// <summary>
        /// Load a single page of the user's game history
        /// </summary>
        /// <param name="username">Track-o-bot username</param>
        /// <param name="apiToken">API token</param>
        /// <param name="page">Page</param>
        /// <returns>Game history</returns>
        public async Task<HistoryPage> GetHistoryPageAsync(string username, string apiToken, int page)
        {
            // Get the history JSON from the server
            this.RequestCount++;
            string url = String.Format(TrackOBot.HistoryUrl, username, apiToken, page);
            string json;

            try
            {
                json = await this.webClient.GetAsync(url);
            }
            catch (HttpRequestException ex)
            {
                throw new FetchOBotUnavailableException(ex);
            }

            // Parse the JSON
            try
            {
                var historyPage = JsonConvert.DeserializeObject<HistoryPage>(json);
                return historyPage;
            }
            catch (JsonException ex)
            {
                throw new FetchOBotParseException(ex, json);
            }
        }
    }
}
