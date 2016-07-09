namespace FetchOBotApi
{
    using System;
    using System.Threading.Tasks;

    public class FetchOBot
    {
        private TrackOBot trackOBot = new TrackOBot(new WebClient());

        /// <summary>
        /// Asynchronously load a single page of the user's game history
        /// </summary>
        /// <param name="username">Track-o-bot username</param>
        /// <param name="apiToken">API token</param>
        /// <param name="page">Page</param>
        /// <returns>Game history</returns>
        public async Task<HistoryPage> GetHistoryAsync(string username, string apiToken, int page = 1)
        {
            var historyPage = await this.trackOBot.GetHistoryAsync(username, apiToken, page);
            return historyPage;
        }
    }
}
