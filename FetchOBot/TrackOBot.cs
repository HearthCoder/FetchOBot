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
            var webClient = new WebClient();
            string json = await webClient.Get(url);

            // Parse the JSON
            var historyPage = JsonConvert.DeserializeObject<HistoryPage>(json);
            return historyPage;
        }
    }
}
