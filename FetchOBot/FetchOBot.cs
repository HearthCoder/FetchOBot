namespace FetchOBotApi
{
    using System;
    using System.Threading.Tasks;

    public class FetchOBot
    {
        private TrackOBot trackOBot;
        private HistoryAccumulator historyAccumulator;

        /// <summary>
        /// Constructor
        /// </summary>
        public FetchOBot()
        {
            this.trackOBot = new TrackOBot(new WebClient());
            this.historyAccumulator = new HistoryAccumulator(this.trackOBot);
        }

        /// <summary>
        /// Asynchronously load a single page of the user's game history
        /// </summary>
        /// <param name="username">Track-o-bot username</param>
        /// <param name="apiToken">API token</param>
        /// <param name="page">Page</param>
        /// <returns>Game history</returns>
        public async Task<HistoryPage> GetHistoryPageAsync(string username, string apiToken, int page = 1)
        {
            var historyPage = await this.trackOBot.GetHistoryPageAsync(username, apiToken, page);
            return historyPage;
        }

        /// <summary>
        /// Asynchronously loads a the user's game history up to a given game ID or start time, whichever is encountered first
        /// </summary>
        /// <param name="username">Track-o-bot username</param>
        /// <param name="apiToken">API token</param>
        /// <param name="gameId">Games are loaded up to but not including this game ID</param>
        /// <param name="rangeStart">Games later than this time (in UTC) are loaded</param>
        /// <returns>Array of games</returns>
        public async Task<Game[]> GetHistoryRangeAsync(string username, string apiToken, int gameId, DateTime rangeStart)
        {
            var history = await this.historyAccumulator.GetHistoryRangeAsync(username, apiToken, gameId, rangeStart);
            return history;
        }

        /// <summary>
        /// Asynchronously loads a the user's game history up to a given game ID
        /// </summary>
        /// <param name="username">Track-o-bot username</param>
        /// <param name="apiToken">API token</param>
        /// <param name="gameId">Games are loaded up to but not including this game ID</param>
        /// <returns>Array of games</returns>
        public async Task<Game[]> GetHistoryRangeAsync(string username, string apiToken, int gameId)
        {
            var history = await this.historyAccumulator.GetHistoryRangeAsync(username, apiToken, gameId, null);
            return history;
        }

        /// <summary>
        /// Asynchronously loads a the user's game history up to a given start time
        /// </summary>
        /// <param name="username">Track-o-bot username</param>
        /// <param name="apiToken">API token</param>
        /// <param name="rangeStart">Games later than this time (in UTC) are loaded</param>
        /// <returns>Array of games</returns>
        public async Task<Game[]> GetHistoryRangeAsync(string username, string apiToken, DateTime rangeStart)
        {
            var history = await this.historyAccumulator.GetHistoryRangeAsync(username, apiToken, null, rangeStart);
            return history;
        }
    }
}
